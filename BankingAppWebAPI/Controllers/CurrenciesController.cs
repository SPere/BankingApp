using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankingAppWebAPI.DBModels;
using System.Collections.Generic;
using BankingAppWebAPI.Services.Interfaces;

namespace BankingAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        private readonly ICurrencyService _currenyService;

        public CurrenciesController(ICurrencyService currenyService)
        {
            _currenyService = currenyService;
        }

        // GET: api/Currencies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Currency>>> GetCurrencies()
        {
            return Ok(await _currenyService.GetCurrencies());
        }
    }
}
