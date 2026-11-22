
using System;
using System.Data;
using System.Data.SqlClient;

namespace StudentDataSet
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

                Console.WriteLine("Student Records:");
                Console.WriteLine("------------------------------");

                foreach (DataRow row in ds.Tables["Student"].Rows)
                {
                    Console.WriteLine("Student ID: " + row["Id"]);
                    Console.WriteLine("Student Name: " + row["Name"]);
                    Console.WriteLine("Course: " + row["Course"]);

                    Console.WriteLine("------------------------------");
                }

                Console.WriteLine("Records Retrieved Successfully!");
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
