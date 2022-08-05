using Model;
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
    public partial class SerialKeyValidation : Form
    {
        public SerialKeyValidation()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Common com = new Common();
            Dictionary<string, string> onlineKeys = new Dictionary<string, string>();

            onlineKeys.Add("UXVQUSI002I4566015", "123456");
            onlineKeys.Add("UXVQUSI002I4566007", "159874");
            onlineKeys.Add("UXVQVSI816J3869719", "654321");
            onlineKeys.Add("UXVQUSI002I4566026", "554321");


            Dictionary<string, string> usersKey = new Dictionary<string, string>();

            usersKey.Add(txtSerial.Text.Trim(), txtKey.Text.Trim());
            if (DictEquals(onlineKeys, usersKey))
            {
                string sql = "Update Settings set KeyValue = '" + txtKey.Text.Trim() + "', IsVerified = '1' WHERE KeyCode = '" + txtSerial.Text.Trim() + "'";
                com.CUD(sql);
                this.Close();
                return;
            }
            
            MessageBox.Show("You are not authorized!!!");
        }

        static bool DictEquals(Dictionary<string, string> d1, Dictionary<string, string> d2)
        {
            return d1.Keys.Any(k => d2.ContainsKey(k) && stringEquals(d1[k], d2[k]));
        }
        static bool stringEquals(string s1, string s2)
        {
            if (String.Compare(s1, s2) == 0)
                return true;

            return false;
        }
    }
}
