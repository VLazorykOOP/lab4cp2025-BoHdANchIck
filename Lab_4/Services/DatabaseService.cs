using Lab_4.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4.Services
{
    public class DatabaseService
    {
        private readonly string connectionString = "server=localhost;user=root;password=KiCo72L9gi7g;database=DairyProduction";

        public List<DairyProduct> GetAllProducts()
        {
            var products = new List<DairyProduct>();

            using var conn = new MySqlConnection(connectionString);
            conn.Open();
            var cmd = new MySqlCommand("SELECT * FROM DairyProduct", conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                products.Add(new DairyProduct
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    Category = reader.GetString("category"),
                    Type = reader.GetString("type"),
                    ExpirationDate = reader.GetDateTime("expiration_date"),
                    Supplier = reader.GetString("supplier"),
                    Price = reader.GetDecimal("price")
                });
            }

            return products;
        }

        public bool Login(string username, string password)
        {
            using var conn = new MySqlConnection(connectionString);
            conn.Open();
            var cmd = new MySqlCommand("SELECT * FROM Users WHERE username=@u AND password=@p", conn);
            cmd.Parameters.AddWithValue("@u", username);
            cmd.Parameters.AddWithValue("@p", password);
            using var reader = cmd.ExecuteReader();

            return reader.Read(); 
        }
        public void AddProduct(DairyProduct product)
        {
            using var conn = new MySqlConnection(connectionString);
            conn.Open();
            var cmd = new MySqlCommand(@"
                INSERT INTO DairyProduct (name, category, type, expiration_date, supplier, price)
                VALUES (@name, @category, @type, @expiration_date, @supplier, @price)", conn);

            cmd.Parameters.AddWithValue("@name", product.Name);
            cmd.Parameters.AddWithValue("@category", product.Category);
            cmd.Parameters.AddWithValue("@type", product.Type);
            cmd.Parameters.AddWithValue("@expiration_date", product.ExpirationDate);
            cmd.Parameters.AddWithValue("@supplier", product.Supplier);
            cmd.Parameters.AddWithValue("@price", product.Price);

            cmd.ExecuteNonQuery();
        }
        public void UpdateProduct(DairyProduct product)
        {
            using var conn = new MySqlConnection(connectionString);
            conn.Open();
            var cmd = new MySqlCommand(@"
                UPDATE DairyProduct SET
                    name = @name,
                    category = @category,
                    type = @type,
                    expiration_date = @expiration_date,
                    supplier = @supplier,
                    price = @price
                WHERE id = @id", conn);

            cmd.Parameters.AddWithValue("@name", product.Name);
            cmd.Parameters.AddWithValue("@category", product.Category);
            cmd.Parameters.AddWithValue("@type", product.Type);
            cmd.Parameters.AddWithValue("@expiration_date", product.ExpirationDate);
            cmd.Parameters.AddWithValue("@supplier", product.Supplier);
            cmd.Parameters.AddWithValue("@price", product.Price);
            cmd.Parameters.AddWithValue("@id", product.Id);

            cmd.ExecuteNonQuery();
        }
        public List<DairyProduct> SearchProducts(string name, string category, string supplier)
        {
            var products = new List<DairyProduct>();

            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            var cmd = new MySqlCommand("SELECT * FROM DairyProduct WHERE " +
                "(@name = '' OR name LIKE CONCAT('%', @name, '%')) AND " +
                "(@category = '' OR category LIKE CONCAT('%', @category, '%')) AND " +
                "(@supplier = '' OR supplier LIKE CONCAT('%', @supplier, '%'))", conn);

            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@category", category);
            cmd.Parameters.AddWithValue("@supplier", supplier);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                products.Add(new DairyProduct
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    Category = reader.GetString("category"),
                    Type = reader.GetString("type"),
                    ExpirationDate = reader.GetDateTime("expiration_date"),
                    Supplier = reader.GetString("supplier"),
                    Price = reader.GetDecimal("price")
                });
            }

            return products;
        }
        public void DeleteProduct(int productId)
        {
            using var conn = new MySqlConnection(connectionString);
            conn.Open();
            var cmd = new MySqlCommand("DELETE FROM DairyProduct WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", productId);
            cmd.ExecuteNonQuery();
        }

    }
}
