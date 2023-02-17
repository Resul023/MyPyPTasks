using Microsoft.Extensions.Caching.Memory;
using SqlDependency.Models;
using SqlDependency.ViewModels;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

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

            var dataTable = GetAllProductsDetail();
            foreach (DataRow row in dataTable.Rows)
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
            #region V1
             //Add cache
            List<Product> cacheProduct;
            if (!_cache.TryGetValue(CACHE_PRODUCT_KEY, out cacheProduct))
            {
                cacheProduct = products;
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(30));
                _cache.Set(CACHE_PRODUCT_KEY, cacheProduct, cacheEntryOptions);

            }
            DateTime dateTime = DateTime.Now;
            ProductViewModel productViewModel = new ProductViewModel(cacheProduct, dateTime.ToString("MM/dd/yyyy HH:mm"));
            #endregion

            #region V2
            string xmlPath = Directory.GetCurrentDirectory() + @"\XmlData.xml";
            StreamWriter createXmlFile = new StreamWriter(xmlPath);
            //XmlDocument xmlDocument = new XmlDocument();
            //xmlDocument.Load(xmlPath);
            createXmlFile.Close();
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(dataTable);
            dataSet.WriteXml(xmlPath);
            #endregion



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
