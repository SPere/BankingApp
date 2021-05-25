using System.Threading.Tasks;
using BankingAppWebAPI.Models;
using BankingAppWebAPI.DBModels;
using Microsoft.EntityFrameworkCore;
using BankingAppWebAPI.Services.Interfaces;
using BankingAppWebAPI.Services.Clients.Interfaces;

namespace BankingAppWebAPI.Services
{
    public class BalanceService : IBalanceService
    {
        private readonly BankingAppDbContext _context;
        private readonly IExchangeService _exchangeService;

        public BalanceService(BankingAppDbContext context, IExchangeService exchangeService)
        {
            _context = context;
            _exchangeService = exchangeService;
        }

        public async Task<Balance> GetUserBalance(int userId)
        {
            return await _context.Balances.Include(b => b.Currency).FirstOrDefaultAsync(b => b.UserId == userId);
        }

        public async Task<BalanceResponse> Withdraw(Balance balance, decimal amount)
        {
            var newBalanceAmount = balance.Amount - amount;
            if (newBalanceAmount < 0)
            {
                return new BalanceResponse
                {
                    CurrentBalance = balance,
                    ErrorCode = "Bank funds are not allowed to be negative",
                    ErrorMessage = "Bank funds are not allowed to be negative"
                };
            }

            balance.Amount = newBalanceAmount;
            await _context.SaveChangesAsync();
            return new BalanceResponse
            {
                CurrentBalance = balance
            };
        }

        public async Task<BalanceResponse> Deposit(Balance balance, decimal amount, string currencyCode)
        {
            if (amount <= 0)
            {
                return new BalanceResponse
                {
                    CurrentBalance = balance,
                    ErrorCode = "Deposit amount has to be greater than 0",
                    ErrorMessage = "Deposit amount has to be greater than 0"
                };
            }

            if (balance.Currency.Code != currencyCode)
            {
                var result = await _exchangeService.GetExchangeRatesForEuro();
                var rateResult = result.Rates[currencyCode];
                amount /= rateResult;
            }

            balance.Amount += amount;
            await _context.SaveChangesAsync();

            return new BalanceResponse
            {
                CurrentBalance = balance
            };
        }
    }
}
