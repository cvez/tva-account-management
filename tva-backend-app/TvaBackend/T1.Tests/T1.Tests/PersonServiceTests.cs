using Application.DTOs;
using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Core.Entities;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace T1.Tests
{
    public class PersonServiceTests
    {
        private readonly Mock<IRepository<Person>> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly PersonService _personService;

        public PersonServiceTests()
        {
            _mockRepository = new Mock<IRepository<Person>>();
            _mockMapper = new Mock<IMapper>();
            _personService = new PersonService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAllPersons_ReturnsPersonDtos()
        {
            // Arrange
            var persons = new List<Person> { new Person { Code = 1, IdNumber = "12345", Name = "John", Surname = "Doe", Accounts = new List<Account>() } };
            var personDtos = new List<PersonDto> { new PersonDto { Code = 1, IdNumber = "12345", Name = "John", Surname = "Doe" } };

            _mockRepository.Setup(repo => repo.GetAll()).ReturnsAsync(persons);
            _mockMapper.Setup(mapper => mapper.Map<IEnumerable<PersonDto>>(persons)).Returns(personDtos);

            // Act
            var result = await _personService.GetAllPersons();

            // Assert
            Assert.Equal(personDtos, result);
        }

        [Fact]
        public async Task GetPersonById_ReturnsPersonDto()
        {
            // Arrange
            var person = new Person { Code = 1, IdNumber = "12345", Name = "John", Surname = "Doe", Accounts = new List<Account>() };
            var personDto = new PersonDto { Code = 1, IdNumber = "12345", Name = "John", Surname = "Doe" };

            _mockRepository.Setup(repo => repo.GetById(1)).ReturnsAsync(person);
            _mockMapper.Setup(mapper => mapper.Map<PersonDto>(person)).Returns(personDto);

            // Act
            var result = await _personService.GetPersonById(1);

            // Assert
            Assert.Equal(personDto, result);
        }

        [Fact]
        public async Task AddPerson_CreatesAndReturnsPersonDto()
        {
            // Arrange
            var personDto = new PersonDto { Code = 1, IdNumber = "12345", Name = "John", Surname = "Doe" };
            var person = new Person { Code = 1, IdNumber = "12345", Name = "John", Surname = "Doe", Accounts = new List<Account>() };

            _mockMapper.Setup(mapper => mapper.Map<Person>(personDto)).Returns(person);
            _mockRepository.Setup(repo => repo.Add(person)).ReturnsAsync(person);
            _mockMapper.Setup(mapper => mapper.Map<PersonDto>(person)).Returns(personDto);

            // Act
            var result = await _personService.AddPerson(personDto);

            // Assert
            Assert.Equal(personDto, result);
        }

        [Fact]
        public async Task UpdatePerson_UpdatesAndReturnsPersonDto()
        {
            // Arrange
            var personDto = new PersonDto { Code = 1, IdNumber = "12345", Name = "John", Surname = "Doe" };
            var person = new Person { Code = 1, IdNumber = "12345", Name = "John", Surname = "Doe", Accounts = new List<Account>() };

            _mockMapper.Setup(mapper => mapper.Map<Person>(personDto)).Returns(person);
            _mockRepository.Setup(repo => repo.Update(person)).ReturnsAsync(person);
            _mockMapper.Setup(mapper => mapper.Map<PersonDto>(person)).Returns(personDto);

            // Act
            var result = await _personService.UpdatePerson(personDto);

            // Assert
            Assert.Equal(personDto, result);
        }

        [Fact]
        public async Task DeletePerson_DeletesAndReturnsSuccess()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.Delete(1)).ReturnsAsync(true);

            // Act
            var result = await _personService.DeletePerson(1);

            // Assert
            Assert.True(result);
        }
    }
}
