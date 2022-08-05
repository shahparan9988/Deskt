using Model;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Racssoft_Dokan
{
    public partial class frmLogin : Common
    {
        private MainParent2 _frmParent;
        private MainParent mainparent;
        public frmLogin(MainParent2 parent)
        {
            InitializeComponent();
            _frmParent = parent;
        }

        public frmLogin(MainParent parent)
        {
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string sql = @"SELECT * FROM Users WHERE Email = '" + txtUserIdentity.Text.Trim() + "' OR" +
                " PhoneNumber = '" + txtUserIdentity.Text.Trim() + "' AND Password = '" + txtPassword.Text.Trim() + "'";
            //cmd = new OleDbCommand(sql, con);

            Result result = Select(sql);
            if(result != null && result.Data != null)
            {
                DataTable dt = (DataTable)result.Data;
                foreach (DataRow row in dt.Rows)
                {
                    object fullName = row["FullName"];
                    object email = row["Email"];
                    object phoneNumber = row["PhoneNumber"];
                    object Id = row["Id"];

                    if (_frmParent != null)
                    {
                        _frmParent.UserFullName = fullName.ToString();
                    }
                    Program.SessionID = Id.ToString();
                    //((Parent)this.MdiParent).UserFullName = fullName.ToString();
                }
                
                this.Close();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
