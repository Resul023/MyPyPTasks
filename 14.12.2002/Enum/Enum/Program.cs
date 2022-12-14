using EnumTask;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Reflection;

class Program
{

    static public void Main(String[] args)
    {
        //var stringColor = Colors.Green;
        //var dbConnection = DbConnections.MySql;
        //Console.WriteLine(stringColor.GetDisplayName());
        //Console.WriteLine(dbConnection.GetDisplayName());
        Colors colors = new Colors();
        DbConnections dbConnections = new DbConnections();
        colors.GenericGetDisplayName();
        dbConnections.GenericGetDisplayName();





    }
}
