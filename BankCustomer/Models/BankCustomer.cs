using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCustomer.Models
{
    public class BankCustomer
    {
        public int BankId { get; set; }
        public Bank Bank { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
