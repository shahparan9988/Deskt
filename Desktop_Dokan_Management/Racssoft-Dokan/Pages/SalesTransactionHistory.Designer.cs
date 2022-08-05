
namespace Racssoft_Dokan.Pages
{
    partial class SalesTransactionHistory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesTransactionHistory));
            this.dataGridViewSalesHistory = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSalesHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewSalesHistory
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Righteous", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewSalesHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewSalesHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSalesHistory.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewSalesHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSalesHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSalesHistory.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewSalesHistory.Name = "dataGridViewSalesHistory";
            this.dataGridViewSalesHistory.Size = new System.Drawing.Size(800, 485);
            this.dataGridViewSalesHistory.TabIndex = 0;
            this.dataGridViewSalesHistory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSalesHistory_CellContentClick);
            // 
            // SalesTransactionHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(800, 485);
            this.Controls.Add(this.dataGridViewSalesHistory);
            this.Font = new System.Drawing.Font("Righteous", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SalesTransactionHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Transaction History";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSalesHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSalesHistory;
    }
}