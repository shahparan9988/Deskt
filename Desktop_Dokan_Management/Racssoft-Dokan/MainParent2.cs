using Model;
using System;
using Racssoft_Dokan.Pages;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace Racssoft_Dokan
{
    public partial class MainParent2 : Common
    {
        public string UserFullName { get; set; }
        public string ComputerSerialKey { get; }
        BalanceSheetGrid balanceSheetGrid;


        //Field Size
        private int borderSize = 3;
        private Size formSize;

        //Constructor
        public MainParent2()
        {
            InitializeComponent();
            //CollapseMenu();
            this.Padding = new Padding(borderSize);//Border size
            this.BackColor = Color.FromArgb(64, 86, 141);//Border color
            Initial();
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

            else if (dt.Rows.Count < 1)
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
                                        "" + balanceSheetGrid.CurrentBalance + ", " + balanceSheetGrid.TotalCredit + "," +
                                        "" + balanceSheetGrid.CreditLiability + ", " + balanceSheetGrid.TotalDebit + "," +
                                        "" + balanceSheetGrid.DebitLiability + ", '" + DateTime.Now + "')";
                    CUD(inputSql);

                }

                else
                {
                    MessageBox.Show("Please, Deposit your money/cash in account info window!!! Without Setting up your Account, please do not perform any transaction. Otherwise, your data will be lost or mismatched!!!");
                    ShowForm(new AccountInfo());
                }


            }

        }
        bool isLvProfileVisible = false;

        //private void lblWelcomeUser_Click(object sender, EventArgs e)
        //{
        //    lvProfile.Visible = !isLvProfileVisible;
        //    isLvProfileVisible = !isLvProfileVisible;

        //    this.panel3.Controls.Add(lvProfile);
        //    lvProfile.BringToFront();

        //}

        private void ShowForm(object form)
        {
            this.panelMain.Controls.Clear();
            Form frm = form as Form;
            frm.Dock = DockStyle.Fill;
            frm.TopLevel = false;
            frm.TopMost = false;
            frm.SendToBack();
            this.panelMain.Controls.Add(frm);
            this.panelMain.Tag = frm;
            frm.Show();
        }

        //private void Parent_Load(object sender, EventArgs e)
        //{
        //    lblWelcomeUser.Visible = false;
        //    frmLogin login = new frmLogin(this);
        //    login.ShowDialog();

        //    lblWelcomeUser.Text = "Welcome " + UserFullName + " !";
        //    lblWelcomeUser.Visible = true;

        //    ShowForm(new Dashboard());
        //    Initial();
        //}

        //private void lvProfile_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (lvProfile.SelectedItems.Count > 0)
        //    {
        //        var item = lvProfile.SelectedItems[0].Text;
        //        if (item == "Logout")
        //        {
        //            Environment.Exit(0);
        //        }
        //    }

        //}

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }



        //Overridden methods
        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0x0083;//Standar Title Bar - Snap Window
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MINIMIZE = 0xF020; //Minimize form (Before)
            const int SC_RESTORE = 0x09; //Restore form (Before)
            const int WM_NCHITTEST = 0x0084;//Win32, Mouse Input Notification: Determine what part of the window corresponds to a point, allows to resize the form.
            const int resizeAreaSize = 10;
            #region Form Resize
            // Resize/WM_NCHITTEST values
            const int HTCLIENT = 1; //Represents the client area of the window
            const int HTLEFT = 10;  //Left border of a window, allows resize horizontally to the left
            const int HTRIGHT = 11; //Right border of a window, allows resize horizontally to the right
            const int HTTOP = 12;   //Upper-horizontal border of a window, allows resize vertically up
            const int HTTOPLEFT = 13;//Upper-left corner of a window border, allows resize diagonally to the left
            const int HTTOPRIGHT = 14;//Upper-right corner of a window border, allows resize diagonally to the right
            const int HTBOTTOM = 15; //Lower-horizontal border of a window, allows resize vertically down
            const int HTBOTTOMLEFT = 16;//Lower-left corner of a window border, allows resize diagonally to the left
            const int HTBOTTOMRIGHT = 17;//Lower-right corner of a window border, allows resize diagonally to the right
            ///<Doc> More Information: https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nchittest </Doc>
            if (m.Msg == WM_NCHITTEST)
            { //If the windows m is WM_NCHITTEST
                base.WndProc(ref m);
                if (this.WindowState == FormWindowState.Normal)//Resize the form if it is in normal state
                {
                    if ((int)m.Result == HTCLIENT)//If the result of the m (mouse pointer) is in the client area of the window
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32()); //Gets screen point coordinates(X and Y coordinate of the pointer)                           
                        Point clientPoint = this.PointToClient(screenPoint); //Computes the location of the screen point into client coordinates                          
                        if (clientPoint.Y <= resizeAreaSize)//If the pointer is at the top of the form (within the resize area- X coordinate)
                        {
                            if (clientPoint.X <= resizeAreaSize) //If the pointer is at the coordinate X=0 or less than the resizing area(X=10) in 
                                m.Result = (IntPtr)HTTOPLEFT; //Resize diagonally to the left
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize))//If the pointer is at the coordinate X=11 or less than the width of the form(X=Form.Width-resizeArea)
                                m.Result = (IntPtr)HTTOP; //Resize vertically up
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTTOPRIGHT;
                        }
                        else if (clientPoint.Y <= (this.Size.Height - resizeAreaSize)) //If the pointer is inside the form at the Y coordinate(discounting the resize area size)
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize horizontally to the left
                                m.Result = (IntPtr)HTLEFT;
                            else if (clientPoint.X > (this.Width - resizeAreaSize))//Resize horizontally to the right
                                m.Result = (IntPtr)HTRIGHT;
                        }
                        else
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize diagonally to the left
                                m.Result = (IntPtr)HTBOTTOMLEFT;
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize)) //Resize vertically down
                                m.Result = (IntPtr)HTBOTTOM;
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTBOTTOMRIGHT;
                        }
                    }
                }
                return;
            }
            #endregion
            //Remove border and keep snap window
            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }
            //Keep form size when it is minimized and restored. Since the form is resized because it takes into account the size of the title bar and borders.
            if (m.Msg == WM_SYSCOMMAND)
            {
                /// <see cref="https://docs.microsoft.com/en-us/windows/win32/menurc/wm-syscommand"/>
                /// Quote:
                /// In WM_SYSCOMMAND messages, the four low - order bits of the wParam parameter 
                /// are used internally by the system.To obtain the correct result when testing 
                /// the value of wParam, an application must combine the value 0xFFF0 with the 
                /// wParam value by using the bitwise AND operator.
                int wParam = (m.WParam.ToInt32() & 0xFFF0);
                if (wParam == SC_MINIMIZE)  //Before
                    formSize = this.ClientSize;
                if (wParam == SC_RESTORE)// Restored form(Before)
                    this.Size = formSize;
            }
            base.WndProc(ref m);
        }

        private void MainParent_Resize(object sender, EventArgs e)
        {
            AdjustForm();
        }

        //Private methods
        private void AdjustForm()
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized: //Maximized form (After)
                    this.Padding = new Padding(8, 8, 8, 0);
                    break;
                case FormWindowState.Normal: //Restored form (After)
                    if (this.Padding.Top != borderSize)
                        this.Padding = new Padding(borderSize);
                    break;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                formSize = this.ClientSize;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.Size = formSize;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            CollapseMenu();
        }

        private void CollapseMenu()
        {
            if (this.panelMenu.Width > 194) //Collapse menu
            {
                panelMenu.Width = 50;
                //pictureBox1.Visible = false;
                panel2.Visible = false;
                btnMenu.Dock = DockStyle.Top;
                foreach (Button menuButton in panelMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "";
                   // menuButton.ImageAlign = ContentAlignment.MiddleCenter;
                    menuButton.Padding = new Padding(0);
                }
            }
            else
            { //Expand menu
                panelMenu.Width = 195;
                panel2.Visible = true;
                pictureBox1.Visible = true;
                btnMenu.Dock = DockStyle.None;
                foreach (Button menuButton in panelMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "   " + menuButton.Tag.ToString();
                    menuButton.ImageAlign = ContentAlignment.MiddleLeft;
                    menuButton.Padding = new Padding(10, 0, 0, 0);
                }
            }
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            ShowForm(new BalanceSheet1());
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            ShowForm(new Products());
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            ShowForm(new Inventory());
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            ShowForm(new Sale());
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            ShowForm(new SalesDetails());
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            ShowForm(new SuppliersRecord());
        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            ShowForm(new AccountInfo());
        }

        private void MainParent_Load(object sender, EventArgs e)
        {
            //frmLogin login = new frmLogin(this);
            //login.ShowDialog();
            ShowForm(new BalanceSheet1());
            Initial();
        }

        private void iconButtonExpenses_Click(object sender, EventArgs e)
        {
            ShowForm(new Expenses());
        }

        private void iconButtonLogHistory_Click(object sender, EventArgs e)
        {
            ShowForm(new History());
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void iconButtonSetting_Click(object sender, EventArgs e)
        {
            ShowForm(new Settings());
        }

        private void iconButtonVatManage_Click(object sender, EventArgs e)
        {
            ShowForm(new VatManage());
        }
    }
}
