using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Domain.Entities
{
    public class Account
    {
        public int Code { get; set; }
        public int PersonCode { get; set; }
        public required string AccountNumber { get; set; } 
        public decimal OutstandingBalance { get; set; }
        [ForeignKey("PersonCode")]
        public required Person Person { get; set; } // This is the person that the account belongs to
        public ICollection<Transaction> Transactions { get; set; } = []; // This is a collection of transactions that the account has

    }
}
