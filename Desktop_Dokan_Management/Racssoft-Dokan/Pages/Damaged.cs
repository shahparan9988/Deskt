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
    public partial class Damaged : Common
    {
        static long productDetailsId;
        static long productId;
        public Damaged(long id)
        {
            InitializeComponent();
            Initial(id);
        }

        void Initial(long id)
        {
            string sql = @"SELECT * FROM Products p LEFT JOIN ProductDetails d ON d.ProductId = p.ID WHERE p.ID = " + id + "";
            DataTable dt = (DataTable)Select(sql).Data;
            productDetailsId = !string.IsNullOrEmpty(dt.Rows[0]["d.ID"].ToString()) ? Convert.ToInt64(dt.Rows[0]["d.ID"].ToString()) : 0;
            productId = !string.IsNullOrEmpty(dt.Rows[0]["p.ID"].ToString()) ? Convert.ToInt64(dt.Rows[0]["p.ID"].ToString()) : 0;
            lblProductName.Text = !string.IsNullOrEmpty(dt.Rows[0][1].ToString()) ? dt.Rows[0][1].ToString() : "";
            lblProductQuantity.Text = !string.IsNullOrEmpty(dt.Rows[0]["TotalQuantity"].ToString()) ? dt.Rows[0]["TotalQuantity"].ToString() : "0";
            lblRemainQuantity.Text = !string.IsNullOrEmpty(dt.Rows[0]["RemainQuantity"].ToString()) ? dt.Rows[0]["RemainQuantity"].ToString() : "0";
            lblBuyingPrice.Text = !string.IsNullOrEmpty(dt.Rows[0]["CostPerUnit"].ToString()) ? dt.Rows[0]["CostPerUnit"].ToString() : "0";

            numericDamagedUnitPrice.Value = Convert.ToDecimal(lblBuyingPrice.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            double damagedQuantity = Convert.ToDouble(numericDamagedQuantity.Value);
            double totalQuantity = Convert.ToDouble(lblProductQuantity.Text);
            double remainQuantity = Convert.ToDouble(lblRemainQuantity.Text);
            //double remainQuantity = Convert.ToDouble(lblRemainQuantity);

            string sqlUpdate = "UPDATE ProductDetails SET RemainQuantity = " + (remainQuantity - damagedQuantity) + " WHERE ID = " + productDetailsId + "";
            CUD(sqlUpdate);
            string sqlReturnProduct = "INSERT INTO DamagedProducts(ProductId, DamagedUnitPrice, DamagedQuantity, CreatedDate)" +
                "VALUES (" + productId + ", " + numericDamagedUnitPrice.Value + ", " + damagedQuantity + ", '" + DateTime.Now + "')";
            CUD(sqlReturnProduct);

            //string sql


            this.Close();
        }
    }
}
