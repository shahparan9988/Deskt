using MaterialSkin;
using MaterialSkin.Controls;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using Color = System.Drawing.Color;

namespace Model
{
    public class Common : Form
    {
        static string conString = null;
        public Common()
        {
            string path = Environment.CurrentDirectory;
            string databasePath = @"\DB\Racssoft-Dokan.accdb;";
            path = path + databasePath;
            conString = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path);
            //conString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}", path);
            //con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path);
        }

        public Result CUD(string sql)
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
                //LogGenerate(ex.GetHashCode(), ex.InnerException.ToString(), ex.Message);
                return result;
            }
            finally
            {
                //con.Close();
            }
        }

       
        //    catch (Exception ex)
        //    {
        //        result = GetResult(false, ex.GetHashCode(), 100);
        //        //LogGenerate(ex.GetHashCode(), ex.InnerException.ToString(), ex.Message);
        //        return result;
        //    }
        //    finally
        //    {
        //        //con.Close();
        //    }
        //}
        public Result Select(string sql)
        {
            Result result = new Result();
            result.IsSuccess = false;
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
                        result.IsSuccess = true;
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                result = GetResult(false, ex.GetHashCode(), 100);
                LogGenerate(ex.GetHashCode(), ex.InnerException?.ToString(), ex.Message);
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

        private void Common_Load(object sender, EventArgs e)
        {

        }
        public struct RGBColor
        {
            public static Color color1 = Color.FromArgb(39, 39, 58);
            public static Color color2 = Color.FromArgb(39, 33, 55);
        }
        public void LoadTheme(Form frm)
        {
            foreach (Control btns in frm.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = RGBColor.color1;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = RGBColor.color1;
                    btn.Font = new System.Drawing.Font("Microsoft YaHei", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    btn.Size = new Size(80, 30);
                    btn.FlatStyle = FlatStyle.Flat;
                }
            }
            //label
            foreach (Control lbls in frm.Controls)
            {
                if (lbls.GetType() == typeof(Label))
                {
                    Label lbl = (Label)lbls;

                    lbl.ForeColor = RGBColor.color1;
                    lbl.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
            //GroupBox
            foreach (Control gpBs in frm.Controls)
            {
                if (gpBs.GetType() == typeof(GroupBox))
                {
                    GroupBox gpB = (GroupBox)gpBs;

                    gpB.ForeColor = RGBColor.color1;
                    gpB.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
            //ChekBox
            foreach (Control ckBs in frm.Controls)
            {
                if (ckBs.GetType() == typeof(CheckBox))
                {
                    CheckBox ckB = (CheckBox)ckBs;

                    ckB.ForeColor = RGBColor.color1;
                    ckB.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
            //DGV
            foreach (Control dgvs in frm.Controls)
            {
                if (dgvs.GetType() == typeof(DataGridView))
                {
                    DataGridView dgv = (DataGridView)dgvs;

                    dgv.EnableHeadersVisualStyles = false;
                    dgv.GridColor = RGBColor.color2;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = RGBColor.color1;
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft YaHei", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft YaHei", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    dgv.DefaultCellStyle.SelectionBackColor = Color.Gainsboro;
                    dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
                }
            }
        }
    
    private void LogGenerate(int code, string shortMessage, string message)
        {
            string log = "INSERT INTO Logs(IsSuccess, Message, CreatedDate, UserId, FormName) VALUES ('0', '', '" + DateTime.Now + "', 1, '')";

            CUD(log);
        }
    }
}
