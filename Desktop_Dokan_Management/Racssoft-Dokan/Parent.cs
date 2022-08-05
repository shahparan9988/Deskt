using Model;
using Models;
using Racssoft_Dokan.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Racssoft_Dokan
{
	public partial class Parent : Common
	{
		public string UserFullName { get; set; }
		public string ComputerSerialKey { get; }
		BalanceSheetGrid balanceSheetGrid;
		public Parent()
		{
			InitializeComponent();
			setAllPanelPicture();
			ImageList();
			
		}


		long getMaxId(string cmd)
		{
			DataTable dt;
			//cmd = "SELECT MAX(Id) FROM Products";
			dt = (DataTable)Select(cmd).Data;
			long id = dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0][0].ToString()) ? Convert.ToInt64(dt.Rows[0][0]) : 0;
			return id;
		}

		void Initial()
        {
			long balanceSheetId = getMaxId("SELECT MAX(Id) FROM BalanceSheet");
			string sql = @"SELECT * FROM BalanceSheet WHERE ID = " + balanceSheetId + "";
			DataTable dt = (DataTable)Select(sql).Data;
			balanceSheetGrid = new BalanceSheetGrid();
			if (dt.Rows.Count == 1)
			{
				balanceSheetGrid.ID = Convert.ToInt64(dt.Rows[0]["ID"]);
				balanceSheetGrid.OpeningBalance = Convert.ToDouble(dt.Rows[0]["OpeningBalance"]);
				balanceSheetGrid.CurrentBalance = Convert.ToDouble(dt.Rows[0]["CurrentBalance"]);
				balanceSheetGrid.UpdatedDate = Convert.ToDateTime(dt.Rows[0]["UpdatedDate"]);
				balanceSheetGrid.TotalCredit = Convert.ToDouble(dt.Rows[0]["TotalCredit"]);
				balanceSheetGrid.CreditLiability = Convert.ToDouble(dt.Rows[0]["CreditLiability"]);
				balanceSheetGrid.TotalDebit = Convert.ToDouble(dt.Rows[0]["TotalDebit"]);
				balanceSheetGrid.DebitLiability = Convert.ToDouble(dt.Rows[0]["DebitLiability"]);

			    //string sss = DateTime.Now.Date.ToString("MM/dd/yyyy");

				if (DateTime.Now.Date.ToString("MM/dd/yyyy") != balanceSheetGrid.UpdatedDate.Date.ToString("MM/dd/yyyy"))
				{
					string sqlForInput = @"INSERT INTO BalanceSheet (OpeningBalance, CurrentBalance, TotalCredit, CreditLiability, 
					TotalDebit, DebitLiability, UpdatedDate) VALUES (" + balanceSheetGrid.CurrentBalance + ", " + balanceSheetGrid.CurrentBalance + "," +
					"" + balanceSheetGrid.TotalCredit + ", " + balanceSheetGrid.CreditLiability + ", " + balanceSheetGrid.TotalDebit + "," +
					"" + balanceSheetGrid.DebitLiability + ", '" + DateTime.Now + "')";
					CUD(sqlForInput);
				}
			}

			else if(dt.Rows.Count < 1)
            {

				string digitalWalletSql = @"SELECT * FROM DigitalWallet";
				DataTable digitalWalletDt = (DataTable)Select(digitalWalletSql).Data;
				double totalDigitalWalletBalance = 0;
				if (digitalWalletDt.Rows.Count > 0)
				{
					for (int i = 0; i < digitalWalletDt.Rows.Count; i++)
					{
						totalDigitalWalletBalance = totalDigitalWalletBalance + Convert.ToDouble(digitalWalletDt.Rows[i]["Amount"]);
					}

					balanceSheetGrid.OpeningBalance = totalDigitalWalletBalance;
					balanceSheetGrid.CurrentBalance = totalDigitalWalletBalance;
					balanceSheetGrid.TotalCredit = totalDigitalWalletBalance;
					balanceSheetGrid.CreditLiability = 0;
					balanceSheetGrid.TotalDebit = 0;
					balanceSheetGrid.DebitLiability = 0;

					string inputSql = @"INSERT INTO BalanceSheet (OpeningBalance, CurrentBalance, TotalCredit, CreditLiability,
										TotalDebit, DebitLiability, UpdatedDate) VALUES (" + balanceSheetGrid.OpeningBalance + "," +
										""+ balanceSheetGrid.CurrentBalance + ", " + balanceSheetGrid.TotalCredit + "," +
										"" + balanceSheetGrid.CreditLiability + ", " + balanceSheetGrid.TotalDebit + "," +
										""+ balanceSheetGrid.DebitLiability + ", '"+ DateTime.Now +"')";
					CUD(inputSql);

				}

                else
                {
					MessageBox.Show("Please, Deposit your money/cash in account info window");
					ShowForm(new AccountInfo());
				}

				
            }

        }

		private void ImageList()
		{
			ImageList myImageList = new ImageList();
			myImageList.Images.Add(Image.FromStream(new MemoryStream(Pictures.GetPicture("Dashboard"))));//0
			myImageList.Images.Add(Image.FromStream(new MemoryStream(Pictures.GetPicture("Suppliers"))));
			myImageList.Images.Add(Image.FromStream(new MemoryStream(Pictures.GetPicture("User"))));
			myImageList.Images.Add(Image.FromStream(new MemoryStream(Pictures.GetPicture("Products"))));//3
			myImageList.Images.Add(Image.FromStream(new MemoryStream(Pictures.GetPicture("Brands"))));//4
			myImageList.Images.Add(Image.FromStream(new MemoryStream(Pictures.GetPicture("Units"))));
			myImageList.Images.Add(Image.FromStream(new MemoryStream(Pictures.GetPicture("Sales"))));
			myImageList.Images.Add(Image.FromStream(new MemoryStream(Pictures.GetPicture("Notification"))));
			myImageList.Images.Add(Image.FromStream(new MemoryStream(Pictures.GetPicture("Logout"))));//8
			myImageList.Images.Add(Image.FromStream(new MemoryStream(Pictures.GetPicture("Users"))));//9
			myImageList.Images.Add(Image.FromStream(new MemoryStream(Pictures.GetPicture("Sales"))));//10
			myImageList.Images.Add(Image.FromStream(new MemoryStream(Pictures.GetPicture("Settings"))));//11
			myImageList.Images.Add(Image.FromStream(new MemoryStream(Pictures.GetPicture("Entry"))));//12
			myImageList.Images.Add(Image.FromStream(new MemoryStream(Pictures.GetPicture("Category"))));//13
			myImageList.Images.Add(Image.FromStream(new MemoryStream(Pictures.GetPicture("Tax"))));//14
			myImageList.Images.Add(Image.FromStream(new MemoryStream(Pictures.GetPicture("Customers"))));//15
			myImageList.Images.Add(Image.FromStream(new MemoryStream(Pictures.GetPicture("Selected"))));//16



			// Assign the ImageList to the TreeView.
			treeViewMenu.ImageList = myImageList;

			// Set the TreeView control's default image and selected image indexes.
			//treeViewMenu.ImageIndex = 0;
			treeViewMenu.SelectedImageIndex = 16;

			treeViewMenu.Nodes[0].ImageIndex = 0;
			treeViewMenu.Nodes[1].ImageIndex = 3;
			treeViewMenu.Nodes[1].Nodes[0].ImageIndex = 12;
			treeViewMenu.Nodes[1].Nodes[1].ImageIndex = 10;
			//treeViewMenu.Nodes[1].Nodes[2].ImageIndex = 4;
			//treeViewMenu.Nodes[1].Nodes[3].ImageIndex = 13;
			//treeViewMenu.Nodes[1].Nodes[4].ImageIndex = 14;
			//treeViewMenu.Nodes[1].Nodes[5].ImageIndex = 5;
			treeViewMenu.Nodes[2].ImageIndex = 9;
			treeViewMenu.Nodes[3].ImageIndex = 9;
			//treeViewMenu.Nodes[3].Nodes[0].ImageIndex = 15;
			//treeViewMenu.Nodes[4].Nodes[1].ImageIndex = 1;
			//treeViewMenu.Nodes[4].Nodes[2].ImageIndex = 9;
			treeViewMenu.Nodes[4].ImageIndex = 11;
			treeViewMenu.Nodes[5].ImageIndex = 11;
			treeViewMenu.Nodes[6].ImageIndex = 11;
			treeViewMenu.Nodes[7].ImageIndex = 11;
			//treeViewMenu.SelectedNode.ImageIndex = 0;
			//treeViewMenu.SelectedNode.SelectedImageIndex = 1;


			// setup listview
			lvProfile.StateImageList = myImageList;
			// set up initial image index
			lvProfile.Items[0].StateImageIndex = 2;
			lvProfile.Items[1].StateImageIndex = 8;

			picLogo.Image = Image.FromStream(new MemoryStream(Pictures.GetPicture("RacsLogo")));
			//this.Icon = Image.FromStream(new MemoryStream(Pictures.GetPicture("RacsIco")));

		}
		private void setAllPanelPicture()
		{
			picNotification.Image = Image.FromStream(new MemoryStream(Pictures.GetPicture("Notification")));
		}
		private void btnClose_Click(object sender, EventArgs e)
		{
			
		}
		void BuyFullVersion()
		{
			MessageBox.Show("Please Buy Full Version" + Environment.NewLine + "Contact Number: +880 9666 770 780");
		}
		bool isLvProfileVisible = false;
        private void lblWelcomeUser_Click(object sender, EventArgs e)
        {
            lvProfile.Visible = !isLvProfileVisible;
            isLvProfileVisible = !isLvProfileVisible;

            this.panel3.Controls.Add(lvProfile);
            lvProfile.BringToFront();

        }
        private void ShowForm(object form)
		{
			this.panel3.Controls.Clear();
			Form frm = form as Form;
			frm.Dock = DockStyle.Fill;
			frm.TopLevel = false;
			frm.TopMost = false;
			frm.SendToBack();
			this.panel3.Controls.Add(frm);
			this.panel3.Tag = frm;
			frm.Show();
		}
        private void Parent_Load(object sender, EventArgs e)
        {
            lblWelcomeUser.Visible = false;
            //frmLogin login = new frmLogin(this);
            //login.ShowDialog();

            lblWelcomeUser.Text = "Welcome " + UserFullName + " !";
            lblWelcomeUser.Visible = true;

            ShowForm(new Dashboard());
            Initial();
        }

        private void lvProfile_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lvProfile.SelectedItems.Count > 0)
			{
				var item = lvProfile.SelectedItems[0].Text;
				if(item == "Logout")
				{
					Environment.Exit(0);
				}
			}
			
		}
		
		private void treeViewMenu_AfterSelect(object sender, TreeViewEventArgs e)
		{
			switch (treeViewMenu.SelectedNode.Name)
			{
				case "nDashboard":
					ShowForm(new Dashboard());
					break;
				case "nEntry":
					ShowForm(new Product());
					break;
				case "nSale":
					ShowForm(new Sale());
					break;
				case "nSalesDetails":
					ShowForm(new SalesDetails());
					break;
				case "nBalanceSheet":
					ShowForm(new BalanceSheet());
					break;
				case "nInventory":
					ShowForm(new Inventory());
					break;

				case "nExpense":
					ShowForm(new Expenses());
					break;

				case "nWallet":
					ShowForm(new AccountInfo());
					break;
				case "nProduct":
					treeViewMenu.Nodes[1].Expand();// Expand the node.
					break;
				case "nUser":
					treeViewMenu.Nodes[2].Expand();// Expand the node.
					break;
				default: 
					BuyFullVersion();break;

			}

			//else if (treeView1.SelectedNode.Name == "Invoice")
			//{
			//	Print print = new Print();
			//	ShowForm(print);

			//}

		}
	}
}
