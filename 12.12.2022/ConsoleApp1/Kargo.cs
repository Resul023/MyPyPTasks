using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Kargo : BaseEntity
    {

        public string OrderStatus { get; set; }
        public Order[]? Orders { get; set; }
        public int? EmployeeId { get; set; }
        public bool ReceivedByClient { get; set; }

    }
}
