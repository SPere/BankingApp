using System.Threading.Tasks;
using BankingAppWebAPI.DBModels;
using System.Collections.Generic;
using BankingAppWebAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankingAppWebAPI.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly BankingAppDbContext _context;

        public CurrencyService(BankingAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Currency>> GetCurrencies()
        {
            return await _context.Currencies.ToListAsync();
        }
    }
}