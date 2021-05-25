using System.Threading.Tasks;
using BankingAppWebAPI.DBModels;
using System.Collections.Generic;
using BankingAppWebAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankingAppWebAPI.Services
{
    public class UsersService : IUsersService
    {
        private readonly BankingAppDbContext _context;

        public UsersService(BankingAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
