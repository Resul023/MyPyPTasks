using Microsoft.Extensions.Caching.Memory;
using SqlDependency.Hubs;
using SqlDependency.Models;
using SqlDependency.ViewModels;
using System.Data;
using System.Xml.Serialization;

namespace SqlDependency.BackgroundServices;

public class MyBackgroundServices : BackgroundService
{
    DashboardHub dashboardHub;

    public MyBackgroundServices(DashboardHub dashboardHub)
    {
        this.dashboardHub = dashboardHub;

    }
    static FileSystemWatcher watcher;
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("Background Service is starting");
        watcher = new();
        watcher.Path = Directory.GetCurrentDirectory();
        watcher.Filter = "*.xml";
        watcher.Changed += Watcher_Changed;
        watcher.IncludeSubdirectories= true;
        watcher.EnableRaisingEvents = true;
    }

    private void Watcher_Changed(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine("Data has been changed");
        var xmlSerializer = new XmlSerializer(typeof(List<Product>));
        var path = Directory.GetCurrentDirectory() + "\\XmlData.xml";

        ProductViewModel productViewModel;
        using(FileStream reader = new FileStream(path, FileMode.Open,FileAccess.Read))
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(reader);
            reader.Dispose();
            List<Product> products = new List<Product>();
            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                Product newProduct = new Product()
                {
                    Id = Convert.ToInt32(dataSet.Tables[0].Rows[i][0]),
                    Name = dataSet.Tables[0].Rows[i][1].ToString(),
                    Price = Convert.ToDecimal(dataSet.Tables[0].Rows[i][2]),
                    Category = dataSet.Tables[0].Rows[i][3].ToString()

                };
                products.Add(newProduct);
            }
            productViewModel = new ProductViewModel(products, DateTime.Now.ToString("MM/dd/yyyy HH:mm"));
        }
        Task.Delay(2000).Wait();
        dashboardHub.SendProductsXml(productViewModel);

    }
}
