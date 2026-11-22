
using System;
using System.Data.SqlClient;

namespace StudentUpdate
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

                Console.Write("Enter Student ID to Update: ");
                int id = Convert.ToInt32(Console.ReadLine());

               
                Console.Write("Enter New Student Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter New Course: ");
                string course = Console.ReadLine();

              
                string query = "UPDATE Student SET Name = @Name, Course = @Course WHERE Id = @Id";

                
                SqlCommand cmd = new SqlCommand(query, con);

                
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Course", course);

                
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    Console.WriteLine("\nStudent Details Updated Successfully!");
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
