
namespace Racssoft_Dokan.Pages
{
    partial class ExpenseTransactionHistory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExpenseTransactionHistory));
            this.dataGridViewExpenseHistory = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpenseHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewExpenseHistory
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Righteous", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewExpenseHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewExpenseHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewExpenseHistory.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewExpenseHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExpenseHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewExpenseHistory.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewExpenseHistory.Name = "dataGridViewExpenseHistory";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Righteous", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewExpenseHistory.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewExpenseHistory.Size = new System.Drawing.Size(800, 485);
            this.dataGridViewExpenseHistory.TabIndex = 0;
            // 
            // ExpenseTransactionHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(800, 485);
            this.Controls.Add(this.dataGridViewExpenseHistory);
            this.Font = new System.Drawing.Font("Righteous", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExpenseTransactionHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expense Transaction History";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpenseHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewExpenseHistory;
    }
}