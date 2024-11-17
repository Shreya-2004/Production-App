using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared.Json;
using MetroFramework;
using MetroFramework.Forms;

namespace Billing_App
{
    public partial class frm_SaleInvoice : MetroForm
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Db_Connection"].ToString());

        public frm_SaleInvoice()
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
                cmd.Parameters.AddWithValue("@Action", "Invoicefetch");
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
                SqlCommand cmd = new SqlCommand("SP_ProductMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "SelectAll");
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                combox_productname.DataSource = dt;
                combox_productname.DisplayMember = "Product_Name";
                combox_productname.ValueMember = "Product_ID";

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        
        private void combox_productname_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //string ProIndex = combox_productname.SelectedIndex.ToString();
                //string ProName = combox_productname.Text.ToString();
                int ProID =Convert.ToInt32(combox_productname.SelectedValue);
                lbl_Product_ID.Text = ProID.ToString();
                GetPriceAndQtys(ProID);
            }
            catch (Exception ex)
            {
               
            }
            finally
            {
            }
            
        }
        public void GetPriceAndQtys(int productID)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_ProductMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Select_productData");
                cmd.Parameters.AddWithValue("@Product_ID", productID);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                txt_price.Text = dt.Rows[0]["Product_Price"].ToString();
                txt_MRP.Text = dt.Rows[0]["Procut_MRP"].ToString();
                lbl_availableQty.Text = dt.Rows[0]["Product_stock"].ToString();

                
            }
            catch (Exception ex)
            {
                con.Close();
            }
        }
        
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
                int rc = grd_productcart.Rows.Count;
                if (rc > 0)
                {
                    for (int i = 0; i < rc;i++) 
                    {
                        if (grd_productcart.Rows[i].Cells[1].Value.ToString()==combox_productname.Text) 
                        {
                            MessageBox.Show("Product Already exist", "Alert");
                            return;
                        }
                    }
                }

                bool isQtyValidate = false;
                isQtyValidate = qtyValidation();
                if (isQtyValidate == true)
                {
                    AddItem();
                    clear();
                    GrandTotal();
                }
                else
                {
                    MessageBox.Show("Invalid Qty");
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
                string indexChange = combox_productname.Text.ToString();
                string price = (Convert.ToDecimal(txt_price.Text)).ToString();
                string qty = (Convert.ToInt32(txt_qty.Text)).ToString();
                string MRP = (Convert.ToDecimal(txt_MRP.Text)).ToString();
                decimal total = (Convert.ToDecimal(txt_price.Text)) * (Convert.ToInt32(txt_qty.Text));
                grd_productcart.Rows.Add(ID, indexChange, price, MRP,qty, total);
               // UpdateProductQty();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }

        }

        public void UpdateProductQty()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_ProductMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "UpdateProductQty");
                cmd.Parameters.AddWithValue("@Product_ID", lbl_Product_ID.Text);
                cmd.Parameters.AddWithValue("@Product_stock", txt_qty.Text);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                lbl_availableQty.Text = dt.Rows[0]["Product_stock"].ToString();

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
                txt_price.Clear();
                txt_qty.Clear();
                txt_MRP.Clear();
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
                    GrandTotal = GrandTotal + Convert.ToDouble(grd_productcart.Rows[i].Cells[5].Value.ToString());
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

        int Result_IM = 0,Result_ID=0;
        private void btn_submit_Click(object sender, EventArgs e)
         {      
            InvoiceMaster();
            Invoice_Details();

            if (Result_ID == 1 && Result_IM == 1)
            {
                MessageBox.Show("Invoice Created successfully", "Action");
            }

            String Msg = "Do you want to print Invoice?";
            string Title = "Alert";

            DialogResult option = new DialogResult();
            option = MessageBox.Show(Msg, Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (option == DialogResult.Yes)
            {
                PrintBill();

            }
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
                cmd.Parameters.AddWithValue("@Invoice_qty", grd_productcart.Rows.Count.ToString());
                //cmd.Parameters.AddWithValue("@Invoice_Date", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
                cmd.ExecuteNonQuery();
                Result_IM = 1;
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
                    cmd.Parameters.AddWithValue("@Invoice_No",Convert.ToInt32( txt_invoiceNO.Text));
                    cmd.Parameters.AddWithValue("@Product_ID",Convert.ToInt32(grd_productcart.Rows[i].Cells[0].Value.ToString()));
                    cmd.Parameters.AddWithValue("@Product_MRP",Convert.ToDecimal( grd_productcart.Rows[i].Cells[3].Value.ToString()));
                    cmd.Parameters.AddWithValue("@Product_Price",Convert.ToDecimal(grd_productcart.Rows[i].Cells[2].Value.ToString()));
                    cmd.Parameters.AddWithValue("@Product_qty",Convert.ToDecimal(grd_productcart.Rows[i].Cells[4].Value.ToString()));
                    cmd.Parameters.AddWithValue("@Product_Total",Convert.ToDecimal( grd_productcart.Rows[i].Cells[5].Value.ToString()));
                    cmd.ExecuteNonQuery();                   
                }
                Result_ID = 1;
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

        public DataTable MatchProduct()
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_ProductMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "MatchProduct");
                cmd.Parameters.AddWithValue("@Product_Name", combox_productname.Text);
                dt.Load(cmd.ExecuteReader());
                con.Close();
            }
            catch (Exception ex)
            {

            }
            return dt;
        }
    }
}
 