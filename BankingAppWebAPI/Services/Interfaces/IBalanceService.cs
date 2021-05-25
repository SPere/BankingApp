using System.Threading.Tasks;
using BankingAppWebAPI.Models;
using BankingAppWebAPI.DBModels;

namespace BankingAppWebAPI.Services.Interfaces
{
    public interface IBalanceService
    {
        Task<Balance> GetUserBalance(int userId);
        Task<BalanceResponse> Withdraw(Balance balance, decimal amount);
        Task<BalanceResponse> Deposit(Balance balance, decimal amount, string currencyCode);
    }
}