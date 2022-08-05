
namespace Racssoft_Dokan.Pages
{
    partial class MainParent1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainParent1));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.materialTabControlParent = new MaterialSkin.Controls.MaterialTabControl();
            this.Dashboard = new System.Windows.Forms.TabPage();
            this.panelDashboard = new System.Windows.Forms.Panel();
            this.Inventory = new System.Windows.Forms.TabPage();
            this.panelInventory = new System.Windows.Forms.Panel();
            this.inventoryDetails = new System.Windows.Forms.TabPage();
            this.panelInventoryDetails = new System.Windows.Forms.Panel();
            this.Sales = new System.Windows.Forms.TabPage();
            this.panelSales = new System.Windows.Forms.Panel();
            this.SalesDetails = new System.Windows.Forms.TabPage();
            this.panelSalesDetails = new System.Windows.Forms.Panel();
            this.Expense = new System.Windows.Forms.TabPage();
            this.panelExpense = new System.Windows.Forms.Panel();
            this.Wallet = new System.Windows.Forms.TabPage();
            this.panelWallet = new System.Windows.Forms.Panel();
            this.Notifications = new System.Windows.Forms.TabPage();
            this.Goal = new System.Windows.Forms.TabPage();
            this.materialTabControlParent.SuspendLayout();
            this.Dashboard.SuspendLayout();
            this.Inventory.SuspendLayout();
            this.inventoryDetails.SuspendLayout();
            this.Sales.SuspendLayout();
            this.SalesDetails.SuspendLayout();
            this.Expense.SuspendLayout();
            this.Wallet.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-borrow-book-32.png");
            this.imageList1.Images.SetKeyName(1, "icons8-marketing-32.png");
            this.imageList1.Images.SetKeyName(2, "icons8-mail-24.png");
            this.imageList1.Images.SetKeyName(3, "icons8-notification-24.png");
            this.imageList1.Images.SetKeyName(4, "icons8-typing-24.png");
            this.imageList1.Images.SetKeyName(5, "icons8-table-32.png");
            this.imageList1.Images.SetKeyName(6, "icons8-goal-24.png");
            this.imageList1.Images.SetKeyName(7, "icons8-line-chart-48.png");
            this.imageList1.Images.SetKeyName(8, "icons8-us-dollar-26.png");
            this.imageList1.Images.SetKeyName(9, "icons8-home-page-24.png");
            // 
            // materialTabControlParent
            // 
            this.materialTabControlParent.Controls.Add(this.Dashboard);
            this.materialTabControlParent.Controls.Add(this.Inventory);
            this.materialTabControlParent.Controls.Add(this.inventoryDetails);
            this.materialTabControlParent.Controls.Add(this.Sales);
            this.materialTabControlParent.Controls.Add(this.SalesDetails);
            this.materialTabControlParent.Controls.Add(this.Expense);
            this.materialTabControlParent.Controls.Add(this.Wallet);
            this.materialTabControlParent.Controls.Add(this.Notifications);
            this.materialTabControlParent.Controls.Add(this.Goal);
            this.materialTabControlParent.Depth = 0;
            this.materialTabControlParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialTabControlParent.ImageList = this.imageList1;
            this.materialTabControlParent.Location = new System.Drawing.Point(0, 64);
            this.materialTabControlParent.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControlParent.Multiline = true;
            this.materialTabControlParent.Name = "materialTabControlParent";
            this.materialTabControlParent.SelectedIndex = 0;
            this.materialTabControlParent.Size = new System.Drawing.Size(913, 572);
            this.materialTabControlParent.TabIndex = 0;
            this.materialTabControlParent.SelectedIndexChanged += new System.EventHandler(this.materialTabControlParent_SelectedIndexChanged);
            this.materialTabControlParent.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.materialTabControlParent_Selecting);
            this.materialTabControlParent.TabIndexChanged += new System.EventHandler(this.materialTabControlParent_TabIndexChanged);
            // 
            // Dashboard
            // 
            this.Dashboard.BackColor = System.Drawing.Color.White;
            this.Dashboard.Controls.Add(this.panelDashboard);
            this.Dashboard.ImageKey = "icons8-home-page-24.png";
            this.Dashboard.Location = new System.Drawing.Point(4, 39);
            this.Dashboard.Name = "Dashboard";
            this.Dashboard.Padding = new System.Windows.Forms.Padding(3);
            this.Dashboard.Size = new System.Drawing.Size(905, 529);
            this.Dashboard.TabIndex = 0;
            this.Dashboard.Text = "Dashboard";
            // 
            // panelDashboard
            // 
            this.panelDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDashboard.Location = new System.Drawing.Point(3, 3);
            this.panelDashboard.Name = "panelDashboard";
            this.panelDashboard.Size = new System.Drawing.Size(899, 523);
            this.panelDashboard.TabIndex = 1;
            // 
            // Inventory
            // 
            this.Inventory.Controls.Add(this.panelInventory);
            this.Inventory.ImageKey = "icons8-table-32.png";
            this.Inventory.Location = new System.Drawing.Point(4, 39);
            this.Inventory.Name = "Inventory";
            this.Inventory.Padding = new System.Windows.Forms.Padding(3);
            this.Inventory.Size = new System.Drawing.Size(889, 490);
            this.Inventory.TabIndex = 1;
            this.Inventory.Text = "Inventory";
            this.Inventory.UseVisualStyleBackColor = true;
            // 
            // panelInventory
            // 
            this.panelInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInventory.Location = new System.Drawing.Point(3, 3);
            this.panelInventory.Name = "panelInventory";
            this.panelInventory.Size = new System.Drawing.Size(883, 484);
            this.panelInventory.TabIndex = 1;
            // 
            // inventoryDetails
            // 
            this.inventoryDetails.Controls.Add(this.panelInventoryDetails);
            this.inventoryDetails.Location = new System.Drawing.Point(4, 39);
            this.inventoryDetails.Name = "inventoryDetails";
            this.inventoryDetails.Size = new System.Drawing.Size(889, 490);
            this.inventoryDetails.TabIndex = 8;
            this.inventoryDetails.Text = "Inventory Details";
            this.inventoryDetails.UseVisualStyleBackColor = true;
            // 
            // panelInventoryDetails
            // 
            this.panelInventoryDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInventoryDetails.Location = new System.Drawing.Point(0, 0);
            this.panelInventoryDetails.Name = "panelInventoryDetails";
            this.panelInventoryDetails.Size = new System.Drawing.Size(889, 490);
            this.panelInventoryDetails.TabIndex = 0;
            // 
            // Sales
            // 
            this.Sales.Controls.Add(this.panelSales);
            this.Sales.ImageKey = "icons8-marketing-32.png";
            this.Sales.Location = new System.Drawing.Point(4, 39);
            this.Sales.Name = "Sales";
            this.Sales.Size = new System.Drawing.Size(889, 490);
            this.Sales.TabIndex = 2;
            this.Sales.Text = "Sales";
            this.Sales.UseVisualStyleBackColor = true;
            // 
            // panelSales
            // 
            this.panelSales.AutoScroll = true;
            this.panelSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSales.Location = new System.Drawing.Point(0, 0);
            this.panelSales.Name = "panelSales";
            this.panelSales.Size = new System.Drawing.Size(889, 490);
            this.panelSales.TabIndex = 0;
            // 
            // SalesDetails
            // 
            this.SalesDetails.Controls.Add(this.panelSalesDetails);
            this.SalesDetails.ImageKey = "icons8-line-chart-48.png";
            this.SalesDetails.Location = new System.Drawing.Point(4, 39);
            this.SalesDetails.Name = "SalesDetails";
            this.SalesDetails.Size = new System.Drawing.Size(889, 490);
            this.SalesDetails.TabIndex = 3;
            this.SalesDetails.Text = "Sales Details";
            this.SalesDetails.UseVisualStyleBackColor = true;
            this.SalesDetails.Click += new System.EventHandler(this.SalesDetails_Click);
            // 
            // panelSalesDetails
            // 
            this.panelSalesDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSalesDetails.Location = new System.Drawing.Point(0, 0);
            this.panelSalesDetails.Name = "panelSalesDetails";
            this.panelSalesDetails.Size = new System.Drawing.Size(889, 490);
            this.panelSalesDetails.TabIndex = 1;
            // 
            // Expense
            // 
            this.Expense.Controls.Add(this.panelExpense);
            this.Expense.ImageKey = "icons8-mail-24.png";
            this.Expense.Location = new System.Drawing.Point(4, 39);
            this.Expense.Name = "Expense";
            this.Expense.Size = new System.Drawing.Size(889, 490);
            this.Expense.TabIndex = 5;
            this.Expense.Text = "Expense";
            this.Expense.UseVisualStyleBackColor = true;
            // 
            // panelExpense
            // 
            this.panelExpense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelExpense.Location = new System.Drawing.Point(0, 0);
            this.panelExpense.Name = "panelExpense";
            this.panelExpense.Size = new System.Drawing.Size(889, 490);
            this.panelExpense.TabIndex = 1;
            // 
            // Wallet
            // 
            this.Wallet.Controls.Add(this.panelWallet);
            this.Wallet.ImageKey = "icons8-us-dollar-26.png";
            this.Wallet.Location = new System.Drawing.Point(4, 39);
            this.Wallet.Name = "Wallet";
            this.Wallet.Size = new System.Drawing.Size(889, 490);
            this.Wallet.TabIndex = 4;
            this.Wallet.Text = "Wallet";
            this.Wallet.UseVisualStyleBackColor = true;
            // 
            // panelWallet
            // 
            this.panelWallet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWallet.Location = new System.Drawing.Point(0, 0);
            this.panelWallet.Name = "panelWallet";
            this.panelWallet.Size = new System.Drawing.Size(889, 490);
            this.panelWallet.TabIndex = 1;
            // 
            // Notifications
            // 
            this.Notifications.ImageKey = "icons8-notification-24.png";
            this.Notifications.Location = new System.Drawing.Point(4, 39);
            this.Notifications.Name = "Notifications";
            this.Notifications.Size = new System.Drawing.Size(889, 490);
            this.Notifications.TabIndex = 6;
            this.Notifications.Text = "Notifications";
            this.Notifications.UseVisualStyleBackColor = true;
            // 
            // Goal
            // 
            this.Goal.ImageKey = "icons8-goal-24.png";
            this.Goal.Location = new System.Drawing.Point(4, 39);
            this.Goal.Name = "Goal";
            this.Goal.Size = new System.Drawing.Size(889, 490);
            this.Goal.TabIndex = 7;
            this.Goal.Text = "Goal";
            this.Goal.UseVisualStyleBackColor = true;
            // 
            // MainParent1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(916, 639);
            this.Controls.Add(this.materialTabControlParent);
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.materialTabControlParent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "MainParent1";
            this.Padding = new System.Windows.Forms.Padding(0, 64, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cash Racs";
            this.materialTabControlParent.ResumeLayout(false);
            this.Dashboard.ResumeLayout(false);
            this.Inventory.ResumeLayout(false);
            this.inventoryDetails.ResumeLayout(false);
            this.Sales.ResumeLayout(false);
            this.SalesDetails.ResumeLayout(false);
            this.Expense.ResumeLayout(false);
            this.Wallet.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private MaterialSkin.Controls.MaterialTabControl materialTabControlParent;
        private System.Windows.Forms.TabPage Dashboard;
        private System.Windows.Forms.TabPage Inventory;
        private System.Windows.Forms.TabPage Sales;
        private System.Windows.Forms.TabPage SalesDetails;
        private System.Windows.Forms.TabPage Wallet;
        private System.Windows.Forms.TabPage Expense;
        private System.Windows.Forms.TabPage Notifications;
        private System.Windows.Forms.TabPage Goal;
        private System.Windows.Forms.Panel panelSales;
        private System.Windows.Forms.TabPage inventoryDetails;
        private System.Windows.Forms.Panel panelDashboard;
        private System.Windows.Forms.Panel panelInventory;
        private System.Windows.Forms.Panel panelSalesDetails;
        private System.Windows.Forms.Panel panelExpense;
        private System.Windows.Forms.Panel panelWallet;
        private System.Windows.Forms.Panel panelInventoryDetails;
    }
}