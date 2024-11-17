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
    public partial class frm_productdata : MetroForm
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Db_Connection"].ToString());

        public frm_productdata()
        {
            InitializeComponent();
        }
        private void DataFetchWithSP()
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

                grd_ProductCart.DataSource = dt;
            }
            catch (Exception ex)
            {

            }
            finally { con.Close(); }

        }

        private void frm_productdata_Load(object sender, EventArgs e)
        {
            DataFetchWithSP();
        }

        public void add_Data()
        {
            try
            {
                con.Open(); 
                SqlCommand command = new SqlCommand("SP_ProductMaster", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Action", "Insert"));
                command.Parameters.Add(new SqlParameter("@Product_Name", txt_productname.Text));
            
                
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Inserted Successfully", "Action");
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }


        }

        public void Update_ProductData()
        {
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("SP_ProductMaster", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Action", "Update"));
                command.Parameters.Add(new SqlParameter("@Product_Name", txt_productname.Text));
                command.Parameters.Add(new SqlParameter("@Product_ID",lbl_id.Text));
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Updated Successfully", "Action");
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            { 
                con.Close(); 
            }           

        }

        int selectedCell;

        private void grd_ProductCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedCell = e.RowIndex;
                lbl_id.Text = grd_ProductCart.Rows[selectedCell].Cells[0].Value.ToString();
                txt_productname.Text = grd_ProductCart.Rows[selectedCell].Cells[1].Value.ToString();

                btn_submit.Text = "Update";
                btn_delete.Visible = true;
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
                txt_productname.Clear();
               
            }
            catch (Exception ex)
            {

            }finally { con.Close(); }


        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {

                if (txt_productname.Text == "")
                {
                    MessageBox.Show("Fill all Fields", "Alert");
                }
                else
                {
                    if (btn_submit.Text == "Submit")
                    {
                        DataTable dt = MatchProduct();
                        if (dt.Rows.Count>0)
                        {
                            MessageBox.Show("Product already Present", "Alert");
                        }
                        else
                        {
                            add_Data();
                        }
                    }
                    else
                    {
                        Update_ProductData();
                        btn_submit.Text = "Submit";
                    }
                }
                DataFetchWithSP();
                clear_data();
            }
            catch (Exception ex)
            {

            }
             

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_ProductMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Action", "Delete_ProductData"));
                cmd.Parameters.Add(new SqlParameter("@Product_ID", lbl_id.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Deleted Successfully", "Action");
                btn_delete.Visible = false;
                btn_submit.Text = "Submit";


            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
                clear_data();
                DataFetchWithSP();
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
                cmd.Parameters.AddWithValue("@Product_Name", txt_productname.Text);
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
