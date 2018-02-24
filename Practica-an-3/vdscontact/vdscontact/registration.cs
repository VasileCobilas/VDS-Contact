using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using vdscontact.vdscontactClasses;


namespace vdscontact
{
    public partial class registration : Form
    {
        
        public registration()
        {
            InitializeComponent();
        }
        

        private void btnRegistration_Click(object sender, EventArgs e)

        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-94086JL;Initial Catalog=vdscontact;Integrated Security=True");

             con.Open();
            string newcon = "insert into tbl_registration(FristName,LastName,Email,Username,Password,ConfirmPassword) VALUES('" + txtBoxFN.Text + "','" + txtBoxLN.Text + "', '" + txtBoxEmail.Text + "','" + txtBoxUsername.Text + "','" + txtBoxPassword.Text + "','" + txtBoxConfirmPassword.Text + "')";
            SqlCommand cmd = new SqlCommand(newcon, con);
            cmd.ExecuteNonQuery();
            const int MIN_LENGTH = 6;
            string passwords = txtBoxPassword.Text;
            Regex reg = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            if (passwords.Length <= MIN_LENGTH || txtBoxPassword.Text != txtBoxConfirmPassword.Text)
            {
                MessageBox.Show("Password  is very small or password don't match!!Pleas entry any password who have minim 6 character");
            }

            else if (!reg.IsMatch(txtBoxEmail.Text))
                {
                // Email is not valid
                MessageBox.Show("Email is not valid !!!");
                }

                else if (passwords.Length >= MIN_LENGTH || txtBoxPassword.Text == txtBoxConfirmPassword.Text)
            {
                MessageBox.Show("Registration successfully!!");
                this.Hide();
                login bv = new login();
                bv.ShowDialog();
                this.Close();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void registration_Load(object sender, EventArgs e)
        {

        }

        
    }
}
