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
using vdscontact.vdscontactClasses;


namespace vdscontact
{
    public partial class registration : Form
    {
        
        public registration()
        {
            InitializeComponent();
        }
        ADDuser t = new ADDuser();

        private void btnRegistration_Click(object sender, EventArgs e)
        {  //Get the value from the input fields
            t.FirstName = txtBoxFN.Text;
            t.LastName = txtBoxLN.Text;
            t.Email = txtBoxEmail.Text;
            t.Username = txtBoxUsername.Text;
            t.Password = txtBoxPassword.Text;
            t.ConfirmPassword = txtBoxConfirmPassword.Text;

            //Inserting Data into Database using the method we created in last stepp
            bool success = t.Insert(t);
            if (success == true)
            {
                //Successfully inserted
                MessageBox.Show("New Contact Successfully Inserted");
                //Call the clear methodhere
                Clear();

            }
            else
            {
                //Failed to add contact
                MessageBox.Show("Failed to add new contacct . Try again");
            }
        }
        void Clear()
        {
            txtBoxFN.Text = "";
            txtBoxLN.Text = "";
            txtBoxEmail.Text = "";
            txtBoxUsername.Text = "";
            txtBoxPassword.Text = "";
            txtBoxConfirmPassword.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
