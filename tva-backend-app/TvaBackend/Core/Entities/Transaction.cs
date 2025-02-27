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
        public required string Description { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        public DateTime CaptureDate { get; set; }

        [Required]
        public int AccountCode { get; set; }

        [ForeignKey("AccountCode")]
        public Account? Account { get; set; }
    }
}
