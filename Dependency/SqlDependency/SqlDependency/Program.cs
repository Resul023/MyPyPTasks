using Microsoft.EntityFrameworkCore;
using SqlDependency.BackgroundServices;
using SqlDependency.DATA;
using SqlDependency.Hubs;
using SqlDependency.MiddlewareExtension;
using SqlDependency.SubscribeTableDependencies;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHostedService<MyBackgroundServices>();
//builder.Services.AddWindowsService();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("default"));
});
// Service ProductSub
builder.Services.AddSingleton<DashboardHub>();
//builder.Services.AddSingleton<SubscribeProductTableDependency>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapHub<DashboardHub>("/dashboardHub");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

//app.UseProductTableDependency();
//app.Services.GetService<SubscribeProductTableDependency>().SubscribeTableDependency();
app.Run();
