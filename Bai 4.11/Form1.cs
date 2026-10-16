using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RepairServiceTracker
{
    public partial class Form1 : Form
    {
        private BindingList<RepairOrder> orderList = new BindingList<RepairOrder>();
        private BindingSource bindingSource = new BindingSource();
        private string currentImagePath = string.Empty;

        public Form1()
        {
            InitializeComponent();
            InitControlData();
        }

        private void InitControlData()
        {
            // Thiết lập danh mục loại thiết bị và trạng thái
            cbDeviceType.Items.AddRange(new string[] { "Laptop", "Điện thoại di động", "Máy tính bảng", "Màn hình", "Máy in", "Thiết bị mạng" });
            if (cbDeviceType.Items.Count > 0) cbDeviceType.SelectedIndex = 0;

            cbStatus.Items.AddRange(new string[] { "Mới tiếp nhận", "Đang sửa", "Chờ linh kiện", "Hoàn tất", "Đã hủy" });
            cbStatus.SelectedIndex = 0;

            cbFilterStatus.Items.Add("Tất cả");
            cbFilterStatus.Items.AddRange(new string[] { "Mới tiếp nhận", "Đang sửa", "Chờ linh kiện", "Hoàn tất", "Đã hủy" });
            cbFilterStatus.SelectedIndex = 0;

            // Cấu hình PictureBox
            pictureBoxDevice.SizeMode = PictureBoxSizeMode.Zoom;

            // Dữ liệu mẫu ban đầu
            orderList.Add(new RepairOrder
            {
                OrderId = "DH001",
                CustomerName = "Nguyễn Minh Tuấn",
                PhoneNumber = "0912345678",
                DeviceType = "Laptop",
                ErrorDescription = "Không lên nguồn, hỏng chân sạc",
                ReceivedDate = DateTime.Now.AddDays(-2),
                EstimatedCost = 500000,
                Status = "Đang sửa",
                ImagePath = string.Empty
            });

            orderList.Add(new RepairOrder
            {
                OrderId = "DH002",
                CustomerName = "Lê Thị Hồng",
                PhoneNumber = "0988123456",
                DeviceType = "Điện thoại di động",
                ErrorDescription = "Vỡ màn hình cảm ứng",
                ReceivedDate = DateTime.Now.AddDays(-1),
                EstimatedCost = 1200000,
                Status = "Chờ linh kiện",
                ImagePath = string.Empty
            });

            bindingSource.DataSource = orderList;
            dgvOrders.DataSource = bindingSource;
            UpdateStatusStrip();
        }

        private void UpdateStatusStrip()
        {
            int totalOrders = dgvOrders.Rows.Count;
            // Tính tổng chi phí dự kiến của các đơn chưa hoàn tất (Trạng thái khác "Hoàn tất" và "Đã hủy")
            decimal totalIncompleteCost = orderList
                .Where(x => x.Status != "Hoàn tất" && x.Status != "Đã hủy")
                .Sum(x => x.EstimatedCost);

            lblStatusCount.Text = $"Tổng số đơn hiển thị: {totalOrders} | Tổng chi phí dự kiến (chưa hoàn tất): {totalIncompleteCost:N0} VNĐ";
        }

        private bool ValidateInput(bool isUpdate = false)
        {
            errorProvider1.Clear();
            bool isValid = true;

            // Kiểm tra Mã đơn
            if (string.IsNullOrWhiteSpace(txtOrderId.Text))
            {
                errorProvider1.SetError(txtOrderId, "Mã đơn không được để trống.");
                isValid = false;
            }
            else if (!isUpdate && orderList.Any(x => x.OrderId == txtOrderId.Text.Trim()))
            {
                errorProvider1.SetError(txtOrderId, "Mã đơn đã tồn tại.");
                isValid = false;
            }

            // Kiểm tra Tên khách hàng
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                errorProvider1.SetError(txtCustomerName, "Tên khách hàng không được để trống.");
                isValid = false;
            }

            // Kiểm tra Số điện thoại
            if (string.IsNullOrWhiteSpace(txtPhone.Text) || !Regex.IsMatch(txtPhone.Text.Trim(), @"^0\d{9}$"))
            {
                errorProvider1.SetError(txtPhone, "SĐT không hợp lệ (Phải gồm 10 chữ số và bắt đầu bằng số 0).");
                isValid = false;
            }

            // Kiểm tra Mô tả lỗi
            if (string.IsNullOrWhiteSpace(txtErrorDescription.Text))
            {
                errorProvider1.SetError(txtErrorDescription, "Mô tả lỗi bắt buộc phải có.");
                isValid = false;
            }

            // Kiểm tra Chi phí dự kiến phải là số không âm
            if (!decimal.TryParse(txtEstimatedCost.Text.Trim(), out decimal cost) || cost < 0)
            {
                errorProvider1.SetError(txtEstimatedCost, "Chi phí dự kiến phải là số không âm.");
                isValid = false;
            }

            return isValid;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(false)) return;

            var newOrder = new RepairOrder
            {
                OrderId = txtOrderId.Text.Trim(),
                CustomerName = txtCustomerName.Text.Trim(),
                PhoneNumber = txtPhone.Text.Trim(),
                DeviceType = cbDeviceType.SelectedItem.ToString(),
                ErrorDescription = txtErrorDescription.Text.Trim(),
                ReceivedDate = dtpReceivedDate.Value,
                EstimatedCost = decimal.Parse(txtEstimatedCost.Text.Trim()),
                Status = cbStatus.SelectedItem.ToString(),
                ImagePath = currentImagePath
            };

            orderList.Add(newOrder);
            MessageBox.Show("Thêm đơn sửa chữa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
            ApplyFilter();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn đơn cần cập nhật trên danh sách.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput(true)) return;

            var selectedOrder = (RepairOrder)dgvOrders.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"Bạn có chắc muốn cập nhật đơn [{selectedOrder.OrderId}]?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                selectedOrder.CustomerName = txtCustomerName.Text.Trim();
                selectedOrder.PhoneNumber = txtPhone.Text.Trim();
                selectedOrder.DeviceType = cbDeviceType.SelectedItem.ToString();
                selectedOrder.ErrorDescription = txtErrorDescription.Text.Trim();
                selectedOrder.ReceivedDate = dtpReceivedDate.Value;
                selectedOrder.EstimatedCost = decimal.Parse(txtEstimatedCost.Text.Trim());
                selectedOrder.Status = cbStatus.SelectedItem.ToString();
                selectedOrder.ImagePath = currentImagePath;

                bindingSource.ResetBindings(false);
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                ApplyFilter();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn đơn cần xóa trên danh sách.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedOrder = (RepairOrder)dgvOrders.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa đơn của khách hàng [{selectedOrder.CustomerName}]?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                orderList.Remove(selectedOrder);
                MessageBox.Show("Xóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                ApplyFilter();
            }
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    currentImagePath = ofd.FileName;
                    try
                    {
                        pictureBoxDevice.ImageLocation = currentImagePath;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Không thể tải hình ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtOrderId.Clear();
            txtOrderId.Enabled = true;
            txtCustomerName.Clear();
            txtPhone.Clear();
            txtErrorDescription.Clear();
            txtEstimatedCost.Clear();
            dtpReceivedDate.Value = DateTime.Now;
            if (cbDeviceType.Items.Count > 0) cbDeviceType.SelectedIndex = 0;
            if (cbStatus.Items.Count > 0) cbStatus.SelectedIndex = 0;
            pictureBoxDevice.Image = null;
            currentImagePath = string.Empty;
            errorProvider1.Clear();
            dgvOrders.ClearSelection();
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var order = (RepairOrder)dgvOrders.Rows[e.RowIndex].DataBoundItem;
                txtOrderId.Text = order.OrderId;
                txtOrderId.Enabled = false; // Khóa mã đơn khi sửa
                txtCustomerName.Text = order.CustomerName;
                txtPhone.Text = order.PhoneNumber;
                cbDeviceType.SelectedItem = order.DeviceType;
                txtErrorDescription.Text = order.ErrorDescription;
                dtpReceivedDate.Value = order.ReceivedDate;
                txtEstimatedCost.Text = order.EstimatedCost.ToString("0");
                cbStatus.SelectedItem = order.Status;
                currentImagePath = order.ImagePath;

                if (!string.IsNullOrEmpty(currentImagePath) && File.Exists(currentImagePath))
                {
                    try
                    {
                        pictureBoxDevice.ImageLocation = currentImagePath;
                    }
                    catch
                    {
                        pictureBoxDevice.Image = null;
                    }
                }
                else
                {
                    pictureBoxDevice.Image = null;
                }

                errorProvider1.Clear();
            }
        }

        private void ApplyFilter()
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            string selectedStatus = cbFilterStatus.SelectedItem?.ToString();

            var filtered = orderList.Where(x =>
                (string.IsNullOrEmpty(keyword) || x.OrderId.ToLower().Contains(keyword) || x.CustomerName.ToLower().Contains(keyword) || x.PhoneNumber.Contains(keyword)) &&
                (selectedStatus == "Tất cả" || string.IsNullOrEmpty(selectedStatus) || x.Status == selectedStatus)
            ).ToList();

            bindingSource.DataSource = new BindingList<RepairOrder>(filtered);
            UpdateStatusStrip();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => ApplyFilter();
        private void cbFilterStatus_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilter();

        private void menuExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV file (*.csv)|*.csv";
                sfd.FileName = "DanhSachDonSuaChua.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(sfd.FileName, false, System.Text.Encoding.UTF8))
                        {
                            sw.WriteLine("Mã đơn,Tên khách hàng,Số điện thoại,Loại thiết bị,Mô tả lỗi,Ngày tiếp nhận,Chi phí dự kiến,Trạng thái");
                            foreach (DataGridViewRow row in dgvOrders.Rows)
                            {
                                if (row.DataBoundItem is RepairOrder o)
                                {
                                    sw.WriteLine($"{o.OrderId},{o.CustomerName},{o.PhoneNumber},{o.DeviceType},\"{o.ErrorDescription}\",{o.ReceivedDate:dd/MM/yyyy},{o.EstimatedCost},{o.Status}");
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

        private void menuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}