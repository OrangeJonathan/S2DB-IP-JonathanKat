using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using GameCollectiblesCore;
using GameCollectiblesCore.Games;

namespace GameCollectiblesData.Games
{

    public class GameRepository : IGameRepository
    {
        private readonly string _connectionString;

        public GameRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Game> GetAllGames()
        {
            var games = new List<Game>();
            string SQL = "SELECT * FROM GameCollectibles.dbo.Game;";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(SQL, connection))
            {
                connection.Open();

                try
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            games.Add(new Game((string)reader["Title"])
                            .setGameID((int)reader["ID"])
                            .setGameDescription((string)reader["Description"]));
                        }
                    }
                    return games;
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();

                }
                

            }


        }

        public void AddGame(Game game)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sqlInsert = "INSERT INTO GameCollectibles.dbo.Game (Title, Description) VALUES (@gameTitle, @gameDescription)";

                using (SqlCommand cmd = new SqlCommand(sqlInsert, connection))
                {
                    cmd.Parameters.AddWithValue("@gameTitle", game.gameTitle);
                    cmd.Parameters.AddWithValue("@gameDescription", game.gameDescription);
                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public Game? GetGameById(int? id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT ID, Title, Description FROM GameCollectibles.dbo.Game WHERE ID = @GameID";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@GameID", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Game((string)reader["Title"])
                            .setGameID((int)reader["ID"])
                            .setGameDescription((string)reader["Description"]);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }


        }


    public void DeleteGame(int id)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string sqlDelete = "DELETE FROM GameCollectibles.dbo.Game WHERE ID = @gameID";

            using (SqlCommand cmd = new SqlCommand(sqlDelete, connection))
            {
                cmd.Parameters.AddWithValue("@gameID", id);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

            }
        }
    }

    public void EditGame(Game game)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string sqlUpdate = "UPDATE GameCollectibles.dbo.Game SET Title = @gameTitle, Description = @gameDescription WHERE ID = @gameID;";

            using (SqlCommand cmd = new SqlCommand(sqlUpdate, connection))
            {
                cmd.Parameters.AddWithValue("@gameTitle", game.gameTitle);
                cmd.Parameters.AddWithValue("@gameDescription", game.gameDescription);
                cmd.Parameters.AddWithValue("@gameID", game.gameID);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }

}
    
}

