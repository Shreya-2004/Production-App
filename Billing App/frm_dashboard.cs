using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Configuration;

namespace Billing_App
{

    public partial class frm_dashboard : MetroForm
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Db_Connection"].ToString());

        public frm_dashboard()
        {
            InitializeComponent();
        }


        private void pictureBox_logout_Click(object sender, EventArgs e)
        {
            try
            {
                frm_login frm = new frm_login();
                frm.Show();


                this.Hide();
            }
            catch (Exception ex)
            {


            }
            finally { this.Close(); }
        }
        private void btn_logout_Click(object sender, EventArgs e)
        {
           
        }

        private void frm_dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        
        private void frm_dashboard_Load(object sender, EventArgs e)
        {
            //try
            //{

            //    lbl_hello.Text = "Hello ," + frm_login.Name;


            //    DateTime currentTime = DateTime.Now.ToLocalTime();
            //    TimeSpan morningStart = new TimeSpan(6, 0, 0);
            //    TimeSpan morningEnd = new TimeSpan(12, 0, 0);
            //    TimeSpan eveningStart = new TimeSpan(18, 0, 0);
            //    TimeSpan eveningEnd = new TimeSpan(23, 0, 0);

            //    if (currentTime.TimeOfDay >= morningStart && currentTime.TimeOfDay < morningEnd)
            //    {
            //        lbl_greeting.Text = "Good Morning";
            //    }
            //    else if (currentTime.TimeOfDay >= eveningStart && currentTime.TimeOfDay < eveningEnd)
            //    {
            //        lbl_greeting.Text = "Good Evening";
            //    }
            //    else
            //    {
            //        lbl_greeting.Text = "Good Afternoon";
            //    }

            //    lbl_msg.Text = ConfigurationManager.AppSettings["FoodMsg"].ToString();
            //}
            //catch (Exception ex)
            //{

            //}         
        }    
        private void btn_clints_Click(object sender, EventArgs e)
        {

            frm_client frm = new frm_client();
            //frm.StartPosition = FormStartPosition.CenterParent; // Centers the dialog relative to the main form
           
            frm.Show();
        }

        private void btn_products_Click(object sender, EventArgs e)
        {
            frm_productdata frm = new frm_productdata();
            frm.ShowDialog();
        }

        private void btn_stocks_Click(object sender, EventArgs e)
        {
            Stocks frm = new Stocks();
            frm.ShowDialog();
        }

        private void btn_invoice_Click(object sender, EventArgs e)
        {
            frm_SaleInvoice frm = new frm_SaleInvoice();
            frm.ShowDialog();
        }

        private void btn_supplierDetails_Click(object sender, EventArgs e)
        {
            frm_supplierDetails frm = new frm_supplierDetails();
            frm.ShowDialog();
        }

        private void btn_addProducts_Click(object sender, EventArgs e)
        {
            frm_PurchaseOrder frm = new frm_PurchaseOrder();
            frm.ShowDialog();
        }

        private void btn_calculator_Click(object sender, EventArgs e)
        {
            Process.Start("calc");
        }

        private void pictureBox_calculator_Click(object sender, EventArgs e)
        {
            Process.Start("calc");
        }

        private void btn_notepad_Click(object sender, EventArgs e)
        {
        }


        private void pictureBox_notes_Click(object sender, EventArgs e)
        {
            Process.Start("notepad");

        }

        private void btn_searchProduct_Click(object sender, EventArgs e)
        {
            frm_SearchInvoice frm = new frm_SearchInvoice();
            frm.ShowDialog(this);
        }

        public void FindContact()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_ClientMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "MatchContact");
            cmd.Parameters.AddWithValue("@Contact",txt_Number.Text);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            int DtCount = dt.Rows.Count;
            if(DtCount > 0 )
            {
                Class_Data.Client_ID =dt.Rows[0]["Client_ID"].ToString();
                Class_Data.Contact =dt.Rows[0]["Contact"].ToString();
                Class_Data.Name = dt.Rows[0]["Name"].ToString();
                Class_Data.Email = dt.Rows[0]["Email"].ToString();
                Class_Data.Address= dt.Rows[0]["Address"].ToString();

                frm_SaleInvoice frm = new frm_SaleInvoice();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Contact not found!", "Warning!");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FindContact();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            frm_Production frm_Production = new frm_Production();
            frm_Production.ShowDialog();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            frm_materialMaster frm = new frm_materialMaster();
            frm.ShowDialog();
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }     
}
 