
using System;
using System.Data.SqlClient;

class Program1
{
    static void Main()
    {
        string connectionString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=CollegeDB;Integrated Security=True";

        SqlConnection con = new SqlConnection(connectionString);

        try
        {
            con.Open();

            Console.WriteLine("Database Connected Successfully!");

            string query = "SELECT * FROM Student";

            SqlCommand cmd = new SqlCommand(query, con);

            
            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("\nStudent Records:");
            Console.WriteLine("----------------------------");

            while (reader.Read())
            {
                Console.WriteLine("ID: " + reader["Id"]);
                Console.WriteLine("Name: " + reader["Name"]);
                Console.WriteLine("Course: " + reader["Course"]);
                Console.WriteLine("----------------------------");
            }

            reader.Close();
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
