using SqlDependency.Models;

namespace SqlDependency.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel(List<Product> products, string dateTime)
        {
            this.products = products;
            this.dateTime = dateTime;
        }

        public List<Product> products { get; set; }
        public string dateTime { get; set; }
    }
}
