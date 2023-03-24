using System.Data.SqlClient;
using System.Configuration;
using CrudExample.Models;
using System.Reflection.PortableExecutable;
namespace CrudExample.DAL
{
    public class Product_DAL
    {
        string conString = "Server=DESKTOP-705H4SM;Database=ProductManagement;Trusted_Connection=True";
        //AddProduct
        public bool AddProduct(Product product)
        {
            int ProductCheck = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("AddProduct", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Description", product.Description);
                connection.Open();
                ProductCheck = command.ExecuteNonQuery();
                connection.Close();
            }
            if (ProductCheck > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //DeleteProduct
        public bool DeleteProduct(Product product)
        {
            int ProductCheck = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("DeleteProduct", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductID", product.ProductID);
                connection.Open();
                ProductCheck = command.ExecuteNonQuery();
                connection.Close();
            }
            if (ProductCheck > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //UpdateProduct
        public bool UpdateProduct(Product product)
        {
            int ProductCheck = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("UpdateProduct", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductID", product.ProductID);
                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Description", product.Description);
                connection.Open();
                ProductCheck = command.ExecuteNonQuery();
                connection.Close();
            }
            if (ProductCheck > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //GET PRODUCT'I USER DALDAKİ GİBİ YAP...
        public bool GetProductByID(Product product)
        {
            int ProductCheck = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("GetProduct", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@GetProductByID", product.ProductID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                connection.Close();
            }

        }
        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("GetAllProducts", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.ProductID = Convert.ToInt32(reader["ProductID"]);
                    product.ProductName = reader["ProductName"].ToString();
                    product.Price = Convert.ToDecimal(reader["Price"]);
                    product.Description = reader["Description"].ToString();
                    products.Add(product);
                }
                reader.Close();
                connection.Close();
            }
            return products;
        }
       
        public List<Product> SearchProducts()
        {
            List<Product> products = new List<Product>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("SearchProducts", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@SearchTerm", SearchProducts);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Product> results = new List<Product>();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.ProductName = reader["ProductName"].ToString();
                    products.Add(product);
                }
                reader.Close();
                connection.Close();
            }
            return products;
        }
    }
}
