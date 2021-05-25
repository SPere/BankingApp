using System.Threading.Tasks;
using BankingAppWebAPI.Models;

namespace BankingAppWebAPI.Services.Clients.Interfaces
{
    public interface IExchangeService
    {
        Task<ExchangeRates> GetExchangeRatesForEuro();
    }
}