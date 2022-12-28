using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async.Models
{
    public class Phone
    {
        public string Number { get; set; }

        public string Provider { get; set; } 

        public decimal Balance { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}
