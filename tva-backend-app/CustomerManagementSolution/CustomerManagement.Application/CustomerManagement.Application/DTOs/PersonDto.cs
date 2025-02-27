using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Application.DTOs
{
    public class PersonDto
    {
        public int Code { get; set; }
        public string IdNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
