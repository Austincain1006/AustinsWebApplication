using GamePicker.Models;
using Microsoft.Data.SqlClient;

namespace GamePicker.Services
{
    public class GamesDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=aspnet-GamePicker-b2648162-89e9-46f6-83f0-8c152de87997;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public List<Game> GetAllGames()
        {
            List<Game> foundGames = new List<Game>();
            string sqlStatement = "SELECT * FROM dbo.Games";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundGames.Add(new Game { Id = (int)reader[0], Name = (string)reader[1] });
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                return foundGames;
            }
        }
    }
}
