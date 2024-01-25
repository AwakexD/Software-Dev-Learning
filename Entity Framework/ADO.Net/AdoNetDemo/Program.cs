using Microsoft.Data.SqlClient;

namespace AdoNetDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            using (SqlConnection sqlConnection =
                   new SqlConnection("Server=.;Database=SoftUni;Integrated Security=true;TrustServerCertificate=True"))
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT FirstName, LastName FROM EMPLOYEES WHERE FirstName = 'John'", sqlConnection);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine((string)reader["FirstName"] + (string)reader["LastName"]);
                }
                
            }
        }
    }
}