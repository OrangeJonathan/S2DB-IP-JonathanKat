using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using GameCollectiblesCore;
using GameCollectiblesCore.Collectibles;
using Microsoft.AspNetCore.Http;

namespace GameCollectiblesData.Collectibles
{

    public class CollectibleRepository : ICollectibleRepository
    {
        private readonly string _connectionString;

        public CollectibleRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Collectible> GetCollectibles(int categoryID, int? userID)
        {
            var collectibles = new List<Collectible>();
            string SQL = "SELECT ID, [Name], [Description] FROM Collectible WHERE CategoryID = @categoryID";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(SQL, connection))
            {
                command.Parameters.AddWithValue("@categoryID", categoryID);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        collectibles.Add(new Collectible(categoryID, (int)reader["ID"], (string)reader["Name"], (string)reader["Description"], getIsCollected((int)reader["ID"], userID)));
                    }
                }

                connection.Close();
                return collectibles;
            }

        }
        public void createCollectible(Collectible collectible, int categoryID)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sqlInsert = "INSERT INTO Collectible (CategoryID, [Name], [Description]) VALUES (@categoryID, @collectibleName, @collectibleDescription)";
                
                using (SqlCommand cmd = new SqlCommand(sqlInsert, connection))
                {
                    cmd.Parameters.AddWithValue("@collectibleName", collectible.collectibleName);
                    cmd.Parameters.AddWithValue("@collectibleDescription", collectible.collectibleDescription);
                    cmd.Parameters.AddWithValue("@categoryID", categoryID);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                
            }
        }
        public bool getIsCollected(int collectibleID, int? userID)
        {
            bool isCollected = false; 
            string SQL = "SELECT * FROM user_collectibles WHERE collectibleID = @collectibleID AND UserID = @userID";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(SQL, connection))
            {
                command.Parameters.AddWithValue("@collectibleID", collectibleID);
                command.Parameters.AddWithValue("@userID", userID);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["UserID"] != null)
                        {
                            isCollected = true;

                        }
                        else
                        {
                            isCollected = false;
                        }

                        isCollected = (bool)reader["Collected"];
                    }
                }

                connection.Close();
                
            }
            return isCollected;
        }

        public void createUserCollectible(int collectibleID, int? userId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sqlInsertUserCollectible = "INSERT INTO User_Collectibles (UserID, CollectibleID, Collected) VALUES (@userID, @collectibleID, @isCollected)";

                using (SqlCommand command = new SqlCommand(sqlInsertUserCollectible, connection))
                {
                    command.Parameters.AddWithValue("@userID", userId);
                    command.Parameters.AddWithValue("@collectibleID", collectibleID);
                    command.Parameters.AddWithValue("@isCollected", true);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                
            }
            
        }

        public void DeleteUserCollectible(int collectibleID, int? userId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sqlDelete = "DELETE FROM User_Collectibles WHERE collectibleID = @collectibleID AND userID = @userID";

                using (SqlCommand cmd = new SqlCommand(sqlDelete, connection))
                {
                    cmd.Parameters.AddWithValue("@collectibleID", collectibleID);
                    cmd.Parameters.AddWithValue("@userID", userId);
                    
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                }
            }
        }


        public void UpdateUserCollectible(int collectibleID, bool collectibleIsCollected, int? userId)
        {
            bool isCollected = !collectibleIsCollected;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sqlUpdate = "UPDATE User_Collectibles SET Collected = @isCollected WHERE UserID = @userID AND CollectibleId = @collectibleID";

                using (SqlCommand cmd = new SqlCommand(sqlUpdate, connection))
                {
                    cmd.Parameters.AddWithValue("@userID", userId);
                    cmd.Parameters.AddWithValue("@collectibleID", collectibleID);
                    cmd.Parameters.AddWithValue("@isCollected", isCollected);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

    }
}

