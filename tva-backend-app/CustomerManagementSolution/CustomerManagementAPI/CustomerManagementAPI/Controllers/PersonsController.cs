using CustomerManagement.Application.DTO;
using CustomerManagement.Application.Interfaces;
using CustomerManagement.Domain.Entities;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IRepository<Person> _repository;
        private readonly IMapper _mapper;

        public PersonsController(IRepository<Person> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonDto>>> GetPersons()
        {
            var persons = await _repository.GetAll();
            return Ok(_mapper.Map<IEnumerable<PersonDto>>(persons));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDto>> GetPerson(int id)
        {
            var person = await _repository.GetById(id);
            if (person == null) return NotFound();

            return Ok(_mapper.Map<PersonDto>(person));
        }

        [HttpPost]
        public async Task<ActionResult<PersonDto>> PostPerson(PersonDto personDto)
        {
            var person = _mapper.Map<Person>(personDto);
            person = await _repository.Add(person);

            return CreatedAtAction("GetPerson", new { id = person.Code }, _mapper.Map<PersonDto>(person));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, PersonDto personDto)
        {
            if (id != personDto.Code) return BadRequest();

            var person = _mapper.Map<Person>(personDto);
            await _repository.Update(person);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var success = await _repository.Delete(id);
            if (!success) return NotFound();

            return NoContent();
        }

    }
}
