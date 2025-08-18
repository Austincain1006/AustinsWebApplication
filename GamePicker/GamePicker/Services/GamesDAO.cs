using GamePicker.Models;
using Microsoft.Data.SqlClient;

namespace GamePicker.Services
{
    public class GamesDAO
    {
        string connectionString = @"Server=tcp:gamepickerdbserver.database.windows.net;Authentication=Active Directory Default;Database=GamePicker_db;";
        public List<Game> GetAllGames()
        {
            List<Game> foundGames = new List<Game>();
            string sqlStatement = "SELECT * FROM dbo.Game";
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

        public List<Game> GetThreeRandomGames()
        {
            List<Game> foundGames = new List<Game>();
            string sqlStatement = "SELECT TOP 3 * FROM dbo.Game ORDER BY NEWID()";
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

        private int getRandIntInRange(int min, int max)
        {
            Random r = new Random();
            return r.Next(min, max);
        }
    }
}
