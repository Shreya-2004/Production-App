using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using MetroFramework.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Configuration;

namespace Billing_App
{
    public partial class Stocks : MetroForm
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Db_Connection"].ToString());

        public Stocks()
        {
            InitializeComponent();
        }

        private void frm_stocks_Load(object sender, EventArgs e)
        {
           
            
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "Material Stocks")
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_MaterialMaster", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Action", "UpdateStockTable"));
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    con.Close();

                    grd_stocks.DataSource = dt;
                   
                }

                else
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_ProductMaster", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Action", "UpdateStockTable"));
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    con.Close();

                    grd_stocks.DataSource = dt;
                }

            }
            catch (Exception ex)
            {

            }
        }


        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text== "Material Stocks")
            {
                (grd_stocks.DataSource as DataTable).DefaultView.RowFilter = String.Format("Material_Name LIKE '%{0}%'", txt_search.Text);

            }
            else
            {
                (grd_stocks.DataSource as DataTable).DefaultView.RowFilter = String.Format("Product_Name LIKE '%{0}%'", txt_search.Text);

            }

        }
        String FileName;
        private void btn_exportExcel_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = ".xls";
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
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
                if (grd_stocks.Rows.Count == 0)
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


                for (int i = 1; i < grd_stocks.Columns.Count + 1; i++)
                {

                    xlWorkSheet.Cells[1, i] = grd_stocks.Columns[i - 1].HeaderText;

                }

                for (int i = 0; i < grd_stocks.Rows.Count; i++)
                {

                    for (int j = 0; j < grd_stocks.Columns.Count; j++)
                    {

                        xlWorkSheet.Cells[i + 2, j + 1] = grd_stocks.Rows[i].Cells[j].Value.ToString();

                    }

                }
                //@"C:\\Excel\Stocks_Report.xls" //for direct location
                xlWorkBook.SaveAs(@""+FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

                MessageBox.Show("Excel Created Successfully.!", "Alert.!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something Went Wrong", "Alert");
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


        
    }
}
