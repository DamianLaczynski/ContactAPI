using ContactAPI.Models;
using ContactAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactAPI.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService) 
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        [Authorize]
        public ActionResult RegisterContact([FromBody]RegisterContactDto dto)
        {
            _accountService.RegisterUser(dto);
            return Ok(); //Zwracanie status 200 OK
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody]LoginDto dto)
        {
            string token = _accountService.GenerateJwt(dto); // Generowanie JWT dla danych z DTO
            return Ok(token); //Token zwracany w odpowiedzi
        }
    }
}
