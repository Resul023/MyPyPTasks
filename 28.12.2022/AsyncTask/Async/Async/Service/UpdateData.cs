using Async.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async.Service
{
    public class UpdateData
    {
        public static void TakeCredit(string code,Phone phone,List<Provider> providerDb)
        {
            var provider = providerDb.FirstOrDefault(x => x.Key == phone.Provider);
            if (provider.Key == "Nar" && code == "*700#")
            {
                phone.Balance += 3;
            }
            else if (provider.Key == "Bak" && code == "*150#")
            {
                phone.Balance += 2;
            }
            else if (provider.Key == "Aze" && code == "*100#")
            {
                phone.Balance += decimal.Parse("0,5");
            }
            else
            {
                Console.WriteLine("Code is not match with the provider");
            }
        }

        public static void WithdrawMoneyFromBalance(int second, Phone phone ,List<Provider> providerDb,string number)
        {

            decimal takeFromBalance = 0;
            foreach (var pro in providerDb)
            {
                foreach (var code in pro.Values)
                {
                    if ( code == number.Replace(" ", "").Substring(4, 3))
                    {
                        takeFromBalance = pro.Price;
                        break;
                    }
                }

            }
            phone.Balance -= takeFromBalance * second;
        }
    }
}
