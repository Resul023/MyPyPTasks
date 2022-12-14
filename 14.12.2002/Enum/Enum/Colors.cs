using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumTask
{
    public enum Colors:byte
    {
        [Display(Name ="This color is Red")]
        Red = 1,
        [Display(Name = "This color is Green")]
        Green =2,

    }
}
