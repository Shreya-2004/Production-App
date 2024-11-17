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
using MetroFramework.Forms;


namespace Billing_App
{
    public partial class frm_login : MetroForm
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Db_Connection"].ToString());
        public frm_login()
        {
            InitializeComponent();
        }
        public static string name;


        int ID;
        string Pass;
        public static string Name;
        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                LoginAction();

                if (txt_password.Text == Pass)
                {
                    MessageBox.Show("you Login Successfully", "Alert");


                    frm_dashboard frm = new frm_dashboard();
                   
                    frm.Show();

                   
                }
                else
                {
                    MessageBox.Show("Enter Valid ID and PASSWARD", "Alert");

                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public void LoginAction() 
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_UserMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "login");
                cmd.Parameters.AddWithValue("@Email", txt_email.Text);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();
                int DtCount=dt.Rows.Count;
                if(DtCount> 0)
                {
                     ID = Convert.ToInt32(dt.Rows[0]["User_ID"].ToString());
                     Pass = dt.Rows[0]["Password"].ToString();
                    Name = dt.Rows[0]["Full_Name"].ToString();
                }
                else
                {
                    MessageBox.Show("Username not found!", "Warning!");
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
    }
}


//if (txt_email.Text == "shreyabagde@gmail.com" && txt_password.Text == "shreya@123" || txt_email.Text == "protect24@gmail.com" && txt_password.Text == "pro@123")

//{

//    MessageBox.Show("you Login Successfully", "Alert");
//    if (txt_email.Text == "shreyabagde@gmail.com")
//    {
//        name = "Shreya";
//    }
//    else
//    {
//        name = "Protect";
//    }

//    this.Hide();
//    frm_dashboard frm = new frm_dashboard();
//    frm.ShowDialog();

//}
//else
//{
//    MessageBox.Show("Enter Valid ID and PASSWARD", "Alert");

//}