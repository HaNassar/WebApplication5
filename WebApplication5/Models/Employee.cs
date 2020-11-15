using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public class Employee
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public Guid CountryId { get; set; }
    }
}
