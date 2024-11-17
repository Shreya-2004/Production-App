using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using MetroFramework;
using MetroFramework.Forms;

namespace Billing_App
{
    public partial class frm_SearchInvoice : MetroForm
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Db_Connection"].ToString());

        public frm_SearchInvoice()
        {
            InitializeComponent();
        }

        
        private void frm_invoice_Load(object sender, EventArgs e)
        {
            try
            {

                lbl_customerName.Text = Class_Data.Name;
                txt_email.Text = Class_Data.Email;
                txt_contact.Text = Class_Data.Contact;
                txt_address.Text = Class_Data.Address;
                txt_ClientID.Text = Class_Data.Client_ID;

                GetInvoiceNO();
                LoadProducts();
            }
            catch (Exception ex)
            {

                
            }
            finally 
            {
                con.Close();
            }          
        }

        int InvoiceNO = 0;
        public void GetInvoiceNO()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_InvoiceMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "GetInvoiceNo");
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                int DtCount = dt.Rows.Count;
                if (DtCount > 0)
                {
                    InvoiceNO = 1 + Convert.ToInt32(dt.Rows[0]["Invoice_No"].ToString());
                    txt_invoiceNO.Text = InvoiceNO.ToString();
                }
                else
                {
                    txt_invoiceNO.Text = "101";
                }

            }
            catch (Exception ex)
            {
            }
        }

        public void LoadProducts()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_ProductData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "SearchProduct");
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                grd_SearchProduct.DataSource = dt;             
            }
            catch (Exception ex)
            {
                throw;
            }
        } 

        private void txt_searchProduct_TextChanged(object sender, EventArgs e)
        {
            if(txt_searchProduct.Text == "")
            {
                grd_SearchProduct.Visible = false;
            }
            else
            {
                grd_SearchProduct.Visible = true;
                (grd_SearchProduct.DataSource as DataTable).DefaultView.RowFilter = String.Format("Product_Name LIKE '%{0}%'", txt_searchProduct.Text);
            }
        }

        int selectedCell;
        private void grd_SearchProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedCell = e.RowIndex;
                lbl_Product_ID.Text = grd_SearchProduct.Rows[selectedCell].Cells[0].Value.ToString();
                txt_searchProduct.Text = grd_SearchProduct.Rows[selectedCell].Cells[1].Value.ToString();
                txt_price.Text = grd_SearchProduct.Rows[selectedCell].Cells[2].Value.ToString();
                lbl_availableQty.Text = grd_SearchProduct.Rows[selectedCell].Cells[3].Value.ToString();
                grd_SearchProduct.Visible=false;
            }
            catch (Exception ex)
            {

            }
        }
 
        //public void GetPriceAndQtys(string productID)
        //{
        //    try
        //    {
        //        con.Open();
        //        SqlCommand cmd = new SqlCommand("SP_ProductData", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@Action", "Select_productData");
        //        cmd.Parameters.AddWithValue("@Product_ID", productID);
        //        DataTable dt = new DataTable();
        //        dt.Load(cmd.ExecuteReader());
        //        con.Close();

        //        txt_price.Text = dt.Rows[0]["Selling_Price"].ToString();
        //        lbl_availableQty.Text = dt.Rows[0]["Stocks_Qty"].ToString();              
        //    }
        //    catch (Exception ex)
        //    {
        //        con.Close();
        //    }
        //}
        
        private bool qtyValidation()
        {

            int qty = Convert.ToInt32(txt_qty.Text);
            int availableQty =Convert.ToInt32(lbl_availableQty.Text);

            if (qty <= availableQty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                bool isQtyValidate=false;
                isQtyValidate= qtyValidation();
                if(isQtyValidate==true)
                {

                    AddItem();
                    clear();
                    GrandTotal();
                }
                else
                {
                    MessageBox.Show("Enter valid Stocks", "ALert");
                }
            }
            catch (Exception ex)
            {
            }
            finally
            { 
                con.Close(); 
            }
            
        }
       
        public void AddItem()
        {
            try
            {
                string ID = lbl_Product_ID.Text.ToString();
                string indexChange = txt_searchProduct.Text.ToString();
                string price = (Convert.ToInt32(txt_price.Text)).ToString();
                string qty = (Convert.ToInt32(txt_qty.Text)).ToString();
                int total = (Convert.ToInt32(txt_price.Text)) * (Convert.ToInt32(txt_qty.Text));
                grd_productcart.Rows.Add(ID, indexChange, price, qty, total);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }

        }

        public void clear()
        {
            try
            {
                txt_searchProduct.Clear();
                txt_price.Clear();
                txt_qty.Clear();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }

        }
       
        public void GrandTotal()
        {
            try
            {
                double GrandTotal = 0;
                int RowCount = grd_productcart.Rows.Count;
                for (int i = 0; i < RowCount; i++)
                {
                    GrandTotal = GrandTotal + Convert.ToDouble(grd_productcart.Rows[i].Cells[4].Value.ToString());
                }
                txt_Grandtotal.Text = GrandTotal.ToString();
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
            InvoiceMaster();
            Invoice_Details();
            MessageBox.Show("Invoice Created successfully", "Action");
            PrintBill();
        }
       
        public void InvoiceMaster()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_InvoiceMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Insert");
                cmd.Parameters.AddWithValue("@Invoice_No", txt_invoiceNO.Text);
                cmd.Parameters.AddWithValue("@Customer_ID", txt_ClientID.Text);
                cmd.Parameters.AddWithValue("@Grand_Total", txt_Grandtotal.Text);
                //cmd.Parameters.AddWithValue("@Invoice_Date", dateTimePicker1.Value.ToString());
                cmd.ExecuteNonQuery();
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

        public void Invoice_Details()
        {
            try
            {
                con.Open();
                int RowCount=grd_productcart.Rows.Count;
                for (int i=0;i<RowCount; i++)
                {
                    SqlCommand cmd = new SqlCommand("SP_InvoiceDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Invoice_No", txt_invoiceNO.Text);
                    cmd.Parameters.AddWithValue("@Product_ID",grd_productcart.Rows[i].Cells[0].Value.ToString());
                    cmd.Parameters.AddWithValue("@Product_Price",grd_productcart.Rows[i].Cells[2].Value.ToString());
                    cmd.Parameters.AddWithValue("@Product_qty",grd_productcart.Rows[i].Cells[3].Value.ToString());
                    cmd.Parameters.AddWithValue("@Total",grd_productcart.Rows[i].Cells[4].Value.ToString());
                    cmd.ExecuteNonQuery();                   
                }
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

        public void PrintBill()
        {
            try
            {
                ReportDocument rptdoc = new ReportDocument();
                frm_Report_Viewer crv = new frm_Report_Viewer();
                SqlCommand cmd = new SqlCommand("SP_InvoiceMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Action", "PrintInvoice"));
                cmd.Parameters.Add(new SqlParameter("@Invoice_No", txt_invoiceNO.Text));
                con.Open();
                DataSet ds = new DataSet(); 
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                con.Close();
                rptdoc.Load(Application.StartupPath + ("\\Report_SaleInvoice.rpt"));

                //passing parmeter to report
                TextObject noteR = (TextObject)rptdoc.ReportDefinition.ReportObjects["txt_ReportNote"];
                noteR.Text=txt_note.Text;

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
    }
}
 