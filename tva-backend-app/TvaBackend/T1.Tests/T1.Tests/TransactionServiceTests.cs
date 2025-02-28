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
    public class TransactionServiceTests
    {
        private readonly Mock<IRepository<Transaction>> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly TransactionService _transactionService;

        public TransactionServiceTests()
        {
            _mockRepository = new Mock<IRepository<Transaction>>();
            _mockMapper = new Mock<IMapper>();
            _transactionService = new TransactionService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAllTransactions_ReturnsTransactionDtos()
        {
            // Arrange
            var transactions = new List<Transaction> { new Transaction { Code = 1, Description = "Transaction1", Amount = 50, TransactionDate = DateTime.Now, CaptureDate = DateTime.Now, AccountCode = 1 } };
            var transactionDtos = new List<TransactionDto> { new TransactionDto { Code = 1, Description = "Transaction1", Amount = 50, TransactionDate = DateTime.Now, CaptureDate = DateTime.Now, AccountCode = 1 } };

            _mockRepository.Setup(repo => repo.GetAll()).ReturnsAsync(transactions);
            _mockMapper.Setup(mapper => mapper.Map<IEnumerable<TransactionDto>>(transactions)).Returns(transactionDtos);

            // Act
            var result = await _transactionService.GetAllTransactions();

            // Assert
            Assert.Equal(transactionDtos, result);
        }

        [Fact]
        public async Task GetTransactionById_ReturnsTransactionDto()
        {
            // Arrange
            var transaction = new Transaction { Code = 1, Description = "Transaction1", Amount = 50, TransactionDate = DateTime.Now, CaptureDate = DateTime.Now, AccountCode = 1 };
            var transactionDto = new TransactionDto { Code = 1, Description = "Transaction1", Amount = 50, TransactionDate = DateTime.Now, CaptureDate = DateTime.Now, AccountCode = 1 };

            _mockRepository.Setup(repo => repo.GetById(1)).ReturnsAsync(transaction);
            _mockMapper.Setup(mapper => mapper.Map<TransactionDto>(transaction)).Returns(transactionDto);

            // Act
            var result = await _transactionService.GetTransactionById(1);

            // Assert
            Assert.Equal(transactionDto, result);
        }

        [Fact]
        public async Task AddTransaction_CreatesAndReturnsTransactionDto()
        {
            // Arrange
            var transactionDto = new TransactionDto { Code = 1, Description = "Transaction1", Amount = 50, TransactionDate = DateTime.Now, CaptureDate = DateTime.Now, AccountCode = 1 };
            var transaction = new Transaction { Code = 1, Description = "Transaction1", Amount = 50, TransactionDate = DateTime.Now, CaptureDate = DateTime.Now, AccountCode = 1 };

            _mockMapper.Setup(mapper => mapper.Map<Transaction>(transactionDto)).Returns(transaction);
            _mockRepository.Setup(repo => repo.Add(transaction)).ReturnsAsync(transaction);
            _mockMapper.Setup(mapper => mapper.Map<TransactionDto>(transaction)).Returns(transactionDto);

            // Act
            var result = await _transactionService.AddTransaction(transactionDto);

            // Assert
            Assert.Equal(transactionDto, result);
        }

        [Fact]
        public async Task UpdateTransaction_UpdatesAndReturnsTransactionDto()
        {
            // Arrange
            var transactionDto = new TransactionDto { Code = 1, Description = "Transaction1", Amount = 50, TransactionDate = DateTime.Now, CaptureDate = DateTime.Now, AccountCode = 1 };
            var transaction = new Transaction { Code = 1, Description = "Transaction1", Amount = 50, TransactionDate = DateTime.Now, CaptureDate = DateTime.Now, AccountCode = 1 };

            _mockMapper.Setup(mapper => mapper.Map<Transaction>(transactionDto)).Returns(transaction);
            _mockRepository.Setup(repo => repo.Update(transaction)).ReturnsAsync(transaction);
            _mockMapper.Setup(mapper => mapper.Map<TransactionDto>(transaction)).Returns(transactionDto);

            // Act
            var result = await _transactionService.UpdateTransaction(transactionDto);

            // Assert
            Assert.Equal(transactionDto, result);
        }

        [Fact]
        public async Task DeleteTransaction_DeletesAndReturnsSuccess()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.Delete(1)).ReturnsAsync(true);

            // Act
            var result = await _transactionService.DeleteTransaction(1);

            // Assert
            Assert.True(result);
        }
    }
}
