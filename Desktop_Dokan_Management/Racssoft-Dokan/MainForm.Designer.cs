
namespace Racssoft_Dokan
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.icnBtnMaximize = new FontAwesome.Sharp.IconButton();
            this.icnBtnMinimize = new FontAwesome.Sharp.IconButton();
            this.icnBtnClose = new FontAwesome.Sharp.IconButton();
            this.lblTitleChildForm = new System.Windows.Forms.Label();
            this.panelDesktopPane = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnBalanceSheet = new FontAwesome.Sharp.IconButton();
            this.btnInventory = new FontAwesome.Sharp.IconButton();
            this.btnSale = new FontAwesome.Sharp.IconButton();
            this.btnSalesReport = new FontAwesome.Sharp.IconButton();
            this.btnDocumentUpload = new FontAwesome.Sharp.IconButton();
            this.btnApartmentManage = new FontAwesome.Sharp.IconButton();
            this.panelTenantManage = new System.Windows.Forms.Panel();
            this.iconButton5 = new FontAwesome.Sharp.IconButton();
            this.btnApartmentAdd = new FontAwesome.Sharp.IconButton();
            this.btnOwnerManage = new FontAwesome.Sharp.IconButton();
            this.btnTenantInfoAdd = new FontAwesome.Sharp.IconButton();
            this.btnTenantDetails = new FontAwesome.Sharp.IconButton();
            this.btnBalanceHistory = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnDatabase = new FontAwesome.Sharp.IconButton();
            this.panelTitleBar.SuspendLayout();
            this.panelDesktopPane.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelTenantManage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panelTitleBar.Controls.Add(this.icnBtnMaximize);
            this.panelTitleBar.Controls.Add(this.icnBtnMinimize);
            this.panelTitleBar.Controls.Add(this.icnBtnClose);
            this.panelTitleBar.Controls.Add(this.lblTitleChildForm);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(200, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(1009, 80);
            this.panelTitleBar.TabIndex = 1;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // icnBtnMaximize
            // 
            this.icnBtnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.icnBtnMaximize.FlatAppearance.BorderSize = 0;
            this.icnBtnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icnBtnMaximize.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this.icnBtnMaximize.IconColor = System.Drawing.Color.White;
            this.icnBtnMaximize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icnBtnMaximize.IconSize = 25;
            this.icnBtnMaximize.Location = new System.Drawing.Point(915, 3);
            this.icnBtnMaximize.Name = "icnBtnMaximize";
            this.icnBtnMaximize.Size = new System.Drawing.Size(30, 30);
            this.icnBtnMaximize.TabIndex = 5;
            this.icnBtnMaximize.UseVisualStyleBackColor = true;
            this.icnBtnMaximize.Visible = false;
            this.icnBtnMaximize.Click += new System.EventHandler(this.icnBtnMaximize_Click);
            // 
            // icnBtnMinimize
            // 
            this.icnBtnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.icnBtnMinimize.FlatAppearance.BorderSize = 0;
            this.icnBtnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icnBtnMinimize.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.icnBtnMinimize.IconColor = System.Drawing.Color.White;
            this.icnBtnMinimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icnBtnMinimize.IconSize = 25;
            this.icnBtnMinimize.Location = new System.Drawing.Point(951, 3);
            this.icnBtnMinimize.Name = "icnBtnMinimize";
            this.icnBtnMinimize.Size = new System.Drawing.Size(30, 30);
            this.icnBtnMinimize.TabIndex = 4;
            this.icnBtnMinimize.UseVisualStyleBackColor = true;
            this.icnBtnMinimize.Click += new System.EventHandler(this.icnBtnMinimize_Click);
            // 
            // icnBtnClose
            // 
            this.icnBtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.icnBtnClose.FlatAppearance.BorderSize = 0;
            this.icnBtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icnBtnClose.IconChar = FontAwesome.Sharp.IconChar.WindowClose;
            this.icnBtnClose.IconColor = System.Drawing.Color.White;
            this.icnBtnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icnBtnClose.IconSize = 25;
            this.icnBtnClose.Location = new System.Drawing.Point(977, 3);
            this.icnBtnClose.Name = "icnBtnClose";
            this.icnBtnClose.Size = new System.Drawing.Size(30, 30);
            this.icnBtnClose.TabIndex = 3;
            this.icnBtnClose.UseVisualStyleBackColor = true;
            this.icnBtnClose.Click += new System.EventHandler(this.icnBtnClose_Click);
            // 
            // lblTitleChildForm
            // 
            this.lblTitleChildForm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitleChildForm.AutoSize = true;
            this.lblTitleChildForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleChildForm.ForeColor = System.Drawing.Color.White;
            this.lblTitleChildForm.Location = new System.Drawing.Point(382, 25);
            this.lblTitleChildForm.Name = "lblTitleChildForm";
            this.lblTitleChildForm.Size = new System.Drawing.Size(126, 25);
            this.lblTitleChildForm.TabIndex = 1;
            this.lblTitleChildForm.Text = "Dashboard";
            // 
            // panelDesktopPane
            // 
            this.panelDesktopPane.AutoScroll = true;
            this.panelDesktopPane.BackColor = System.Drawing.Color.White;
            this.panelDesktopPane.Controls.Add(this.statusStrip1);
            this.panelDesktopPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktopPane.Location = new System.Drawing.Point(200, 80);
            this.panelDesktopPane.Name = "panelDesktopPane";
            this.panelDesktopPane.Size = new System.Drawing.Size(1009, 529);
            this.panelDesktopPane.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 507);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1009, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(1, 2, 0, 2);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(158, 18);
            this.toolStripStatusLabel1.Text = "© Copyright By Racssoft";
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(33)))), ((int)(((byte)(55)))));
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(200, 80);
            this.panelLogo.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnBalanceSheet
            // 
            this.btnBalanceSheet.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBalanceSheet.FlatAppearance.BorderSize = 0;
            this.btnBalanceSheet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBalanceSheet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBalanceSheet.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnBalanceSheet.IconChar = FontAwesome.Sharp.IconChar.CashRegister;
            this.btnBalanceSheet.IconColor = System.Drawing.Color.Gainsboro;
            this.btnBalanceSheet.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBalanceSheet.IconSize = 32;
            this.btnBalanceSheet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBalanceSheet.Location = new System.Drawing.Point(0, 80);
            this.btnBalanceSheet.Name = "btnBalanceSheet";
            this.btnBalanceSheet.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnBalanceSheet.Size = new System.Drawing.Size(200, 45);
            this.btnBalanceSheet.TabIndex = 2;
            this.btnBalanceSheet.Text = "  Balance Sheet";
            this.btnBalanceSheet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBalanceSheet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBalanceSheet.UseVisualStyleBackColor = true;
            this.btnBalanceSheet.Click += new System.EventHandler(this.btnCashMaintain_Click_1);
            // 
            // btnInventory
            // 
            this.btnInventory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInventory.FlatAppearance.BorderSize = 0;
            this.btnInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventory.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnInventory.IconChar = FontAwesome.Sharp.IconChar.Store;
            this.btnInventory.IconColor = System.Drawing.Color.Gainsboro;
            this.btnInventory.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnInventory.IconSize = 32;
            this.btnInventory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventory.Location = new System.Drawing.Point(0, 125);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnInventory.Size = new System.Drawing.Size(200, 45);
            this.btnInventory.TabIndex = 3;
            this.btnInventory.Text = "  Inventory";
            this.btnInventory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInventory.UseVisualStyleBackColor = true;
            this.btnInventory.Click += new System.EventHandler(this.btnDailyExpense_Click);
            // 
            // btnSale
            // 
            this.btnSale.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSale.FlatAppearance.BorderSize = 0;
            this.btnSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSale.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSale.IconChar = FontAwesome.Sharp.IconChar.ShoppingCart;
            this.btnSale.IconColor = System.Drawing.Color.Gainsboro;
            this.btnSale.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSale.IconSize = 32;
            this.btnSale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSale.Location = new System.Drawing.Point(0, 170);
            this.btnSale.Name = "btnSale";
            this.btnSale.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnSale.Size = new System.Drawing.Size(200, 45);
            this.btnSale.TabIndex = 4;
            this.btnSale.Text = "  Sale";
            this.btnSale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSale.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSale.UseVisualStyleBackColor = true;
            this.btnSale.Click += new System.EventHandler(this.btnCreateInvoice_Click);
            // 
            // btnSalesReport
            // 
            this.btnSalesReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSalesReport.FlatAppearance.BorderSize = 0;
            this.btnSalesReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalesReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalesReport.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSalesReport.IconChar = FontAwesome.Sharp.IconChar.Newspaper;
            this.btnSalesReport.IconColor = System.Drawing.Color.Gainsboro;
            this.btnSalesReport.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSalesReport.IconSize = 32;
            this.btnSalesReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalesReport.Location = new System.Drawing.Point(0, 215);
            this.btnSalesReport.Name = "btnSalesReport";
            this.btnSalesReport.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnSalesReport.Size = new System.Drawing.Size(200, 45);
            this.btnSalesReport.TabIndex = 5;
            this.btnSalesReport.Text = "  Sales Report";
            this.btnSalesReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalesReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalesReport.UseVisualStyleBackColor = true;
            this.btnSalesReport.Click += new System.EventHandler(this.btnCollection_Click);
            // 
            // btnDocumentUpload
            // 
            this.btnDocumentUpload.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDocumentUpload.FlatAppearance.BorderSize = 0;
            this.btnDocumentUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDocumentUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDocumentUpload.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDocumentUpload.IconChar = FontAwesome.Sharp.IconChar.Info;
            this.btnDocumentUpload.IconColor = System.Drawing.Color.Gainsboro;
            this.btnDocumentUpload.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDocumentUpload.IconSize = 32;
            this.btnDocumentUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDocumentUpload.Location = new System.Drawing.Point(0, 260);
            this.btnDocumentUpload.Name = "btnDocumentUpload";
            this.btnDocumentUpload.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnDocumentUpload.Size = new System.Drawing.Size(200, 45);
            this.btnDocumentUpload.TabIndex = 6;
            this.btnDocumentUpload.Text = "  Document Upload";
            this.btnDocumentUpload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDocumentUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDocumentUpload.UseVisualStyleBackColor = true;
            this.btnDocumentUpload.Click += new System.EventHandler(this.btnDocumentUpload_Click_1);
            // 
            // btnApartmentManage
            // 
            this.btnApartmentManage.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnApartmentManage.FlatAppearance.BorderSize = 0;
            this.btnApartmentManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApartmentManage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApartmentManage.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnApartmentManage.IconChar = FontAwesome.Sharp.IconChar.Building;
            this.btnApartmentManage.IconColor = System.Drawing.Color.Gainsboro;
            this.btnApartmentManage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnApartmentManage.IconSize = 32;
            this.btnApartmentManage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApartmentManage.Location = new System.Drawing.Point(0, 305);
            this.btnApartmentManage.Name = "btnApartmentManage";
            this.btnApartmentManage.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnApartmentManage.Size = new System.Drawing.Size(200, 45);
            this.btnApartmentManage.TabIndex = 9;
            this.btnApartmentManage.Text = "  Apartments Manage";
            this.btnApartmentManage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApartmentManage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnApartmentManage.UseVisualStyleBackColor = true;
            this.btnApartmentManage.Click += new System.EventHandler(this.btnApartmentManage_Click);
            // 
            // panelTenantManage
            // 
            this.panelTenantManage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(33)))), ((int)(((byte)(55)))));
            this.panelTenantManage.Controls.Add(this.btnTenantDetails);
            this.panelTenantManage.Controls.Add(this.btnTenantInfoAdd);
            this.panelTenantManage.Controls.Add(this.btnOwnerManage);
            this.panelTenantManage.Controls.Add(this.btnApartmentAdd);
            this.panelTenantManage.Controls.Add(this.iconButton5);
            this.panelTenantManage.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTenantManage.Location = new System.Drawing.Point(0, 350);
            this.panelTenantManage.Name = "panelTenantManage";
            this.panelTenantManage.Size = new System.Drawing.Size(200, 145);
            this.panelTenantManage.TabIndex = 10;
            // 
            // iconButton5
            // 
            this.iconButton5.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton5.IconColor = System.Drawing.Color.Black;
            this.iconButton5.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton5.Location = new System.Drawing.Point(0, 0);
            this.iconButton5.Name = "iconButton5";
            this.iconButton5.Size = new System.Drawing.Size(75, 23);
            this.iconButton5.TabIndex = 10;
            // 
            // btnApartmentAdd
            // 
            this.btnApartmentAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnApartmentAdd.FlatAppearance.BorderSize = 0;
            this.btnApartmentAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApartmentAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApartmentAdd.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnApartmentAdd.IconChar = FontAwesome.Sharp.IconChar.LayerGroup;
            this.btnApartmentAdd.IconColor = System.Drawing.Color.Gainsboro;
            this.btnApartmentAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnApartmentAdd.IconSize = 32;
            this.btnApartmentAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApartmentAdd.Location = new System.Drawing.Point(0, 0);
            this.btnApartmentAdd.Name = "btnApartmentAdd";
            this.btnApartmentAdd.Padding = new System.Windows.Forms.Padding(25, 0, 20, 0);
            this.btnApartmentAdd.Size = new System.Drawing.Size(200, 36);
            this.btnApartmentAdd.TabIndex = 9;
            this.btnApartmentAdd.Text = "  Apartment Add";
            this.btnApartmentAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApartmentAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnApartmentAdd.UseVisualStyleBackColor = true;
            this.btnApartmentAdd.Click += new System.EventHandler(this.btnApartmentAdd_Click);
            // 
            // btnOwnerManage
            // 
            this.btnOwnerManage.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOwnerManage.FlatAppearance.BorderSize = 0;
            this.btnOwnerManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOwnerManage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOwnerManage.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnOwnerManage.IconChar = FontAwesome.Sharp.IconChar.UserCog;
            this.btnOwnerManage.IconColor = System.Drawing.Color.Gainsboro;
            this.btnOwnerManage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnOwnerManage.IconSize = 32;
            this.btnOwnerManage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOwnerManage.Location = new System.Drawing.Point(0, 36);
            this.btnOwnerManage.Name = "btnOwnerManage";
            this.btnOwnerManage.Padding = new System.Windows.Forms.Padding(25, 0, 20, 0);
            this.btnOwnerManage.Size = new System.Drawing.Size(200, 36);
            this.btnOwnerManage.TabIndex = 11;
            this.btnOwnerManage.Text = "  Owner Manage";
            this.btnOwnerManage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOwnerManage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOwnerManage.UseVisualStyleBackColor = true;
            this.btnOwnerManage.Click += new System.EventHandler(this.btnOwnerManage_Click);
            // 
            // btnTenantInfoAdd
            // 
            this.btnTenantInfoAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTenantInfoAdd.FlatAppearance.BorderSize = 0;
            this.btnTenantInfoAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTenantInfoAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTenantInfoAdd.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnTenantInfoAdd.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.btnTenantInfoAdd.IconColor = System.Drawing.Color.Gainsboro;
            this.btnTenantInfoAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTenantInfoAdd.IconSize = 32;
            this.btnTenantInfoAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTenantInfoAdd.Location = new System.Drawing.Point(0, 72);
            this.btnTenantInfoAdd.Name = "btnTenantInfoAdd";
            this.btnTenantInfoAdd.Padding = new System.Windows.Forms.Padding(25, 0, 20, 0);
            this.btnTenantInfoAdd.Size = new System.Drawing.Size(200, 36);
            this.btnTenantInfoAdd.TabIndex = 12;
            this.btnTenantInfoAdd.Text = "  Tenant Info Add";
            this.btnTenantInfoAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTenantInfoAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTenantInfoAdd.UseVisualStyleBackColor = true;
            this.btnTenantInfoAdd.Click += new System.EventHandler(this.btnTenantInfoAdd_Click_1);
            // 
            // btnTenantDetails
            // 
            this.btnTenantDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTenantDetails.FlatAppearance.BorderSize = 0;
            this.btnTenantDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTenantDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTenantDetails.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnTenantDetails.IconChar = FontAwesome.Sharp.IconChar.FileAlt;
            this.btnTenantDetails.IconColor = System.Drawing.Color.Gainsboro;
            this.btnTenantDetails.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTenantDetails.IconSize = 32;
            this.btnTenantDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTenantDetails.Location = new System.Drawing.Point(0, 108);
            this.btnTenantDetails.Name = "btnTenantDetails";
            this.btnTenantDetails.Padding = new System.Windows.Forms.Padding(25, 0, 20, 0);
            this.btnTenantDetails.Size = new System.Drawing.Size(200, 36);
            this.btnTenantDetails.TabIndex = 13;
            this.btnTenantDetails.Text = "  Tenant Details";
            this.btnTenantDetails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTenantDetails.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTenantDetails.UseVisualStyleBackColor = true;
            this.btnTenantDetails.Click += new System.EventHandler(this.btnTenantDetails_Click);
            // 
            // btnBalanceHistory
            // 
            this.btnBalanceHistory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBalanceHistory.FlatAppearance.BorderSize = 0;
            this.btnBalanceHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBalanceHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBalanceHistory.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnBalanceHistory.IconChar = FontAwesome.Sharp.IconChar.History;
            this.btnBalanceHistory.IconColor = System.Drawing.Color.Gainsboro;
            this.btnBalanceHistory.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBalanceHistory.IconSize = 32;
            this.btnBalanceHistory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBalanceHistory.Location = new System.Drawing.Point(0, 495);
            this.btnBalanceHistory.Name = "btnBalanceHistory";
            this.btnBalanceHistory.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnBalanceHistory.Size = new System.Drawing.Size(200, 45);
            this.btnBalanceHistory.TabIndex = 11;
            this.btnBalanceHistory.Text = "  Financial Report";
            this.btnBalanceHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBalanceHistory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBalanceHistory.UseVisualStyleBackColor = true;
            this.btnBalanceHistory.Click += new System.EventHandler(this.btnBalanceHistory_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 579);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 30);
            this.panel1.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(49, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = "Version: 1.0.0";
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panelMenu.Controls.Add(this.btnDatabase);
            this.panelMenu.Controls.Add(this.panel1);
            this.panelMenu.Controls.Add(this.btnBalanceHistory);
            this.panelMenu.Controls.Add(this.panelTenantManage);
            this.panelMenu.Controls.Add(this.btnApartmentManage);
            this.panelMenu.Controls.Add(this.btnDocumentUpload);
            this.panelMenu.Controls.Add(this.btnSalesReport);
            this.panelMenu.Controls.Add(this.btnSale);
            this.panelMenu.Controls.Add(this.btnInventory);
            this.panelMenu.Controls.Add(this.btnBalanceSheet);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(200, 609);
            this.panelMenu.TabIndex = 0;
            // 
            // btnDatabase
            // 
            this.btnDatabase.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDatabase.FlatAppearance.BorderSize = 0;
            this.btnDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDatabase.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDatabase.IconChar = FontAwesome.Sharp.IconChar.Database;
            this.btnDatabase.IconColor = System.Drawing.Color.Gainsboro;
            this.btnDatabase.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDatabase.IconSize = 32;
            this.btnDatabase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDatabase.Location = new System.Drawing.Point(0, 540);
            this.btnDatabase.Name = "btnDatabase";
            this.btnDatabase.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnDatabase.Size = new System.Drawing.Size(200, 45);
            this.btnDatabase.TabIndex = 12;
            this.btnDatabase.Text = "  Backup/Restore";
            this.btnDatabase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDatabase.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDatabase.UseVisualStyleBackColor = true;
            this.btnDatabase.Click += new System.EventHandler(this.btnDatabase_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1209, 609);
            this.ControlBox = false;
            this.Controls.Add(this.panelDesktopPane);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.panelDesktopPane.ResumeLayout(false);
            this.panelDesktopPane.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelTenantManage.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label lblTitleChildForm;
        private System.Windows.Forms.Panel panelDesktopPane;
        private FontAwesome.Sharp.IconButton icnBtnClose;
        private FontAwesome.Sharp.IconButton icnBtnMaximize;
        private FontAwesome.Sharp.IconButton icnBtnMinimize;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton btnBalanceSheet;
        private FontAwesome.Sharp.IconButton btnInventory;
        private FontAwesome.Sharp.IconButton btnSale;
        private FontAwesome.Sharp.IconButton btnSalesReport;
        private FontAwesome.Sharp.IconButton btnDocumentUpload;
        private FontAwesome.Sharp.IconButton btnApartmentManage;
        private System.Windows.Forms.Panel panelTenantManage;
        private FontAwesome.Sharp.IconButton btnTenantDetails;
        private FontAwesome.Sharp.IconButton btnTenantInfoAdd;
        private FontAwesome.Sharp.IconButton btnOwnerManage;
        private FontAwesome.Sharp.IconButton btnApartmentAdd;
        private FontAwesome.Sharp.IconButton iconButton5;
        private FontAwesome.Sharp.IconButton btnBalanceHistory;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelMenu;
        private FontAwesome.Sharp.IconButton btnDatabase;
    }
}