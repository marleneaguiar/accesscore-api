using AccessCore.Infrastructure.Persistence;
using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class PersonalAccountRepository : IPersonalAccountRepository
    {
        private readonly AccessCoreDbContext _dbContext;

        public PersonalAccountRepository(AccessCoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _dbContext.personalAccounts.AnyAsync(account => account.Email == email);
        }

        public async Task AddAsync(PersonalAccount account)
        {
            await _dbContext.personalAccounts.AddAsync(account);
            await _dbContext.SaveChangesAsync();
        }

    }
}