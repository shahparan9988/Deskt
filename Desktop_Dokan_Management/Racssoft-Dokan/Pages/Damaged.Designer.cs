
namespace Racssoft_Dokan.Pages
{
    partial class Damaged
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Damaged));
            this.groupDamaged = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.numericDamagedUnitPrice = new System.Windows.Forms.NumericUpDown();
            this.numericDamagedQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblBuyingPrice = new System.Windows.Forms.Label();
            this.lblRemainQuantity = new System.Windows.Forms.Label();
            this.lblProductQuantity = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupDamaged.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericDamagedUnitPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDamagedQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // groupDamaged
            // 
            this.groupDamaged.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.groupDamaged.Controls.Add(this.btnSave);
            this.groupDamaged.Controls.Add(this.numericDamagedUnitPrice);
            this.groupDamaged.Controls.Add(this.numericDamagedQuantity);
            this.groupDamaged.Controls.Add(this.lblBuyingPrice);
            this.groupDamaged.Controls.Add(this.lblRemainQuantity);
            this.groupDamaged.Controls.Add(this.lblProductQuantity);
            this.groupDamaged.Controls.Add(this.lblProductName);
            this.groupDamaged.Controls.Add(this.label10);
            this.groupDamaged.Controls.Add(this.label9);
            this.groupDamaged.Controls.Add(this.label7);
            this.groupDamaged.Controls.Add(this.label5);
            this.groupDamaged.Controls.Add(this.label3);
            this.groupDamaged.Controls.Add(this.label1);
            this.groupDamaged.Location = new System.Drawing.Point(5, -1);
            this.groupDamaged.Name = "groupDamaged";
            this.groupDamaged.Size = new System.Drawing.Size(390, 229);
            this.groupDamaged.TabIndex = 1;
            this.groupDamaged.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(311, 173);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(55, 25);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // numericDamagedUnitPrice
            // 
            this.numericDamagedUnitPrice.Location = new System.Drawing.Point(132, 177);
            this.numericDamagedUnitPrice.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numericDamagedUnitPrice.Name = "numericDamagedUnitPrice";
            this.numericDamagedUnitPrice.Size = new System.Drawing.Size(120, 21);
            this.numericDamagedUnitPrice.TabIndex = 1;
            this.numericDamagedUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericDamagedQuantity
            // 
            this.numericDamagedQuantity.Location = new System.Drawing.Point(132, 150);
            this.numericDamagedQuantity.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numericDamagedQuantity.Name = "numericDamagedQuantity";
            this.numericDamagedQuantity.Size = new System.Drawing.Size(120, 21);
            this.numericDamagedQuantity.TabIndex = 1;
            this.numericDamagedQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBuyingPrice
            // 
            this.lblBuyingPrice.AutoSize = true;
            this.lblBuyingPrice.Location = new System.Drawing.Point(122, 104);
            this.lblBuyingPrice.Name = "lblBuyingPrice";
            this.lblBuyingPrice.Size = new System.Drawing.Size(14, 14);
            this.lblBuyingPrice.TabIndex = 0;
            this.lblBuyingPrice.Text = "_";
            // 
            // lblRemainQuantity
            // 
            this.lblRemainQuantity.AutoSize = true;
            this.lblRemainQuantity.Location = new System.Drawing.Point(122, 80);
            this.lblRemainQuantity.Name = "lblRemainQuantity";
            this.lblRemainQuantity.Size = new System.Drawing.Size(14, 14);
            this.lblRemainQuantity.TabIndex = 0;
            this.lblRemainQuantity.Text = "_";
            // 
            // lblProductQuantity
            // 
            this.lblProductQuantity.AutoSize = true;
            this.lblProductQuantity.Location = new System.Drawing.Point(122, 56);
            this.lblProductQuantity.Name = "lblProductQuantity";
            this.lblProductQuantity.Size = new System.Drawing.Size(14, 14);
            this.lblProductQuantity.TabIndex = 0;
            this.lblProductQuantity.Text = "_";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(122, 32);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(14, 14);
            this.lblProductName.TabIndex = 0;
            this.lblProductName.Text = "_";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 179);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 14);
            this.label10.TabIndex = 0;
            this.label10.Text = "Damaged Unit Price";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 150);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 14);
            this.label9.TabIndex = 0;
            this.label9.Text = "Damaged Quantity";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 14);
            this.label7.TabIndex = 0;
            this.label7.Text = "Buying Cost/unit";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "Remain Quantity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "Total Quantity";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product Name";
            // 
            // Damaged
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(399, 233);
            this.Controls.Add(this.groupDamaged);
            this.Font = new System.Drawing.Font("Righteous", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Damaged";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Damaged";
            this.groupDamaged.ResumeLayout(false);
            this.groupDamaged.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericDamagedUnitPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDamagedQuantity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupDamaged;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.NumericUpDown numericDamagedUnitPrice;
        private System.Windows.Forms.NumericUpDown numericDamagedQuantity;
        private System.Windows.Forms.Label lblBuyingPrice;
        private System.Windows.Forms.Label lblRemainQuantity;
        private System.Windows.Forms.Label lblProductQuantity;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}