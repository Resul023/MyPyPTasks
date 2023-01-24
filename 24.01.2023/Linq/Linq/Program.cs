using Linq.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NorthwindContext context = new NorthwindContext();

            #region Linq to Entity

            //1
            //context.Orders
            //    .Include(x => x.Customer)
            //    .Include(x => x.Employee)
            //    .Select(x => new { x.Customer.CompanyName, x.Employee.FirstName, x.Employee.LastName, x.OrderId, x.ShippedDate,x.ShipVia})
            //    .ToList()
            //    .ForEach(x => {
            //        Console.WriteLine($"""
            //            {x.CompanyName} - {x.FirstName} - {x.LastName} - {x.OrderId} - {x.ShippedDate} -{context.Shippers.FirstOrDefault(y=>y.ShipperId == x.ShipVia.Value).CompanyName}
            //            _______________________________________________________________________________________
            //            """);
            //    });

            //2
            //context.Employees
            //    .Select(x => new { x.FirstName, x.LastName, x.BirthDate })
            //    .ToList()
            //    .ForEach(x =>
            //    {
            //        if (x.BirthDate != null)
            //        {

            //            Console.WriteLine($"{x.FirstName} - {x.LastName} - {x.BirthDate} - {DateTime.Now.Year - x.BirthDate.Value.Year}  ");
            //        }
            //        else
            //        {
            //            Console.WriteLine($"{x.FirstName} - {x.LastName} - {x.BirthDate} ");
            //        }
            //        Console.WriteLine("______________________________________________________________");
            //    });

            //3
            //context.Customers
            //    .Where(x => x.CompanyName.Contains("Restaurant"))
            //    .ToList()
            //    .ForEach(x => {
            //        Console.WriteLine(x.CompanyName);
            //    });

            //4
            //var result = context.Products
            //    .Include(x=>x.Category)
            //    .GroupBy(x => x.CategoryId)
            //    .ToList();
            //foreach (var item in result)
            //{
            //    Console.WriteLine($"{item.Key} - {context.Categories.FirstOrDefault(x=>x.CategoryId == item.Key).CategoryName} - {item.Count()}");
            //}

            //5
            //Product product = new Product();
            //product.ProductName = "Cola";
            //product.UnitPrice= 5;
            //product.UnitsInStock= 500;
            //product.CategoryId = context.Categories.FirstOrDefault(x => x.CategoryName == "Beverages").CategoryId;
            //context.Products.Add(product); 
            //context.SaveChanges();

            #endregion

            #region Linq to Sql
            //1
            //var query = (from o in context.Orders
            //            join c in context.Customers on o.CustomerId equals c.CustomerId
            //            join e in context.Employees on o.EmployeeId equals e.EmployeeId
            //            join s in context.Shippers on o.ShipVia equals s.ShipperId
            //            select new 
            //            {
            //                CompanyName = c.CompanyName,
            //                FullName =e.FirstName + ' ' + e.LastName ,
            //                OrderId = o.OrderId,
            //                ShipDate = o.ShippedDate,
            //                Company = s.CompanyName
            //            }).ToList();

            //query.ForEach(x => 
            //{
            //    Console.WriteLine($"{x.CompanyName} - {x.FullName} - {x.OrderId} - {x.ShipDate} - {x.Company}");
            //});

            //2
            //var query = (from o in context.Employees
            //             select new
            //             {
            //                 FirstName = o.FirstName,
            //                 LastName = o.LastName,
            //                 BirthDate = o.BirthDate,
            //                 Age = DateTime.Now.Year - (o.BirthDate.Value.Year != null ? o.BirthDate.Value.Year : 0)
            //             }).ToList();
            //query.ForEach(x =>
            //{
            //    Console.WriteLine($"{x.FirstName} - {x.LastName} - {x.BirthDate} - {x.Age}");
            //});

            //3
            //var query = (from o in context.Customers
            //             where o.CompanyName.Contains("Restaurant")
            //             select o
            //            ).ToList();
            //query.ForEach(x =>
            //{
            //    Console.WriteLine($"{x.CompanyName} - {x.ContactName} - {x.Country} - {x.ContactTitle}");
            //});

            //4
            //var query = (from o in context.Categories
            //             join p in context.Products on o.CategoryId equals p.CategoryId
            //             group o by (o.CategoryId)
            //    ).ToList();

            //foreach (var item in query)
            //{
            //    Console.WriteLine($"Id-{item.Key}");
            //    foreach (var item2 in item)
            //    {
            //        Console.WriteLine($"{item2.CategoryName} - {item2.Description}");
            //        break;
            //    }
            //}

            //5
            //Product product = new Product();
            //product.ProductName = "Cola";
            //product.UnitPrice = 5;
            //product.UnitsInStock = 500;
            //product.CategoryId = context.Categories.FirstOrDefault(x => x.CategoryName == "Beverages").CategoryId;
            //context.Products.Add(product);
            //context.SaveChanges();
            #endregion
        }
    }
}