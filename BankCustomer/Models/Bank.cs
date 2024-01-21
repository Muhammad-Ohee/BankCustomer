using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCustomer.Models
{
    public class Bank
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BankCode { get; set; }
        public string Branch { get; set; }

        public List<BankCustomer> Customers { get; set; } = new List<BankCustomer>();
    }
}
