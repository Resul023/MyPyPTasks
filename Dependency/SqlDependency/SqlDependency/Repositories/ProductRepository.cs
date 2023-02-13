using Microsoft.Extensions.Caching.Memory;
using SqlDependency.Models;
using SqlDependency.ViewModels;
using System.Data;
using System.Data.SqlClient;

namespace SqlDependency.Repositories
{
    public class ProductRepository
    {
        string connectionString;
        private readonly IMemoryCache _cache;
        private readonly string CACHE_PRODUCT_KEY ="_product";
        public ProductRepository(string connectionString,IMemoryCache cache)
        {
            this.connectionString = connectionString;
            this._cache = cache;
        }

        public ProductViewModel GetProducts()
        {
            List<Product> products= new List<Product>();
            Product product;

            var data = GetAllProductsDetail();
            foreach (DataRow row in data.Rows)
            {
                product = new Product
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    Category = row["Category"].ToString(),
                    Price = Convert.ToDecimal(row["Price"])
                };
                products.Add(product);
            }
            //Add cache
            List<Product> cacheProduct;
            if (!_cache.TryGetValue(CACHE_PRODUCT_KEY,out cacheProduct))
            {
                cacheProduct = products;
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(30));
                _cache.Set(CACHE_PRODUCT_KEY, cacheProduct, cacheEntryOptions);

            }
            DateTime dateTime = DateTime.Now;
            ProductViewModel productViewModel = new ProductViewModel(cacheProduct, dateTime.ToString("MM/dd/yyyy HH:mm"));
            return productViewModel;
        }
        public DataTable GetAllProductsDetail()
        {
            var query = "SELECT * FROM Product";
            DataTable dataTable= new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query,connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
                connection.Close();
            }
            return dataTable;
        }
    }
}
