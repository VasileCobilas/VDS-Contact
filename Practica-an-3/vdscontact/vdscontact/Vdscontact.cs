using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using vdscontact.vdscontactClasses;

namespace vdscontact
{
    public partial class Vdscontact : Form
    {
        public Vdscontact()
        {
            InitializeComponent();
        }
        contactClass c = new contactClass();


        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Get the value from the input fields
            c.FirstName = txtBoxFirstName.Text;
            c.LastName = txtBoxLastName.Text;
            c.ContactNo = txtBoxContactNumber.Text;
            c.Address = txtBoxAddress.Text;
            c.Gender = cmbGender.Text;

            //Inserting Data into Database using the method we created in last stepp
            bool success = c.Insert(c);

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
                
            }
            //Load Data on Data Gridview
            DataTable dt = c.Select();
            dvgContactList.DataSource = dt;




        }

        private void Vdscontact_Load(object sender, EventArgs e)
        {
            //Load Data on Data Gridview
            DataTable dt = c.Select();
            dvgContactList.DataSource = dt;
        }

        
        //method to clear fields
        public void Clear()
        {
            txtBoxFirstName.Text = "";
            txtBoxLastName.Text = "";
            txtBoxContactNumber.Text = "";
            txtBoxAddress.Text = "";
            cmbGender.Text = "";
            txtboxContactID.Text = "";


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //get the data from textboxes
            c.ContactID = int.Parse(txtboxContactID.Text);
            c.FirstName = txtBoxFirstName.Text;
            c.LastName = txtBoxLastName.Text;
            c.ContactNo = txtBoxContactNumber.Text;
            c.Address = txtBoxAddress.Text;
            c.Gender = cmbGender.Text;
            //Update data in database
            bool success = c.Update(c);
            if(success==true)
            {
                //Update Successfully
                MessageBox.Show("Contact has been successfuly Update");
                //Load Data on Data Gridview
                DataTable dt = c.Select();
                dvgContactList.DataSource = dt;
                //Call clear method 
                Clear();

                
            }
            else
            {
                //Failed to Updata
                MessageBox.Show("Failed to contact update");
            }

        }

        private void dvgContactList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //  GetAccessibilityObjectById the data frim data grid and load in to the textboxes reaspectively 
            //identify the row on which mouse is clicked
            int rowIndex = e.RowIndex;
            txtboxContactID.Text = dvgContactList.Rows[rowIndex].Cells[0].Value.ToString();
            txtBoxFirstName.Text = dvgContactList.Rows[rowIndex].Cells[1].Value.ToString();
            txtBoxLastName.Text = dvgContactList.Rows[rowIndex].Cells[2].Value.ToString();
            txtBoxContactNumber.Text = dvgContactList.Rows[rowIndex].Cells[3].Value.ToString();
            txtBoxAddress.Text = dvgContactList.Rows[rowIndex].Cells[4].Value.ToString();
            cmbGender.Text = dvgContactList.Rows[rowIndex].Cells[5].Value.ToString();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Get data from the textboxes
            c.ContactID = Convert.ToInt32(txtboxContactID.Text);
            bool success = c.Delete(c);
            if (success == true) 
            {
                MessageBox.Show("Contact success deleted.");
                    //refreh datagrid
                    DataTable dt = c.Select();
                dvgContactList.DataSource = dt;
                //Call te clear metod here
                Clear();


            }
            else{
                MessageBox.Show("Contact failed deleted.");
            }
        }
        static string myconnstr = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            //Get the value from text box   
            string keyword = txtBoxSearch.Text;

            SqlConnection conn = new SqlConnection(myconnstr);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tbl_contact WHERE FirstName LIKE'%" + keyword+"%' OR LastName LIKE '%" + keyword+"%'OR Address LIKE '%" + keyword+"%'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dvgContactList.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login fm = new login();
            fm.Show();

            this.Close();
        }

        
    }

}
