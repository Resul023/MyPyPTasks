using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EnumTask
{
    public static class EnumExtensions
    {
        public static void GenericGetDisplayName(this Enum enumValue)
        {
            foreach (var field in enumValue.GetType().GetFields())
            {
                if (field.Name != "value__")
                {
                    var res = enumValue.GetType()
                                .GetMember(field.Name.ToString()).First().GetCustomAttribute<DisplayAttribute>()
                                .GetName().ToString();
                    Console.WriteLine($"Field:{field.Name} -+- Display:{res}");
                }

            }

        public static string GetDisplayName(this Enum enumValue)
        {
            var result = enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
            return result;
        }
    }
}
