using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationSignUp
{
    class DataHandler
    {
        string conn = @"Data Source=DESKTOP-TVQQ8OC;Initial Catalog=MetaPlatformDB;Integrated Security=True";

        public DataTable Display()
        {
            SqlConnection connection = new SqlConnection(conn);
            SqlDataAdapter adapter = new SqlDataAdapter("Display", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public void AddStudent(string name, string surname, string email, string password, string gender, DateTime dateOfbirth)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    SqlCommand cmd = new SqlCommand("AddStudent", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FirstName", name);
                    cmd.Parameters.AddWithValue("@LastName", surname);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@DateOfBirth", dateOfbirth);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Successfully Added");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void DeleteStudent(string email)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    SqlCommand cmd = new SqlCommand("DeleteStudent", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", email);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Successfully Deleted");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public DataTable SearchStudent(string email)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("SearchStudent", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Email", email);
                connection.Open();
                DataTable dt = new DataTable();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr);
                    return dt;
                }
            }
        }
    }
}
