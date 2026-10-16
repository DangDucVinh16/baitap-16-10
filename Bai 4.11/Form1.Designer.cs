namespace RepairServiceTracker
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatusCount = new System.Windows.Forms.ToolStripStatusLabel();
            
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            
            this.pnlInput = new System.Windows.Forms.Panel();
            this.tlpInputParent = new System.Windows.Forms.TableLayoutPanel();
            this.tlpInput = new System.Windows.Forms.TableLayoutPanel();
            
            this.lblOrderId = new System.Windows.Forms.Label();
            this.txtOrderId = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            
            this.lblDeviceType = new System.Windows.Forms.Label();
            this.cbDeviceType = new System.Windows.Forms.ComboBox();
            this.lblReceivedDate = new System.Windows.Forms.Label();
            this.dtpReceivedDate = new System.Windows.Forms.DateTimePicker();
            this.lblEstimatedCost = new System.Windows.Forms.Label();
            this.txtEstimatedCost = new System.Windows.Forms.TextBox();
            
            this.lblErrorDesc = new System.Windows.Forms.Label();
            this.txtErrorDescription = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            
            this.pnlImageContainer = new System.Windows.Forms.Panel();
            this.pictureBoxDevice = new System.Windows.Forms.PictureBox();
            this.btnBrowseImage = new System.Windows.Forms.Button();
            
            this.pnlSearchFilter = new System.Windows.Forms.Panel();
            this.flpSearch = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblFilterStatus = new System.Windows.Forms.Label();
            this.cbFilterStatus = new System.Windows.Forms.ComboBox();
            
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.colOrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeviceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colErrorDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceivedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstimatedCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.pnlInput.SuspendLayout();
            this.tlpInputParent.SuspendLayout();
            this.tlpInput.SuspendLayout();
            this.flpButtons.SuspendLayout();
            this.pnlImageContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDevice)).BeginInit();
            this.pnlSearchFilter.SuspendLayout();
            this.flpSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.menuFile });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1150, 24);
            this.menuStrip1.TabIndex = 0;
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.menuExport, this.toolStripSeparator1, this.menuExit });
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "Tệp";
            // 
            // menuExport
            // 
            this.menuExport.Name = "menuExport";
            this.menuExport.Size = new System.Drawing.Size(155, 22);
            this.menuExport.Text = "Xuất ra CSV...";
            this.menuExport.Click += new System.EventHandler(this.menuExport_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(155, 22);
            this.menuExit.Text = "Thoát";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.lblStatusCount });
            this.statusStrip1.Location = new System.Drawing.Point(0, 709);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1150, 22);
            this.statusStrip1.TabIndex = 1;
            // 
            // lblStatusCount
            // 
            this.lblStatusCount.Name = "lblStatusCount";
            this.lblStatusCount.Size = new System.Drawing.Size(260, 17);
            this.lblStatusCount.Text = "Tổng số đơn hiển thị: 0 | Tổng chi phí dự kiến: 0 VNĐ";
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.pnlInput, 0, 0);
            this.tlpMain.Controls.Add(this.pnlSearchFilter, 0, 1);
            this.tlpMain.Controls.Add(this.dgvOrders, 0, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 24);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1150, 685);
            this.tlpMain.TabIndex = 2;
            // 
            // pnlInput
            // 
            this.pnlInput.Controls.Add(this.tlpInputParent);
            this.pnlInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInput.Location = new System.Drawing.Point(3, 3);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(1144, 234);
            this.pnlInput.TabIndex = 0;
            // 
            // tlpInputParent
            // 
            this.tlpInputParent.ColumnCount = 2;
            this.tlpInputParent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78F));
            this.tlpInputParent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tlpInputParent.Controls.Add(this.tlpInput, 0, 0);
            this.tlpInputParent.Controls.Add(this.pnlImageContainer, 1, 0);
            this.tlpInputParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInputParent.Location = new System.Drawing.Point(0, 0);
            this.tlpInputParent.Name = "tlpInputParent";
            this.tlpInputParent.RowCount = 1;
            this.tlpInputParent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInputParent.Size = new System.Drawing.Size(1144, 234);
            this.tlpInputParent.TabIndex = 0;
            // 
            // tlpInput
            // 
            this.tlpInput.ColumnCount = 4;
            this.tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tlpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpInput.Controls.Add(this.lblOrderId, 0, 0);
            this.tlpInput.Controls.Add(this.txtOrderId, 1, 0);
            this.tlpInput.Controls.Add(this.lblDeviceType, 2, 0);
            this.tlpInput.Controls.Add(this.cbDeviceType, 3, 0);
            this.tlpInput.Controls.Add(this.lblCustomerName, 0, 1);
            this.tlpInput.Controls.Add(this.txtCustomerName, 1, 1);
            this.tlpInput.Controls.Add(this.lblReceivedDate, 2, 1);
            this.tlpInput.Controls.Add(this.dtpReceivedDate, 3, 1);
            this.tlpInput.Controls.Add(this.lblPhone, 0, 2);
            this.tlpInput.Controls.Add(this.txtPhone, 1, 2);
            this.tlpInput.Controls.Add(this.lblEstimatedCost, 2, 2);
            this.tlpInput.Controls.Add(this.txtEstimatedCost, 3, 2);
            this.tlpInput.Controls.Add(this.lblErrorDesc, 0, 3);
            this.tlpInput.Controls.Add(this.txtErrorDescription, 1, 3);
            this.tlpInput.Controls.Add(this.lblStatus, 2, 3);
            this.tlpInput.Controls.Add(this.cbStatus, 3, 3);
            this.tlpInput.Controls.Add(this.flpButtons, 1, 4);
            this.tlpInput.SetColumnSpan(this.flpButtons, 3);
            this.tlpInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInput.Location = new System.Drawing.Point(3, 3);
            this.tlpInput.Name = "tlpInput";
            this.tlpInput.RowCount = 5;
            this.tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInput.Size = new System.Drawing.Size(886, 228);
            this.tlpInput.TabIndex = 0;
            // 
            // lblOrderId
            // 
            this.lblOrderId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOrderId.AutoSize = true;
            this.lblOrderId.Location = new System.Drawing.Point(3, 11);
            this.lblOrderId.Name = "lblOrderId";
            this.lblOrderId.Size = new System.Drawing.Size(43, 13);
            this.lblOrderId.TabIndex = 0;
            this.lblOrderId.Text = "Mã đơn:";
            // 
            // txtOrderId
            // 
            this.txtOrderId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOrderId.Location = new System.Drawing.Point(103, 3);
            this.txtOrderId.Name = "txtOrderId";
            this.txtOrderId.Size = new System.Drawing.Size(331, 20);
            this.txtOrderId.TabIndex = 1;
            // 
            // lblDeviceType
            // 
            this.lblDeviceType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDeviceType.AutoSize = true;
            this.lblDeviceType.Location = new System.Drawing.Point(440, 11);
            this.lblDeviceType.Name = "lblDeviceType";
            this.lblDeviceType.Size = new System.Drawing.Size(64, 13);
            this.lblDeviceType.TabIndex = 2;
            this.lblDeviceType.Text = "Loại thiết bị:";
            // 
            // cbDeviceType
            // 
            this.cbDeviceType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbDeviceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDeviceType.FormattingEnabled = true;
            this.cbDeviceType.Location = new System.Drawing.Point(550, 3);
            this.cbDeviceType.Name = "cbDeviceType";
            this.cbDeviceType.Size = new System.Drawing.Size(333, 21);
            this.cbDeviceType.TabIndex = 3;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(3, 46);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(89, 13);
            this.lblCustomerName.TabIndex = 4;
            this.lblCustomerName.Text = "Tên khách hàng:";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCustomerName.Location = new System.Drawing.Point(103, 38);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(331, 20);
            this.txtCustomerName.TabIndex = 5;
            // 
            // lblReceivedDate
            // 
            this.lblReceivedDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblReceivedDate.AutoSize = true;
            this.lblReceivedDate.Location = new System.Drawing.Point(440, 46);
            this.lblReceivedDate.Name = "lblReceivedDate";
            this.lblReceivedDate.Size = new System.Drawing.Size(81, 13);
            this.lblReceivedDate.TabIndex = 6;
            this.lblReceivedDate.Text = "Ngày tiếp nhận:";
            // 
            // dtpReceivedDate
            // 
            this.dtpReceivedDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpReceivedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReceivedDate.Location = new System.Drawing.Point(550, 38);
            this.dtpReceivedDate.Name = "dtpReceivedDate";
            this.dtpReceivedDate.Size = new System.Drawing.Size(333, 20);
            this.dtpReceivedDate.TabIndex = 7;
            // 
            // lblPhone
            // 
            this.lblPhone.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(3, 81);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(73, 13);
            this.lblPhone.TabIndex = 8;
            this.lblPhone.Text = "Số điện thoại:";
            // 
            // txtPhone
            // 
            this.txtPhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPhone.Location = new System.Drawing.Point(103, 73);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(331, 20);
            this.txtPhone.TabIndex = 9;
            // 
            // lblEstimatedCost
            // 
            this.lblEstimatedCost.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEstimatedCost.AutoSize = true;
            this.lblEstimatedCost.Location = new System.Drawing.Point(440, 81);
            this.lblEstimatedCost.Name = "lblEstimatedCost";
            this.lblEstimatedCost.Size = new System.Drawing.Size(81, 13);
            this.lblEstimatedCost.TabIndex = 10;
            this.lblEstimatedCost.Text = "Chi phí dự kiến:";
            // 
            // txtEstimatedCost
            // 
            this.txtEstimatedCost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEstimatedCost.Location = new System.Drawing.Point(550, 73);
            this.txtEstimatedCost.Name = "txtEstimatedCost";
            this.txtEstimatedCost.Size = new System.Drawing.Size(333, 20);
            this.txtEstimatedCost.TabIndex = 11;
            // 
            // lblErrorDesc
            // 
            this.lblErrorDesc.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblErrorDesc.AutoSize = true;
            this.lblErrorDesc.Location = new System.Drawing.Point(3, 116);
            this.lblErrorDesc.Name = "lblErrorDesc";
            this.lblErrorDesc.Size = new System.Drawing.Size(61, 13);
            this.lblErrorDesc.TabIndex = 12;
            this.lblErrorDesc.Text = "Mô tả lỗi:";
            // 
            // txtErrorDescription
            // 
            this.txtErrorDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtErrorDescription.Location = new System.Drawing.Point(103, 108);
            this.txtErrorDescription.Name = "txtErrorDescription";
            this.txtErrorDescription.Size = new System.Drawing.Size(331, 20);
            this.txtErrorDescription.TabIndex = 13;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(440, 116);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(58, 13);
            this.lblStatus.TabIndex = 14;
            this.lblStatus.Text = "Trạng thái:";
            // 
            // cbStatus
            // 
            this.cbStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(550, 108);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(333, 21);
            this.cbStatus.TabIndex = 15;
            // 
            // flpButtons
            // 
            this.flpButtons.Controls.Add(this.btnAdd);
            this.flpButtons.Controls.Add(this.btnUpdate);
            this.flpButtons.Controls.Add(this.btnDelete);
            this.flpButtons.Controls.Add(this.btnClear);
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpButtons.Location = new System.Drawing.Point(103, 143);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Size = new System.Drawing.Size(780, 82);
            this.flpButtons.TabIndex = 16;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(3, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 30);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(94, 3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(85, 30);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(185, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 30);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(276, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(85, 30);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Làm mới";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // pnlImageContainer
            // 
            this.pnlImageContainer.Controls.Add(this.pictureBoxDevice);
            this.pnlImageContainer.Controls.Add(this.btnBrowseImage);
            this.pnlImageContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImageContainer.Location = new System.Drawing.Point(895, 3);
            this.pnlImageContainer.Name = "pnlImageContainer";
            this.pnlImageContainer.Size = new System.Drawing.Size(246, 228);
            this.pnlImageContainer.TabIndex = 1;
            // 
            // pictureBoxDevice
            // 
            this.pictureBoxDevice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxDevice.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxDevice.Name = "pictureBoxDevice";
            this.pictureBoxDevice.Size = new System.Drawing.Size(246, 195);
            this.pictureBoxDevice.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxDevice.TabIndex = 0;
            this.pictureBoxDevice.TabStop = false;
            // 
            // btnBrowseImage
            // 
            this.btnBrowseImage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnBrowseImage.Location = new System.Drawing.Point(0, 195);
            this.btnBrowseImage.Name = "btnBrowseImage";
            this.btnBrowseImage.Size = new System.Drawing.Size(246, 33);
            this.btnBrowseImage.TabIndex = 1;
            this.btnBrowseImage.Text = "Chọn ảnh thiết bị...";
            this.btnBrowseImage.UseVisualStyleBackColor = true;
            this.btnBrowseImage.Click += new System.EventHandler(this.btnBrowseImage_Click);
            // 
            // pnlSearchFilter
            // 
            this.pnlSearchFilter.Controls.Add(this.flpSearch);
            this.pnlSearchFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSearchFilter.Location = new System.Drawing.Point(3, 243);
            this.pnlSearchFilter.Name = "pnlSearchFilter";
            this.pnlSearchFilter.Size = new System.Drawing.Size(1144, 44);
            this.pnlSearchFilter.TabIndex = 1;
            // 
            // flpSearch
            // 
            this.flpSearch.Controls.Add(this.lblSearch);
            this.flpSearch.Controls.Add(this.txtSearch);
            this.flpSearch.Controls.Add(this.lblFilterStatus);
            this.flpSearch.Controls.Add(this.cbFilterStatus);
            this.flpSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpSearch.Location = new System.Drawing.Point(0, 0);
            this.flpSearch.Name = "flpSearch";
            this.flpSearch.Padding = new System.Windows.Forms.Padding(5);
            this.flpSearch.Size = new System.Drawing.Size(1144, 44);
            this.flpSearch.TabIndex = 0;
            // 
            // lblSearch
            // 
            this.lblSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(8, 11);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(135, 13);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Tìm kiếm (Mã/Tên/SĐT):";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSearch.Location = new System.Drawing.Point(149, 8);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblFilterStatus
            // 
            this.lblFilterStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFilterStatus.AutoSize = true;
            this.lblFilterStatus.Location = new System.Drawing.Point(355, 11);
            this.lblFilterStatus.Name = "lblFilterStatus";
            this.lblFilterStatus.Size = new System.Drawing.Size(58, 13);
            this.lblFilterStatus.TabIndex = 2;
            this.lblFilterStatus.Text = "Trạng thái:";
            // 
            // cbFilterStatus
            // 
            this.cbFilterStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterStatus.FormattingEnabled = true;
            this.cbFilterStatus.Location = new System.Drawing.Point(419, 8);
            this.cbFilterStatus.Name = "cbFilterStatus";
            this.cbFilterStatus.Size = new System.Drawing.Size(130, 21);
            this.cbFilterStatus.TabIndex = 3;
            this.cbFilterStatus.SelectedIndexChanged += new System.EventHandler(this.cbFilterStatus_SelectedIndexChanged);
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrderId,
            this.colCustomerName,
            this.colPhone,
            this.colDeviceType,
            this.colErrorDesc,
            this.colReceivedDate,
            this.colEstimatedCost,
            this.colStatus});
            this.dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrders.Location = new System.Drawing.Point(3, 293);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(1144, 389);
            this.dgvOrders.TabIndex = 2;
            this.dgvOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellClick);
            // 
            // colOrderId
            // 
            this.colOrderId.DataPropertyName = "OrderId";
            this.colOrderId.HeaderText = "Mã đơn";
            this.colOrderId.Name = "colOrderId";
            this.colOrderId.ReadOnly = true;
            // 
            // colCustomerName
            // 
            this.colCustomerName.DataPropertyName = "CustomerName";
            this.colCustomerName.HeaderText = "Tên khách hàng";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.ReadOnly = true;
            // 
            // colPhone
            // 
            this.colPhone.DataPropertyName = "PhoneNumber";
            this.colPhone.HeaderText = "Số điện thoại";
            this.colPhone.Name = "colPhone";
            this.colPhone.ReadOnly = true;
            // 
            // colDeviceType
            // 
            this.colDeviceType.DataPropertyName = "DeviceType";
            this.colDeviceType.HeaderText = "Loại thiết bị";
            this.colDeviceType.Name = "colDeviceType";
            this.colDeviceType.ReadOnly = true;
            // 
            // colErrorDesc
            // 
            this.colErrorDesc.DataPropertyName = "ErrorDescription";
            this.colErrorDesc.HeaderText = "Mô tả lỗi";
            this.colErrorDesc.Name = "colErrorDesc";
            this.colErrorDesc.ReadOnly = true;
            // 
            // colReceivedDate
            // 
            this.colReceivedDate.DataPropertyName = "ReceivedDate";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            this.colReceivedDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.colReceivedDate.HeaderText = "Ngày tiếp nhận";
            this.colReceivedDate.Name = "colReceivedDate";
            this.colReceivedDate.ReadOnly = true;
            // 
            // colEstimatedCost
            // 
            this.colEstimatedCost.DataPropertyName = "EstimatedCost";
            dataGridViewCellStyle1.Format = "N0";
            this.colEstimatedCost.DefaultCellStyle = dataGridViewCellStyle1;
            this.colEstimatedCost.HeaderText = "Chi phí dự kiến";
            this.colEstimatedCost.Name = "colEstimatedCost";
            this.colEstimatedCost.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "Trạng thái";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 731);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý đơn đăng ký dịch vụ sửa chữa";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            this.pnlInput.ResumeLayout(false);
            this.tlpInputParent.ResumeLayout(false);
            this.tlpInput.ResumeLayout(false);
            this.tlpInput.PerformLayout();
            this.flpButtons.ResumeLayout(false);
            this.pnlImageContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDevice)).EndInit();
            this.pnlSearchFilter.ResumeLayout(false);
            this.flpSearch.ResumeLayout(false);
            this.flpSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuExport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusCount;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.TableLayoutPanel tlpInputParent;
        private System.Windows.Forms.TableLayoutPanel tlpInput;
        private System.Windows.Forms.Label lblOrderId;
        private System.Windows.Forms.TextBox txtOrderId;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblDeviceType;
        private System.Windows.Forms.ComboBox cbDeviceType;
        private System.Windows.Forms.Label lblReceivedDate;
        private System.Windows.Forms.DateTimePicker dtpReceivedDate;
        private System.Windows.Forms.Label lblEstimatedCost;
        private System.Windows.Forms.TextBox txtEstimatedCost;
        private System.Windows.Forms.Label lblErrorDesc;
        private System.Windows.Forms.TextBox txtErrorDescription;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel pnlImageContainer;
        private System.Windows.Forms.PictureBox pictureBoxDevice;
        private System.Windows.Forms.Button btnBrowseImage;
        private System.Windows.Forms.Panel pnlSearchFilter;
        private System.Windows.Forms.FlowLayoutPanel flpSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblFilterStatus;
        private System.Windows.Forms.ComboBox cbFilterStatus;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeviceType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colErrorDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceivedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstimatedCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}