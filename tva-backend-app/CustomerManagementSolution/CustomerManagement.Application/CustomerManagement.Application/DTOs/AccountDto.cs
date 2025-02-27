using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Application.DTOs
{
    public class AccountDto
    {
        public int Code { get; set; }
        public string AccountNumber { get; set; }
        public decimal OutstandingBalance { get; set; }
        public int PersonCode { get; set; }
    }
}
