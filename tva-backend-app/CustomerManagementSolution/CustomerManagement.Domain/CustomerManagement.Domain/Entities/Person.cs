using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Domain.Entities
{
    public class Person
    {
        public int Code { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string IdNumber { get; set; }
        public ICollection<Account> Accounts { get; set; } = []; // This is a collection of accounts that the person has

    }
}
