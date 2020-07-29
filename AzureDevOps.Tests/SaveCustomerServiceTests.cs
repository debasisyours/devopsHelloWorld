using AzureDevOps.Domain.Entities;
using AzureDevOps.Domain.Models;
using AzureDevOps.Repositories;
using AzureDevOps.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AzureDevOps.Tests
{
    [TestClass]
    public class SaveCustomerServiceTests
    {
        private ISaveCustomerService _saveCustomerService = null;
        private Mock<ICustomerRepository> _mockCustomerRepository = null;

        [TestInitialize]
        public void InitializeTest()
        {
            _mockCustomerRepository = new Mock<ICustomerRepository>();
            _saveCustomerService = new SaveCustomerService(_mockCustomerRepository.Object);
        }

        [TestMethod]
        public void When_I_Call_SaveCustomer_With_Valid_Input_I_Should_Get_Success_Response()
        {
            // Arrange
            var response = new ResponseMessage { IsSuccess = true };
            var customer = new Customer { FirstName = "Test", LastName = "Test", AccountNumber = "ACCT-0001" };
            _mockCustomerRepository.Setup(x => x.SaveCustomerAsync(customer)).ReturnsAsync(response);

            // Act
            var result = _saveCustomerService.SaveCustomerAsync(customer).Result;

            // Assert
            Assert.IsTrue(result.IsSuccess);
        }
    }
}
