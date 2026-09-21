using Domain.Entities;

namespace Application.Repositories
{
    public interface IPersonalAccountRepository
    {
        Task AddAsync(PersonalAccount account);
        Task<bool> ExistsByEmailAsync(string email);
    }
}