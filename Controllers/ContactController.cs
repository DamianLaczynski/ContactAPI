using AutoMapper;
using ContactAPI.Entities;
using ContactAPI.Models;
using ContactAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactAPI.Controllers
{
    [Route("api/contact")]
    [ApiController]
    [Authorize]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpDelete("{id}")]

        public ActionResult Delete([FromRoute]int id) 
        {
            var isDeleted = _contactService.Delete(id);

            if(isDeleted)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateContact([FromBody] UpdateContactDto dto, [FromRoute]int id)
        {
            var isUpdated = _contactService.Update(id, dto);
            if(!isUpdated)
            {
                return NotFound();
            }
            return Ok();
        }


        [HttpGet]
        public ActionResult<IEnumerable<ContactAutorizedDto>> GetAllAutorized()
        {
            var contacts = _contactService.GetAll<ContactAutorizedDto>();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public ActionResult<ContactAutorizedDto> GetAutorized([FromRoute] int id)
        {
            var retContact = _contactService.GetById<ContactAutorizedDto>(id);

            if (retContact == null)
            {
                return NotFound();
            }
            return Ok(retContact);
        }
    }
}
