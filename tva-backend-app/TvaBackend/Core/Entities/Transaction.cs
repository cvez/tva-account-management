using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Transaction
    {
        [Key]
        public int Code { get; set; }

        [Required]
        [Column("description")]
        public required string Description { get; set; }

        [Required]
        [Column("amount")]
        public decimal Amount { get; set; }

        [Required]
        [Column("transaction_date")]
        public DateTime TransactionDate { get; set; }

        [Required]
        [Column("capture_date")]
        public DateTime CaptureDate { get; set; }

        [Required]
        [Column("account_code")]
        public int AccountCode { get; set; }

        [ForeignKey("AccountCode")]
        public Account? Account { get; set; }
    }
}
