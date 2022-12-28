using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async.Models
{
    public class NumberValidation
    {
        public static bool CountryValidition(string number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (number[0] != '+' || number[1] != '9' || number[2] != '9' || number[3] != '4')
                {
                    return false;
                }

            }
            return true;
        }
        public static bool LengthValidation(string number)
        {
            return number.Replace(" ", "").Length !=14 ? false : true;
        }
        public static bool IsNumber(string number)
        {
            string numberTrimVersion = number.Replace(" ", "");
            for (int i = 1; i < numberTrimVersion.Length; i++)
            {
                if (!char.IsDigit(numberTrimVersion[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool CheckProvider(string number, List<Provider> providers)
        {
            var numberItem = number.Replace(" ", "").Substring(4, 3);
            foreach (var provider in providers)
            {
                foreach (var item in provider.Values)
                {
                    if (item == numberItem )
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
