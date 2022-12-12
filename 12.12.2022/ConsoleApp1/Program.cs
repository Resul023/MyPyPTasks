using ConsoleApp1;
using System;

class Program
{
    public static void Main(String[] args)
    {
        var categories = CreatedCategories();
        var suppliers = CreatedSupliers();
        var products = CreatedProduct();
        var employees = CreatedEmployee();
        var clients = CreatedClient();
        var kargo = CreatedKargo();
        var orders = CreatedOrder(products);
        kargo.Orders = orders;
        kargo.EmployeeId = 1;
        Console.WriteLine("Order Detail-0");
        Console.WriteLine("Looking Kargo Status-1");
        Console.WriteLine("Change Kargo status change to (on road)-2");
        Console.WriteLine("Change Kargo status change to (received by client)-3");
        Console.WriteLine("Finish Project -4");
        bool isContinue = true;
        while (isContinue)
        {
            var option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 0:

                    foreach (var order in orders)
                    {
                        foreach (var client in clients)
                        {
                            if (order.ClientId == client.Id)
                            {
                                Console.WriteLine($"Client FullName-{client.Name} {client.Surname}");
                                Console.WriteLine($"Kargo Name-{kargo.Name}");
                            }
                        }

                    }
                    break;
                case 1:

                    if (kargo.EmployeeId == 1 && !kargo.ReceivedByClient)
                    {
                        kargo.OrderStatus = "Prepared";
                    }
                    else if (kargo.ReceivedByClient)
                    {
                        kargo.OrderStatus = "The product has been delivered";
                    }
                    
                    else
                    {
                        kargo.OrderStatus = "On Road";
                    }
                    Console.WriteLine(kargo.OrderStatus);
                    break;
                case 2:
                    if (kargo.EmployeeId == 2)
                    {
                        Console.WriteLine("Kargo status is already on road");
                    }
                    else
                    {
                        kargo.EmployeeId = 2;
                    }
                    
                    break;
                case 3:
                    if (kargo.EmployeeId == 2)
                    {
                        kargo.ReceivedByClient = true;
                    }
                    else
                    {
                        Console.WriteLine("Kargo is preparing right now.You have to change status to On road");
                    }
                    break;
                case 4:
                    isContinue = false;
                    break;
                default:
                    Console.WriteLine("You have to choose only 0,1,2,3,4");
                    break;
            }
        }
        


    }
    
    static Category[] CreatedCategories()
    {
        Category category1 = new Category
        {
            Id = 1,
            Name = "T-shirt"
        };
        Category category2 = new Category
        {
            Id = 2,
            Name = "Jacket"
        };
        Category category3 = new Category
        {
            Id = 3,
            Name = "Bag"
        };
        Category[] categories = new Category[3];
        categories[0] = category1;
        categories[1] = category2;
        categories[2] = category3;
        return categories;
    }

    static Supplier[] CreatedSupliers()
    {
        Supplier supplier1 = new Supplier
        {
            Id = 1,
            Name = "Zara"
        };
        Supplier supplier2 = new Supplier
        {
            Id = 2,
            Name = "Bershka"
        };
        Supplier[] suppliers = new Supplier[2];
        suppliers[0] = supplier1;
        suppliers[1] = supplier2;
        return suppliers;
    }
    static Product[] CreatedProduct()
    {
        Product product1 = new Product 
        {
            Id = 1,
            Name = "Slim Fit Bisiklet Yaka Uzun Kollu Basic Tişört",
            CategoryId = 1,
            SupplierId =1,
        };
        Product product2 = new Product
        {
            Id = 2,
            Name = "Deri Canta",
            CategoryId = 3,
            SupplierId = 1,
        };
        Product product3 = new Product
        {
            Id = 3,
            Name = "Deri Jacket",
            CategoryId = 2,
            SupplierId = 2,
        };
        Product[] products = new Product[3];
        products[0] = product1;
        products[1] = product2;
        products[2] = product3;
        return products;
    }
    static Client[] CreatedClient()
    {
        Client client1 = new Client
        {
            Id = 1,
            Name = "Yavuz",
            Surname = "Yilmaz"
        };
        Client client2 = new Client
        {
            Id = 2,
            Name = "Sahin",
            Surname = "Aktas"
        };
        Client[] clients = new Client[2];
        clients[0]= client1;
        clients[1]= client2;
        return clients;
    }
    static Employee[] CreatedEmployee()
    {
        Employee employee1 = new Employee
        {
            Id = 1,
            Position= "Preparer"
        };
        Employee employee2 = new Employee
        {
            Id = 2,
            Position = "Carrier"
        };
        Employee[] employees = new Employee[2];
        employees[0] = employee1;   
        employees[1] = employee2;
        return employees;
    }
    static Kargo CreatedKargo()
    {
        Kargo kargo = new Kargo
        {
            Id = 1, 
            Name = "Fedex",
        };
        return kargo;
    }

    static Order[] CreatedOrder(Product[] products)
    {
        Order order1 = new Order
        {
            Products = new Product[2],
            KargoId = 1,
            ClientId = 2,
        };
        order1.Products[0]= products[0];
        order1.Products[1]= products[2];

        Order[] orders = new Order[1];
        orders[0] = order1;
        return orders;
    }
}
