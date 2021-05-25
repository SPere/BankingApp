using System.Collections.Generic;
using System.Threading.Tasks;
using BankingAppWebAPI.DBModels;

namespace BankingAppWebAPI.Services.Interfaces
{
    public interface IUsersService
    {
        Task<IEnumerable<User>> GetUsers();
    }
}