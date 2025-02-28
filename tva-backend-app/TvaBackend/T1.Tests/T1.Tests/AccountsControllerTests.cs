using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Controllers;
using Xunit;

namespace T1.Tests
{
    public class AccountsControllerTests
    {
        private readonly Mock<IAccountService> _mockAccountService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly AccountsController _controller;

        public AccountsControllerTests()
        {
            _mockAccountService = new Mock<IAccountService>();
            _mockMapper = new Mock<IMapper>();
            _controller = new AccountsController(_mockAccountService.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAccounts_ReturnsOkResult_WithListOfAccounts()
        {
            // Arrange
            var accounts = new List<AccountDto> { new AccountDto { Code = 1, AccountNumber = "Account1" } };
            _mockAccountService.Setup(service => service.GetAllAccounts()).ReturnsAsync(accounts);

            // Act
            var result = await _controller.GetAccounts();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<AccountDto>>(okResult.Value);
            Assert.Equal(1, returnValue.Count);
        }

        [Fact]
        public async Task GetAccount_ReturnsOkResult_WithAccount()
        {
            // Arrange
            var account = new AccountDto { Code = 1, AccountNumber = "Account1" };
            _mockAccountService.Setup(service => service.GetAccountById(1)).ReturnsAsync(account);

            // Act
            var result = await _controller.GetAccount(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<AccountDto>(okResult.Value);
            Assert.Equal(account.Code, returnValue.Code);
        }

        [Fact]
        public async Task GetAccount_ReturnsNotFoundResult_WhenAccountDoesNotExist()
        {
            // Arrange
            _mockAccountService.Setup(service => service.GetAccountById(1)).ReturnsAsync((AccountDto)null);

            // Act
            var result = await _controller.GetAccount(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task PostAccount_ReturnsCreatedAtActionResult_WithAccount()
        {
            // Arrange
            var account = new AccountDto { Code = 1, AccountNumber = "Account1" };
            _mockAccountService.Setup(service => service.AddAccount(account)).ReturnsAsync(account);

            // Act
            var result = await _controller.PostAccount(account);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnValue = Assert.IsType<AccountDto>(createdAtActionResult.Value);
            Assert.Equal(account.Code, returnValue.Code);
        }

        [Fact]
        public async Task PutAccount_ReturnsOkResult_WithUpdatedAccount()
        {
            // Arrange
            var account = new AccountDto { Code = 1, AccountNumber = "Account1" };
            _mockAccountService.Setup(service => service.UpdateAccount(account)).ReturnsAsync(account);

            // Act
            var result = await _controller.PutAccount(1, account);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<AccountDto>(okResult.Value);
            Assert.Equal(account.Code, returnValue.Code);
        }

        [Fact]
        public async Task PutAccount_ReturnsBadRequest_WhenIdsDoNotMatch()
        {
            // Arrange
            var account = new AccountDto { Code = 1, AccountNumber = "Account1" };

            // Act
            var result = await _controller.PutAccount(2, account);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task DeleteAccount_ReturnsNoContentResult()
        {
            // Arrange
            _mockAccountService.Setup(service => service.DeleteAccount(1)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteAccount(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteAccount_ReturnsNotFoundResult_WhenAccountDoesNotExist()
        {
            // Arrange
            _mockAccountService.Setup(service => service.DeleteAccount(1)).ReturnsAsync(false);

            // Act
            var result = await _controller.DeleteAccount(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
