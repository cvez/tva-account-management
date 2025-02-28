using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Core.Entities
{
    public class Account
    {
        [Key]
        public int Code { get; set; }

        [Required]
        [Column("account_number")]
        public required string AccountNumber { get; set; }

        [Required]
        [Column("outstanding_balance")]
        public decimal OutstandingBalance { get; set; }

        [Required]
        [Column("person_code")]
        public int PersonCode { get; set; }

        [ForeignKey("PersonCode")]
        public  Person? Person { get; set; }

        public required ICollection<Transaction> Transactions { get; set; }
    }
}
