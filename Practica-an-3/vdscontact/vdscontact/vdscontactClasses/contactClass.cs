using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vdscontact.vdscontactClasses
{
    class contactClass
    {
        //Geter Setter Properties
        //Acts as Data Carrier   in Our Aplication
        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }

        static string myconnstrgn = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        //Selecting Data from Database
        public DataTable Select()
        {
            //step 1 DataBase Conection 
            SqlConnection conn = new SqlConnection(myconnstrgn);
            DataTable dt = new DataTable();
            try
            {
                //Step 2: Writing SQL qery
                string sql = "SELECT * FROM tbl_contact";
                //Creating cmd using sql conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Creating SQL DataAdapter using cmd
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);


            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();

            }
            return dt;

        }
        //Inserting Data into DataBase
        public bool Insert(contactClass c)
        {
            //Creating a defaul return type and setting it is value to false
            bool isSuccess = false;
            //Step1: Connect DataBase
            SqlConnection conn = new SqlConnection(myconnstrgn);

            if (c.FirstName == "" || c.LastName == "" || c.ContactNo == "" || c.Address == "" || c.Gender == "")
            {
                MessageBox.Show("Please entry value !!!!");
            }

            else
            
            try
            {
                //Step  2: Create a scql Weryto insert Data
                string sql = "INSERT INTO tbl_contact(FirstName, LastName, ContactNo, Address, Gender) VALUES(@FirstName, @LastName, @ContactNo, @Address, @Gender)";
                //Creating SQl Command using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Create Parameters to add data
                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@ContactNo", c.ContactNo);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);
                //Conection Open Here
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                //If the query runs succesfully then the value of rows will be greater than zero else it is value will be 0 
                if (rows > 0)
                {
                    isSuccess = true;

                }
                else
                {
                    isSuccess = false;

                }
            }
                
            catch(Exception ex)
            {

            }

            finally
            {
                conn.Close();

            }
            return isSuccess;
        }
        //Method to update bata in database from our application
        public bool Update(contactClass c)
        {
            //Create default return type and set its default value to false
            bool isSucces = false;
            SqlConnection conn = new SqlConnection(myconnstrgn);
            try
            {
                //SQL to update data in our Database
                string sql = "UPDATE tbl_contact SET FirstName=@FirstName, LastName=@LastName, ContactNo=@ContactNo,Address=@Address, Gender=@Gender WHERE ContactID=@ContactID";
                //Creating SQL command
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Create Parameters to add value
                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@ContactNo", c.ContactNo);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);
                cmd.Parameters.AddWithValue("@ContactID", c.ContactID);
                //Open database connection
                conn.Open();

                int rows = cmd.ExecuteNonQuery();
                //if the query runs successfully the the value of rows wil be greater than zero else it is value will be 0
                if(rows>0)
                {
                    isSucces = true;
                }
                else
                {
                    isSucces = false;
                }

            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();

            }
            return isSucces;
        }
        //Method to delete data from database
        public bool Delete(contactClass c)
        {
            //Create a default return value and set its value to false 
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrgn);
            try
            {
                //SQL to delete data
                string sql = "DELETE FROM tbl_contact WHERE ContactID=@ContactID";
                //Creating SQL comand
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ContactID", c.ContactID);
                //Open connection
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                //If the  query run successfylly than the value of rows is greater than zero  else its value is zero
                if(rows>0)
                    {
                    isSuccess = true;

                     }   
                else
                     {
                        isSuccess = false;
                      }
            }

            catch
            {

            }
            finally
            {
                //Close conection
                conn.Close();

            }
            return isSuccess;
        }
    }
}
    