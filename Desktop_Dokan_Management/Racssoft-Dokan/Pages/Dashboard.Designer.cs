
namespace Racssoft_Dokan.Pages
{
    partial class Dashboard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Others = new System.Windows.Forms.RadioButton();
            this.Female = new System.Windows.Forms.RadioButton();
            this.Male = new System.Windows.Forms.RadioButton();
            this.isDeletedBox = new System.Windows.Forms.CheckBox();
            this.createdDateBox = new System.Windows.Forms.DateTimePicker();
            this.addressBox = new System.Windows.Forms.RichTextBox();
            this.cityBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ageBox = new System.Windows.Forms.TextBox();
            this.phoneNoBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.saleChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saleChart)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Others);
            this.groupBox1.Controls.Add(this.Female);
            this.groupBox1.Controls.Add(this.Male);
            this.groupBox1.Controls.Add(this.isDeletedBox);
            this.groupBox1.Controls.Add(this.createdDateBox);
            this.groupBox1.Controls.Add(this.addressBox);
            this.groupBox1.Controls.Add(this.cityBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ageBox);
            this.groupBox1.Controls.Add(this.phoneNoBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nameBox);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSignIn);
            this.groupBox1.Controls.Add(this.saleChart);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(881, 449);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dashboard";
            // 
            // Others
            // 
            this.Others.AutoSize = true;
            this.Others.Location = new System.Drawing.Point(655, 419);
            this.Others.Name = "Others";
            this.Others.Size = new System.Drawing.Size(81, 24);
            this.Others.TabIndex = 11;
            this.Others.TabStop = true;
            this.Others.Text = "Others";
            this.Others.UseVisualStyleBackColor = true;
            // 
            // Female
            // 
            this.Female.AutoSize = true;
            this.Female.Location = new System.Drawing.Point(655, 389);
            this.Female.Name = "Female";
            this.Female.Size = new System.Drawing.Size(86, 24);
            this.Female.TabIndex = 11;
            this.Female.TabStop = true;
            this.Female.Text = "Female";
            this.Female.UseVisualStyleBackColor = true;
            // 
            // Male
            // 
            this.Male.AutoSize = true;
            this.Male.Location = new System.Drawing.Point(655, 359);
            this.Male.Name = "Male";
            this.Male.Size = new System.Drawing.Size(65, 24);
            this.Male.TabIndex = 11;
            this.Male.TabStop = true;
            this.Male.Text = "Male";
            this.Male.UseVisualStyleBackColor = true;
            this.Male.CheckedChanged += new System.EventHandler(this.Male_CheckedChanged);
            // 
            // isDeletedBox
            // 
            this.isDeletedBox.AutoSize = true;
            this.isDeletedBox.Location = new System.Drawing.Point(503, 326);
            this.isDeletedBox.Name = "isDeletedBox";
            this.isDeletedBox.Size = new System.Drawing.Size(104, 24);
            this.isDeletedBox.TabIndex = 10;
            this.isDeletedBox.Text = "isDeleted";
            this.isDeletedBox.UseVisualStyleBackColor = true;
            this.isDeletedBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // createdDateBox
            // 
            this.createdDateBox.Location = new System.Drawing.Point(655, 291);
            this.createdDateBox.Name = "createdDateBox";
            this.createdDateBox.Size = new System.Drawing.Size(199, 26);
            this.createdDateBox.TabIndex = 9;
            // 
            // addressBox
            // 
            this.addressBox.Location = new System.Drawing.Point(655, 148);
            this.addressBox.Name = "addressBox";
            this.addressBox.Size = new System.Drawing.Size(199, 96);
            this.addressBox.TabIndex = 8;
            this.addressBox.Text = "";
            // 
            // cityBox
            // 
            this.cityBox.FormattingEnabled = true;
            this.cityBox.Location = new System.Drawing.Point(655, 114);
            this.cityBox.Name = "cityBox";
            this.cityBox.Size = new System.Drawing.Size(199, 28);
            this.cityBox.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(501, 363);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Age";
            this.label7.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(501, 296);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Created Date";
            this.label6.Click += new System.EventHandler(this.label5_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(501, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Age";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // ageBox
            // 
            this.ageBox.Location = new System.Drawing.Point(655, 250);
            this.ageBox.Name = "ageBox";
            this.ageBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ageBox.Size = new System.Drawing.Size(199, 26);
            this.ageBox.TabIndex = 6;
            // 
            // phoneNoBox
            // 
            this.phoneNoBox.Location = new System.Drawing.Point(655, 82);
            this.phoneNoBox.Name = "phoneNoBox";
            this.phoneNoBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.phoneNoBox.Size = new System.Drawing.Size(199, 26);
            this.phoneNoBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(501, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(501, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "City";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(501, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Phone No";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(655, 50);
            this.nameBox.Name = "nameBox";
            this.nameBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.nameBox.Size = new System.Drawing.Size(199, 26);
            this.nameBox.TabIndex = 4;
            this.nameBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(49, 453);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 61);
            this.button1.TabIndex = 2;
            this.button1.Text = "Sign In";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(501, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "User Name";
            // 
            // btnSignIn
            // 
            this.btnSignIn.Location = new System.Drawing.Point(363, 193);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(90, 61);
            this.btnSignIn.TabIndex = 2;
            this.btnSignIn.Text = "Sign In";
            this.btnSignIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSignIn.UseVisualStyleBackColor = true;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // saleChart
            // 
            chartArea2.Name = "ChartArea1";
            this.saleChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.saleChart.Legends.Add(legend2);
            this.saleChart.Location = new System.Drawing.Point(31, 25);
            this.saleChart.Name = "saleChart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "sale";
            this.saleChart.Series.Add(series2);
            this.saleChart.Size = new System.Drawing.Size(300, 389);
            this.saleChart.TabIndex = 1;
            this.saleChart.Tag = "";
            this.saleChart.Text = "saleChart";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title1";
            title2.Text = "Sale";
            this.saleChart.Titles.Add(title2);
            this.saleChart.UseWaitCursor = true;
            this.saleChart.Click += new System.EventHandler(this.pieChart_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 450);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saleChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.DataVisualization.Charting.Chart saleChart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox addressBox;
        private System.Windows.Forms.ComboBox cityBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox phoneNoBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ageBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker createdDateBox;
        private System.Windows.Forms.RadioButton Male;
        private System.Windows.Forms.CheckBox isDeletedBox;
        private System.Windows.Forms.RadioButton Others;
        private System.Windows.Forms.RadioButton Female;
        private System.Windows.Forms.Label label7;
    }
}