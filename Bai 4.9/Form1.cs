using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ClinicAppointmentManager
{
    public partial class Form1 : Form
    {
        private BindingList<Appointment> appointmentList = new BindingList<Appointment>();
        private BindingSource bindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            InitControlData();
        }

        private void InitControlData()
        {
            // Thiết lập giá trị cho các ComboBox bác sĩ, trạng thái
            cbDoctor.Items.AddRange(new string[] { "BS. Nguyễn Văn A", "BS. Trần Thị B", "BS. Lê Văn C", "BS. Hoàng Thị D" });
            if (cbDoctor.Items.Count > 0) cbDoctor.SelectedIndex = 0;

            cbStatus.Items.AddRange(new string[] { "Chờ khám", "Đang khám", "Hoàn tất", "Đã hủy" });
            if (cbStatus.Items.Count > 0) cbStatus.SelectedIndex = 0;

            cbFilterStatus.Items.Add("Tất cả");
            cbFilterStatus.Items.AddRange(new string[] { "Chờ khám", "Đang khám", "Hoàn tất", "Đã hủy" });
            cbFilterStatus.SelectedIndex = 0;

            // Định dạng ngày giờ hiển thị trên DateTimePicker
            dtpAppointmentDate.Format = DateTimePickerFormat.Custom;
            dtpAppointmentDate.CustomFormat = "dd/MM/yyyy HH:mm";

            // Dữ liệu mẫu ban đầu
            appointmentList.Add(new Appointment { AppointmentId = "LH001", PatientName = "Nguyễn Văn An", PhoneNumber = "0901234567", AppointmentDateTime = DateTime.Now.AddHours(2), Doctor = "BS. Nguyễn Văn A", Reason = "Đau đầu", Status = "Chờ khám" });
            appointmentList.Add(new Appointment { AppointmentId = "LH002", PatientName = "Trần Thị Bình", PhoneNumber = "0987654321", AppointmentDateTime = DateTime.Now.AddHours(4), Doctor = "BS. Trần Thị B", Reason = "Khám tổng quát", Status = "Chờ khám" });

            bindingSource.DataSource = appointmentList;
            dgvAppointments.DataSource = bindingSource;
            UpdateStatusCount();
        }

        private void UpdateStatusCount()
        {
            lblStatusCount.Text = $"Tổng số lịch hẹn hiển thị: {dgvAppointments.Rows.Count}";
        }

        private bool ValidateInput(bool isUpdate = false)
        {
            errorProvider1.Clear();
            bool isValid = true;

            // Kiểm tra Mã lịch hẹn
            if (string.IsNullOrWhiteSpace(txtAppointmentId.Text))
            {
                errorProvider1.SetError(txtAppointmentId, "Mã lịch hẹn không được để trống.");
                isValid = false;
            }
            else if (!isUpdate && appointmentList.Any(x => x.AppointmentId == txtAppointmentId.Text.Trim()))
            {
                errorProvider1.SetError(txtAppointmentId, "Mã lịch hẹn đã tồn tại.");
                isValid = false;
            }

            // Kiểm tra Tên bệnh nhân
            if (string.IsNullOrWhiteSpace(txtPatientName.Text))
            {
                errorProvider1.SetError(txtPatientName, "Họ tên bệnh nhân không được để trống.");
                isValid = false;
            }

            // Kiểm tra Số điện thoại (Đủ 10 chữ số, bắt đầu bằng số 0)
            if (string.IsNullOrWhiteSpace(txtPhone.Text) || !Regex.IsMatch(txtPhone.Text.Trim(), @"^0\d{9}$"))
            {
                errorProvider1.SetError(txtPhone, "SĐT không hợp lệ (Phải gồm 10 chữ số và bắt đầu bằng số 0).");
                isValid = false;
            }

            // Kiểm tra Lý do khám
            if (string.IsNullOrWhiteSpace(txtReason.Text))
            {
                errorProvider1.SetError(txtReason, "Lý do khám không được để trống.");
                isValid = false;
            }

            // Kiểm tra Ngày hẹn không nằm trong quá khứ
            if (!isUpdate && dtpAppointmentDate.Value < DateTime.Now.AddMinutes(-1))
            {
                errorProvider1.SetError(dtpAppointmentDate, "Thời gian hẹn không được nằm trong quá khứ.");
                isValid = false;
            }

            return isValid;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(false)) return;

            appointmentList.Add(new Appointment
            {
                AppointmentId = txtAppointmentId.Text.Trim(),
                PatientName = txtPatientName.Text.Trim(),
                PhoneNumber = txtPhone.Text.Trim(),
                AppointmentDateTime = dtpAppointmentDate.Value,
                Doctor = cbDoctor.SelectedItem?.ToString(),
                Reason = txtReason.Text.Trim(),
                Status = cbStatus.SelectedItem?.ToString()
            });

            MessageBox.Show("Thêm lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
            ApplyFilter();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn lịch hẹn cần cập nhật trên danh sách.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput(true)) return;

            var appt = (Appointment)dgvAppointments.SelectedRows[0].DataBoundItem;
            if (MessageBox.Show($"Bạn có muốn cập nhật lịch hẹn [{appt.AppointmentId}]?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                appt.PatientName = txtPatientName.Text.Trim();
                appt.PhoneNumber = txtPhone.Text.Trim();
                appt.AppointmentDateTime = dtpAppointmentDate.Value;
                appt.Doctor = cbDoctor.SelectedItem?.ToString();
                appt.Reason = txtReason.Text.Trim();
                appt.Status = cbStatus.SelectedItem?.ToString();

                bindingSource.ResetBindings(false);
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                ApplyFilter();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn lịch hẹn cần xóa trên danh sách.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var appt = (Appointment)dgvAppointments.SelectedRows[0].DataBoundItem;
            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa lịch hẹn của bệnh nhân [{appt.PatientName}]?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                appointmentList.Remove(appt);
                MessageBox.Show("Xóa lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtAppointmentId.Clear();
            txtAppointmentId.Enabled = true; // Mở lại để cho phép nhập mã mới
            txtPatientName.Clear();
            txtPhone.Clear();
            txtReason.Clear();
            dtpAppointmentDate.Value = DateTime.Now;
            if (cbDoctor.Items.Count > 0) cbDoctor.SelectedIndex = 0;
            if (cbStatus.Items.Count > 0) cbStatus.SelectedIndex = 0;
            errorProvider1.Clear();
            dgvAppointments.ClearSelection();
        }

        private void dgvAppointments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var appt = (Appointment)dgvAppointments.Rows[e.RowIndex].DataBoundItem;
                txtAppointmentId.Text = appt.AppointmentId;
                txtAppointmentId.Enabled = false; // Khóa mã lịch hẹn khi đang chọn sửa
                txtPatientName.Text = appt.PatientName;
                txtPhone.Text = appt.PhoneNumber;
                dtpAppointmentDate.Value = appt.AppointmentDateTime;
                cbDoctor.SelectedItem = appt.Doctor;
                txtReason.Text = appt.Reason;
                cbStatus.SelectedItem = appt.Status;
                errorProvider1.Clear();
            }
        }

        private void ApplyFilter()
        {
            string kw = txtSearch.Text.Trim().ToLower();
            string st = cbFilterStatus.SelectedItem?.ToString();

            var filtered = appointmentList.Where(x =>
                (string.IsNullOrEmpty(kw) || x.PatientName.ToLower().Contains(kw) || x.PhoneNumber.Contains(kw)) &&
                (!chkFilterDate.Checked || x.AppointmentDateTime.Date == dtpFilterDate.Value.Date) &&
                (st == "Tất cả" || string.IsNullOrEmpty(st) || x.Status == st)
            ).ToList();

            bindingSource.DataSource = new BindingList<Appointment>(filtered);
            UpdateStatusCount();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => ApplyFilter();
        private void chkFilterDate_CheckedChanged(object sender, EventArgs e) { dtpFilterDate.Enabled = chkFilterDate.Checked; ApplyFilter(); }
        private void dtpFilterDate_ValueChanged(object sender, EventArgs e) => ApplyFilter();
        private void cbFilterStatus_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilter();

        private void menuExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog { Filter = "CSV file (*.csv)|*.csv", FileName = "DanhSachLichHen.csv" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(sfd.FileName, false, System.Text.Encoding.UTF8))
                        {
                            sw.WriteLine("Mã lịch hẹn,Họ tên bệnh nhân,Số điện thoại,Ngày giờ hẹn,Bác sĩ,Lý do khám,Trạng thái");
                            foreach (DataGridViewRow row in dgvAppointments.Rows)
                            {
                                if (row.DataBoundItem is Appointment a)
                                    sw.WriteLine($"{a.AppointmentId},{a.PatientName},{a.PhoneNumber},{a.AppointmentDateTime:dd/MM/yyyy HH:mm},{a.Doctor},{a.Reason},{a.Status}");
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