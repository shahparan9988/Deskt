using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using Model;
using System.Windows.Forms.DataVisualization.Charting;

namespace Racssoft_Dokan.Pages
{
    public partial class SalesDetails : Common
    {
        public SalesDetails()
        {
            InitializeComponent();
            Initial();
        }

        void Initial()
        {
            cmbSelectSearch.SelectedIndex = 0;
            cmbSelectSearchAction();
            string sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.CreatedDate AS [Date]
                    FROM (Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Now.ToString("MM/dd/yyyy") + "# " +
                    "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "#";
            string sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM ((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID WHERE s.CreatedDate BETWEEN #" + DateTime.Now.ToString("MM/dd/yyyy") + "# " +
                    "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "#";
            gridView1Generator(sql, sql1);
            //MessageBox.Show(DateTime.Now.AddDays(3).ToString());
            //MessageBox.Show(DateTime.Now. ToString());
        }

        void chartGenerator(string sql)
        {
            // chartArea
            ChartArea chartArea = new ChartArea();
            chartSale.ChartAreas[0].Axes[0].MajorGrid.Enabled = false;//x axis
                                                                      //chartAccounts.ChartAreas[0].AxisY.LabelStyle.Format = "P";
                                                                      //chart1.ChartAreas[0].AxisX.ScaleView.Zoom(0, 13);
            chartSale.ChartAreas[0].AxisX.Interval = 1;
            chartSale.ChartAreas[0].Axes[1].MajorGrid.Enabled = true;//y axis

            //Series
            Series series1 = new Series();
            chartSale.Series.Add(series1);
            //Series style
            series1.ChartType = SeriesChartType.Column;  // type
            series1.BorderWidth = 2;
            series1.Color = Color.Green;
            series1.Name = "Amount";

            //Series series2 = new Series();
            //chartAccounts.Series.Add(series2);
            ////Series style
            //series2.ChartType = SeriesChartType.Spline;  // type
            //series2.BorderWidth = 2;
            //series2.Color = Color.Blue;
            ////series1.Name = "Balance";

            DataTable dt = (DataTable)Select(sql).Data;
            //chartAccounts.DataBindTable(dt.DefaultView, "Balance");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string name = Convert.ToString(dt.Rows[i]["Date"]);
                double amount = Convert.ToDouble(dt.Rows[i]["Balance"]);
                series1.Points.AddXY(name, amount);
                //series2.Points.AddXY(name, amount);
            }
        }

        void cmbSelectSearchAction()
        {
            if(cmbSelectSearch.SelectedItem == "Search by Date")
            {
                groupBoxSearchByDate.Visible = true;
            }
        }

        private void cmbSelectSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                if (e.RowIndex > -1)
                {
                    long salesId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    (new SalesPayment(salesId)).ShowDialog();
                    button1_Click(button1, e);

                }
            }


            else if (e.ColumnIndex == 8)
            {
                if (e.RowIndex > -1)
                {
                    int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    string sql = @"SELECT d.ID, p.Name, c.Title AS [Category], b.Title AS [Brand], d.Quantity, d.SellingPrice AS [Price], d.TotalPrice AS [Total Price]
                FROM (((Products AS p LEFT JOIN SalesDetails AS d ON d.ProductId = p.ID)
                LEFT JOIN Category c ON c.ID = p.CategoryId) LEFT JOIN Brand b ON b.ID = p.BrandId)   
                WHERE d.SalesId =" + id + "";


                    DataTable dt = (DataTable)Select(sql).Data;
                    groupBoxInvoiceDetails.Visible = true;

                    dataGridView2.Visible = true;
                    dataGridView2.DataSource = dt;
                    dataGridView2.Columns[0].Visible = false;
                    dataGridView2.Refresh();


                    lblCustomerName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    lblCustomerMobile.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    lblPurchasedDate.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                    lblPaid.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    lblDue.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();


                    //lblInvoiceId.Visible = true;
                    //lblInvoiceNumber.Visible = true;
                }

            }
         }

        void clear()
        {
            cmbSelectSearch.SelectedIndex = 0;
            checkBoxforIndividual.Checked = false;
            groupBoxSearchByDate.Enabled = false;
            txtMobileNo.Text = "";
            groupBoxInvoiceDetails.Enabled = true;
            checkBoxDue.Checked = false;
            Initial();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            groupBoxInvoiceDetails.Visible = true;

            if (cmbSelectSearch.SelectedIndex == 1)
            {
                groupBoxSearchByDate.Enabled = true;
                DateTime date = DateTime.Parse(dateTimePicker1.Text);
                DateTime date2 = DateTime.Parse(dateTimePicker2.Text);
                //DateTime.Now.AddDays(-2).ToString("MM/dd/yyyy")

                string sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.CreatedDate AS [Date]
                    FROM (Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Parse(date.ToString("MM/dd/yyyy")) + "# " +
                    "AND #" + DateTime.Parse(date2.AddDays(1).ToString("MM/dd/yyyy")) + "#";
                string sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM ((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID WHERE s.CreatedDate BETWEEN #" + DateTime.Parse(date.ToString("MM/dd/yyyy")) + "# " +
                    "AND #" + DateTime.Parse(date2.AddDays(1).ToString("MM/dd/yyyy")) + "#";

                if (!string.IsNullOrEmpty(txtMobileNo.Text.Trim()))
                {
                    sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.CreatedDate AS [Date]
                    FROM (Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Parse(date.ToString("MM/dd/yyyy")) + "# " +
                            "AND #" + DateTime.Parse(date2.AddDays(1).ToString("MM/dd/yyyy")) + "# AND d.CustomerMobile = '" + txtMobileNo.Text.Trim() + "'";
                    sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM (((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID) LEFT JOIN Customer c ON c.ID = s.CustomerId WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Parse(date.ToString("MM/dd/yyyy")) + "# " +
                            "AND #" + DateTime.Parse(date2.AddDays(1).ToString("MM/dd/yyyy")) + "# AND c.CustomerMobile = '" + txtMobileNo.Text.Trim() + "'";

                    if (checkBoxDue.Checked)
                    {
                        sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.CreatedDate AS [Date]
                        FROM (Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) WHERE s.CreatedDate 
                        BETWEEN #" + DateTime.Parse(date.ToString("MM/dd/yyyy")) + "# " +
                        "AND #" + DateTime.Parse(date2.AddDays(1).ToString("MM/dd/yyyy")) + "# AND d.CustomerMobile = '" + txtMobileNo.Text.Trim() + "' AND s.Due <> 0";

                        sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM (((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID) LEFT JOIN Customer c ON c.ID = s.CustomerId WHERE s.CreatedDate 
                        BETWEEN #" + DateTime.Parse(date.ToString("MM/dd/yyyy")) + "# " +
                        "AND #" + DateTime.Parse(date2.AddDays(1).ToString("MM/dd/yyyy")) + "# AND c.CustomerMobile = '" + txtMobileNo.Text.Trim() + "' AND s.Due <> 0";
                    }


                }

                else if(checkBoxDue.Checked && string.IsNullOrEmpty(txtMobileNo.Text.Trim()))
                {
                    sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.CreatedDate AS [Date]
                    FROM (Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Parse(date.ToString("MM/dd/yyyy")) + "# " +
                    "AND #" + DateTime.Parse(date2.AddDays(1).ToString("MM/dd/yyyy")) + "# AND s.Due <> 0";

                    sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM ((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Parse(date.ToString("MM/dd/yyyy")) + "# " +
                    "AND #" + DateTime.Parse(date2.AddDays(1).ToString("MM/dd/yyyy")) + "# AND s.Due <> 0";
                }

                gridView1Generator(sql, sql1);
                
                
            }

            else if (cmbSelectSearch.SelectedIndex == 2)
            {
                string sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.CreatedDate AS [Date]
                    FROM (Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Now.ToString("MM/dd/yyyy") + "# " +
                    "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "#";
                string sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM ((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID WHERE s.CreatedDate BETWEEN #" + DateTime.Now.ToString("MM/dd/yyyy") + "# " +
                    "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "#";

                if (!string.IsNullOrEmpty(txtMobileNo.Text.Trim()))
                {
                    sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.CreatedDate AS [Date]
                    FROM (Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Now.ToString("MM/dd/yyyy") + "# " +
                            "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "# AND d.CustomerMobile = '" + txtMobileNo.Text.Trim() + "'";
                    sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM (((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID) LEFT JOIN Customer c ON c.ID = s.CustomerId WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Now.ToString("MM/dd/yyyy") + "# " +
                            "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "# AND c.CustomerMobile = '" + txtMobileNo.Text.Trim() + "'";

                    if (checkBoxDue.Checked)
                    {
                        sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.CreatedDate AS [Date]
                        FROM (Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) WHERE s.CreatedDate 
                        BETWEEN #" + DateTime.Now.ToString("MM/dd/yyyy") + "# " +
                        "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "# AND d.CustomerMobile = '" + txtMobileNo.Text.Trim() + "' AND s.Due <> 0";

                        sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM (((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID) LEFT JOIN Customer c ON c.ID = s.CustomerId WHERE s.CreatedDate 
                        BETWEEN #" + DateTime.Now.ToString("MM/dd/yyyy") + "# " +
                        "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "# AND c.CustomerMobile = '" + txtMobileNo.Text.Trim() + "' AND s.Due <> 0";
                    }


                }

                else if (checkBoxDue.Checked && string.IsNullOrEmpty(txtMobileNo.Text.Trim()))
                {
                    sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.CreatedDate AS [Date]
                    FROM (Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Now.ToString("MM/dd/yyyy") + "# " +
                    "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "# AND s.Due <> 0";

                    sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM ((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Now.ToString("MM/dd/yyyy") + "# " +
                    "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "# AND s.Due <> 0";
                }

                gridView1Generator(sql, sql1);


            }

            else if (cmbSelectSearch.SelectedIndex == 3)
            {
                string sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.CreatedDate AS [Date]
                    FROM (Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Now.AddDays(-2).ToString("MM/dd/yyyy") + "# " +
                    "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "#";
                string sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM ((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID WHERE s.CreatedDate BETWEEN #" + DateTime.Now.AddDays(-2).ToString("MM/dd/yyyy") + "# " +
                    "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "#";

                if (!string.IsNullOrEmpty(txtMobileNo.Text.Trim()))
                {
                    sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.CreatedDate AS [Date]
                    FROM (Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Now.AddDays(-2).ToString("MM/dd/yyyy") + "# " +
                            "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "# AND d.CustomerMobile = '" + txtMobileNo.Text.Trim() + "'";
                    sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM (((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID) LEFT JOIN Customer c ON c.ID = s.CustomerId WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Now.AddDays(-2).ToString("MM/dd/yyyy") + "# " +
                            "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "# AND c.CustomerMobile = '" + txtMobileNo.Text.Trim() + "'";

                    if (checkBoxDue.Checked)
                    {
                        sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.CreatedDate AS [Date]
                        FROM (Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) WHERE s.CreatedDate 
                        BETWEEN #" + DateTime.Now.AddDays(-2).ToString("MM/dd/yyyy") + "# " +
                        "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "# AND d.CustomerMobile = '" + txtMobileNo.Text.Trim() + "' AND s.Due <> 0";

                        sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM (((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID) LEFT JOIN Customer c ON c.ID = s.CustomerId WHERE s.CreatedDate 
                        BETWEEN #" + DateTime.Now.AddDays(-2).ToString("MM/dd/yyyy") + "# " +
                        "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "# AND c.CustomerMobile = '" + txtMobileNo.Text.Trim() + "' AND s.Due <> 0";
                    }


                }

                else if (checkBoxDue.Checked && string.IsNullOrEmpty(txtMobileNo.Text.Trim()))
                {
                    sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.CreatedDate AS [Date]
                    FROM (Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Now.AddDays(-2).ToString("MM/dd/yyyy") + "# " +
                    "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "# AND s.Due <> 0";

                    sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM ((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Now.AddDays(-2).ToString("MM/dd/yyyy") + "# " +
                    "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "# AND s.Due <> 0";
                }

                gridView1Generator(sql, sql1);


            }

            else if (cmbSelectSearch.SelectedIndex == 4)
            {
                string sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.CreatedDate AS [Date]
                    FROM (Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Now.AddDays(-7).ToString("MM/dd/yyyy") + "# " +
                    "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "#";
                string sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM ((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID WHERE s.CreatedDate BETWEEN #" + DateTime.Now.AddDays(-7).ToString("MM/dd/yyyy") + "# " +
                    "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "#";

                if (!string.IsNullOrEmpty(txtMobileNo.Text.Trim()))
                {
                    sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.CreatedDate AS [Date]
                    FROM (Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Now.AddDays(-7).ToString("MM/dd/yyyy") + "# " +
                            "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "# AND d.CustomerMobile = '" + txtMobileNo.Text.Trim() + "'";
                    sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM (((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID) LEFT JOIN Customer c ON c.ID = s.CustomerId WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Now.AddDays(-7).ToString("MM/dd/yyyy") + "# " +
                            "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "# AND c.CustomerMobile = '" + txtMobileNo.Text.Trim() + "'";

                    if (checkBoxDue.Checked)
                    {
                        sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.CreatedDate AS [Date]
                        FROM (Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) WHERE s.CreatedDate 
                        BETWEEN #" + DateTime.Now.AddDays(-7).ToString("MM/dd/yyyy") + "# " +
                        "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "# AND d.CustomerMobile = '" + txtMobileNo.Text.Trim() + "' AND s.Due <> 0";

                        sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM (((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID) LEFT JOIN Customer c ON c.ID = s.CustomerId WHERE s.CreatedDate 
                        BETWEEN #" + DateTime.Now.AddDays(-7).ToString("MM/dd/yyyy") + "# " +
                        "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "# AND c.CustomerMobile = '" + txtMobileNo.Text.Trim() + "' AND s.Due <> 0";
                    }


                }

                else if (checkBoxDue.Checked && string.IsNullOrEmpty(txtMobileNo.Text.Trim()))
                {
                    sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.CreatedDate AS [Date]
                    FROM (Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Now.AddDays(-7).ToString("MM/dd/yyyy") + "# " +
                    "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "# AND s.Due <> 0";

                    sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM ((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Now.AddDays(-7).ToString("MM/dd/yyyy") + "# " +
                    "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "# AND s.Due <> 0";
                }

                gridView1Generator(sql, sql1);


            }

            else if (cmbSelectSearch.SelectedIndex == 5)
            {
                string sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.CreatedDate AS [Date]
                    FROM (Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Now.AddDays(-15).ToString("MM/dd/yyyy") + "# " +
                   "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "#";
                string sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM ((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID WHERE s.CreatedDate BETWEEN #" + DateTime.Now.AddDays(-15).ToString("MM/dd/yyyy") + "# " +
                    "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "#";

                if (!string.IsNullOrEmpty(txtMobileNo.Text.Trim()))
                {
                    sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.CreatedDate AS [Date]
                    FROM (Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Now.AddDays(-15).ToString("MM/dd/yyyy") + "# " +
                            "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "# AND d.CustomerMobile = '" + txtMobileNo.Text.Trim() + "'";
                    sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM (((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID) LEFT JOIN Customer c ON c.ID = s.CustomerId WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Now.AddDays(-15).ToString("MM/dd/yyyy") + "# " +
                            "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "# AND c.CustomerMobile = '" + txtMobileNo.Text.Trim() + "'";

                    if (checkBoxDue.Checked)
                    {
                        sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.CreatedDate AS [Date]
                        FROM (Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) WHERE s.CreatedDate 
                        BETWEEN #" + DateTime.Now.AddDays(-15).ToString("MM/dd/yyyy") + "# " +
                        "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "# AND d.CustomerMobile = '" + txtMobileNo.Text.Trim() + "' AND s.Due <> 0";

                        sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM (((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID) LEFT JOIN Customer c ON c.ID = s.CustomerId WHERE s.CreatedDate 
                        BETWEEN #" + DateTime.Now.AddDays(-15).ToString("MM/dd/yyyy") + "# " +
                        "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "# AND c.CustomerMobile = '" + txtMobileNo.Text.Trim() + "' AND s.Due <> 0";
                    }


                }

                else if (checkBoxDue.Checked && string.IsNullOrEmpty(txtMobileNo.Text.Trim()))
                {
                    sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.CreatedDate AS [Date]
                    FROM (Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Now.AddDays(-15).ToString("MM/dd/yyyy") + "# " +
                    "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "# AND s.Due <> 0";

                    sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM ((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Now.AddDays(-15).ToString("MM/dd/yyyy") + "# " +
                    "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "# AND s.Due <> 0";
                }

                gridView1Generator(sql, sql1);

            }

            else if (cmbSelectSearch.SelectedIndex == 6)
            {
                string sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.CreatedDate AS [Date]
                    FROM (Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Now.AddDays(-30).ToString("MM/dd/yyyy") + "# " +
                   "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "#";
                string sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM ((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID WHERE s.CreatedDate BETWEEN #" + DateTime.Now.AddDays(-30).ToString("MM/dd/yyyy") + "# " +
                    "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "#";

                if (!string.IsNullOrEmpty(txtMobileNo.Text.Trim()))
                {
                    sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.CreatedDate AS [Date]
                    FROM (Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Now.AddDays(-30).ToString("MM/dd/yyyy") + "# " +
                            "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "# AND d.CustomerMobile = '" + txtMobileNo.Text.Trim() + "'";
                    sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM (((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID) LEFT JOIN Customer c ON c.ID = s.CustomerId WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Now.AddDays(-30).ToString("MM/dd/yyyy") + "# " +
                            "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "# AND c.CustomerMobile = '" + txtMobileNo.Text.Trim() + "'";

                    if (checkBoxDue.Checked)
                    {
                        sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.CreatedDate AS [Date]
                        FROM (Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) WHERE s.CreatedDate 
                        BETWEEN #" + DateTime.Now.AddDays(-30).ToString("MM/dd/yyyy") + "# " +
                        "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "# AND d.CustomerMobile = '" + txtMobileNo.Text.Trim() + "' AND s.Due <> 0";

                        sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM (((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID) LEFT JOIN Customer c ON c.ID = s.CustomerId WHERE s.CreatedDate 
                        BETWEEN #" + DateTime.Now.AddDays(-30).ToString("MM/dd/yyyy") + "# " +
                        "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "# AND c.CustomerMobile = '" + txtMobileNo.Text.Trim() + "' AND s.Due <> 0";
                    }


                }

                else if (checkBoxDue.Checked && string.IsNullOrEmpty(txtMobileNo.Text.Trim()))
                {
                    sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.CreatedDate AS [Date]
                    FROM (Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Now.AddDays(-30).ToString("MM/dd/yyyy") + "# " +
                    "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "# AND s.Due <> 0";

                    sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM ((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID WHERE s.CreatedDate 
                    BETWEEN #" + DateTime.Now.AddDays(-30).ToString("MM/dd/yyyy") + "# " +
                    "AND #" + DateTime.Now.AddDays(1).ToString("MM/dd/yyyy") + "# AND s.Due <> 0";
                }

                gridView1Generator(sql, sql1);

            }

            else if (checkBoxforIndividual.Checked && checkBoxDue.Checked)
            {
                //string name = txtMobileNo.Text.ToString();
                string sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.CreatedDate AS [Date]
                        FROM (Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) WHERE d.CustomerMobile = '" + txtMobileNo.Text.Trim() + "' AND s.Due <> 0";
                string sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM (((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID) LEFT JOIN Customer c ON c.ID = s.CustomerId WHERE c.CustomerMobile = '" + txtMobileNo.Text.Trim() + "' AND s.Due <> 0";
                gridView1Generator(sql, sql1);
            }
            else if (checkBoxforIndividual.Checked)
            {
                string sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.CreatedDate AS [Date]
                        FROM (Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) WHERE d.CustomerMobile = '" + txtMobileNo.Text.Trim() + "'";
                string sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM (((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID) LEFT JOIN Customer c ON c.ID = s.CustomerId WHERE c.CustomerMobile = '" + txtMobileNo.Text.Trim() + "'";
                gridView1Generator(sql, sql1);
            }

            else if (checkBoxDue.Checked)
            {
                string sql = @"SELECT s.ID, d.CustomerName, d.CustomerMobile, s.TotalPayable AS [Total Amount], s.Due, s.Discount, s.CreatedDate AS [Date]
                        FROM (Sales AS s LEFT JOIN Customer AS d ON s.CustomerId = d.ID) WHERE s.Due <> 0";
                string sql1 = @"SELECT s.ID, s.CreatedDate, d.ID, d.Quantity, d.SellingPrice, d.GivenVat, d.VatPaid, d.TotalPrice, p.ID, p.Vat, p.VatType, p.TotalQuantity,
                              p.PaidAmount, p.CostPerUnit, p.CreateDate, pd.ID, pd.GivenVat, pd.RemainQuantity FROM (((Sales s LEFT JOIN SalesDetails d ON s.ID = d.SalesId)
                              LEFT JOIN Products p ON p.ID = d.ProductId) LEFT JOIN ProductDetails pd ON p.ID = pd.ProductID) LEFT JOIN Customer c ON c.ID = s.CustomerId WHERE s.Due <> 0";
                gridView1Generator(sql, sql1);
            }
            

        }

        void profitCalculator(string sql)
        {
            double totalCostPerUnit = 0, totalSellingPrice = 0, soldQuantity = 0, costPerUnit = 0, profit = 0, dueVat = 0, customerGivenVat = 0, sellerGivenVat = 0;
            double totalQuantity = 0, pdGivenVat = 0, vatPaid = 0;
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
                costPerUnit = dt1.Rows.Count > 0 && !string.IsNullOrEmpty(dt1.Rows[i]["CostPerUnit"].ToString()) ? Convert.ToInt64(dt1.Rows[i]["CostPerUnit"]) : 0;
                //costPerUnit = dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0][2].ToString()) ? Convert.ToDouble(dt.Rows[0][2]) : 0;
                //soldQuantity = Convert.ToDouble(dt1.Rows[i]["Quantity"]);
                soldQuantity = dt1.Rows.Count > 0 && !string.IsNullOrEmpty(dt1.Rows[i]["Quantity"].ToString()) ? Convert.ToInt64(dt1.Rows[i]["Quantity"]) : 0;
                //totalQuantity = Convert.ToDouble(dt1.Rows[i]["TotalQuantity"]);
                totalQuantity = dt1.Rows.Count > 0 && !string.IsNullOrEmpty(dt1.Rows[i]["TotalQuantity"].ToString()) ? Convert.ToInt64(dt1.Rows[i]["TotalQuantity"]) : 0;
                totalCostPerUnit = totalCostPerUnit + (costPerUnit * soldQuantity);
                //totalSellingPrice = totalSellingPrice + Convert.ToDouble(dt1.Rows[i]["TotalPrice"]);
                totalSellingPrice = totalSellingPrice + (dt1.Rows.Count > 0 && !string.IsNullOrEmpty(dt1.Rows[i]["TotalPrice"].ToString()) ? Convert.ToInt64(dt1.Rows[i]["TotalPrice"]) : 0);
                //customerGivenVat = customerGivenVat + Convert.ToDouble(dt1.Rows[i]["d.GivenVat"]);
                customerGivenVat = customerGivenVat + (dt1.Rows.Count > 0 && !string.IsNullOrEmpty(dt1.Rows[i]["d.GivenVat"].ToString()) ? Convert.ToInt64(dt1.Rows[i]["d.GivenVat"]) : 0);
                vatPaid = (dt1.Rows.Count > 0 && !string.IsNullOrEmpty(dt1.Rows[i]["VatPaid"].ToString()) ? Convert.ToDouble(dt1.Rows[i]["VatPaid"]) : 0);
                //sellerGivenVat = sellerGivenVat + ((Convert.ToDouble(dt1.Rows[i]["pd.GivenVat"]) / totalQuantity) * soldQuantity);
                pdGivenVat = dt1.Rows.Count > 0 && !string.IsNullOrEmpty(dt1.Rows[i]["pd.GivenVat"].ToString()) ? Convert.ToInt64(dt1.Rows[i]["pd.GivenVat"]) : 0;
                sellerGivenVat = sellerGivenVat + vatPaid + ((pdGivenVat) / totalQuantity) * soldQuantity;

                //quantity = Convert.ToDouble(dt1.Rows[i]["Quantity"]);
                //if (dt1.Rows[i]["SellingPrice"] != DBNull.Value) sellingPrice = sellingPrice + (Convert.ToDouble(dt1.Rows[i]["SellingPrice"])*quantity);
            }

            profit = totalSellingPrice - totalCostPerUnit;
            lblCollectedVat.Text = Convert.ToString(customerGivenVat);
            lblPaidVat.Text = Convert.ToString(sellerGivenVat);
            dueVat = customerGivenVat - sellerGivenVat;

            lblDueVat.Text = Convert.ToString(Math.Round(dueVat, 2));
            

            lblTotalProfit.Text = Convert.ToString(Math.Round(profit, 2));
            lblTotalCost.Text = Convert.ToString(Math.Round(totalCostPerUnit, 2));
           
        }

        void gridView1Generator(string sql, string sql1) {
            DataTable dt = (DataTable)Select(sql).Data;
            dataGridView1.DataSource = dt;

            //DataTable dt1 = (DataTable)Select(sql1).Data;
            //double 
            profitCalculator(sql1);

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.AutoGenerateColumns = false;
            if (dataGridView1.Columns.Count == 7)
            {
                DataGridViewLinkColumn edit = new DataGridViewLinkColumn();
                edit.UseColumnTextForLinkValue = true;
                edit.HeaderText = "Payment";
                edit.DataPropertyName = "lnkColumn";
                edit.LinkBehavior = LinkBehavior.AlwaysUnderline;
                edit.Text = "Payment";
                edit.LinkColor = Color.Blue;
                dataGridView1.Columns.Add(edit);


                DataGridViewLinkColumn viewDetails = new DataGridViewLinkColumn();
                viewDetails.UseColumnTextForLinkValue = true;
                viewDetails.HeaderText = "View";
                viewDetails.DataPropertyName = "lnkColumn";
                viewDetails.LinkBehavior = LinkBehavior.AlwaysUnderline;
                viewDetails.Text = "View Details";
                viewDetails.LinkColor = Color.Blue;
                dataGridView1.Columns.Add(viewDetails);
            }
            dataGridView1.Refresh();
            //dataGridView1.AutoGenerateColumns = false;
            //dataGridView1.Refresh();
            GrandTotalAmountofGridview1();
            GrandTotalDueofGridview1();
        }

        public void GrandTotalAmountofGridview1()
        {
            double totaQty = 0;
            for (int a = 0; a < dataGridView1.Rows.Count - 1; a++)
            {
                var valueQty = dataGridView1.Rows[a].Cells[3].Value.ToString();
                if (valueQty != DBNull.Value.ToString())
                {
                    totaQty += Convert.ToDouble(valueQty);
                }
            }
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Style.BackColor = Color.Gray;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Value = "Total";
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[3].Value = totaQty.ToString();
            lblTotalSale.Text = totaQty.ToString();

        }
        public void GrandTotalDueofGridview1()
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
            //dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Style.BackColor = Color.Gray;
            //dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Value = "Total ";
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[4].Value = totaQty.ToString();
            lblTotalDue.Text = totaQty.ToString();

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

        
    }
 }

