using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async.Models
{
    public class Provider
    {
        public string Key { get; set; }

        public List<string> Values { get; set; } = new List<string>();

        public decimal Price { get; set; }
    }
}
