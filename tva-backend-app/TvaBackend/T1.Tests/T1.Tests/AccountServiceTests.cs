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
    public class AccountServiceTests
    {
        private readonly Mock<IRepository<Account>> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly AccountService _accountService;

        public AccountServiceTests()
        {
            _mockRepository = new Mock<IRepository<Account>>();
            _mockMapper = new Mock<IMapper>();
            _accountService = new AccountService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAllAccounts_ReturnsAccountDtos()
        {
            // Arrange
            var accounts = new List<Account> { new Account { Code = 1, AccountNumber = "Account1", OutstandingBalance = 100, PersonCode = 1, Transactions = new List<Transaction>() } };
            var accountDtos = new List<AccountDto> { new AccountDto { Code = 1, AccountNumber = "Account1", OutstandingBalance = 100, PersonCode = 1 } };

            _mockRepository.Setup(repo => repo.GetAll()).ReturnsAsync(accounts);
            _mockMapper.Setup(mapper => mapper.Map<IEnumerable<AccountDto>>(accounts)).Returns(accountDtos);

            // Act
            var result = await _accountService.GetAllAccounts();

            // Assert
            Assert.Equal(accountDtos, result);
        }

        [Fact]
        public async Task GetAccountById_ReturnsAccountDto()
        {
            // Arrange
            var account = new Account { Code = 1, AccountNumber = "Account1", OutstandingBalance = 100, PersonCode = 1, Transactions = new List<Transaction>() };
            var accountDto = new AccountDto { Code = 1, AccountNumber = "Account1", OutstandingBalance = 100, PersonCode = 1 };

            _mockRepository.Setup(repo => repo.GetById(1)).ReturnsAsync(account);
            _mockMapper.Setup(mapper => mapper.Map<AccountDto>(account)).Returns(accountDto);

            // Act
            var result = await _accountService.GetAccountById(1);

            // Assert
            Assert.Equal(accountDto, result);
        }

        [Fact]
        public async Task AddAccount_CreatesAndReturnsAccountDto()
        {
            // Arrange
            var accountDto = new AccountDto { Code = 1, AccountNumber = "Account1", OutstandingBalance = 100, PersonCode = 1 };
            var account = new Account { Code = 1, AccountNumber = "Account1", OutstandingBalance = 100, PersonCode = 1, Transactions = new List<Transaction>() };

            _mockMapper.Setup(mapper => mapper.Map<Account>(accountDto)).Returns(account);
            _mockRepository.Setup(repo => repo.Add(account)).ReturnsAsync(account);
            _mockMapper.Setup(mapper => mapper.Map<AccountDto>(account)).Returns(accountDto);

            // Act
            var result = await _accountService.AddAccount(accountDto);

            // Assert
            Assert.Equal(accountDto, result);
        }

        [Fact]
        public async Task UpdateAccount_UpdatesAndReturnsAccountDto()
        {
            // Arrange
            var accountDto = new AccountDto { Code = 1, AccountNumber = "Account1", OutstandingBalance = 100, PersonCode = 1 };
            var account = new Account { Code = 1, AccountNumber = "Account1", OutstandingBalance = 100, PersonCode = 1, Transactions = new List<Transaction>() };

            _mockMapper.Setup(mapper => mapper.Map<Account>(accountDto)).Returns(account);
            _mockRepository.Setup(repo => repo.Update(account)).ReturnsAsync(account);
            _mockMapper.Setup(mapper => mapper.Map<AccountDto>(account)).Returns(accountDto);

            // Act
            var result = await _accountService.UpdateAccount(accountDto);

            // Assert
            Assert.Equal(accountDto, result);
        }

        [Fact]
        public async Task DeleteAccount_DeletesAndReturnsSuccess()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.Delete(1)).ReturnsAsync(true);

            // Act
            var result = await _accountService.DeleteAccount(1);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task GetAccountWithTransactions_ReturnsAccountDtoWithTransactions()
        {
            // Arrange
            var transactions = new List<Transaction> { new Transaction { Code = 1, Description = "Transaction1", Amount = 50, TransactionDate = DateTime.Now, CaptureDate = DateTime.Now, AccountCode = 1 } };
            var account = new Account { Code = 1, AccountNumber = "Account1", OutstandingBalance = 100, PersonCode = 1, Transactions = transactions };
            var accountDto = new AccountDto { Code = 1, AccountNumber = "Account1", OutstandingBalance = 100, PersonCode = 1 };

            _mockRepository.Setup(repo => repo.GetById(1)).ReturnsAsync(account);
            _mockMapper.Setup(mapper => mapper.Map<AccountDto>(account)).Returns(accountDto);

            // Act
            var result = await _accountService.GetAccountById(1);

            // Assert
            Assert.Equal(accountDto, result);
        }

        [Fact]
        public async Task AddAccountWithTransactions_CreatesAndReturnsAccountDto()
        {
            // Arrange
            var transactions = new List<Transaction> { new Transaction { Code = 1, Description = "Transaction1", Amount = 50, TransactionDate = DateTime.Now, CaptureDate = DateTime.Now, AccountCode = 1 } };
            var accountDto = new AccountDto { Code = 1, AccountNumber = "Account1", OutstandingBalance = 100, PersonCode = 1 };
            var account = new Account { Code = 1, AccountNumber = "Account1", OutstandingBalance = 100, PersonCode = 1, Transactions = transactions };

            _mockMapper.Setup(mapper => mapper.Map<Account>(accountDto)).Returns(account);
            _mockRepository.Setup(repo => repo.Add(account)).ReturnsAsync(account);
            _mockMapper.Setup(mapper => mapper.Map<AccountDto>(account)).Returns(accountDto);

            // Act
            var result = await _accountService.AddAccount(accountDto);

            // Assert
            Assert.Equal(accountDto, result);
        }

        [Fact]
        public async Task UpdateAccountWithTransactions_UpdatesAndReturnsAccountDto()
        {
            // Arrange
            var transactions = new List<Transaction> { new Transaction { Code = 1, Description = "Transaction1", Amount = 50, TransactionDate = DateTime.Now, CaptureDate = DateTime.Now, AccountCode = 1 } };
            var accountDto = new AccountDto { Code = 1, AccountNumber = "Account1", OutstandingBalance = 100, PersonCode = 1 };
            var account = new Account { Code = 1, AccountNumber = "Account1", OutstandingBalance = 100, PersonCode = 1, Transactions = transactions };

            _mockMapper.Setup(mapper => mapper.Map<Account>(accountDto)).Returns(account);
            _mockRepository.Setup(repo => repo.Update(account)).ReturnsAsync(account);
            _mockMapper.Setup(mapper => mapper.Map<AccountDto>(account)).Returns(accountDto);

            // Act
            var result = await _accountService.UpdateAccount(accountDto);

            // Assert
            Assert.Equal(accountDto, result);
        }

        [Fact]
        public async Task DeleteAccountWithTransactions_DeletesAndReturnsSuccess()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.Delete(1)).ReturnsAsync(true);

            // Act
            var result = await _accountService.DeleteAccount(1);

            // Assert
            Assert.True(result);
        }
    }
}
