
namespace Racssoft_Dokan.Pages
{
    partial class FundTransactionHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FundTransactionHistory));
            this.dataGridViewFundHistory = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFundHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewFundHistory
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Righteous", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewFundHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewFundHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewFundHistory.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewFundHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFundHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFundHistory.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewFundHistory.Name = "dataGridViewFundHistory";
            this.dataGridViewFundHistory.Size = new System.Drawing.Size(800, 485);
            this.dataGridViewFundHistory.TabIndex = 0;
            // 
            // FundTransactionHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 485);
            this.Controls.Add(this.dataGridViewFundHistory);
            this.Font = new System.Drawing.Font("Righteous", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FundTransactionHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FundTransactionHistory";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFundHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewFundHistory;
    }
}