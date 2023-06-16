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
using Microsoft.AspNetCore.Http;
using GameCollectiblesCore.Categories;
using GameCollectiblesData.Collectibles;

namespace GameCollectiblesData.Categories
{

    public class CategoryRepository : ICategoryRepository
    {
        private readonly string _connectionString;
        private readonly CollectibleRepository _collectibleRepository;


        public CategoryRepository(string connectionString)
        {
            _collectibleRepository = new CollectibleRepository(connectionString);
            _connectionString = connectionString;
        }

        public IEnumerable<Category> GetCategories(int gameID)
        {
            var categories = new List<Category>();
            string SQL = "SELECT * FROM GameCollectibles.dbo.Category WHERE GameID = @gameID;";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(SQL, connection))
            {
                command.Parameters.AddWithValue("@gameID", gameID);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        categories.Add(new Category(gameID, (int)reader["ID"], (string)reader["Name"])
                        .setDescription((string)reader["Description"]));                    
                    }
                }

                connection.Close();
                return categories;
            }


        }
         public void createCategory(Category category)
        {

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sqlInsert = "INSERT INTO category (GameID, [Name], [Description]) VALUES (@gameID, @categoryName, @categoryDescription)";
                
                using (SqlCommand cmd = new SqlCommand(sqlInsert, connection))
                {
                    cmd.Parameters.AddWithValue("@categoryName", category.categoryName);
                    cmd.Parameters.AddWithValue("@categoryDescription", category.categoryDescription);
                    cmd.Parameters.AddWithValue("@gameID", category.gameID);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }


        public IEnumerable<Category> GetCategoriesCollectibles(int gameID, int? userID)
        {
            var collectibleList = new List<GameCollectiblesCore.Collectibles.Collectible>();
            var categories = new List<Category>();
            var processedCategoryIDs = new HashSet<int>(); // Track unique category IDs

            string SQL = "SELECT Collectible.ID AS collectibleID, Collectible.[Name] AS collectibleName, Collectible.[Description] AS collectibleDescription, Category.ID AS categoryID, Category.[Name] AS categoryName, Category.[Description] AS categoryDescription, Category.GameID FROM Collectible INNER JOIN Category ON Category.ID = Collectible.CategoryID WHERE GameID = @gameID";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(SQL, connection))
            {
                command.Parameters.AddWithValue("@gameID", gameID);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var categoryID = (int)reader["categoryID"];
                        if (processedCategoryIDs.Contains(categoryID))
                        {
                            // Skip this category as it has already been processed
                            continue;
                        }

                        collectibleList.Add(new GameCollectiblesCore.Collectibles.Collectible(categoryID, (int)reader["collectibleID"], (string)reader["collectibleName"], (string)reader["collectibleDescription"], _collectibleRepository.getIsCollected(gameID, userID))
                        .setGameID(gameID));
                        categories.Add(new Category(gameID, categoryID, (string)reader["categoryName"])
                        .setDescription((string)reader["categoryDescription"])
                        .setCollectibles(collectibleList));

                        

                        processedCategoryIDs.Add(categoryID);
                    }
                }

                connection.Close();
                return categories;
            }
        }





    }
}

