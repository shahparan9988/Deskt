using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Racssoft_Dokan.Pages;
using Models;
using Model;

namespace Racssoft_Dokan
{
    public partial class MainForm : Common
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        public MainForm()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 45);
            panelMenu.Controls.Add(leftBorderBtn);
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            
            panelTenantManage.Visible = false;
            this.MinimumSize = new Size(1525, 848);
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            OpenChildForm2(new BalanceSheet());
        }

        //Methods
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(25, 182, 241);
        }
        private void ActiveButton(object senderBtn,Color color)
        {
            DisableButton();
            currentBtn = (IconButton)senderBtn;
            currentBtn.BackColor = Color.FromArgb(37, 36, 81);
            currentBtn.ForeColor = color;
            //currentBtn.TextAlign = ContentAlignment.MiddleCenter;
            currentBtn.IconColor = color;
            //currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
            //currentBtn.ImageAlign = ContentAlignment.MiddleRight;
            leftBorderBtn.BackColor = color;
            leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
            leftBorderBtn.Visible = true;
            leftBorderBtn.BringToFront();
            //icon Current Child Form
            
        }
        private void ActiveButton2(object senderBtn, Color color)
        {
            DisableButton();
            currentBtn = (IconButton)senderBtn;
            currentBtn.BackColor = Color.FromArgb(37, 36, 81);
            currentBtn.ForeColor = color;
            //currentBtn.TextAlign = ContentAlignment.MiddleCenter;
            currentBtn.IconColor = color;
            //currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
            //currentBtn.ImageAlign = ContentAlignment.MiddleRight;
            
            //icon Current Child Form
            
        }
        private void DisableButton()
        {
            if(currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(51, 51, 76);
                currentBtn.ForeColor = Color.Gainsboro;
                //currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                //currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                //currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        private void OpenChildForm(Form childForm)
        {
            //toolStripProgressBar1.Value = 0;
            //toolStripStatusLabel2.Visible = true;
            //toolStripProgressBar1.Visible = true;
            if (currentChildForm != null)
                currentChildForm.Close();
            currentChildForm = childForm;
            //toolStripProgressBar1.Step += 15;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;


            //if (childForm.InvokeRequired)
            //{
            //    childForm.Invoke(new MethodInvoker(delegate { this.panelDesktopPane.Controls.Add(childForm); }));
            //    toolStripProgressBar1.Value = 100;
            //}
            //else
            //{
            LoadTheme(childForm);
            this.panelDesktopPane.Controls.Add(childForm);
                //toolStripProgressBar1.Value = 100;
            //}
            //await Task.Run(() => { panelDesktopPane.Controls.Add(childForm); });
            
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitleChildForm.Text = childForm.Text;
            LoadTheme(childForm);

            //toolStripStatusLabel2.Visible = false;
            //toolStripProgressBar1.Visible = false;
        }
        private void OpenChildForm2(Form childForm)
        {
            if (currentChildForm != null)
                currentChildForm.Close();
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitleChildForm.Text = childForm.Text;
            
        }
        

        private void btnCashMaintain_Click_1(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color1);
            OpenChildForm2(new BalanceSheet());
        }

        private void btnDailyExpense_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color1);
            OpenChildForm2(new Product());
        }

        private void btnCreateInvoice_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color1);
            OpenChildForm(new Sale());
        }

        private void btnCollection_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color1);
            OpenChildForm2(new SalesDetails());
        }

        private void btnDocumentUpload_Click_1(object sender, EventArgs e)
        {
            ActiveButton2(sender, RGBColors.color1);
            //OpenChildForm(new Pages.FileUpload());
        }
        private void btnApartmentManage_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color1);
            showSubMenue2(panelTenantManage);
        }

        private void btnApartmentAdd_Click(object sender, EventArgs e)
        {
            ActiveButton2(sender, RGBColors.color1);
            //OpenChildForm(new Pages.ApartmentManage());
        }

        private void btnOwnerManage_Click(object sender, EventArgs e)
        {
            ActiveButton2(sender, RGBColors.color1);
            //OpenChildForm(new Pages.Buyer());
        }

        private void btnTenantInfoAdd_Click_1(object sender, EventArgs e)
        {
            ActiveButton2(sender, RGBColors.color1);
            //OpenChildForm(new Pages.Tenant.AllTenants());
        }

        private void btnTenantDetails_Click(object sender, EventArgs e)
        {
            ActiveButton2(sender, RGBColors.color1);
            //OpenChildForm(new Pages.TenantInfo());
        }
        private void btnBalanceHistory_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color1);
            //OpenChildForm(new Pages.BalanceHistory());
        }

        private void btnDatabase_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color1);
            //OpenChildForm2(new Pages.Download());
        }

        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Reset()
        {
            DisableButton();
            lblTitleChildForm.Text = "DashBoard";
            currentBtn = null;
            leftBorderBtn.Visible = false;
            
        }
        private void icnBtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void icnBtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void icnBtnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }
        
        void hideSubMenue2()
        {
            if (panelTenantManage.Visible == true)
            {
                panelTenantManage.Visible = false;
            }
        }
        void showSubMenue2(Panel panel)
        {
            if (panel.Visible == false)
            {
                hideSubMenue2();
                panel.Visible = true;
            }
            else
            {
                panel.Visible = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null)
                currentChildForm.Close();
            Reset();
            OpenChildForm2(new BalanceSheet());
        }

        
    }
}
