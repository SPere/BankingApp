using System.Threading;
using System.Threading.Tasks;
using BankingAppWebAPI.DBModels;
using BankingAppWebAPI.Services;
using BankingAppWebAPI.Services.Clients.Interfaces;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BankingAppWebAPITests.Services
{
    [TestClass]
    public class BalanceServiceTests
    {
        [TestMethod]
        public async Task ShouldReturnErrorMessage_WhenUserWithdrawMoreThenAvailableBalanceAmount()
        {
            // arrange
            var mockSet = new Mock<DbSet<Balance>>();
            var mockDbContext = new Mock<BankingAppDbContext>();
            mockDbContext.Setup(m => m.Balances).Returns(mockSet.Object);
            var mockExchangeService = new Mock<IExchangeService>();
            var sut = new BalanceService(mockDbContext.Object, mockExchangeService.Object);

            var originalBalance = new Balance {Amount = 10};

            // act
            var withdrawResult = await sut.Withdraw(originalBalance, 20);

            // assert
            withdrawResult.CurrentBalance.Amount.Should().Be(originalBalance.Amount);
            withdrawResult.ErrorCode.Should().Be("Bank funds are not allowed to be negative");
            withdrawResult.ErrorMessage.Should().Be("Bank funds are not allowed to be negative");
        }

        [TestMethod]
        public async Task ShouldReturnErrorMessage_WhenUserDepositsNegativeAmount()
        {
            // arrange
            var mockSet = new Mock<DbSet<Balance>>();
            var mockDbContext = new Mock<BankingAppDbContext>();
            mockDbContext.Setup(m => m.Balances).Returns(mockSet.Object);
            mockDbContext.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
            var mockExchangeService = new Mock<IExchangeService>();
            var sut = new BalanceService(mockDbContext.Object, mockExchangeService.Object);

            var originalBalance = new Balance { Amount = 10, Currency = new Currency { Code = "EUR"}};

            // act
            var withdrawResult = await sut.Deposit(originalBalance, -5, "EUR");

            // assert
            withdrawResult.CurrentBalance.Amount.Should().Be(originalBalance.Amount);
            withdrawResult.ErrorCode.Should().Be("Deposit amount has to be greater than 0");
            withdrawResult.ErrorMessage.Should().Be("Deposit amount has to be greater than 0");
        }

    }
}
