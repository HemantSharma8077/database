
using System;
using System.Data.SqlClient;

namespace StudentDelete
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string cs = @"Data Source=.\SQLEXPRESS;Initial Catalog=CollegeDB;Integrated Security=True";

            
            SqlConnection con = new SqlConnection(cs);

            try
            {
               
                con.Open();

                Console.WriteLine("Database Connected Successfully!");

              
                Console.Write("Enter Student ID to Delete: ");
                int id = Convert.ToInt32(Console.ReadLine());

               
                string query = "DELETE FROM Student WHERE Id = @Id";

               
                SqlCommand cmd = new SqlCommand(query, con);

                
                cmd.Parameters.AddWithValue("@Id", id);

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
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
