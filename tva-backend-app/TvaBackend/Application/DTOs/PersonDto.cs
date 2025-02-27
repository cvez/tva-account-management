using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class PersonDto
    {
        public int Code { get; set; }
        public required string IdNumber { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
    }
}
