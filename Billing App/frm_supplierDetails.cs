using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Configuration;
using MetroFramework.Forms;
using System.IO;

namespace Billing_App
{
    public partial class frm_supplierDetails : MetroForm
    {
        //SqlConnection con = new SqlConnection("Data Source = DESKTOP-L16LSD5\\SQLEXPRESS;initial catalog =DB_BillingApp;integrated security=true;");
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Db_Connection"].ToString());

        public frm_supplierDetails()
        {

            InitializeComponent();
        }

        private void frm_supplierDetails_Load(object sender, EventArgs e)
        {
           SupplierDataFetch();
        }
        private void SupplierDataFetch()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_SupplierDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "SelectAll");
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();
                grd_suppliertable.DataSource = dt;
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
                        DataTable dt = ContactValidate();
                        if (dt.Rows.Count > 0 )
                        {
                            MessageBox.Show("Contact Already Exist!", "Alert");
                        }
                        else
                        {
                            AddSupplierData();
                        }
                    }
                    else
                    {
                        Update_SupplierData();
                        btn_submit.Text = "Submit";
                        btn_delete.Visible = false;
                        btn_purchaseMaterial.Visible = false;
                    }
                }
                clear_data();
                SupplierDataFetch();
            } 
            catch (Exception ex ) 
            { 

            }
                 finally
                {
                    con.Close() ;
                }
        }

        public DataTable ContactValidate()
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_SupplierDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "ContactValidate");
                cmd.Parameters.AddWithValue("@Contact", txt_contact.Text);
                dt.Load(cmd.ExecuteReader());
                con.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close( );
            }
            return dt;
        }

        private void AddSupplierData()
        {
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("SP_SupplierDetails", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Action", "AddSupplier");
                command.Parameters.AddWithValue("@Name", txt_name.Text);
                command.Parameters.AddWithValue("@Contact", txt_contact.Text);
                command.Parameters.AddWithValue("@Email", txt_email.Text);
                command.Parameters.AddWithValue("@PAN", txt_pan.Text);
                command.Parameters.AddWithValue("@Address", txt_address.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("Data Inserted Successfully", "Action");
                con.Close();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                con.Close();
            }
        }

        public void Update_SupplierData()
        {
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("SP_SupplierDetails", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Action", "UpdateSupplier");
                command.Parameters.AddWithValue("@Name", txt_name.Text);
                command.Parameters.AddWithValue("@Contact", txt_contact.Text);
                command.Parameters.AddWithValue("@Email", txt_email.Text);
                command.Parameters.AddWithValue("@PAN", txt_pan.Text);
                command.Parameters.AddWithValue("@Address", txt_address.Text);
                command.Parameters.AddWithValue("@Supplier_ID", lbl_id.Text);
                command.ExecuteNonQuery();
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

        private void btn_purchaseMaterial_Click(object sender, EventArgs e)
        {
            try
            {
                SupplierClass.Name = txt_name.Text;
                SupplierClass.Email = txt_email.Text;
                SupplierClass.Contact = txt_contact.Text;
                SupplierClass.Address = txt_address.Text;
                SupplierClass.Supplier_ID = lbl_id.Text;
                frm_PurchaseOrder frm = new frm_PurchaseOrder();
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

        int selectedCell;
        private void grd_suppliertable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedCell = e.RowIndex;
                lbl_id.Text = grd_suppliertable.Rows[selectedCell].Cells[0].Value.ToString();
                txt_name.Text = grd_suppliertable.Rows[selectedCell].Cells[1].Value.ToString();
                txt_contact.Text = grd_suppliertable.Rows[selectedCell].Cells[2].Value.ToString();
                txt_email.Text = grd_suppliertable.Rows[selectedCell].Cells[3].Value.ToString();
                txt_pan.Text = grd_suppliertable.Rows[selectedCell].Cells[4].Value.ToString();
                txt_address.Text = grd_suppliertable.Rows[selectedCell].Cells[5].Value.ToString();

                btn_submit.Text = "Update";
                btn_delete.Visible = true;
                btn_purchaseMaterial.Visible = true;
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
                txt_pan.Clear();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
        }

         public void Delete_SupplierData()
         {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_SupplierDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Action", "DeleteSupplier");
                cmd.Parameters.AddWithValue("@Supplier_ID", lbl_id.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Deleted Successfully", "Action");
                btn_delete.Visible = false;
                btn_submit.Text = "Submit";
                btn_purchaseMaterial.Visible = false;
            }
            catch (Exception ex)
            {

            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            Delete_SupplierData();
            clear_data();
            SupplierDataFetch();
         }


        string FileName;
        private void btn_export_Click(object sender, EventArgs e)
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
                if (grd_suppliertable.Rows.Count == 0)
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


                for (int i = 1; i < grd_suppliertable.Columns.Count + 1; i++)
                {

                    xlWorkSheet.Cells[1, i] = grd_suppliertable.Columns[i - 1].HeaderText;

                }

                for (int i = 0; i < grd_suppliertable.Rows.Count; i++)
                {

                    for (int j = 0; j < grd_suppliertable.Columns.Count; j++)
                    {

                        xlWorkSheet.Cells[i + 2, j + 1] = grd_suppliertable.Rows[i].Cells[j].Value.ToString();

                    }

                }

                xlWorkBook.SaveAs(@""+ FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
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
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }



        private void btn_open_Click(object sender, EventArgs e)
        {
            con.Open();
            MessageBox.Show("Connection open", "Action");
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            con.Close();
            MessageBox.Show("Connection close", "Action");

        }

    }
}
