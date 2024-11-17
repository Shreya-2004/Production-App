using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using MetroFramework;
using MetroFramework.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Configuration;

namespace Billing_App
{
    public partial class frm_client : MetroForm
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Db_Connection"].ToString());
        public frm_client()
        {
            InitializeComponent();
        }

        public static string Details;


        private void DataFetch()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_ClientMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Action", "SelectAll"));
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                grd_clienttable.DataSource = dt;
            }
            catch (Exception ex)
            {


            }
            finally
            {
                con.Close();
            }

        }

        private void frm_client_Load(object sender, EventArgs e)
        {
            DataFetch();
        }

        public void add_Data()
        {
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("SP_ClientMaster", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Action","AddClient"));
                command.Parameters.Add(new SqlParameter("@Client_Name", txt_name.Text));
                command.Parameters.Add(new SqlParameter("@Contact ", txt_contact.Text));
                command.Parameters.Add(new SqlParameter("@Email", txt_email.Text));
                command.Parameters.Add(new SqlParameter("@Address", txt_address.Text));

                int result = command.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Data Inserted Successfully", "Action");
                }
                else
                {
                    MessageBox.Show("Something went wrong", "Action");
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong", "Action");
            }
            finally
            {
                con.Close();
            }

        }


        public void Update_clientData()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_ClientMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Action","UpdateClient"));
                cmd.Parameters.Add(new SqlParameter("@Client_Name", txt_name.Text));
                cmd.Parameters.Add(new SqlParameter("@Contact", txt_contact.Text));
                cmd.Parameters.Add(new SqlParameter("@Email", txt_email.Text));
                cmd.Parameters.Add(new SqlParameter("@Address", txt_address.Text));
                cmd.Parameters.Add(new SqlParameter("@Client_ID",Convert.ToInt32(lbl_id.Text)));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Updated Successfully", "Action");
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
        }

        int selectedCell;
        private void grd_clienttable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedCell = e.RowIndex;
                lbl_id.Text = grd_clienttable.Rows[selectedCell].Cells[0].Value.ToString();
                txt_name.Text = grd_clienttable.Rows[selectedCell].Cells[1].Value.ToString();
                txt_email.Text = grd_clienttable.Rows[selectedCell].Cells[2].Value.ToString();
                txt_address.Text = grd_clienttable.Rows[selectedCell].Cells[3].Value.ToString();
                txt_contact.Text = grd_clienttable.Rows[selectedCell].Cells[4].Value.ToString();

                btn_submit.Text = "Update";
                btn_delete.Visible = true;
                btn_createinvoice.Visible = true;
                btn_searchInvoice.Visible = true;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }

        }

        public void clear_data()
        {
            try
            {
                txt_name.Clear();
                txt_email.Clear();
                txt_address.Clear();
                txt_contact.Clear();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }

        }
        private void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_name.Text == "" || txt_email.Text == "" || txt_contact.Text == "" || txt_address.Text == "")
                {
                    MessageBox.Show("Fill all Fields", "Alert");
                }
                else
                {
                    if (btn_submit.Text == "Submit")
                    {
                        DataTable dt = MatchContact();
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("Contact already Present", "Alert");
                        }
                        else
                        {
                            add_Data();
                            clear_data();
                        }
                    }
                    else
                    {
                        Update_clientData();
                        btn_submit.Text = "Submit";
                        btn_delete.Visible = false;
                        btn_createinvoice.Visible = false;
                        btn_searchInvoice.Visible = false;
                        clear_data();

                    }
                }
                DataFetch();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }

        }

        public DataTable MatchContact()
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_ClientMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "MatchContact");
                cmd.Parameters.AddWithValue("Contact", txt_contact.Text);
                dt.Load(cmd.ExecuteReader());
                con.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return dt;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_ClientMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Action","DeleteClient"));
                cmd.Parameters.Add(new SqlParameter("@Client_ID", lbl_id.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Deleted Successfully", "Action");
                btn_delete.Visible = false;
                btn_submit.Text = "Submit";
                btn_createinvoice.Visible = false;


            }
            catch (Exception ex)
            {

            }
            finally
            {
                clear_data();
                DataFetch();
                con.Close();
            }

        }

        private void btn_createinvoice_Click(object sender, EventArgs e)
        {
            try
            {
                Class_Data.Name = txt_name.Text;
                Class_Data.Email = txt_email.Text;
                Class_Data.Contact = txt_contact.Text;
                Class_Data.Address = txt_address.Text;
                Class_Data.Client_ID = lbl_id.Text;
                frm_SaleInvoice frm = new frm_SaleInvoice();
                frm.ShowDialog();
                //DataClass.value = "Hey, im from Student data";
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
        }
        string FileName;
        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            (grd_clienttable.DataSource as DataTable).DefaultView.RowFilter = String.Format("Name LIKE '%{0}%'", txt_search.Text);
        }

        private void btn_exportExcel_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = ".xls";
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                // File.WriteAllText(saveFileDialog1.FileName, grd_clienttable.ToString());
                FileName = saveFileDialog1.FileName;
            }
            else
            {
                MessageBox.Show("Cancle", "Message");
            }
            ExportExcel();
        }

        private void ExportExcel()
        {
            try
            {
                if (grd_clienttable.Rows.Count == 0)
                {
                    MessageBox.Show("No Data Found.!", "Alert.!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                //int i = 0;
                //int j = 0;


                for (int i = 1; i < grd_clienttable.Columns.Count + 1; i++)
                {

                    xlWorkSheet.Cells[1, i] = grd_clienttable.Columns[i - 1].HeaderText;

                }

                for (int i = 0; i < grd_clienttable.Rows.Count; i++)
                {

                    for (int j = 0; j < grd_clienttable.Columns.Count; j++)
                    {

                        xlWorkSheet.Cells[i + 2, j + 1] = grd_clienttable.Rows[i].Cells[j].Value.ToString();

                    }

                }

                xlWorkBook.SaveAs(@"" + FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

                MessageBox.Show("Excel Created Successfully.!", "Alert.!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
            }
            finally
            {

            }
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        public void PrintCllientData()
        {
            try
            {
                ReportDocument rptdoc = new ReportDocument();
                frm_Report_Viewer crv = new frm_Report_Viewer();
                SqlCommand cmd = new SqlCommand("SP_ClientMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Action", "printClientData"));
                cmd.Parameters.Add(new SqlParameter("@Client_ID", lbl_id.Text));
                con.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                con.Close();
                rptdoc.Load(Application.StartupPath + ("\\Report_ClientDetails.rpt"));
                rptdoc.SetDataSource(ds.Tables[0]);
                crv.crystalReportViewer1.ReportSource = rptdoc;
                crv.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            finally
            {
                con.Close();
            }
        }

        private void btn_clientReport_Click(object sender, EventArgs e)
        {
            PrintCllientData();
        }

        private void btn_searchInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                Class_Data.Name = txt_name.Text;
                Class_Data.Email = txt_email.Text;
                Class_Data.Contact = txt_contact.Text;
                Class_Data.Address = txt_address.Text;
                Class_Data.Client_ID = lbl_id.Text;
                frm_SearchInvoice frm = new frm_SearchInvoice();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {


            }
            finally
            {
                con.Close();
            }
        }

        private void grd_clienttable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
