using SqlDependency.Hubs;
using SqlDependency.Models;
using TableDependency.SqlClient;

namespace SqlDependency.SubscribeTableDependencies
{
    public class SubscribeProductTableDependency
    {
        SqlTableDependency<Product> tableDependency;
        DashboardHub dashboardHub;
        public SubscribeProductTableDependency( DashboardHub dashboardHub)
        {
            this.dashboardHub = dashboardHub;
        }

        public void SubscribeTableDependency()
        {
            string connectionString = "server=localhost;database=DependencyDb;Trusted_Connection=True;TrustServerCertificate=True";
            tableDependency = new SqlTableDependency<Product>(connectionString);
            tableDependency.OnChanged += TableDependency_OnChanged;
            tableDependency.OnError += TableDependency_OnError;
            tableDependency.Start();
        }
        private void TableDependency_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<Product> e)
        {
            //if (e.ChangeType != TableDependency.SqlClient.Base.Enums.ChangeType.None)
            //{
            //}
                dashboardHub.SendProducts();
            
        }

        private void TableDependency_OnError(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
        {
            Console.WriteLine($"{nameof(Product)} SqlDependencyError error: {e.Error.Message}");
        }

    }
}
