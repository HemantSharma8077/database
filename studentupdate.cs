
using System;
using System.Data;
using System.Data.SqlClient;

namespace StudentUpdateDisconnected
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

                Console.Write("Enter Student ID to Update: ");
                int id = Convert.ToInt32(Console.ReadLine());

             
                DataRow[] rows = ds.Tables["Student"].Select("Id = " + id);

                if (rows.Length > 0)
                {
                   
                    Console.Write("Enter New Student Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter New Course: ");
                    string course = Console.ReadLine();

                   
                    rows[0]["Name"] = name;
                    rows[0]["Course"] = course;

                    
                    SqlCommandBuilder builder = new SqlCommandBuilder(da);

                    da.Update(ds, "Student");

                    Console.WriteLine("\nStudent Record Updated Successfully!");
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
