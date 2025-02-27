using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Person
    {

        [Key]
        [Column("code")]
        public int Code { get; set; }

        [Required]
        [Column("id_number")]
        public required string IdNumber { get; set; }

        [Column("name")]
        public required string Name { get; set; }
        [Column("surname")]
        public required string Surname { get; set; }

        public required ICollection<Account> Accounts { get; set; }
    }
}
