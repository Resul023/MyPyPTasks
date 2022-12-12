using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Product: BaseEntity
    {
        
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }

    }
}
