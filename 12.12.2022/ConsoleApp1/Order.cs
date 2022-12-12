using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Order: BaseEntity
    {
        public Product[] Products { get; set; }
        
        public int KargoId { get; set; }

        public int ClientId { get; set; }

    }
}
