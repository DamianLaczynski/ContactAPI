using AutoMapper;
using ContactAPI.Entities;
using ContactAPI.Models;
using ContactAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactAPI.Controllers
{
    [Route("api/contact")]
    [ApiController]
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

        [HttpPost]
        public ActionResult CreateContact([FromBody] CreateContactDto dto)
        {
            int id = _contactService.Create(dto);
            return Created($"/api/contact/{id}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ContactDto>> GetAll()
        {
            var contacts = _contactService.GetAll();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public ActionResult<ContactDto> Get([FromRoute] int id)
        {
            var retContact = _contactService.GetById(id);

            if(retContact == null)
            {
                return NotFound();
            }
            return Ok(retContact);
        }
    }
}
