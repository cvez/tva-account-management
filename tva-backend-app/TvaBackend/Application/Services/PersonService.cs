using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<Person> _repository;
        private readonly IMapper _mapper;

        public PersonService(IRepository<Person> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonDto>> GetAllPersons()
        {
            var persons = await _repository.GetAll();
            return _mapper.Map<IEnumerable<PersonDto>>(persons);
        }

        public async Task<PersonDto> GetPersonById(int id)
        {
            var person = await _repository.GetById(id);
            return _mapper.Map<PersonDto>(person);
        }

        public async Task<PersonDto> AddPerson(PersonDto personDto)
        {
            var person = _mapper.Map<Person>(personDto);
            person = await _repository.Add(person);
            return _mapper.Map<PersonDto>(person);
        }

        public async Task<PersonDto> UpdatePerson(PersonDto personDto)
        {
            var person = _mapper.Map<Person>(personDto);
            person = await _repository.Update(person);
            return _mapper.Map<PersonDto>(person);
        }

        public async Task<bool> DeletePerson(int id)
        {
            return await _repository.Delete(id);
        }
    }
}
