
using System;
using System.Data.SqlClient;

namespace StudentInsert
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string cs = @"Data Source=.\SQLEXPRESS;
                          Initial Catalog=CollegeDB;
                          Integrated Security=True";

            
            SqlConnection con = new SqlConnection(cs);

            try
            {
                
                con.Open();

                Console.WriteLine("Database Connected Successfully!");

              
                Console.Write("Enter Student ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Student Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Student Course: ");
                string course = Console.ReadLine();

                
                string query = "INSERT INTO Student (Id, Name, Course) VALUES (@Id, @Name, @Course)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Course", course);

                
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    Console.WriteLine("\nStudent Record Inserted Successfully!");
                }
                else
                {
                    Console.WriteLine("\nRecord Not Inserted!");
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
