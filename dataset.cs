
using System;
using System.Data;
using System.Data.SqlClient;

namespace StudentOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string cs = @"Data Source=.\SQLEXPRESS;Initial Catalog=CollegeDB;Integrated Security=True";

            SqlConnection con = new SqlConnection(cs);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT * FROM Student", con);

                DataSet ds = new DataSet();

           
                da.Fill(ds, "Student");

                
                SqlCommandBuilder builder = new SqlCommandBuilder(da);

                Console.WriteLine("1. Insert Student");
                Console.WriteLine("2. Update Student");
                Console.WriteLine("3. Delete Student");

                Console.Write("\nEnter Your Choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    
                    Console.Write("Enter Student ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Student Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Course: ");
                    string course = Console.ReadLine();

                    DataRow row = ds.Tables["Student"].NewRow();

                    row["Id"] = id;
                    row["Name"] = name;
                    row["Course"] = course;

                    ds.Tables["Student"].Rows.Add(row);

                    da.Update(ds, "Student");

                    Console.WriteLine("\nStudent Inserted Successfully!");
                }
                else if (choice == 2)
                {
                
                    Console.Write("Enter Student ID to Update: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    DataRow[] rows = ds.Tables["Student"].Select("Id = " + id);

                    if (rows.Length > 0)
                    {
                        Console.Write("Enter New Name: ");
                        rows[0]["Name"] = Console.ReadLine();

                        Console.Write("Enter New Course: ");
                        rows[0]["Course"] = Console.ReadLine();

                        da.Update(ds, "Student");

                        Console.WriteLine("\nStudent Updated Successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Student ID Not Found!");
                    }
                }
                else if (choice == 3)
                {
                    
                    Console.Write("Enter Student ID to Delete: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    DataRow[] rows = ds.Tables["Student"].Select("Id = " + id);

                    if (rows.Length > 0)
                    {
                        rows[0].Delete();

                        da.Update(ds, "Student");

                        Console.WriteLine("\nStudent Deleted Successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Student ID Not Found!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Choice!");
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
