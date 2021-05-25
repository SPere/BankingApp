using System.Threading.Tasks;
using BankingAppWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using BankingAppWebAPI.DBModels;
using BankingAppWebAPI.Services.Interfaces;

namespace BankingAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalancesController : ControllerBase
    {
        private readonly IBalanceService _balanceService;

        public BalancesController(IBalanceService balanceService)
        {
            _balanceService = balanceService;
        }

        // GET: api/Balances/5
        [HttpGet("{userId}")]
        public async Task<ActionResult<Balance>> Get(int userId)
        {
            var balance = await _balanceService.GetUserBalance(userId);

            if (balance == null)
            {
                return NotFound();
            }

            return balance;
        }

        // POST: api/balances/withdraw/
        [HttpPost("/withdraw")]
        public async Task<ActionResult<BalanceResponse>> Withdraw(WithdrawRequest request)
        {
            var balance = await _balanceService.GetUserBalance(request.UserId);

            if (balance == null)
            {
                return NotFound();
            }

            return Ok(await _balanceService.Withdraw(balance, request.Amount));
        }

        // POST: api/balances/deposit/
        [HttpPost("/deposit")]
        public async Task<ActionResult<BalanceResponse>> Deposit(DepositRequest request)
        {
            var balance = await _balanceService.GetUserBalance(request.UserId);

            if (balance == null)
            {
                return NotFound();
            }

            return Ok(await _balanceService.Deposit(balance, request.Amount, request.CurrencyCode));
        }


    }
}
