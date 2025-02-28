using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Controllers;
using Xunit;

namespace T2.Tests
{
    public class TransactionsControllerTests
    {
        private readonly Mock<ITransactionService> _mockTransactionService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly TransactionsController _controller;

        public TransactionsControllerTests()
        {
            _mockTransactionService = new Mock<ITransactionService>();
            _mockMapper = new Mock<IMapper>();
            _controller = new TransactionsController(_mockTransactionService.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetTransactions_ReturnsOkResult_WithListOfTransactions()
        {
            // Arrange
            var transactions = new List<TransactionDto> { new TransactionDto { Code = 1, Description = "Transaction1" } };
            _mockTransactionService.Setup(service => service.GetAllTransactions()).ReturnsAsync(transactions);

            // Act
            var result = await _controller.GetTransactions();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<TransactionDto>>(okResult.Value);
            Assert.Equal(1, returnValue.Count);
        }

        [Fact]
        public async Task GetTransaction_ReturnsOkResult_WithTransaction()
        {
            // Arrange
            var transaction = new TransactionDto { Code = 1, Description = "Transaction1" };
            _mockTransactionService.Setup(service => service.GetTransactionById(1)).ReturnsAsync(transaction);

            // Act
            var result = await _controller.GetTransaction(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<TransactionDto>(okResult.Value);
            Assert.Equal(transaction.Code, returnValue.Code);
        }

        [Fact]
        public async Task GetTransaction_ReturnsNotFoundResult_WhenTransactionDoesNotExist()
        {
            // Arrange
            _mockTransactionService.Setup(service => service.GetTransactionById(1)).ReturnsAsync((TransactionDto)null);

            // Act
            var result = await _controller.GetTransaction(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task PostTransaction_ReturnsCreatedAtActionResult_WithTransaction()
        {
            // Arrange
            var transaction = new TransactionDto { Code = 1, Description = "Transaction1" };
            _mockTransactionService.Setup(service => service.AddTransaction(transaction)).ReturnsAsync(transaction);

            // Act
            var result = await _controller.PostTransaction(transaction);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnValue = Assert.IsType<TransactionDto>(createdAtActionResult.Value);
            Assert.Equal(transaction.Code, returnValue.Code);
        }

        [Fact]
        public async Task PutTransaction_ReturnsOkResult_WithUpdatedTransaction()
        {
            // Arrange
            var transaction = new TransactionDto { Code = 1, Description = "Transaction1" };
            _mockTransactionService.Setup(service => service.UpdateTransaction(transaction)).ReturnsAsync(transaction);

            // Act
            var result = await _controller.PutTransaction(1, transaction);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<TransactionDto>(okResult.Value);
            Assert.Equal(transaction.Code, returnValue.Code);
        }

        [Fact]
        public async Task DeleteTransaction_ReturnsNoContentResult()
        {
            // Arrange
            _mockTransactionService.Setup(service => service.DeleteTransaction(1)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteTransaction(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}

