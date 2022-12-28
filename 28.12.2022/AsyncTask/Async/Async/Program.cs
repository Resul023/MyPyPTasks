using Async.Models;
using Async.Service;
using Async.Validation;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Numerics;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Async
{
    internal class Program
    {
        static bool isTimerRuning;
        private static Stopwatch watch = new Stopwatch();

        static async Task Main(string[] args)
        {
            List<Task> tasks = new List<Task>();
            List<Provider> myProviderDb = GetProvidersDb();
            List<Contact> myContactDb = GetContactDb();

            Phone phone = new Phone();
            phone.Contacts = myContactDb;
            phone.Number = "+994 055 357 17 68";
            phone.Balance = decimal.Parse("0,1");
            phone.Provider = GetProvider(phone.Number , myProviderDb);

            Console.WriteLine(phone.Provider);
            CancellationTokenSource ctsForRealWatchUi = new CancellationTokenSource();

            Task taskRealWatch = new Task(() => ShowTheWatchInLine(ctsForRealWatchUi, phone));
            

            taskRealWatch.Start();

            bool isExit = true;
            while (isExit)
            {
                Console.WriteLine("1-Calling");
                Console.WriteLine("2-Return Phone");
                Console.WriteLine("3-Take Credit");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        ctsForRealWatchUi.Cancel();
                        Console.Clear();
                        Console.WriteLine("Enter number");
                        string number = Console.ReadLine();
                        bool isExistContactNumber = CheckData.isExistsInContact(number, phone.Contacts);
                        bool isEnoughBalance = CheckData.isEnoughBalance(number, phone.Balance, myProviderDb);
                        if (isExistContactNumber && isEnoughBalance)
                        {
                            CancellationTokenSource ctsForCalling = new CancellationTokenSource();
                            Task taskCall = new Task(() => CallSomeone(ctsForCalling));
                            taskCall.Start();
                            CallUi(taskCall, taskRealWatch, ctsForCalling, ctsForRealWatchUi); // zeng vaxti iwleyecek;
                            int second = (int)watch.ElapsedMilliseconds / 1000;
                            UpdateData.WithdrawMoneyFromBalance(second, phone, myProviderDb,number);
                            watch.Reset();
                        }
                        break;
                    case 2:
                        ctsForRealWatchUi = new CancellationTokenSource();
                        taskRealWatch = new Task(() => ShowTheWatchInLine(ctsForRealWatchUi, phone));
                        taskRealWatch.Start();
                        
                        break;
                    case 3:
                        ctsForRealWatchUi.Cancel();
                        Console.Clear();
                        Console.WriteLine("Nar-*700#");
                        Console.WriteLine("Bak-*150#");
                        Console.WriteLine("Aze-*100#");
                        Console.WriteLine("Enter your provider code:");
                        string code = Console.ReadLine();
                        UpdateData.TakeCredit(code,phone,myProviderDb);
                        break;
                    case 4:
                        isExit = false;
                        break;
                    default:
                        Console.WriteLine("Write true option");
                        break;
                }
            }
            
            GetRealWatchUi(taskRealWatch, ctsForRealWatchUi); // While i iwledir die awagida yazmaq lazimdi !!!

            
 
        }
        static void CallUi(
            Task taskCall,
            Task taskRealWatch,
            CancellationTokenSource ctsForCalling, 
            CancellationTokenSource ctsForRealWatchUi

            )
        {
            isTimerRuning = true;
            while (!taskCall.IsCompleted)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Y-Calling N-Finish Calling");
                var keyInput = Console.ReadKey(true);
                Console.Clear();
                if (!Console.KeyAvailable)
                {
                    int count = 0;
                    if (keyInput.Key == ConsoleKey.Y && count<=2)
                    {
                        count++;
                        if (watch.ElapsedMilliseconds / 1000 >= 10)
                        {
                            watch.Reset();
                            ctsForCalling.Cancel();
                            break;
                        }
                        
                        else if (isTimerRuning)
                        {
                            watch.Start();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Calling...");
                            
                        }
                        else
                        {
                            watch.Reset();
                            watch.Start();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Clear();
                            Console.WriteLine("\nCalling start");
                        }
                        isTimerRuning = !isTimerRuning;
                    }
                    else if (keyInput.Key == ConsoleKey.N)
                    {
                        Console.WriteLine("Calling is stop");
                        ctsForCalling.Cancel();
                    }
                    
                    Task.Delay(1000).Wait();
                }
            }
            
        }
        static void CallSomeone(CancellationTokenSource _cts)
        {
            int minuteInOneHour = 60;
            int secondInOneMinute = 60;
            int milisecondInOneSecond = 1000;
            Task.Delay(1).Wait();
            while (!_cts.IsCancellationRequested)
            {
                Console.SetCursorPosition(0, 4);
                if (isTimerRuning)
                {
                    if (watch.ElapsedMilliseconds != 0)
                    {
                        var minute = (watch.ElapsedMilliseconds / (secondInOneMinute * milisecondInOneSecond)) % minuteInOneHour;
                        var sec = (watch.ElapsedMilliseconds / milisecondInOneSecond) % secondInOneMinute;
                        Console.WriteLine("{0,2:0#}:{1,2:0#}", minute, sec);
                        if (sec > 10)
                        {
                            _cts.Cancel();
                        }
                    }
                }
                Task.Delay(1).Wait();
            }
        }
        static void GetRealWatchUi(Task task, CancellationTokenSource cts)
        {
            while (!task.IsCompleted)
            {
                var keyInput = Console.ReadKey(true);
                if (!Console.KeyAvailable)
                {
                    if (keyInput.Key == ConsoleKey.Spacebar)
                    {
                        isTimerRuning = !isTimerRuning;
                    }

                    else if (keyInput.Key == ConsoleKey.Escape)
                    {
                        cts.Cancel();
                        Task.Delay(1).Wait();
                        break;
                    }
                }
                Task.Delay(6000).Wait();
            }
        }
        static void ShowContact(Phone phone)
        {
            foreach (var item in phone.Contacts)
            {
                Console.WriteLine(item.Number);
            }
            
        }
        static  void ShowTheWatchInLine(CancellationTokenSource _cts,Phone phone)
        {
            Task.Delay(1).Wait();
            string provider = phone.Provider;
            decimal balance = phone.Balance;
            while (!_cts.IsCancellationRequested)
            {
                    var date = System.DateTime.Now.ToLongTimeString();
                    Console.SetCursorPosition(0, 3);
                    Console.WriteLine(@$"
                          __________________________
                         |  {provider}                  4G |
                         |                          |
                         |  Balance-{balance}             |
                         |                          |
                         |                          |
                         |          {date}        |
                         |          ________        |
                         |                          |
                         |                          |
                         |                          |
                         |                          |
                         |                          |
                         |                          |
                         |                          |
                         |           _____          | 
                         |          |_____|         |
                         |__________________________|


                        -------------Kredit---------
                         Nar - *700# - 3 Azn
                         Bakcell - *150# - 2 Azn
                         Azercell - *100# - 0.5 Azn
                    ");
                
                Task.Delay(1).Wait();
            }
        }

        
        static string GetProvider(string number, List<Provider> myProviderDb)
        {
            var numberItem = number.Replace(" ", "").Substring(4, 3);
            foreach (var provider in myProviderDb)
            {
                foreach (var item in provider.Values)
                {
                    if (numberItem == item)
                    {
                        return provider.Key;

                    }
                }
            }
            return "";
        }
        static string EnterNumber(List<Provider> myProviderDb)
        {
            bool defaultValue = true;
            string myNum;
            do
            {
                Console.WriteLine("Write your Number");
                 myNum = Console.ReadLine();
                if (NumberValidation.CountryValidition(myNum)
                    && NumberValidation.LengthValidation(myNum)
                    && NumberValidation.IsNumber(myNum)
                    && NumberValidation.CheckProvider(myNum, myProviderDb)
                   )
                {
                    defaultValue = false;
                }
            } while (defaultValue);
            return myNum;
        }
        static decimal EnterBalance()
        {
            bool defaultValue = true;
            string myBalance;
            do
            {
                Console.WriteLine("Write your Badge");
                myBalance = Console.ReadLine();
                foreach (var item in myBalance)
                {
                    if (char.IsDigit(item) || item == ',')
                    {
                        defaultValue = false;
                    }
                }
            } while (defaultValue);
            return decimal.Parse(myBalance);
        }
        static List<Provider> GetProvidersDb()
        {
            List<Provider> myProviderDb = new List<Provider>();

            Provider nar = new Provider();
            nar.Key = "Nar";
            nar.Values.Add("077");
            nar.Values.Add("070");
            nar.Price = decimal.Parse("0,2");

            Provider bakcell = new Provider();
            bakcell.Key = "Bak";
            bakcell.Values.Add("055");
            bakcell.Values.Add("099");
            bakcell.Price = decimal.Parse("0,1");

            Provider azerCell = new Provider();
            azerCell.Key = "Aze";
            azerCell.Values.Add("050");
            azerCell.Values.Add("010");
            azerCell.Price = decimal.Parse("0,3");

            Provider forCheck = new Provider();
            azerCell.Key = "Az";
            azerCell.Values.Add("0a0");
            azerCell.Values.Add("01");
            myProviderDb.Add(nar);
            myProviderDb.Add(bakcell);
            myProviderDb.Add(azerCell);
            myProviderDb.Add(forCheck);
            return myProviderDb;
        }
        static List<Contact> GetContactDb()
        {
            List<Contact> myContactDb = new List<Contact>();
            Contact newContact = new Contact
            {
                Id = 1,
                FullName = "Dilqem",
                Number = "+994 055 465 12 23"

            };
            Contact newContact2 = new Contact
            {
                Id = 2,
                FullName = "Elwen",
                Number = "+994 077 465 31 23"

            };
            Contact newContact3 = new Contact
            {
                Id = 3,
                FullName = "Gulwen",
                Number = "+994 050 465 12 69"

            };
            //Contact forCheck = new Contact
            //{
            //    Id = 1,
            //    FullName = "Test",
            //    Number = "+994 05 a65 12 23"

            //};
            myContactDb.Add(newContact);
            myContactDb.Add(newContact2);
            myContactDb.Add(newContact3);
            //myContactDb.Add(forCheck);

            return myContactDb;

        }

    }
}