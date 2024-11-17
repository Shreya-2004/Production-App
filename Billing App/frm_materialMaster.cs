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
    public partial class frm_materialMaster : MetroForm
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Db_Connection"].ToString());

        public frm_materialMaster()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            DataTable dtMaterial = matrialValidate();
            if (dtMaterial.Rows.Count > 0)
            {
                MessageBox.Show("Material Already Exist!");
            }
            else
            {
                materialAdd();
                txt_material.Clear();
            }
        }
        public DataTable matrialValidate()
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_MaterialMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "MaterialValidate");
                cmd.Parameters.AddWithValue("@Material_Name", txt_material.Text);
				//cmd.Parameters.AddWithValue("@Material_Quantity", txt_qty.Text);
				dt.Load(cmd.ExecuteReader());
                con.Close();
            }
            catch (Exception ex)
            {

            }
            return dt;
        }
        public void materialAdd()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_MaterialMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "AddMaterial");
                cmd.Parameters.AddWithValue("@Material_Name", txt_material.Text);
				cmd.Parameters.AddWithValue("@Material_Quantity", txt_qty.Text);
				cmd.ExecuteNonQuery();
                MessageBox.Show("Material Added!");
            }
            catch (Exception ex)
            {
            }
        }

        
    }
}
