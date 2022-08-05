using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Racssoft_Dokan.Pages
{
    public partial class MainParent1 : MaterialSkin.Controls.MaterialForm
    {
        public MainParent1()
        {
            InitializeComponent();
           // var materialSkinManager = MaterialSkinManager.Instance;
            MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.LightBlue400, MaterialSkin.Primary.BlueGrey900, MaterialSkin.Primary.Blue500, Accent.Orange700, MaterialSkin.TextShade.WHITE);
            //materialTextBox1.BackColor = Color.Transparent;
            // materialSkinManager.AddFormToManage(this);
            //materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            //materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey900, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void materialTabControlParent_SelectedIndexChanged(object sender, EventArgs e)
        {


            //ShowForm(new Products(), panelInventory);
            if (materialTabControlParent.SelectedIndex == 0)
            {
                ShowForm(new BalanceSheet(), panelDashboard);
               
            }

            else if (materialTabControlParent.SelectedIndex == 1)
            {
                ShowForm(new Products(), panelInventory);
            }

            else if (materialTabControlParent.SelectedIndex == 2)
            {
                ShowForm(new Inventory(), panelInventoryDetails);
            }
            else if (materialTabControlParent.SelectedIndex == 3)
            {
                ShowForm(new Sale(), panelSales);
            }
            else if (materialTabControlParent.SelectedIndex == 4)
            {
                ShowForm(new SalesDetails(), panelSalesDetails);
            }
            else if (materialTabControlParent.SelectedIndex == 5)
            {
                ShowForm(new Expenses(), panelExpense);
            }
            else if (materialTabControlParent.SelectedIndex == 6)
            {
                ShowForm(new AccountInfo(), panelWallet);
            }
        }

        private void ShowForm(object materialForm, Panel panel)
        {
            //MaterialForm n = new MaterialForm();
            //MaterialForm p = new MaterialForm();
            panel.Controls.Clear();
            MaterialForm p = materialForm as MaterialForm;
            p.TopLevel = false;
            //no border if needed
            p.FormBorderStyle = FormBorderStyle.None;
            p.AutoScaleMode = AutoScaleMode.Dpi;
            //  Form frm = form as Form;
            //Dashboard.Controls.Add(new Products());
            panel.Controls.Add(p);
            p.Dock = DockStyle.Fill;
            p.Show();
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {

        }

        private void SalesDetails_Click(object sender, EventArgs e)
        {

        }

        private void panelInventoryDetails_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialTabControlParent_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void materialTabControlParent_Selecting(object sender, TabControlCancelEventArgs e)
        {

        }
    }
}
