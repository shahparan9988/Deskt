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
    public partial class Settings : Common
    {
        public Settings()
        {
            InitializeComponent();
            Initial();
        }

        void Initial()
        {
            string vatSql = @"SELECT ID, Title, Vat, VatTypeId FROM SetVat";
            DataTable dtVat = (DataTable)Select(vatSql).Data;
            decimal vatValue = Convert.ToDecimal(dtVat.Rows[0]["Vat"]);
            numericUpDownAmount.Value = vatValue;
            comboBoxType.Items.AddRange(getVatType().Select(s => s.Value).ToArray());
            int count = dtVat.Rows.Count;
            if (count > 0) {
                comboBoxType.SelectedIndex = Convert.ToInt32(dtVat.Rows[0]["VatTypeId"]) - 1;
                    }
        }

        Dictionary<int, string> getVatType()
        {
            string sql = "Select * FROM VatType";
            DataTable dt = (DataTable)Select(sql).Data;
            return dt.AsEnumerable()
      .ToDictionary<DataRow, int, string>(row => row.Field<int>(0),
                                row => row.Field<string>(1));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            double vatAmount = Convert.ToDouble(numericUpDownAmount.Value);
            int vatType = comboBoxType.SelectedIndex + 1;
            string sqlVat = @"UPDATE SetVat SET Vat = " + vatAmount + ", VatTypeId = " + vatType + "";
            CUD(sqlVat);
            MessageBox.Show("Updated Successfully!!!");
            comboBoxType.Items.Clear();
            Initial();
        }
    }
}
