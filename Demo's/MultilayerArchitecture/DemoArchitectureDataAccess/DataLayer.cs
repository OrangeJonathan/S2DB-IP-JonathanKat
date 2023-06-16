using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoArchitectureDataAccess
{
    public class DataLayer
    {
        private readonly string _connectionString;

        public DataLayer()
        {
            _connectionString = "Data Source=(local);Initial Catalog=MyDatabase;Integrated Security=True";
        }

        public List<ProductDto> GetProducts()
        {
            var products = new List<ProductDto>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT * FROM Products", connection);

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var product = new ProductDto
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        Name = reader.GetString(reader.GetOrdinal("Name")),
                        Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                        Description = reader.GetString(reader.GetOrdinal("Description")),
                    };

                    products.Add(product);
                }
            }

            return products;
        }
    }
}
