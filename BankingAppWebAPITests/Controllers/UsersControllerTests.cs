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
    public class UsersControllerTests
    {
        [TestMethod]
        public async Task ShouldReturnUsers_WhenUsersServiceReturnsUsers()
        {
            // arrange
            var mockUserService = new Mock<IUsersService>();
            var returnResult = new List<User> { new User { Name = "Test User", UserId = 10 } };
            mockUserService.Setup(x => x.GetUsers()).ReturnsAsync(returnResult);
            var sut = new UsersController(mockUserService.Object);

            // act
            var actionResult = await sut.GetUsers();

            // assert
            actionResult.Result.Should().BeOfType<OkObjectResult>();
            (actionResult.Result as OkObjectResult)?.Value.Should().BeSameAs(returnResult);
        }


    }
}
