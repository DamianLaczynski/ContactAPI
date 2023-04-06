using ContactAPI.Models;
using ContactAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactAPI.Controllers
{
    [Route("api/public-contact")]
    [ApiController]
    //kontroler dla użytkowników niezalogowanych
    public class ContactPublicController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactPublicController(IContactService contactService)
        {
            _contactService = contactService;
        }


        //zwrócenie wszystkich publicznych kontaktów
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<ContactDto>> GetAll()
        {
            var contacts = _contactService.GetAll<ContactDto>();
            return Ok(contacts); //status 200 OK
        }


        //zwrócenie kontaku publicznego o zadanycm ID
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<ContactDto> Get([FromRoute] int id)
        {

            var retContact = _contactService.GetById<ContactDto>(id);

            if (retContact == null)
            {
                return NotFound();
            }
            return Ok(retContact); //status 200 OK

        }
    }
}
