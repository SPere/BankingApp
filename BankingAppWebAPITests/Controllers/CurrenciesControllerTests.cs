using System.Collections.Generic;
using System.Threading.Tasks;
using BankingAppWebAPI.Controllers;
using BankingAppWebAPI.DBModels;
using BankingAppWebAPI.Services.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BankingAppWebAPITests.Controllers
{
    [TestClass]
    public class CurrenciesControllerTests
    {
        [TestMethod]
        public async Task ShouldReturnCurrencies_WhenCurrencyServiceReturnsCurrencies()
        {
            // arrange
            var mockCurrenciesService = new Mock<ICurrencyService>();
            var returnResult = new List<Currency> { new Currency { Name = "Test Currency", CurrencyId = 10 } };
            mockCurrenciesService.Setup(x => x.GetCurrencies()).ReturnsAsync(returnResult);
            var sut = new CurrenciesController(mockCurrenciesService.Object);

            // act
            var actionResult = await sut.GetCurrencies();

            // assert
            actionResult.Result.Should().BeOfType<OkObjectResult>();
            (actionResult.Result as OkObjectResult)?.Value.Should().BeSameAs(returnResult);
        }


    }
}
