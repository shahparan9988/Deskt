using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Racssoft_Dokan
{
    public partial class Common : Form
    {
        //public OleDbConnection con;
        //public OleDbCommand cmd;
        //public OleDbDataAdapter adapter;
        //public readonly DataTable dt = new DataTable();
        string conString = null;
        public Common()
        {
            InitializeComponent();
            string path = Environment.CurrentDirectory;
            string databasePath = @"\DB\Racssoft-Dokan.accdb;";
            path = path + databasePath;
            conString = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path);
            //conString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}", path);
            //con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path);
        }

        public Result Create(string sql)
        {
            Result result = new Result();
            result = GetResult(false, 0, 0);
            try
            {
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    using (OleDbCommand cmd = new OleDbCommand(sql, con))
                    {
                        con.Open();

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            result = GetResult(true, 0, 1);
                        }
                    }
                }


                return result;
            }
            catch (Exception ex)
            {
                result = GetResult(false, ex.GetHashCode(), 100);
                LogGenerate(ex.GetHashCode(), ex.InnerException.ToString(), ex.Message);
                return result;
            }
            finally
            {
                //con.Close();
            }
        }
        public Result Select(string sql)
        {
            Result result = new Result();
            result = GetResult(false, 0, 0);
            try
            {
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    using (OleDbCommand cmd = new OleDbCommand(sql, con))
                    {
                        con.Open();

                        DataTable table = new DataTable();
                        OleDbDataAdapter adapter = new OleDbDataAdapter();
                        adapter.SelectCommand = cmd;
                        adapter.Fill(table);
                        result.Data = table;
                    }
                }


                return result;
            }
            catch (Exception ex)
            {
                result = GetResult(false, ex.GetHashCode(), 100);
                LogGenerate(ex.GetHashCode(), ex.InnerException.ToString(), ex.Message);
                return result;
            }
            finally
            {
                //con.Close();
            }
        }
        private Result GetResult(bool isSuccess, int code, int messageType)
        {
            Result result = new Result();
            string message = null;
            switch (messageType)
            {
                case 1: message = ""; break;
                case 2: message = ""; break;
                case 3: message = ""; break;
            }
            result.Message = message;
            result.IsSuccess = isSuccess;
            result.Code = code;

            return result;
        }
        private void LogGenerate(int code, string shortMessage, string message)
        {
            string log = "";
        }
    }
}
