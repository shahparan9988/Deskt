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
    public partial class InventoryDetails : Common
    {
        public static long inventoryId;
        public static double payableAmount;
        public static string sqlDetail;
        public InventoryDetails(string sql)
        {
            InitializeComponent();
            sqlDetail = sql;
            Initial(sql);
        }

        void Initial(string sql)
        {
            string sqlForDgProducts = sql;
            DataTable dt = (DataTable)Select(sqlForDgProducts).Data;
            dgProducts.Refresh();
            dgProducts.DataSource = dt;
            dgProducts.AutoGenerateColumns = false;
            dgProducts.Columns[0].Visible = false;
            dgProducts.Columns[1].Visible = false;
            dgProducts.Columns[2].Visible = false;
            dgProducts.Columns[3].Visible = false;
            dgProducts.Columns[14].Visible = false;
            dgProducts.Columns[15].Visible = false;
            dgProducts.Columns[16].Visible = false;
            dgProducts.Columns[17].Visible = false;

            if (dgProducts.Columns.Count == 19)
            {

                DataGridViewLinkColumn Return = new DataGridViewLinkColumn();
                Return.UseColumnTextForLinkValue = true;
                Return.HeaderText = "Return";
                Return.DataPropertyName = "lnkColumn";
                Return.LinkBehavior = LinkBehavior.SystemDefault;
                Return.Text = "Return";
                dgProducts.Columns.Add(Return);

                DataGridViewLinkColumn damaged = new DataGridViewLinkColumn();
                damaged.UseColumnTextForLinkValue = true;
                damaged.HeaderText = "Damaged";
                damaged.DataPropertyName = "lnkColumn";
                damaged.LinkBehavior = LinkBehavior.SystemDefault;
                damaged.Text = "Damaged";
                dgProducts.Columns.Add(damaged);
            }

            lblInvoiceNo.Text = dt.Rows[0]["InvoiceNo"].ToString();
            lblSupplierName.Text = dt.Rows[0]["SName"].ToString();
            lblOtherCost.Text = dt.Rows[0]["OtherCost"].ToString();
            lblPaidAmount.Text = dt.Rows[0]["PaidAmount"].ToString();
            lblDiscount.Text = dt.Rows[0]["Discount"].ToString();
            lblDue.Text = dt.Rows[0]["Due"].ToString();
            lblCreatedDate.Text = dt.Rows[0]["CreatedDate"].ToString();
            //lblUpdatedDate.Text = dt.Rows[0]["UpdatedDate"].ToString();
            payableAmount = Convert.ToDouble(dt.Rows[0]["PaidAmount"]) + Convert.ToDouble(dt.Rows[0]["Due"]);
            lblPayableAmount.Text = payableAmount.ToString();

        }

        private void dgProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 17 && e.RowIndex > -1)
            {
                //dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0][2].ToString()) ? Convert.ToDouble(dt.Rows[0][2]) : 0;

                long productId = !string.IsNullOrEmpty(dgProducts.Rows[e.RowIndex].Cells[3].Value.ToString()) ? Convert.ToInt64(dgProducts.Rows[e.RowIndex].Cells[3].Value.ToString()) : 0;
                (new Return(productId)).ShowDialog();
                //(new Damaged(productId)).ShowDialog();
                Initial(sqlDetail);

            }
            if (e.ColumnIndex == 18 && e.RowIndex > -1)
            {
                long productId = !string.IsNullOrEmpty(dgProducts.Rows[e.RowIndex].Cells[3].Value.ToString()) ? Convert.ToInt64(dgProducts.Rows[e.RowIndex].Cells[3].Value.ToString()) : 0;
                (new Damaged(productId)).ShowDialog();
                Initial(sqlDetail);
            }
        }
    }
}
