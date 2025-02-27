using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Domain.Entities
{
    public class Transaction
    {
        [Key]
        public int Code { get; set; } // This is the code of the transaction
        public int AccountCode { get; set; } // This is the account code that the transaction belongs to
        public required DateTime TransactionDate { get; set; } // This is the date that the transaction was made
        public required DateTime CaptureDate { get; set; } // This is the date that the transaction was captured
        public required decimal Amount { get; set; } // This is the amount of the transaction
        public required string Description { get; set; } // This is a description of the transaction
        [ForeignKey("AccountCode")]
        public required Account Account { get; set; } // This is the account that the transaction belongs to

    }
}
