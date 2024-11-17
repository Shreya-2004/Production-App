using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace Billing_App
{
    public partial class frm_PurchaseOrder : MetroForm
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Db_Connection"].ToString());

        public frm_PurchaseOrder()
        {
            InitializeComponent();
        }

        private void frm_PurchaseOrder_Load(object sender, EventArgs e)
        {
            try
            {

                lbl_customerName.Text = SupplierClass.Name;
                txt_email.Text = SupplierClass.Email;
                txt_contact.Text = SupplierClass.Contact;
                txt_address.Text = SupplierClass.Address;
                txt_supplierD.Text = SupplierClass.Supplier_ID;

                GetPurchaseNo();
                LoadMaterial();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
        }

        int PurchaseNO = 0;
        public void GetPurchaseNo()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_PurchaseMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "GetPurchaseNo");
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                int DtCount = dt.Rows.Count;
                if (DtCount > 0)
                {
                    PurchaseNO = 1 + Convert.ToInt32(dt.Rows[0]["Purchase_OrderNo"].ToString());
                    txt_PurchaseNO.Text = PurchaseNO.ToString();
                }
                else
                {
                    txt_PurchaseNO.Text = "101";
                }

            }
            catch (Exception ex)
            {
            }
        }

        public void LoadMaterial()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_MaterialMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "SelectAll");
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                combox_MaterialName.DataSource = dt;
                combox_MaterialName.DisplayMember = "Material_Name";
                combox_MaterialName.ValueMember = "Material_ID";

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
                string ProID = combox_MaterialName.SelectedValue.ToString();
                lbl_materialID.Text = ProID;
               // GetPrice(ProID);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
        }

        //public void GetPrice(string productID)
        //{
        //    try
        //    {
        //        con.Open();
        //        SqlCommand cmd = new SqlCommand("SP_MaterialMaster", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@Action", "Select");
        //        cmd.Parameters.AddWithValue("@Material_ID", productID);
        //        DataTable dt = new DataTable();
        //        dt.Load(cmd.ExecuteReader());
        //        con.Close();

        //        txt_mrp.Text = dt.Rows[0]["Selling_Price"].ToString();
        //        //txt_mrp.Text = dt.Rows[0]["MRP"].ToString();

        //    }
        //    catch (Exception ex)
        //    {
        //        con.Close();
        //    }
        //}

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                AddItem();
                clear();
                GrandTotal();
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
                string ID = lbl_materialID.Text.ToString();
                string ProductName = combox_MaterialName.Text.ToString();
                string Price = (Convert.ToInt32(txt_price.Text)).ToString();
                string MRP = (Convert.ToInt32(txt_mrp.Text)).ToString();
                string qty = (Convert.ToInt32(txt_qty.Text)).ToString();
                string total = ((Convert.ToInt32(txt_mrp.Text)) * (Convert.ToInt32(txt_qty.Text))).ToString();
                string date = dateTimePicker1.Value.Date.ToString();
                //cmd.Parameters.AddWithValue("@Invoice_Date", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
                string[] row = new string[] { ID, ProductName, MRP,Price, qty,date,total };
                grd_productcart.Rows.Add(row);
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
                txt_mrp.Clear();
                txt_qty.Clear();
                txt_price.Clear();
                //txt_mrp.Clear();
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
                    GrandTotal = GrandTotal + Convert.ToDouble(grd_productcart.Rows[i].Cells[6].Value.ToString());
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
            PurchaseMaster(); 
            PurchaseDetails();
            
            if (PM_result == 1 && PD_result == 2)
            { 
                MessageBox.Show("Data Inserted Successfully", "Action");
            }
            else
            {
                MessageBox.Show("Something went wrong", "Action");
            }
        }

        int PM_result=0;
        int PD_result=0;
        public void PurchaseMaster()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_PurchaseMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Insert");
                cmd.Parameters.AddWithValue("@Purchase_OrderNo", Convert.ToInt32(txt_PurchaseNO.Text));
                cmd.Parameters.AddWithValue("@Supplier_ID", Convert.ToInt32(txt_supplierD.Text));
                cmd.Parameters.AddWithValue("@Grand_Total",Convert.ToDouble(txt_Grandtotal.Text));
                cmd.Parameters.AddWithValue("@Purchase_Date", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
                cmd.Parameters.AddWithValue("@Purchase_qty",  grd_productcart.Rows.Count.ToString());
                PM_result = cmd.ExecuteNonQuery();
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

        public void PurchaseDetails()
        {
            try
            {
                int RowCount = grd_productcart.Rows.Count;
                con.Open();
                for (int i = 0; i < RowCount; i++)
                {
                    SqlCommand cmd1 = new SqlCommand("SP_PurchaseDetails", con);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@Purchase_OrderNo", Convert.ToInt32(txt_PurchaseNO.Text));
                    cmd1.Parameters.AddWithValue("@Material_ID", Convert.ToInt32( grd_productcart.Rows[i].Cells[0].Value.ToString()));
                    //cmd1.Parameters.AddWithValue("@Material_Name",grd_productcart.Rows[i].Cells[1].Value.ToString());
                    cmd1.Parameters.AddWithValue("@Material_Price", Convert.ToDouble(grd_productcart.Rows[i].Cells[2].Value.ToString()));
                    cmd1.Parameters.AddWithValue("@Material_MRP", Convert.ToDouble(grd_productcart.Rows[i].Cells[3].Value.ToString()));
                    cmd1.Parameters.AddWithValue("@Material_qty", Convert.ToDouble(grd_productcart.Rows[i].Cells[4].Value.ToString()));
                    cmd1.Parameters.AddWithValue("@Material_Total", Convert.ToDouble(grd_productcart.Rows[i].Cells[6].Value.ToString()));
                    PD_result=cmd1.ExecuteNonQuery();

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

        private void lbl_newMaterial_Click(object sender, EventArgs e)
        {
            frm_materialMaster frm = new frm_materialMaster();
            frm.ShowDialog();
            LoadMaterial();
        }

     



        private void lbl_supplierID_Click(object sender, EventArgs e)
        {

        }
    }  
}
