using Async.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async.Service
{
    public class CheckData
    {
        public static bool isExistsInContact(string number,List<Contact> contactDb)
        {
            foreach (var item in contactDb)
            {
                if (item.Number.Replace(" ","") == number.Replace(" ", ""))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool isEnoughBalance(string number,decimal balance,List<Provider> providerDb)
        {
            string providerCode = number.Replace(" ", "").Substring(4, 3);
            decimal providerPrice = 0;
            foreach (var pro in providerDb)
            {
                foreach (var proCode  in pro.Values)
                {
                    if (providerCode == proCode)
                    {
                        providerPrice = pro.Price;
                    }
                }
            }

            if (providerPrice !=0)
            {
                if (providerPrice <= balance)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("You don't have enough money ay yazig");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("there are no this kind of provider((");
                return false;
            }
            
           
        }
    }
}
