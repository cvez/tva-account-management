using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class AccountDto
    {
        public int Code { get; set; }
        public required string AccountNumber { get; set; }
        public decimal OutstandingBalance { get; set; }
        public int PersonCode { get; set; }
    }
}
