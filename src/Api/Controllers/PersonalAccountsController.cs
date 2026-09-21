using Application.DTOs.PersonalAccounts;
using Application.UseCases.PersonalAccounts;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("personal-accounts")]
    public class PersonalAccountsController : ControllerBase
    {
        private readonly RegisterPersonalAccountUseCase _registerUseCase;

        public PersonalAccountsController(
            RegisterPersonalAccountUseCase registerUseCase)
        {
            _registerUseCase = registerUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> Register(
            [FromBody] RegisterPersonalAccountRequestDTO request)
        {
            await _registerUseCase.Execute(request);

            return StatusCode(StatusCodes.Status201Created);
        }
    }
}