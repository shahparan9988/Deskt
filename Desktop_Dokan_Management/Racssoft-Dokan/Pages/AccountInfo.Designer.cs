
namespace Racssoft_Dokan.Pages
{
    partial class AccountInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCreateAccount = new System.Windows.Forms.Button();
            this.numericAccountAmount = new System.Windows.Forms.NumericUpDown();
            this.txtAccountNo = new System.Windows.Forms.TextBox();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgAccounts = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.chartAccounts = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBoxFundManage = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelFundManage = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelCreateView = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericAccountAmount)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAccounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAccounts)).BeginInit();
            this.groupBoxFundManage.SuspendLayout();
            this.tableLayoutPanelFundManage.SuspendLayout();
            this.tableLayoutPanelCreateView.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnCreateAccount);
            this.groupBox1.Controls.Add(this.numericAccountAmount);
            this.groupBox1.Controls.Add(this.txtAccountNo);
            this.groupBox1.Controls.Add(this.txtAccountName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(476, 169);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create Account";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Righteous", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.label5.Location = new System.Drawing.Point(6, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(464, 35);
            this.label5.TabIndex = 5;
            this.label5.Text = "Make sure that you can not delete or edit Account Name, Account No, once an accou" +
    "nt is created!!!";
            // 
            // btnCreateAccount
            // 
            this.btnCreateAccount.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCreateAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.btnCreateAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateAccount.ForeColor = System.Drawing.Color.White;
            this.btnCreateAccount.Location = new System.Drawing.Point(329, 92);
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.Size = new System.Drawing.Size(58, 28);
            this.btnCreateAccount.TabIndex = 4;
            this.btnCreateAccount.Text = "Create Account";
            this.btnCreateAccount.UseVisualStyleBackColor = false;
            this.btnCreateAccount.Click += new System.EventHandler(this.btnCreateAccount_Click);
            // 
            // numericAccountAmount
            // 
            this.numericAccountAmount.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.numericAccountAmount.Location = new System.Drawing.Point(198, 121);
            this.numericAccountAmount.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numericAccountAmount.Name = "numericAccountAmount";
            this.numericAccountAmount.Size = new System.Drawing.Size(100, 22);
            this.numericAccountAmount.TabIndex = 3;
            this.numericAccountAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtAccountNo
            // 
            this.txtAccountNo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtAccountNo.Location = new System.Drawing.Point(198, 95);
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.Size = new System.Drawing.Size(100, 22);
            this.txtAccountNo.TabIndex = 2;
            // 
            // txtAccountName
            // 
            this.txtAccountName.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtAccountName.Location = new System.Drawing.Point(198, 67);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(100, 22);
            this.txtAccountName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(109, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Amount";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Account No";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgAccounts);
            this.groupBox2.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 207);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(476, 232);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Account Info";
            // 
            // dgAccounts
            // 
            this.dgAccounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgAccounts.BackgroundColor = System.Drawing.Color.White;
            this.dgAccounts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(114)))), ((int)(((byte)(186)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(114)))), ((int)(((byte)(186)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgAccounts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgAccounts.Location = new System.Drawing.Point(3, 18);
            this.dgAccounts.Name = "dgAccounts";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgAccounts.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgAccounts.Size = new System.Drawing.Size(470, 211);
            this.dgAccounts.TabIndex = 0;
            this.dgAccounts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAccounts_CellContentClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(96, -24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Total Balance";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.Location = new System.Drawing.Point(221, -24);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(18, 20);
            this.lblBalance.TabIndex = 2;
            this.lblBalance.Text = "0";
            // 
            // chartAccounts
            // 
            chartArea2.Name = "ChartArea1";
            this.chartAccounts.ChartAreas.Add(chartArea2);
            this.chartAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chartAccounts.Legends.Add(legend2);
            this.chartAccounts.Location = new System.Drawing.Point(491, 3);
            this.chartAccounts.Name = "chartAccounts";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartAccounts.Series.Add(series2);
            this.chartAccounts.Size = new System.Drawing.Size(482, 442);
            this.chartAccounts.TabIndex = 3;
            this.chartAccounts.Text = "chart1";
            // 
            // groupBoxFundManage
            // 
            this.groupBoxFundManage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.groupBoxFundManage.Controls.Add(this.tableLayoutPanelFundManage);
            this.groupBoxFundManage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxFundManage.Font = new System.Drawing.Font("Righteous", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxFundManage.Location = new System.Drawing.Point(3, 0);
            this.groupBoxFundManage.Name = "groupBoxFundManage";
            this.groupBoxFundManage.Size = new System.Drawing.Size(982, 474);
            this.groupBoxFundManage.TabIndex = 4;
            this.groupBoxFundManage.TabStop = false;
            this.groupBoxFundManage.Text = "Fund Manage";
            // 
            // tableLayoutPanelFundManage
            // 
            this.tableLayoutPanelFundManage.ColumnCount = 2;
            this.tableLayoutPanelFundManage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelFundManage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelFundManage.Controls.Add(this.tableLayoutPanelCreateView, 0, 0);
            this.tableLayoutPanelFundManage.Controls.Add(this.chartAccounts, 1, 0);
            this.tableLayoutPanelFundManage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelFundManage.Location = new System.Drawing.Point(3, 23);
            this.tableLayoutPanelFundManage.Name = "tableLayoutPanelFundManage";
            this.tableLayoutPanelFundManage.RowCount = 1;
            this.tableLayoutPanelFundManage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelFundManage.Size = new System.Drawing.Size(976, 448);
            this.tableLayoutPanelFundManage.TabIndex = 0;
            // 
            // tableLayoutPanelCreateView
            // 
            this.tableLayoutPanelCreateView.ColumnCount = 1;
            this.tableLayoutPanelCreateView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelCreateView.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanelCreateView.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanelCreateView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCreateView.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelCreateView.Name = "tableLayoutPanelCreateView";
            this.tableLayoutPanelCreateView.RowCount = 2;
            this.tableLayoutPanelCreateView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.15385F));
            this.tableLayoutPanelCreateView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.84615F));
            this.tableLayoutPanelCreateView.Size = new System.Drawing.Size(482, 442);
            this.tableLayoutPanelCreateView.TabIndex = 0;
            // 
            // AccountInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(988, 477);
            this.Controls.Add(this.groupBoxFundManage);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AccountInfo";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.Text = "AccountInfo";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericAccountAmount)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAccounts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAccounts)).EndInit();
            this.groupBoxFundManage.ResumeLayout(false);
            this.tableLayoutPanelFundManage.ResumeLayout(false);
            this.tableLayoutPanelCreateView.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCreateAccount;
        private System.Windows.Forms.NumericUpDown numericAccountAmount;
        private System.Windows.Forms.TextBox txtAccountNo;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgAccounts;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAccounts;
        private System.Windows.Forms.GroupBox groupBoxFundManage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFundManage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCreateView;
        private System.Windows.Forms.Label label5;
    }
}