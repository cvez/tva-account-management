using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : Controller
    {
            private readonly IPersonService _personService;
            private readonly IMapper _mapper;

            public PersonsController(IPersonService personService, IMapper mapper)
            {
                _personService = personService;
                _mapper = mapper;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<PersonDto>>> GetPersons()
            {
                var persons = await _personService.GetAllPersons();
                return Ok(persons);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<PersonDto>> GetPerson(int id)
            {
                var person = await _personService.GetPersonById(id);
                if (person == null) return NotFound();

                return Ok(person);
            }

            [HttpPost]
            public async Task<ActionResult<PersonDto>> PostPerson(PersonDto personDto)
            {
                var person = await _personService.AddPerson(personDto);
                return CreatedAtAction("GetPerson", new { id = person.Code }, person);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> PutPerson(int id, PersonDto personDto)
            {
                if (id != personDto.Code) return BadRequest();

                var person = await _personService.UpdatePerson(personDto);
                return Ok(person);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeletePerson(int id)
            {
                var success = await _personService.DeletePerson(id);
                if (!success) return NotFound();

                return NoContent();
            }
        }
    }
