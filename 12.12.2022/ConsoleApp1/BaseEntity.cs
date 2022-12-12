using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool DeleteStatus { get; set; } = false;
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public string? CreatedIp { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string? ModifiedTimeIp { get; set; }
    }
}
