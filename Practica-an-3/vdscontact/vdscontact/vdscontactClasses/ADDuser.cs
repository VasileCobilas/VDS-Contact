using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vdscontact.vdscontactClasses
{
    class ADDuser
    {

        //Geter Setter Properties
        //Acts as Data Carrier   in Our Aplication
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        static string myconnstrgn = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        //Selecting Data from Database
        public DataTable Select()
        {
            //step 1 DataBase Conection 
            SqlConnection conn = new SqlConnection("Data Source = DESKTOP - 94086JL; Initial Catalog = vdscontact; Integrated Security = True;");
            DataTable dt = new DataTable();
           try
            {
                //Step 2: Writing SQL qery
                string sql = "SELECT * FROM tbl_registration";
                //Creating cmd using sql conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Creating SQL DataAdapter using cmd
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);


            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();

            }
            return dt;

        }
        //Inserting Data into DataBase
        public bool Insert(ADDuser t)
        {
            //Creating a defaul return type and setting it is value to false
            bool isSuccess = false;
            //Step1: Connect DataBase
            SqlConnection conn = new SqlConnection(myconnstrgn);
            try
            {
                //Step  2: Create a scql Weryto insert Data
                string sql = "INSERT INTO tbl_registration(FirstName, LastName, Email, Username, Password, ConnfirmPassword) VALUES(@FirstName, @LastName, @Email, @Username, @Password, @ConfirmPassword)";
                //Creating SQl Command using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Create Parameters to add data
                cmd.Parameters.AddWithValue("@FirstName", t.FirstName);
                cmd.Parameters.AddWithValue("@LastName", t.LastName);
                cmd.Parameters.AddWithValue("@Email", t.Email);
                cmd.Parameters.AddWithValue("@Username", t.Username);
                cmd.Parameters.AddWithValue("@Password", t.Password);
                cmd.Parameters.AddWithValue("@ConfirmPassword", t.ConfirmPassword);
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
            catch (Exception ex)
            {

            }

            finally
            {
                conn.Close();

            }
            return isSuccess;
        }
    }
}
