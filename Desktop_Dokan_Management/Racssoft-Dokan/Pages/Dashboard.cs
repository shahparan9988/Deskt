using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Models;

namespace Racssoft_Dokan.Pages
{
    public partial class Dashboard : Common
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        public string radioButtonSelector()
        {
            if (Male.Checked == true)
            {
                return "Male";
            }
            else if (Female.Checked == true)
            {
                return "Female";
            }
            else return "Others";
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            //Environment.Exit(5000);
            //string sql = "Insert into Suppliers(SName) values('shah')";
            //CUD(sql);
            string name = nameBox.Text.Trim();
            string phoneNo = phoneNoBox.Text.Trim();
            string city = cityBox.Text.Trim();
            string address = addressBox.Text.Trim();
            decimal age = Convert.ToDecimal(ageBox.Text.Trim());
            //string createdDate = Convert.ToString(createdDateBox.Text);
            //DateTime dT = DateTime.Parse(createdDate);
            DateTime dT = DateTime.Parse(createdDateBox.Text);
            bool isDeleted = Convert.ToBoolean(isDeletedBox.Checked);

            string gender = radioButtonSelector();
            string sql = "SELECT * From Suppliers WHERE SName = '"+name+"'";
            address = city + ", " +address;
            //Result result = Select(sql);
            DataTable dt = (DataTable)Select(sql).Data;

            if (dt.Rows.Count == 0)
            {
                //string city = "Dhaka";
                //string address = "House-5, Road-2, Sector-12";
                
                string sql1 = "Insert into Suppliers(Age, Address, SName, Phone, CreatedDate, IsDeleted, Gender) values('" + age + "', '" + address + "', '" + name + "','" + phoneNo + "','"+ dT + "', " + isDeleted + ",'" +gender+ "')";
                CUD(sql1);
            }
            else MessageBox.Show("The user name is already exist");


        }

  

        private void Dashboard_Load(object sender, EventArgs e)
        {
            /*
             string sql = "Insert into Suppliers(SName) values('shah')";
             CUD(sql);
             sql = "SELECT * From Suppliers WHERE name = 'Abdus Salam'";

             //Result result = Select(sql);
             DataTable dt = (DataTable)Select(sql).Data;

             if (dt != null && dt.Rows.Count == 0)
             {
                 string sql1 = "Insert into Suppliers(SName) values('Abdus Salam')";
                 CUD(sql1);
             }
             else MessageBox.Show("The user name is already exist"); 
            */

            saleChart.Series["sale"].Points.AddXY("Sh", 1000);
            saleChart.Series["sale"].Points[0].Color = Color.Red;
            saleChart.Series["sale"].Points.AddXY("Hb", 2000);
            saleChart.Series["sale"].Points[1].Color = Color.YellowGreen;
            saleChart.Series["sale"].Points.AddXY("Shaikot", 2000);
            saleChart.Series["sale"].Points[2].Color = Color.BurlyWood;
            saleChart.Series["sale"].Points.AddXY("Salam", 5000);
            saleChart.Series["sale"].Points[3].Color = Color.RoyalBlue;




        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pieChart_Click(object sender, EventArgs e)
        {

        }

        private void Male_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
