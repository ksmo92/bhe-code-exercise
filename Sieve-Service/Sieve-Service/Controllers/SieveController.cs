using System.Drawing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sieve_Service.Services;

namespace Sieve_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SieveController : ControllerBase
    {
        private readonly ILogger<SieveController> _logger;
        private readonly IPrimeService _primeService; 

        public SieveController(ILogger<SieveController> logger, IPrimeService primeService)
        {
            _logger = logger;
            _primeService = primeService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetNthPrime([FromQuery] int n)
        {
            return Ok(await _primeService.GetNthPrime(n+1));
        }

        [HttpGet("twinprime")]
        public async Task<IActionResult> IsTwinPrime([FromQuery] int n)
        {
            return Ok(await _primeService.GetTwinPrime(n + 1));
        }
    }
}
