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
    public partial class frm_Production : MetroForm
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Db_Connection"].ToString());

        public frm_Production()
        {
            InitializeComponent();
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

                combox_material.DataSource = dt;
               combox_material.DisplayMember = "Material_Name";
                combox_material.ValueMember = "Material_ID";

            }
            catch (Exception ex)
            {
            }

        }

        int ProductionOrderNO = 0;
        public void GetProductionOrderNO()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_ProductionMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "GetProductionOrderNo");
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                int DtCount = dt.Rows.Count;
                if (DtCount > 0)
                {
                    ProductionOrderNO = 1 + Convert.ToInt32(dt.Rows[0]["PDM_OrderNo"].ToString());
                    txt_orderNO.Text = ProductionOrderNO.ToString();
                }
                else
                {
                    txt_orderNO.Text = "1";
                }

            }
            catch (Exception ex)
            {
            }
        }

        private void frm_Production_Load(object sender, EventArgs e)
        {
            LoadMaterial();
            LoadProducts();
            GetProductionOrderNO();
        }

        private void combox_material_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Getqty(combox_material.SelectedValue.ToString());
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }

        }
        public void Getqty(string ID)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_MaterialMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "GetMaterialQty");
                cmd.Parameters.AddWithValue("@Material_ID", ID);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                lbl_availableQty.Text = dt.Rows[0]["Material_Quantity"].ToString();


            }
            catch (Exception ex)
            {
                con.Close();
            }
        }

        private bool qtyValidation()
        {

            int qty = Convert.ToInt32(txt_qty.Text);
            int availableQty = Convert.ToInt32(lbl_availableQty.Text);

            if (qty <= availableQty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void ADD()
        {
            try
            {
                bool isQtyValidate = false;
                isQtyValidate = qtyValidation();
                if (isQtyValidate == true)
                {
                    int ID = Convert.ToInt32(combox_material.SelectedValue.ToString());
                    string Material = combox_material.Text.ToString();
                    Double Qty = Convert.ToDouble(txt_qty.Text.ToString());

                    grd_material.Rows.Add(ID, Material, Qty);

                    txt_qty.Clear();
                }
                else
                {
                    MessageBox.Show("Invalid qty");
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

                combox_product.DataSource = dt;
                combox_product.DisplayMember = "Product_Name";
                combox_product.ValueMember = "Product_ID";

            }
            catch (Exception ex)
            {
            }

        }

        public void UpdateMaterialStock()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_MaterialMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "UpdateQty");
                cmd.Parameters.AddWithValue("@Material_ID", lbl_ID.Text);
                cmd.Parameters.AddWithValue("@Material_Stocks", txt_qty.Text);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());               
                con.Close();

                lbl_availableQty.Text= dt.Rows[0]["Material_Stocks"].ToString();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
        }

        public void clearMaterial()
        {
            txt_MRP.Clear();
            txt_sellingPrice.Clear();
            txt_productQty.Clear();

        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            ADD();
            
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            ProductionMaster();
            ProductionDetails();
            //UpdateMaterialStock();
            clearMaterial();

            if (PM_Result == 1 && PD_Result == 1)
            {
                MessageBox.Show("Data Inserted Successfully", "Action");
            }
            else
            {
                MessageBox.Show("Something went wrong", "Action");
            }
        }

        int PM_Result = 0;
        int PD_Result = 0;
        public void ProductionMaster()
        {
            try
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("SP_ProductionMaster", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@Action", "Insert");
                //cmd1.Parameters.AddWithValue("@PDM_OrderNo",Convert.ToInt32(txt_orderNO.Text));
                cmd1.Parameters.AddWithValue("@Product_ID",combox_product.SelectedValue);
                cmd1.Parameters.AddWithValue("@MRP", Convert.ToDouble(txt_MRP.Text));
                cmd1.Parameters.AddWithValue("@SellingPrice", Convert.ToDouble(txt_sellingPrice.Text));
                cmd1.Parameters.AddWithValue("@Pieces", Convert.ToInt32(txt_productQty.Text));
                cmd1.ExecuteNonQuery();
                PM_Result = 1;
                con.Close();
            }
            catch (Exception ex)
            {
                PM_Result = 0;
            }
            finally { con.Close(); }
        }

        public void ProductionDetails()
        {
            try
            {
                int RowCount = grd_material.Rows.Count;
                con.Open();
                for (int i = 0; i < RowCount; i++)
                {
                    SqlCommand cmd = new SqlCommand("SP_ProductionDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@Material_ID", Convert.ToInt32(grd_material.Rows[i].Cells[0].Value.ToString()));
                    cmd.Parameters.AddWithValue("@Material_Qty", Convert.ToInt32(grd_material.Rows[i].Cells[2].Value.ToString()));
                    cmd.Parameters.AddWithValue("@PDM_OrderNo", Convert.ToInt32(txt_orderNO.Text));
                    cmd.ExecuteNonQuery();
                }
                PD_Result = 1;
                con.Close();
            }
            catch (Exception ex)
            {
                PD_Result = 0;
            }
            finally { con.Close(); }
        }


        private void txt_MRP_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
