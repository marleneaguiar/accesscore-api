using Application.DTOs.PersonalAccounts;
using Application.Exceptions;
using Application.Repositories;
using Application.Security;
using Domain.Entities;

namespace Application.UseCases.PersonalAccounts
{
    public class RegisterPersonalAccountUseCase
    {
        private readonly IPersonalAccountRepository _repository;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterPersonalAccountUseCase(
            IPersonalAccountRepository repository,
            IPasswordHasher passwordHasher)
        {
            _repository = repository;
            _passwordHasher = passwordHasher;
        }
        public async Task Execute(RegisterPersonalAccountRequestDTO request) //para executar o caso de uso de cadastro, preciso dos dados contidos no DTO
        {
            var emailAlreadyExists =
                await _repository.ExistsByEmailAsync(request.Email);

            if (emailAlreadyExists)
            {
                throw new EmailAlreadyExistsException();
            }

            var passwordHash = _passwordHasher.Hash(request.Password);

            var account = new PersonalAccount(
               request.Name,
               request.Email,
               passwordHash,
               DateTimeOffset.UtcNow
               );

            await _repository.AddAsync(account);

        }
    }
}