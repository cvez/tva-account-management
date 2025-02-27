using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Person
    {

        [Key]
        public int Code { get; set; }

        [Required]
        public required string IdNumber { get; set; }

        public required string Name { get; set; }

        public required string Surname { get; set; }

        public required ICollection<Account> Accounts { get; set; }
    }
}
