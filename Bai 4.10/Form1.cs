using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LabEquipmentCheckout
{
    public partial class Form1 : Form
    {
        private BindingList<EquipmentLoan> loanList = new BindingList<EquipmentLoan>();
        private BindingSource bindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            InitControlData();
        }

        private void InitControlData()
        {
            // Thiết lập danh mục thiết bị và trạng thái
            cbEquipment.Items.AddRange(new string[] { "Máy hiện sóng (Oscilloscope)", "Bộ nguồn DC", "Máy hàn điện tử", "Đồng hồ vạn năng số", "Kit vi điều khiển STM32" });
            if (cbEquipment.Items.Count > 0) cbEquipment.SelectedIndex = 0;

            cbStatus.Items.AddRange(new string[] { "Đang mượn", "Đã trả", "Quá hạn" });
            cbStatus.SelectedIndex = 0;

            cbFilterStatus.Items.Add("Tất cả");
            cbFilterStatus.Items.AddRange(new string[] { "Đang mượn", "Đã trả", "Quá hạn" });
            cbFilterStatus.SelectedIndex = 0;

            // Dữ liệu mẫu ban đầu
            loanList.Add(new EquipmentLoan
            {
                LoanId = "PM001",
                StudentId = "SV001",
                StudentName = "Nguyễn Văn Hoàng",
                EquipmentName = "Máy hiện sóng (Oscilloscope)",
                Quantity = 1,
                LoanDate = DateTime.Now.AddDays(-3),
                DueDate = DateTime.Now.AddDays(2),
                ReturnDate = null,
                Status = "Đang mượn"
            });

            loanList.Add(new EquipmentLoan
            {
                LoanId = "PM002",
                StudentId = "SV002",
                StudentName = "Trần Thị Mai",
                EquipmentName = "Đồng hồ vạn năng số",
                Quantity = 2,
                LoanDate = DateTime.Now.AddDays(-7),
                DueDate = DateTime.Now.AddDays(-1), // Quá hạn
                ReturnDate = null,
                Status = "Đang mượn"
            });

            CheckAndUpdateOverdueStatus();
            bindingSource.DataSource = loanList;
            dgvLoans.DataSource = bindingSource;
            UpdateStatusStrip();
        }

        // Tự động cập nhật trạng thái Quá hạn nếu hạn trả trước ngày hiện tại và chưa trả
        private void CheckAndUpdateOverdueStatus()
        {
            foreach (var loan in loanList)
            {
                if (loan.Status == "Đang mượn" && loan.DueDate.Date < DateTime.Now.Date)
                {
                    loan.Status = "Quá hạn";
                }
            }
        }

        private void UpdateStatusStrip()
        {
            int total = dgvLoans.Rows.Count;
            int overdue = loanList.Count(x => x.Status == "Quá hạn");
            lblStatusCount.Text = $"Tổng số phiếu: {total} | Số phiếu quá hạn: {overdue}";
        }

        private bool ValidateInput(bool isUpdate = false)
        {
            errorProvider1.Clear();
            bool isValid = true;

            // Mã phiếu không trống & không trùng
            if (string.IsNullOrWhiteSpace(txtLoanId.Text))
            {
                errorProvider1.SetError(txtLoanId, "Mã phiếu không được để trống.");
                isValid = false;
            }
            else if (!isUpdate && loanList.Any(x => x.LoanId == txtLoanId.Text.Trim()))
            {
                errorProvider1.SetError(txtLoanId, "Mã phiếu mượn đã tồn tại.");
                isValid = false;
            }

            // Mã sinh viên không trống
            if (string.IsNullOrWhiteSpace(txtStudentId.Text))
            {
                errorProvider1.SetError(txtStudentId, "Mã sinh viên không được để trống.");
                isValid = false;
            }

            // Tên sinh viên không trống
            if (string.IsNullOrWhiteSpace(txtStudentName.Text))
            {
                errorProvider1.SetError(txtStudentName, "Họ tên sinh viên không được để trống.");
                isValid = false;
            }

            // Thiết bị
            if (cbEquipment.SelectedIndex == -1)
            {
                errorProvider1.SetError(cbEquipment, "Vui lòng chọn thiết bị.");
                isValid = false;
            }

            // Số lượng phải lớn hơn 0
            if (!int.TryParse(txtQuantity.Text.Trim(), out int qty) || qty <= 0)
            {
                errorProvider1.SetError(txtQuantity, "Số lượng phải là số nguyên lớn hơn 0.");
                isValid = false;
            }

            // Hạn trả không trước ngày mượn
            if (dtpDueDate.Value.Date < dtpLoanDate.Value.Date)
            {
                errorProvider1.SetError(dtpDueDate, "Hạn trả không được trước ngày mượn.");
                isValid = false;
            }

            // Nếu trạng thái là Đã trả, ngày trả thực tế không được trước ngày mượn
            string status = cbStatus.SelectedItem?.ToString();
            if (status == "Đã trả" && dtpReturnDate.Value.Date < dtpLoanDate.Value.Date)
            {
                errorProvider1.SetError(dtpReturnDate, "Ngày trả thực tế không được trước ngày mượn.");
                isValid = false;
            }

            return isValid;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(false)) return;

            string status = cbStatus.SelectedItem.ToString();
            DateTime? returnDate = null;

            if (status == "Đã trả")
            {
                returnDate = dtpReturnDate.Value;
            }
            else if (status == "Đang mượn" && dtpDueDate.Value.Date < DateTime.Now.Date)
            {
                status = "Quá hạn"; // Tự động cập nhật nếu hạn trả đã qua
            }

            var newLoan = new EquipmentLoan
            {
                LoanId = txtLoanId.Text.Trim(),
                StudentId = txtStudentId.Text.Trim(),
                StudentName = txtStudentName.Text.Trim(),
                EquipmentName = cbEquipment.SelectedItem.ToString(),
                Quantity = int.Parse(txtQuantity.Text.Trim()),
                LoanDate = dtpLoanDate.Value,
                DueDate = dtpDueDate.Value,
                ReturnDate = returnDate,
                Status = status
            };

            loanList.Add(newLoan);
            MessageBox.Show("Thêm phiếu mượn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
            ApplyFilter();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvLoans.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phiếu mượn cần cập nhật trên danh sách.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput(true)) return;

            var selectedLoan = (EquipmentLoan)dgvLoans.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"Bạn có chắc muốn cập nhật phiếu mượn [{selectedLoan.LoanId}]?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                selectedLoan.StudentId = txtStudentId.Text.Trim();
                selectedLoan.StudentName = txtStudentName.Text.Trim();
                selectedLoan.EquipmentName = cbEquipment.SelectedItem.ToString();
                selectedLoan.Quantity = int.Parse(txtQuantity.Text.Trim());
                selectedLoan.LoanDate = dtpLoanDate.Value;
                selectedLoan.DueDate = dtpDueDate.Value;
                
                string status = cbStatus.SelectedItem.ToString();
                selectedLoan.Status = status;

                if (status == "Đã trả")
                {
                    selectedLoan.ReturnDate = dtpReturnDate.Value;
                }
                else
                {
                    selectedLoan.ReturnDate = null;
                    if (status == "Đang mượn" && selectedLoan.DueDate.Date < DateTime.Now.Date)
                    {
                        selectedLoan.Status = "Quá hạn";
                    }
                }

                bindingSource.ResetBindings(false);
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                ApplyFilter();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvLoans.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phiếu mượn cần xóa trên danh sách.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedLoan = (EquipmentLoan)dgvLoans.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa phiếu mượn của sinh viên [{selectedLoan.StudentName}]?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                loanList.Remove(selectedLoan);
                MessageBox.Show("Xóa phiếu mượn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                ApplyFilter();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtLoanId.Clear();
            txtLoanId.Enabled = true;
            txtStudentId.Clear();
            txtStudentName.Clear();
            txtQuantity.Clear();
            if (cbEquipment.Items.Count > 0) cbEquipment.SelectedIndex = 0;
            if (cbStatus.Items.Count > 0) cbStatus.SelectedIndex = 0;
            dtpLoanDate.Value = DateTime.Now;
            dtpDueDate.Value = DateTime.Now.AddDays(7);
            dtpReturnDate.Value = DateTime.Now;
            errorProvider1.Clear();
            dgvLoans.ClearSelection();
        }

        private void dgvLoans_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLoans.Rows[e.RowIndex];
                var loan = (EquipmentLoan)row.DataBoundItem;

                txtLoanId.Text = loan.LoanId;
                txtLoanId.Enabled = false; // Khóa mã phiếu khi đang sửa
                txtStudentId.Text = loan.StudentId;
                txtStudentName.Text = loan.StudentName;
                cbEquipment.SelectedItem = loan.EquipmentName;
                txtQuantity.Text = loan.Quantity.ToString();
                dtpLoanDate.Value = loan.LoanDate;
                dtpDueDate.Value = loan.DueDate;
                if (loan.ReturnDate.HasValue)
                {
                    dtpReturnDate.Value = loan.ReturnDate.Value;
                }
                cbStatus.SelectedItem = loan.Status;
                errorProvider1.Clear();
            }
        }

        private void ApplyFilter()
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            string selectedStatus = cbFilterStatus.SelectedItem?.ToString();

            var filtered = loanList.Where(x =>
                (string.IsNullOrEmpty(keyword) || x.StudentId.ToLower().Contains(keyword) || x.EquipmentName.ToLower().Contains(keyword)) &&
                (selectedStatus == "Tất cả" || string.IsNullOrEmpty(selectedStatus) || x.Status == selectedStatus)
            ).ToList();

            bindingSource.DataSource = new BindingList<EquipmentLoan>(filtered);
            UpdateStatusStrip();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => ApplyFilter();
        private void cbFilterStatus_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilter();

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Bật/tắt hoặc hỗ trợ chọn ngày trả thực tế khi đổi trạng thái sang Đã trả
            if (cbStatus.SelectedItem?.ToString() == "Đã trả" && dtpReturnDate.Value < dtpLoanDate.Value)
            {
                dtpReturnDate.Value = DateTime.Now;
            }
        }

        private void menuExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV file (*.csv)|*.csv";
                sfd.FileName = "DanhSachPhieuMuon.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(sfd.FileName, false, System.Text.Encoding.UTF8))
                        {
                            sw.WriteLine("Mã phiếu,Mã sinh viên,Họ tên sinh viên,Thiết bị,Số lượng,Ngày mượn,Hạn trả,Ngày trả thực tế,Trạng thái");
                            foreach (DataGridViewRow row in dgvLoans.Rows)
                            {
                                if (row.DataBoundItem is EquipmentLoan l)
                                {
                                    string retDateStr = l.ReturnDate.HasValue ? l.ReturnDate.Value.ToString("dd/MM/yyyy") : "";
                                    sw.WriteLine($"{l.LoanId},{l.StudentId},{l.StudentName},{l.EquipmentName},{l.Quantity},{l.LoanDate:dd/MM/yyyy},{l.DueDate:dd/MM/yyyy},{retDateStr},{l.Status}");
                                }
                            }
                        }
                        MessageBox.Show("Xuất file CSV thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xuất file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}