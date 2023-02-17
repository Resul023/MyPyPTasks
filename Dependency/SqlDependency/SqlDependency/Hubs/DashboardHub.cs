using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;
using SqlDependency.Models;
using SqlDependency.Repositories;
using SqlDependency.ViewModels;

namespace SqlDependency.Hubs
{
    public class DashboardHub:Hub
    {
        private readonly IMemoryCache _cache;
        ProductRepository productRepository;

        public DashboardHub(IConfiguration configuration,IMemoryCache cache)
        {
            this._cache = cache;
            var connectionString = configuration.GetConnectionString("default");
            productRepository= new ProductRepository(connectionString,_cache);
        }
        //public async Task SendProducts()
        //{
        //    var products = productRepository.GetProducts();
        //    await Clients.All.SendAsync("ReceivedProducts", products);
        //}
        public async Task SendProductsXml(ProductViewModel productViewModel)
        {
            //var products = productRepository.GetProducts();
            await Clients.All.SendAsync("ReceivedProducts", productViewModel);
        }
        //public async Task SendProducts(ProductViewModel productViewModel)
        //{
        //    await Clients.All.SendAsync("ReceivedProducts", productViewModel);
        //}
    }
}
