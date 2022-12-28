using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async.Validation
{
    public class ProviderValidation
    {

        public static bool LengthValidation(string number,string key)
        {
            
            return number.Replace(" ", "").Length != 3 && number.Replace(" ", "").Length != 3 ? false : true;
        }

        public static bool IsNumber(string number)
        {
            foreach (var item in number)
            {
                if(!char.IsDigit(item))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
