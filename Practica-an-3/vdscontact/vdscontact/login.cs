using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vdscontact
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-94086JL;Initial Catalog=vdscontact;Integrated Security=True");
            con.Open();
            string newcon= "select Username  from tbl_registration where Username ='" + txtBoxUserName.Text + "' and Password ='" + txtBoxPassword.Text + "'";
            SqlDataAdapter adp = new SqlDataAdapter(newcon, con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            DataTable dt = ds.Tables[0];

            if(dt.Rows.Count>=1)
            {
                MessageBox.Show("WELLCOME");
               // Vdscontact vc = new Vdscontact();
                //vc.Show();
                this.Hide();
                 Vdscontact wq = new Vdscontact();
                wq.ShowDialog();
                this.Close();


            

            }
            
            else
            {
                MessageBox.Show("Invalid login credentials.!");
            }
           
            
            
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            registration bn = new registration();
            bn.ShowDialog();
            this.Close();

            
            



        }

      

        private void txtBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                btnSubmit.PerformClick();

            }
        }
    }

}
