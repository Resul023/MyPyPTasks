using SqlDependency.SubscribeTableDependencies;

namespace SqlDependency.MiddlewareExtension
{
    public static class ApplicationBuilderExtension
    {
        public static void UseProductTableDependency(this IApplicationBuilder app)
        {
            var serviceProvider = app.ApplicationServices;
            var service = serviceProvider.GetService<SubscribeProductTableDependency>();
            service.SubscribeTableDependency();
        }
    }
}
