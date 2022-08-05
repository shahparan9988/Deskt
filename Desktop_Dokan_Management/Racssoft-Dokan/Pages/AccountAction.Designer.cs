
namespace Racssoft_Dokan.Pages
{
    partial class AccountAction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountAction));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextTransactionPurpose = new System.Windows.Forms.RichTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.comboWithdrawMoney = new System.Windows.Forms.CheckBox();
            this.gBoxWithdrawMoney = new System.Windows.Forms.GroupBox();
            this.numericWithdraw = new System.Windows.Forms.NumericUpDown();
            this.comboDepositMoney = new System.Windows.Forms.CheckBox();
            this.gBoxDepositMoney = new System.Windows.Forms.GroupBox();
            this.numericDeposit = new System.Windows.Forms.NumericUpDown();
            this.lblAccountBalance = new System.Windows.Forms.Label();
            this.lblAccountNo = new System.Windows.Forms.Label();
            this.lblAccountName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.gBoxWithdrawMoney.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericWithdraw)).BeginInit();
            this.gBoxDepositMoney.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericDeposit)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.groupBox1.Controls.Add(this.richTextTransactionPurpose);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.comboWithdrawMoney);
            this.groupBox1.Controls.Add(this.gBoxWithdrawMoney);
            this.groupBox1.Controls.Add(this.comboDepositMoney);
            this.groupBox1.Controls.Add(this.gBoxDepositMoney);
            this.groupBox1.Controls.Add(this.lblAccountBalance);
            this.groupBox1.Controls.Add(this.lblAccountNo);
            this.groupBox1.Controls.Add(this.lblAccountName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Righteous", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(378, 403);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Accounts";
            // 
            // richTextTransactionPurpose
            // 
            this.richTextTransactionPurpose.Location = new System.Drawing.Point(185, 270);
            this.richTextTransactionPurpose.Name = "richTextTransactionPurpose";
            this.richTextTransactionPurpose.Size = new System.Drawing.Size(162, 82);
            this.richTextTransactionPurpose.TabIndex = 5;
            this.richTextTransactionPurpose.Text = "";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(141)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(292, 367);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(55, 27);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // comboWithdrawMoney
            // 
            this.comboWithdrawMoney.AutoSize = true;
            this.comboWithdrawMoney.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboWithdrawMoney.Location = new System.Drawing.Point(35, 220);
            this.comboWithdrawMoney.Name = "comboWithdrawMoney";
            this.comboWithdrawMoney.Size = new System.Drawing.Size(120, 20);
            this.comboWithdrawMoney.TabIndex = 3;
            this.comboWithdrawMoney.Text = "Withdraw Money";
            this.comboWithdrawMoney.UseVisualStyleBackColor = true;
            this.comboWithdrawMoney.CheckedChanged += new System.EventHandler(this.comboWithdrawMoney_CheckedChanged);
            // 
            // gBoxWithdrawMoney
            // 
            this.gBoxWithdrawMoney.Controls.Add(this.numericWithdraw);
            this.gBoxWithdrawMoney.Enabled = false;
            this.gBoxWithdrawMoney.Location = new System.Drawing.Point(185, 199);
            this.gBoxWithdrawMoney.Name = "gBoxWithdrawMoney";
            this.gBoxWithdrawMoney.Size = new System.Drawing.Size(162, 51);
            this.gBoxWithdrawMoney.TabIndex = 2;
            this.gBoxWithdrawMoney.TabStop = false;
            // 
            // numericWithdraw
            // 
            this.numericWithdraw.Location = new System.Drawing.Point(28, 18);
            this.numericWithdraw.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numericWithdraw.Name = "numericWithdraw";
            this.numericWithdraw.Size = new System.Drawing.Size(109, 22);
            this.numericWithdraw.TabIndex = 0;
            this.numericWithdraw.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // comboDepositMoney
            // 
            this.comboDepositMoney.AutoSize = true;
            this.comboDepositMoney.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboDepositMoney.Location = new System.Drawing.Point(35, 160);
            this.comboDepositMoney.Name = "comboDepositMoney";
            this.comboDepositMoney.Size = new System.Drawing.Size(109, 20);
            this.comboDepositMoney.TabIndex = 3;
            this.comboDepositMoney.Text = "Deposit Money";
            this.comboDepositMoney.UseVisualStyleBackColor = true;
            this.comboDepositMoney.CheckedChanged += new System.EventHandler(this.comboDepositMoney_CheckedChanged);
            // 
            // gBoxDepositMoney
            // 
            this.gBoxDepositMoney.Controls.Add(this.numericDeposit);
            this.gBoxDepositMoney.Enabled = false;
            this.gBoxDepositMoney.Location = new System.Drawing.Point(185, 139);
            this.gBoxDepositMoney.Name = "gBoxDepositMoney";
            this.gBoxDepositMoney.Size = new System.Drawing.Size(162, 51);
            this.gBoxDepositMoney.TabIndex = 2;
            this.gBoxDepositMoney.TabStop = false;
            // 
            // numericDeposit
            // 
            this.numericDeposit.Location = new System.Drawing.Point(28, 18);
            this.numericDeposit.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numericDeposit.Name = "numericDeposit";
            this.numericDeposit.Size = new System.Drawing.Size(109, 22);
            this.numericDeposit.TabIndex = 0;
            this.numericDeposit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblAccountBalance
            // 
            this.lblAccountBalance.AutoSize = true;
            this.lblAccountBalance.Location = new System.Drawing.Point(182, 117);
            this.lblAccountBalance.Name = "lblAccountBalance";
            this.lblAccountBalance.Size = new System.Drawing.Size(16, 16);
            this.lblAccountBalance.TabIndex = 0;
            this.lblAccountBalance.Text = "0";
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Location = new System.Drawing.Point(182, 83);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(16, 16);
            this.lblAccountNo.TabIndex = 0;
            this.lblAccountNo.Text = "0";
            // 
            // lblAccountName
            // 
            this.lblAccountName.AutoSize = true;
            this.lblAccountName.Location = new System.Drawing.Point(182, 46);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(16, 16);
            this.lblAccountName.TabIndex = 0;
            this.lblAccountName.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 275);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Transaction Purpose";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Balance";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Account No";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account Name";
            // 
            // AccountAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(383, 409);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AccountAction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AccountAction";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gBoxWithdrawMoney.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericWithdraw)).EndInit();
            this.gBoxDepositMoney.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericDeposit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblAccountBalance;
        private System.Windows.Forms.Label lblAccountNo;
        private System.Windows.Forms.Label lblAccountName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox comboWithdrawMoney;
        private System.Windows.Forms.GroupBox gBoxWithdrawMoney;
        private System.Windows.Forms.NumericUpDown numericWithdraw;
        private System.Windows.Forms.CheckBox comboDepositMoney;
        private System.Windows.Forms.GroupBox gBoxDepositMoney;
        private System.Windows.Forms.NumericUpDown numericDeposit;
        private System.Windows.Forms.RichTextBox richTextTransactionPurpose;
        private System.Windows.Forms.Label label2;
    }
}