
using System;
using System.Data;
using System.Data.SqlClient;

namespace StudentDeleteDisconnected
{
    class Program
    {
        static void Main(string[] args)
        {
           
            string cs = @"Data Source=.\SQLEXPRESS;Initial Catalog=CollegeDB;Integrated Security=True";

            SqlConnection con = new SqlConnection(cs);

            try
            {
              
                string query = "SELECT * FROM Student";

                SqlDataAdapter da = new SqlDataAdapter(query, con);

                
                DataSet ds = new DataSet();

                da.Fill(ds, "Student");

               
                Console.Write("Enter Student ID to Delete: ");
                int id = Convert.ToInt32(Console.ReadLine());

                DataRow[] rows = ds.Tables["Student"].Select("Id = " + id);

                if (rows.Length > 0)
                {
                    
                    rows[0].Delete();

                    
                    SqlCommandBuilder builder = new SqlCommandBuilder(da);

                    da.Update(ds, "Student");

                    Console.WriteLine("\nStudent Record Deleted Successfully!");
                }
                else
                {
                    Console.WriteLine("\nStudent ID Not Found!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            Console.ReadLine();
        }
    }
}
