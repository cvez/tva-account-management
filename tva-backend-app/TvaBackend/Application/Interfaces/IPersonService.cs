using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonDto>> GetAllPersons();
        Task<PersonDto> GetPersonById(int id);
        Task<PersonDto> AddPerson(PersonDto personDto);
        Task<PersonDto> UpdatePerson(PersonDto personDto);
        Task<bool> DeletePerson(int id);
    }
}
