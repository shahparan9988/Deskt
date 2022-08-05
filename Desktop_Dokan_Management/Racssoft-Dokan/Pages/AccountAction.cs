using System;
using Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace Racssoft_Dokan.Pages
{
    public partial class AccountAction : Common
    {

        static long id;
        static BalanceSheetGrid balanceSheetGrid;

        void initial(long ID)
        {
            balanceSheetGrid = new BalanceSheetGrid();
            string sql = @"SELECT Title, AccountNo, Amount FROM DigitalWallet WHERE ID = " + ID + "";
            DataTable dt = (DataTable)Select(sql).Data;
            lblAccountName.Text = Convert.ToString(dt.Rows[0]["Title"]);
            lblAccountNo.Text = Convert.ToString(dt.Rows[0]["AccountNo"]);
            lblAccountBalance.Text = Convert.ToString(dt.Rows[0]["Amount"]);
        }
        public AccountAction(long ID)
        {
            id = ID;
            InitializeComponent();
            initial(ID);
            BalanceSheetGridGenerator();
        }

        void BalanceSheetGridGenerator()
        {
            long balanceSheetId = getMaxId("SELECT MAX(Id) FROM BalanceSheet");
            string balanceSheetSql = "SELECT * FROM BalanceSheet WHERE ID = " + balanceSheetId + "";
            DataTable dt = (DataTable)Select(balanceSheetSql).Data;
            if (dt.Rows.Count > 0)
            {
                balanceSheetGrid.ID = dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0][0].ToString()) ? Convert.ToInt64(dt.Rows[0][0]) : 0;
                balanceSheetGrid.CurrentBalance = dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0][2].ToString()) ? Convert.ToDouble(dt.Rows[0][2]) : 0;
                balanceSheetGrid.TotalCredit = dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0][3].ToString()) ? Convert.ToDouble(dt.Rows[0][3]) : 0;
                balanceSheetGrid.TotalDebit = dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0][5].ToString()) ? Convert.ToDouble(dt.Rows[0][5]) : 0;
                balanceSheetGrid.UpdatedDate = Convert.ToDateTime(dt.Rows[0]["UpdatedDate"]);
            }

            

        }
        private void comboDepositMoney_CheckedChanged(object sender, EventArgs e)
        {
            if (comboDepositMoney.Checked)
            {
                gBoxDepositMoney.Enabled = true;
                numericDeposit.Value = 0;
            }

            if (comboDepositMoney.Checked != true)
            {
                gBoxDepositMoney.Enabled = false;
                numericDeposit.Value = 0;
            }
        }

        private void comboWithdrawMoney_CheckedChanged(object sender, EventArgs e)
        {
            if (comboWithdrawMoney.Checked)
            {
                gBoxWithdrawMoney.Enabled = true;
                numericWithdraw.Value = 0;
            }

            if (comboWithdrawMoney.Checked != true)
            {
                gBoxWithdrawMoney.Enabled = false;
                numericWithdraw.Value = 0;
            }
        }

        long getMaxId(string cmd)
        {
            DataTable dt;
            //cmd = "SELECT MAX(Id) FROM Products";
            dt = (DataTable)Select(cmd).Data;
            long id = dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0][0].ToString()) ? Convert.ToInt64(dt.Rows[0][0]) : 0;
            return id;
        }

        public double DigitalWalletBalance()
        {
            string digitalWalletSql = @"SELECT * FROM DigitalWallet";
            DataTable digitalWalletDt = (DataTable)Select(digitalWalletSql).Data;
            double totalDigitalWalletBalance = 0;
            for (int i = 0; i < digitalWalletDt.Rows.Count; i++)
            {
                totalDigitalWalletBalance = totalDigitalWalletBalance + Convert.ToDouble(digitalWalletDt.Rows[i]["Amount"]);
            }
            return totalDigitalWalletBalance;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BalanceSheetGridGenerator();
            double depositMoney = Convert.ToDouble(numericDeposit.Value);
            double withdrawMoney = Convert.ToDouble(numericWithdraw.Value);
            double balanceSheetId = getMaxId("SELECT MAX(ID) FROM BalanceSheet");

            double transactedMoney = depositMoney - withdrawMoney;
            if (transactedMoney < 0) transactedMoney = -transactedMoney;

            double balance = Convert.ToDouble(lblAccountBalance.Text.ToString());
            string transactionType = "";
            string detailPurpose = richTextTransactionPurpose.Text.ToString();
            
            if ((depositMoney - withdrawMoney) != 0)
            {
                if ((depositMoney - withdrawMoney) > 0) transactionType = "DEPOSITED";
                if ((withdrawMoney - depositMoney) > 0) transactionType = "WITHDRAWN";
                double newBalance = balance + depositMoney - withdrawMoney;
                if (newBalance >= 0)
                {
                    string sql = @"UPDATE DigitalWallet SET Amount = " + newBalance + " WHERE ID = " + id + "";
                    CUD(sql);
                    string sql1 = @"INSERT INTO DigitalWallet_History(DigitalWalletId, TransactionType, DetailPurpose, TransactedAmount, UpdatedDate, BalanceSheetId)
                            VALUES(" + id + ", '" + transactionType + "','" + detailPurpose + "', " + transactedMoney + ", '" + DateTime.Now + "', " + balanceSheetId + ")";
                    CUD(sql1);
                    balanceSheetGrid.TotalCredit += depositMoney;
                    balanceSheetGrid.TotalDebit += withdrawMoney;
                    //AccountInfo a = new AccountInfo();
                    //getAccountInfo();


                    double totalBalance = DigitalWalletBalance();
                    balanceSheetGrid.CurrentBalance = totalBalance;
                    


                    if (balanceSheetGrid.ID > 0)
                    {
                        string sqlBalanceSheet = @"UPDATE BalanceSheet SET CurrentBalance = " + balanceSheetGrid.CurrentBalance + ", " +
                            " TotalCredit = " + balanceSheetGrid.TotalCredit + ", TotalDebit = " + balanceSheetGrid.TotalDebit + " WHERE ID = " + balanceSheetGrid.ID + "";
                        CUD(sqlBalanceSheet);

                    }

                    else if(balanceSheetGrid.ID < 1)
                    {
                        balanceSheetGrid.OpeningBalance = totalBalance;
                        balanceSheetGrid.CreditLiability = 0;
                        balanceSheetGrid.DebitLiability = 0;
                        string sqlBalanceSheet = @"INSERT INTO BalanceSheet (OpeningBalance, CurrentBalance, TotalCredit, 
                        CreditLiability, TotalDebit, debitLiability, UpdatedDate) VALUES (" + balanceSheetGrid.OpeningBalance + "," +
                        "" + balanceSheetGrid.CurrentBalance + ", " + balanceSheetGrid.TotalCredit + "," +
                        "" + balanceSheetGrid.CreditLiability + ", " + balanceSheetGrid.TotalDebit + "," +
                        "" + balanceSheetGrid.DebitLiability + ", '" + DateTime.Now + "')";
                        CUD(sqlBalanceSheet);
                        BalanceSheetGridGenerator();
                    }
                    }
                    else MessageBox.Show("You have not enough balance to withdraw!!!");

            }

            
            initial(id);
            comboDepositMoney.Checked = false;
            comboWithdrawMoney.Checked = false;
            richTextTransactionPurpose.Text = "";
        }
    }
}
