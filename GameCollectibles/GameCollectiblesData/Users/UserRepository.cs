using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollectiblesCore;
using GameCollectiblesCore.Users;


namespace GameCollectiblesData.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = new List<User>();
            string SQL = "SELECT * FROM [User] ORDER BY ID asc";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(SQL, connection))
            {
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            userID = (int)reader["ID"],
                            userName = (string)reader["UserName"],
                        });
                    }
                }

                connection.Close();
                return users;
            }
        }
    }
}

