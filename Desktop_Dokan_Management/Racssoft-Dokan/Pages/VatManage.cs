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
    public partial class VatManage : Common
    {
        double soldQuantity = 0, dueVat = 0, customerGivenVat = 0, sellerGivenVat = 0;
        double totalQuantity = 0, pdGivenVat = 0, vatPaid = 0;
        public VatManage()
        {
            InitializeComponent();
            AddHeaderCheckBox();
            Initial();
            //AddHeaderCheckBox();

        }

        void Initial()
        {
            cmbSelectSearch.SelectedIndex = 0;
            cmbSelectSearchAction();
            string sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.IsVatPaid AS [Is VAT Paid?], s.CreatedDate AS [Date]
                    FROM (((Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) LEFT JOIN SalesDetails sd ON sd.SalesId = s.ID)
                        LEFT JOIN Products p ON p.ID = sd.ProductId) WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Now.ToString("MM/dd/yyyy") + "# " +
                    "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "#";
            string sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM ((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID WHERE s.CreatedDate BETWEEN #" + DateTime.Now.ToString("MM/dd/yyyy") + "# " +
                    "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "#";
            gridView1Generator(sql, sql1);
        }

        void cmbSelectSearchAction()
        {
            if (cmbSelectSearch.SelectedItem == "Search by Date")
            {
                groupBoxSearchByDate.Visible = true;
            }
        }

        CheckBox HeaderCheckBox = null;
        bool IsHeaderCheckBoxClicked = false;
        private void AddHeaderCheckBox()
        {
            HeaderCheckBox = new CheckBox();
            HeaderCheckBox.Size = new Size(15, 15);

            HeaderCheckBox.Padding = new Padding(0);
            HeaderCheckBox.Margin = new Padding(0);
            HeaderCheckBox.Text = "Mark All";
            this.dataGridView1.Controls.Add(HeaderCheckBox);

            

        }

        private void HeaderCheckBoxClick(CheckBox HCheckBox)
        {
            IsHeaderCheckBoxClicked = true;

            foreach(DataGridViewRow Row in dataGridView1.Rows)
            {
                ((DataGridViewCheckBoxCell)Row.Cells[1]).Value = HCheckBox.Checked;
                ((DataGridViewCheckBoxCell)Row.Cells[7]).Value = HCheckBox.Checked;
            }

            dataGridView1.RefreshEdit();
            IsHeaderCheckBoxClicked = false;
        }

        void gridView1Generator(string sql, string sql1)
        {
            DataTable dt = (DataTable)Select(sql).Data;
            int rowsCount = 0;
            rowsCount = dt.Rows.Count;

            List <int> ids = new List<int>();

            for(int i = 0; i < rowsCount; i++)
            {
                if (ids.Contains(Convert.ToInt32(dt.Rows[i]["ID"].ToString())))
                {

                    dt.Rows.RemoveAt(i);
                    rowsCount--;
                    i--;
                    //continue;
                }
                else
                {
                    ids.Add(Convert.ToInt32(dt.Rows[i]["ID"].ToString()));

                }
                }
                dataGridView1.DataSource = dt;

            //DataTable dt1 = (DataTable)Select(sql1).Data;
            //double 
            VatCalculator(sql1);

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.AutoGenerateColumns = false;
            if (dataGridView1.Columns.Count == 8)
            {
                DataGridViewLinkColumn edit = new DataGridViewLinkColumn();
                edit.UseColumnTextForLinkValue = true;
                edit.HeaderText = "Payment";
                edit.DataPropertyName = "lnkColumn";
                edit.LinkBehavior = LinkBehavior.AlwaysUnderline;
                edit.Text = "Payment";
                edit.LinkColor = Color.Blue;
                dataGridView1.Columns.Add(edit);


                DataGridViewCheckBoxColumn checkBox = new DataGridViewCheckBoxColumn();
                checkBox.HeaderText = "Mark All";
                //CheckBox HeaderCheckBox = null;
                //HeaderCheckBox = new CheckBox();
                //HeaderCheckBox.Size = new Size(15, 15);
                //this.dataGridView1.Controls.Add(HeaderCheckBox);
                //checkBox.AutoSizeMode = true;
                
               // check.ValueType = CheckBox(HeaderCheckBox);
                //checkBox.HeaderCell = HeaderCheckBox;
                checkBox.DataPropertyName = "lnkColumn";
                //checkBox.LinkBehavior = LinkBehavior.AlwaysUnderline;
                //checkBox.Text = "View Details";
                //checkBox.LinkColor = Color.Blue;
                dataGridView1.Columns.Insert(1, checkBox);
                //DataGridViewColumnHeaderCell check = new DataGridViewColumnHeaderCell();
                //check = dataGridView1.Columns[dataGridView1.Columns.Count - 1].HeaderCell;
                //DataGridViewHeaderCell header = dataGridView1.Columns[dataGridView1.Columns.Count - 1].HeaderCell;
                
                //HeaderCheckBox.Location = new Point(
                //    (header.ContentBounds.Left +
                //     (header.ContentBounds.Right - header.ContentBounds.Left + HeaderCheckBox.Size.Width)
                //     / 2) - 2,
                //    (header.ContentBounds.Top +
                //     (header.ContentBounds.Bottom - header.ContentBounds.Top + HeaderCheckBox.Size.Height)
                //     / 2) - 2);
                HeaderCheckBox.Location = new Point(50, 5);

                HeaderCheckBox.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);
                dataGridView1.AllowUserToAddRows = false;
                
            }
            dataGridView1.Refresh();
            //dataGridView1.AutoGenerateColumns = false;
            //dataGridView1.Refresh();
            //GrandTotalAmountofGridview1();
            //GrandTotalDueofGridview1();
        }

        private void HeaderCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxClick((CheckBox)sender);
        }

        

        void VatCalculator(string sql)
        {
            
            DataTable dt1 = (DataTable)Select(sql).Data;
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                //if (dt1.Rows[i]["CostPerUnit"] != DBNull.Value)
                //{
                //    costPerUnit = Convert.ToDouble(dt1.Rows[i]["CostPerUnit"]);
                //    if (dt1.Rows[i]["Quantity"] != DBNull.Value)
                //    {
                //        quantity = Convert.ToDouble(dt1.Rows[i]["Quantity"]);
                //    }
                //    totalCostPerUnit = totalCostPerUnit + (costPerUnit * quantity);
                //}
                //dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0][2].ToString()) ? Convert.ToDouble(dt.Rows[0][2]) : 0;
                //dt1.Rows.Count > 0 && !string.IsNullOrEmpty(dt1.Rows[i]["CostPerUnit"].ToString()) ? Convert.ToInt64(dt1.Rows[i]["CostPerUnit"] : 0;
                //costPerUnit = Convert.ToDouble(dt1.Rows[i]["CostPerUnit"]);
                //costPerUnit = dt1.Rows.Count > 0 && !string.IsNullOrEmpty(dt1.Rows[i]["CostPerUnit"].ToString()) ? Convert.ToInt64(dt1.Rows[i]["CostPerUnit"]) : 0;
                //costPerUnit = dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0][2].ToString()) ? Convert.ToDouble(dt.Rows[0][2]) : 0;
                //soldQuantity = Convert.ToDouble(dt1.Rows[i]["Quantity"]);
                soldQuantity = dt1.Rows.Count > 0 && !string.IsNullOrEmpty(dt1.Rows[i]["Quantity"].ToString()) ? Convert.ToInt64(dt1.Rows[i]["Quantity"]) : 0;
                //totalQuantity = Convert.ToDouble(dt1.Rows[i]["TotalQuantity"]);
                totalQuantity = dt1.Rows.Count > 0 && !string.IsNullOrEmpty(dt1.Rows[i]["TotalQuantity"].ToString()) ? Convert.ToInt64(dt1.Rows[i]["TotalQuantity"]) : 0;
                //totalCostPerUnit = totalCostPerUnit + (costPerUnit * soldQuantity);
                //totalSellingPrice = totalSellingPrice + Convert.ToDouble(dt1.Rows[i]["TotalPrice"]);
                //totalSellingPrice = totalSellingPrice + (dt1.Rows.Count > 0 && !string.IsNullOrEmpty(dt1.Rows[i]["TotalPrice"].ToString()) ? Convert.ToInt64(dt1.Rows[i]["TotalPrice"]) : 0);
                //customerGivenVat = customerGivenVat + Convert.ToDouble(dt1.Rows[i]["d.GivenVat"]);
                customerGivenVat = customerGivenVat + (dt1.Rows.Count > 0 && !string.IsNullOrEmpty(dt1.Rows[i]["d.GivenVat"].ToString()) ? Convert.ToInt64(dt1.Rows[i]["d.GivenVat"]) : 0);
                vatPaid = (dt1.Rows.Count > 0 && !string.IsNullOrEmpty(dt1.Rows[i]["VatPaid"].ToString()) ? Convert.ToDouble(dt1.Rows[i]["VatPaid"]) : 0);
                //sellerGivenVat = sellerGivenVat + ((Convert.ToDouble(dt1.Rows[i]["pd.GivenVat"]) / totalQuantity) * soldQuantity);
                pdGivenVat = dt1.Rows.Count > 0 && !string.IsNullOrEmpty(dt1.Rows[i]["pd.GivenVat"].ToString()) ? Convert.ToInt64(dt1.Rows[i]["pd.GivenVat"]) : 0;
                sellerGivenVat = sellerGivenVat + vatPaid + ((pdGivenVat) / totalQuantity) * soldQuantity;









                //quantity = Convert.ToDouble(dt1.Rows[i]["Quantity"]);
                //if (dt1.Rows[i]["SellingPrice"] != DBNull.Value) sellingPrice = sellingPrice + (Convert.ToDouble(dt1.Rows[i]["SellingPrice"])*quantity);
            }

            //profit = totalSellingPrice - totalCostPerUnit;
            lblCollectedVat.Text = Convert.ToString(customerGivenVat);
            lblPaidVat.Text = Convert.ToString(sellerGivenVat);
            dueVat = customerGivenVat - sellerGivenVat;

            lblDueVat.Text = Convert.ToString(Math.Round(dueVat, 2));


            //lblTotalProfit.Text = Convert.ToString(Math.Round(profit, 2));
            //lblTotalCost.Text = Convert.ToString(Math.Round(totalCostPerUnit, 2));

        }

        public void GrandTotalAmountofGridview1()
        {
            double totaQty = 0;
            for (int a = 0; a < dataGridView1.Rows.Count - 1; a++)
            {
                var valueQty = dataGridView1.Rows[a].Cells[4].Value.ToString();
                if (valueQty != DBNull.Value.ToString())
                {
                    totaQty += Convert.ToDouble(valueQty);
                }
            }
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[3].Style.BackColor = Color.Gray;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[3].Value = "Total";
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[4].Value = totaQty.ToString();
            //lblTotalSale.Text = totaQty.ToString();

        }

        public void GrandTotalDueofGridview1()
        {
            double totaQty = 0;
            for (int a = 0; a < dataGridView1.Rows.Count - 1; a++)
            {
                var valueQty = dataGridView1.Rows[a].Cells[5].Value.ToString();
                if (valueQty != DBNull.Value.ToString())
                {
                    totaQty += Convert.ToDouble(valueQty);
                }
            }
            //dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Style.BackColor = Color.Gray;
            //dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Value = "Total ";
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[5].Value = totaQty.ToString();
            //lblTotalDue.Text = totaQty.ToString();

        }

        private void checkBoxforIndividual_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxforIndividual.Checked)
            {
                grpBoxCustomerMobile.Enabled = true;
            }

            else
            {
                grpBoxCustomerMobile.Enabled = false;
                txtMobileNo.Text = "";
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clear();
        }

        void clear()
        {
            cmbSelectSearch.SelectedIndex = 0;
            checkBoxforIndividual.Checked = false;
            groupBoxSearchByDate.Enabled = false;
            txtMobileNo.Text = "";
            //groupBoxInvoiceDetails.Enabled = true;
            checkBoxDue.Checked = false;
            Initial();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //groupBoxInvoiceDetails.Visible = true;

            soldQuantity = 0;
            dueVat = 0;
            customerGivenVat = 0;
            sellerGivenVat = 0;
            totalQuantity = 0;
            pdGivenVat = 0;
            vatPaid = 0;

            if (cmbSelectSearch.SelectedIndex == 1)
            {
                groupBoxSearchByDate.Enabled = true;
                DateTime date = DateTime.Parse(dateTimePicker1.Text);
                DateTime date2 = DateTime.Parse(dateTimePicker2.Text);
                //DateTime.Now.AddDays(-2).ToString("MM/dd/yyyy")

                string sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.IsVatPaid AS [Is VAT Paid?], s.CreatedDate AS [Date]
                    FROM (((Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) LEFT JOIN SalesDetails sd ON sd.SalesId = s.ID)
                        LEFT JOIN Products p ON p.ID = sd.ProductId) WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Parse(date.ToString("MM/dd/yyyy")) + "# " +
                    "AND #" + DateTime.Parse(date2.AddDays(1).ToString("MM/dd/yyyy")) + "#";
                string sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM ((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID WHERE s.CreatedDate BETWEEN #" + DateTime.Parse(date.ToString("MM/dd/yyyy")) + "# " +
                    "AND #" + DateTime.Parse(date2.AddDays(1).ToString("MM/dd/yyyy")) + "#";

                if (!string.IsNullOrEmpty(txtMobileNo.Text.Trim()))
                {
                    sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.IsVatPaid AS [Is VAT Paid?], s.CreatedDate AS [Date]
                    FROM (((Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) LEFT JOIN SalesDetails sd ON sd.SalesId = s.ID)
                        LEFT JOIN Products p ON p.ID = sd.ProductId) WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Parse(date.ToString("MM/dd/yyyy")) + "# " +
                            "AND #" + DateTime.Parse(date2.AddDays(1).ToString("MM/dd/yyyy")) + "# AND d.CustomerMobile = '" + txtMobileNo.Text.Trim() + "'";
                    sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM (((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID) LEFT JOIN Customer c ON c.ID = s.CustomerId WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Parse(date.ToString("MM/dd/yyyy")) + "# " +
                            "AND #" + DateTime.Parse(date2.AddDays(1).ToString("MM/dd/yyyy")) + "# AND c.CustomerMobile = '" + txtMobileNo.Text.Trim() + "'";

                    if (checkBoxDue.Checked)
                    {
                        sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.IsVatPaid AS [Is VAT Paid?], s.CreatedDate AS [Date]
                        FROM (((Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) LEFT JOIN SalesDetails sd ON sd.SalesId = s.ID)
                        LEFT JOIN Products p ON p.ID = sd.ProductId) WHERE s.CreatedDate 
                        BETWEEN #" + DateTime.Parse(date.ToString("MM/dd/yyyy")) + "# " +
                        "AND #" + DateTime.Parse(date2.AddDays(1).ToString("MM/dd/yyyy")) + "# AND d.CustomerMobile = '" + txtMobileNo.Text.Trim() + "' AND sd.VatPaid = 0 AND p.Vat <> 0";

                        sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM (((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID) LEFT JOIN Customer c ON c.ID = s.CustomerId WHERE s.CreatedDate 
                        BETWEEN #" + DateTime.Parse(date.ToString("MM/dd/yyyy")) + "# " +
                        "AND #" + DateTime.Parse(date2.AddDays(1).ToString("MM/dd/yyyy")) + "# AND c.CustomerMobile = '" + txtMobileNo.Text.Trim() + "' AND d.VatPaid = 0 AND p.Vat <> 0";
                    }


                }

                else if (checkBoxDue.Checked && string.IsNullOrEmpty(txtMobileNo.Text.Trim()))
                {
                    sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.IsVatPaid AS [Is VAT Paid?], s.CreatedDate AS [Date]
                    FROM (((Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) LEFT JOIN SalesDetails sd ON sd.SalesId = s.ID)
                        LEFT JOIN Products p ON p.ID = sd.ProductId) WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Parse(date.ToString("MM/dd/yyyy")) + "# " +
                    "AND #" + DateTime.Parse(date2.AddDays(1).ToString("MM/dd/yyyy")) + "# AND sd.VatPaid = 0 AND p.Vat <> 0";

                    sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM ((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Parse(date.ToString("MM/dd/yyyy")) + "# " +
                    "AND #" + DateTime.Parse(date2.AddDays(1).ToString("MM/dd/yyyy")) + "# AND d.VatPaid = 0 AND p.Vat <> 0";
                }

                gridView1Generator(sql, sql1);


            }

            else if (cmbSelectSearch.SelectedIndex == 2)
            {
                string sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.IsVatPaid AS [Is VAT Paid?], s.CreatedDate AS [Date]
                    FROM (((Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) LEFT JOIN SalesDetails sd ON sd.SalesId = s.ID)
                        LEFT JOIN Products p ON p.ID = sd.ProductId) WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Now.ToString("MM/dd/yyyy") + "# " +
                    "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "#";
                string sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM ((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID WHERE s.CreatedDate BETWEEN #" + DateTime.Now.ToString("MM/dd/yyyy") + "# " +
                    "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "#";

                if (!string.IsNullOrEmpty(txtMobileNo.Text.Trim()))
                {
                    sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.IsVatPaid AS [Is VAT Paid?], s.CreatedDate AS [Date]
                    FROM (((Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) LEFT JOIN SalesDetails sd ON sd.SalesId = s.ID)
                        LEFT JOIN Products p ON p.ID = sd.ProductId) WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Now.ToString("MM/dd/yyyy") + "# " +
                            "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "# AND d.CustomerMobile = '" + txtMobileNo.Text.Trim() + "'";
                    sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM (((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID) LEFT JOIN Customer c ON c.ID = s.CustomerId WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Now.ToString("MM/dd/yyyy") + "# " +
                            "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "# AND c.CustomerMobile = '" + txtMobileNo.Text.Trim() + "'";

                    if (checkBoxDue.Checked)
                    {
                        sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.IsVatPaid AS [Is VAT Paid?], s.CreatedDate AS [Date]
                        FROM (((Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) LEFT JOIN SalesDetails sd ON sd.SalesId = s.ID)
                        LEFT JOIN Products p ON p.ID = sd.ProductId) WHERE s.CreatedDate 
                        BETWEEN #" + DateTime.Now.ToString("MM/dd/yyyy") + "# " +
                        "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "# AND d.CustomerMobile = '" + txtMobileNo.Text.Trim() + "' AND sd.VatPaid = 0 AND p.Vat <> 0";

                        sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM (((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID) LEFT JOIN Customer c ON c.ID = s.CustomerId WHERE s.CreatedDate 
                        BETWEEN #" + DateTime.Now.ToString("MM/dd/yyyy") + "# " +
                        "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "# AND c.CustomerMobile = '" + txtMobileNo.Text.Trim() + "' AND d.VatPaid = 0 AND p.Vat <> 0";
                    }


                }

                else if (checkBoxDue.Checked && string.IsNullOrEmpty(txtMobileNo.Text.Trim()))
                {
                    sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.IsVatPaid AS [Is VAT Paid?], s.CreatedDate AS [Date]
                    FROM (((Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) LEFT JOIN SalesDetails sd ON sd.SalesId = s.ID)
                        LEFT JOIN Products p ON p.ID = sd.ProductId) WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Now.ToString("MM/dd/yyyy") + "# " +
                    "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "# AND sd.VatPaid = 0 AND p.Vat <> 0";

                    sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM ((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Now.ToString("MM/dd/yyyy") + "# " +
                    "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "# AND d.VatPaid = 0 AND p.Vat <> 0";
                }

                gridView1Generator(sql, sql1);


            }

            

            else if (checkBoxforIndividual.Checked && checkBoxDue.Checked)
            {
                //string name = txtMobileNo.Text.ToString();
                string sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.IsVatPaid AS [Is VAT Paid?], s.CreatedDate AS [Date]
                        FROM (((Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) LEFT JOIN SalesDetails sd ON sd.SalesId = s.ID)
                        LEFT JOIN Products p ON p.ID = sd.ProductId) WHERE d.CustomerMobile = '" + txtMobileNo.Text.Trim() + "' AND sd.VatPaid = 0 AND p.Vat <> 0";
                string sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM (((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID) LEFT JOIN Customer c ON c.ID = s.CustomerId WHERE c.CustomerMobile = '" + txtMobileNo.Text.Trim() + "' AND d.VatPaid = 0 AND p.Vat <> 0";
                gridView1Generator(sql, sql1);
            }
            else if (checkBoxforIndividual.Checked)
            {
                string sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.IsVatPaid AS [Is VAT Paid?], s.CreatedDate AS [Date]
                        FROM (((Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) LEFT JOIN SalesDetails sd ON sd.SalesId = s.ID)
                        LEFT JOIN Products p ON p.ID = sd.ProductId) WHERE d.CustomerMobile = '" + txtMobileNo.Text.Trim() + "'";
                string sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM (((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID) LEFT JOIN Customer c ON c.ID = s.CustomerId WHERE c.CustomerMobile = '" + txtMobileNo.Text.Trim() + "'";
                gridView1Generator(sql, sql1);
            }

            else if (checkBoxDue.Checked)
            {
                string sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.IsVatPaid AS [Is VAT Paid?], s.CreatedDate AS [Date]
                        FROM (((Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) LEFT JOIN SalesDetails sd ON sd.SalesId = s.ID)
                        LEFT JOIN Products p ON p.ID = sd.ProductId) WHERE sd.VatPaid = 0 AND p.Vat <> 0";
                string sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM (((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID) LEFT JOIN Customer c ON c.ID = s.CustomerId WHERE d.VatPaid = 0 AND p.Vat <> 0";
                gridView1Generator(sql, sql1);
            }


        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            soldQuantity = 0;
            dueVat = 0;
            customerGivenVat = 0;
            sellerGivenVat = 0;
            totalQuantity = 0;
            pdGivenVat = 0;
            vatPaid = 0;
            int id = 0;
            //double dueVat = 0;
            List<int> listOfIds = new List<int>();
            
            for(int i = 0; i <= dataGridView1.RowCount - 1; i++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[1].Value) == true)
                {
                    id = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    listOfIds.Add(id);
                    string sql1 = @"SELECT s.ID, d.ID, d.Quantity, d.GivenVat, d.VatPaid, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                               pd.ID, pd.GivenVat, pd.RemainQuantity FROM ((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID WHERE
                                s.ID = " + id + "";
                    VatCalculator(sql1);

                }
            }

            (new VatPayment(customerGivenVat, sellerGivenVat, dueVat, listOfIds)).ShowDialog();

            soldQuantity = 0;
            dueVat = 0;
            customerGivenVat = 0;
            sellerGivenVat = 0;
            totalQuantity = 0;
            pdGivenVat = 0;
            vatPaid = 0;
            listOfIds.Clear();
            //a.Add(1052);

            //(new VatPayment()).ShowDialog();
        }
    }
}
