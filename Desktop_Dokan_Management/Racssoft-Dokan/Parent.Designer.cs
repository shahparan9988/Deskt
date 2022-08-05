
namespace Racssoft_Dokan
{
	partial class Parent
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Dashboard");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Entry");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Inventory");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Product", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Sale");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Sale Details");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Balance Sheet");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Expense");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Wallet");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Settings");
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Your Profile");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Logout");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Parent));
            this.panel1 = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.picNotification = new System.Windows.Forms.PictureBox();
            this.lblWelcomeUser = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.treeViewMenu = new System.Windows.Forms.TreeView();
            this.timerWindowAnimation = new System.Windows.Forms.Timer(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.lvProfile = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNotification)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.picLogo);
            this.panel1.Controls.Add(this.picNotification);
            this.panel1.Controls.Add(this.lblWelcomeUser);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 57);
            this.panel1.TabIndex = 0;
            // 
            // picLogo
            // 
            this.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.picLogo.Location = new System.Drawing.Point(0, 0);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(255, 53);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 16;
            this.picLogo.TabStop = false;
            // 
            // picNotification
            // 
            this.picNotification.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.picNotification.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picNotification.Location = new System.Drawing.Point(798, 10);
            this.picNotification.Name = "picNotification";
            this.picNotification.Size = new System.Drawing.Size(39, 35);
            this.picNotification.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picNotification.TabIndex = 16;
            this.picNotification.TabStop = false;
            // 
            // lblWelcomeUser
            // 
            this.lblWelcomeUser.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblWelcomeUser.AutoSize = true;
            this.lblWelcomeUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblWelcomeUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblWelcomeUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcomeUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblWelcomeUser.Location = new System.Drawing.Point(843, 16);
            this.lblWelcomeUser.Name = "lblWelcomeUser";
            this.lblWelcomeUser.Size = new System.Drawing.Size(47, 20);
            this.lblWelcomeUser.TabIndex = 15;
            this.lblWelcomeUser.Text = "User";
            this.lblWelcomeUser.Click += new System.EventHandler(this.lblWelcomeUser_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.treeViewMenu);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 57);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panel2.Size = new System.Drawing.Size(200, 393);
            this.panel2.TabIndex = 4;
            // 
            // treeViewMenu
            // 
            this.treeViewMenu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeViewMenu.Location = new System.Drawing.Point(0, 10);
            this.treeViewMenu.Name = "treeViewMenu";
            treeNode1.Checked = true;
            treeNode1.Name = "nDashboard";
            treeNode1.Text = "Dashboard";
            treeNode2.Name = "nEntry";
            treeNode2.Text = "Entry";
            treeNode3.Name = "nInventory";
            treeNode3.Text = "Inventory";
            treeNode4.Name = "nProduct";
            treeNode4.Text = "Product";
            treeNode5.Name = "nSale";
            treeNode5.Text = "Sale";
            treeNode6.Name = "nSalesDetails";
            treeNode6.Text = "Sale Details";
            treeNode7.Name = "nBalanceSheet";
            treeNode7.Text = "Balance Sheet";
            treeNode8.Name = "nExpense";
            treeNode8.Text = "Expense";
            treeNode9.Name = "nWallet";
            treeNode9.Text = "Wallet";
            treeNode10.Name = "nSetting";
            treeNode10.Text = "Settings";
            this.treeViewMenu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10});
            this.treeViewMenu.Size = new System.Drawing.Size(200, 383);
            this.treeViewMenu.TabIndex = 5;
            this.treeViewMenu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewMenu_AfterSelect);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lvProfile);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(200, 57);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 393);
            this.panel3.TabIndex = 5;
            // 
            // lvProfile
            // 
            this.lvProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lvProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lvProfile.HideSelection = false;
            this.lvProfile.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.lvProfile.Location = new System.Drawing.Point(695, 0);
            this.lvProfile.Name = "lvProfile";
            this.lvProfile.Size = new System.Drawing.Size(93, 45);
            this.lvProfile.TabIndex = 17;
            this.lvProfile.UseCompatibleStateImageBehavior = false;
            this.lvProfile.View = System.Windows.Forms.View.SmallIcon;
            this.lvProfile.Visible = false;
            this.lvProfile.SelectedIndexChanged += new System.EventHandler(this.lvProfile_SelectedIndexChanged);
            // 
            // Parent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Parent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Parent";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Parent_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNotification)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TreeView treeViewMenu;
		private System.Windows.Forms.PictureBox picNotification;
		private System.Windows.Forms.Label lblWelcomeUser;
		private System.Windows.Forms.PictureBox picLogo;
		private System.Windows.Forms.Timer timerWindowAnimation;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.ListView lvProfile;
	}
}