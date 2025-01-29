using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sieve_Service.Controllers;
using Sieve_Service.Services;
using System.Drawing;
using System.Threading.Tasks;
using Xunit;

namespace Sieve_Service.Tests
{
    public class SieveControllerTests
    {
        private readonly ILogger<SieveController> _logger;
        private readonly IPrimeService _primeService;
        private readonly SieveController _controller;

        public SieveControllerTests()
        {
            _logger = new LoggerFactory().CreateLogger<SieveController>();
            _primeService = new PrimeService();
            _controller = new SieveController(_logger, _primeService);
        }

        private async Task<int> GetNthPrimeValue(int n)
        {
            var result = await _controller.GetNthPrime(n);
            var okResult = Assert.IsType<OkObjectResult>(result);
            return (int)okResult.Value;
        }

        private async Task<bool> GetTwinValue(int n)
        {
            var result = await _controller.IsTwinPrime(n);
            var okResult = Assert.IsType<OkObjectResult>(result);
            return (bool)okResult.Value;
        }

        [Fact]
        public async Task GetNthPrime_ReturnsOkResult_WithCorrectPrime()
        {
            // Arrange
            int n = 5;
            int expectedPrime = 13;

            // Act & Assert
            Assert.Equal(expectedPrime, await GetNthPrimeValue(n));

            // Additional tests
            Assert.Equal(2, await GetNthPrimeValue(0));
            Assert.Equal(71, await GetNthPrimeValue(19));
            Assert.Equal(541, await GetNthPrimeValue(99));
            Assert.Equal(3581, await GetNthPrimeValue(500));
            Assert.Equal(7793, await GetNthPrimeValue(986));
            Assert.Equal(17393, await GetNthPrimeValue(2000));
            Assert.Equal(15485867, await GetNthPrimeValue(1000000));
            Assert.Equal(179424691, await GetNthPrimeValue(10000000));
        }

        [Fact]
        public async Task GetTwinPrime_ReturnsOkResult_WithCorrectValue()
        {
            // Arrange
            int n = 5;
            bool expected = true;

            // Act & Assert
            Assert.Equal(expected, await GetTwinValue(n));

            
            // Additional tests
            Assert.Equal(true, await GetTwinValue(1));
            Assert.Equal(false, await GetTwinValue(392));

            
        }
    }
}