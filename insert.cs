
using System;
using System.Data;
using System.Data.SqlClient;

namespace StudentInsertDisconnected
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

                Console.Write("Enter Student ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Student Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Student Course: ");
                string course = Console.ReadLine();

               
                DataRow row = ds.Tables["Student"].NewRow();

                row["Id"] = id;
                row["Name"] = name;
                row["Course"] = course;

                ds.Tables["Student"].Rows.Add(row);

               
                SqlCommandBuilder builder = new SqlCommandBuilder(da);

              
                da.Update(ds, "Student");

                Console.WriteLine("\nStudent Record Inserted Successfully!");
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
