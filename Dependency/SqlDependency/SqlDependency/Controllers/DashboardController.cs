using Microsoft.AspNetCore.Mvc;
using SqlDependency.DATA;
using SqlDependency.Models;
using System.Data;
using System.Data.SqlClient;

namespace SqlDependency.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public DashboardController(AppDbContext context, IConfiguration configuration)
        {
            this._context = context;
            this._configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            Product model = _context.Product.FirstOrDefault(x => x.Id == id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("default")))
            {
                var query = $"UPDATE Product Set Name = @name ,Category = @category, Price =@price  Where Id = @Id";
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.Connection = connection;
                command.CommandText = query;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = product.Name;
                command.Parameters.AddWithValue("@price", SqlDbType.Decimal).Value = product.Price;
                command.Parameters.AddWithValue("@category", SqlDbType.NVarChar).Value = product.Category;
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = product.Id;
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            //var isExists = _context.Product.FirstOrDefault(x => x.Id == product.Id);
            //isExists.Name = product.Name;
            //_context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
