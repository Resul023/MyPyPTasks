using DataAccess.Models;
using DataAccess.Services;
using Pluralize.NET;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace DataAccess
{
    internal class Program
    {
        
        
        static void Main(string[] args)
        {
            bool continueForMenu = true;
            Console.WriteLine($"""
                1-Add Person (a);
                1-Get All Person (l);
                1-Get Person (s);
                1-Exit (e)
                """);
            while (continueForMenu)
            {
                string options = Console.ReadLine();
                Console.Clear();
                Console.WriteLine($"""
                1-Add Person (a);
                2-Get All Person (l);
                3-Get Person (s);
                4-Exit (e)

                """);
                switch (options)
                {
                    case "a":
                        Person person = SetDataToPerson();
                        Console.WriteLine("Are you sure for add data Y/N:");
                        string answer = Console.ReadLine();
                        bool optionForAdd = true;
                        while (optionForAdd)
                        {
                            if (answer == "Y")
                            {
                                PersonService.InsertPerson(person);
                                Console.WriteLine("Data saved");
                                optionForAdd = false;
                            }
                            else if (answer == "N")
                            {
                                Console.WriteLine("Data was not save");
                                optionForAdd = false;
                            }
                        }
                        break;
                    case "l":
                        List<Person> persons = PersonService.GetAllPerson();
                        Console.WriteLine($"""
                            Id      FirstName       Soyadi                Telefon                       Mail      
                            _______________________________________________________________________________________________________

                           """);
                        foreach (var pers in persons)
                        {
                            Console.WriteLine($""" 
                            {pers.Id,2}       {pers.FirstName,6}     {pers.LastName,13}       {pers.Phone,25}            {pers.Email,27}

                            """);
                        }
                            Console.WriteLine("Do you want to delete data in database then-D");
                            Console.WriteLine("Back to menu-M");
                            bool continueForDelete = true;
                        
                        while (continueForDelete)
                        {
                            string answerForDelete = Console.ReadLine();
                            if (answerForDelete == "D")
                            {
                                Console.WriteLine("Enter Id");
                                int id = int.Parse(Console.ReadLine());
                                PersonService.DeletePerson(id);
                                continueForDelete = false;
                                Console.Clear();
                            }
                            else if (answerForDelete == "M")
                            {
                                continueForDelete = false;
                                Console.Clear();
                            }
                            else
                            {
                                continueForDelete = true;
                            }
                        }
                        break;
                    case "s":
                        Console.WriteLine("Write Search keyword");
                        string keywordForSearch = Console.ReadLine();
                        List<Person> personForSearch = PersonService.GetPerson(keywordForSearch);
                        if (personForSearch.Count > 0)
                        {
                            foreach (var pers in personForSearch)
                            {
                                Console.WriteLine($"""
                                FirstName - {pers.FirstName}
                                LastName - {pers.LastName}
                                Phone - {pers.Phone}
                                Email - {pers.Email}
                                """);
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no this kind of user");
                        }
                        break;
                    case "e":
                        continueForMenu = false;
                        break;
                    default:
                        Console.WriteLine("Choose again");
                        break;
                }
            }

        }
        static Person SetDataToPerson()
        {
            Console.WriteLine("First Name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Last Name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Email:");
            string email = Console.ReadLine();
            Console.WriteLine("Number:");
            string number = Console.ReadLine();
            Person person = new Person
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,  
                Phone= number,
            };
            return person;
        }
    }
}