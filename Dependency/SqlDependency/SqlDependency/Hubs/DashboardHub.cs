using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;
using SqlDependency.Repositories;

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
        public async Task SendProducts()
        {
            var products = productRepository.GetProducts();
            await Clients.All.SendAsync("ReceivedProducts", products);
        }
    }
}
