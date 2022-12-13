using Reflection;
using System;
using System.Reflection;

class Program
{
    static public void Main(String[] args)
    {
        User newUser = new User("Yilmaz","yilmaz@code.edu.az");
        GetAllProperties(newUser);
        var myMethod = newUser.GetType().GetMethod("GetEmail");
        string myEmail = "yilmazNewEmail@code.edu.az";
        var myMethodInvoke = myMethod.Invoke(newUser, new object[] { myEmail });
        Console.WriteLine(myMethodInvoke);
    }
    static void GetAllProperties(User user)
    {
        foreach (var item in user.GetType().GetProperties())
        {
            Console.WriteLine($"{item.Name}-{item.GetValue(user)}");
        }
    }
}
