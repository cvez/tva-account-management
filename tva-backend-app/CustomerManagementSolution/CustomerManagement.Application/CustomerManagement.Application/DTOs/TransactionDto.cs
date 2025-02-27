using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Application.DTOs
{
    public class TransactionDto
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime CaptureDate { get; set; }
        public int AccountCode { get; set; }
    }
}
