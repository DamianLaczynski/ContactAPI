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
    [Authorize] //Wszystkie działania będą wymagały aby użytkownik był zautoryzowany
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        // Usuwanie kontaktu o zadanym ID
        [HttpDelete("{id}")] 
        [Authorize(Roles ="admin")]
        public ActionResult Delete([FromRoute]int id) 
        {
            var isDeleted = _contactService.Delete(id); // Usuwanie kontaktu

            if (isDeleted)
            {
                return NoContent();  // Zwracamy status 204 No Content, jeśli kontakt został usunięty
            }
            return NotFound(); //status 404 Not Found, jeśli kontakt nie został znaleziony
        }

        [HttpPut("{id}")] //Aktualizacja kontaktu
        public ActionResult UpdateContact([FromBody] UpdateContactDto dto, [FromRoute]int id)
        {
            var isUpdated = _contactService.Update(id, dto); //Aktualizowanie kontaktu
            if(!isUpdated)
            {
                return NotFound(); //status 404 Not Found, jeśli kontakt nie został znaleziony
            }
            return Ok(); //status 200 OK, jeśli kontakt został zaktualizowany
        }


        [HttpGet] // Pobieranie wszystkich kontaktów
        public ActionResult<IEnumerable<ContactAutorizedDto>> GetAllAutorized()
        {
            var contacts = _contactService.GetAll<ContactAutorizedDto>();
            return Ok(contacts); //Zwracanie wszystkich kontaktów w odpowiedzi HTTP
        }

        [HttpGet("{id}")] // Pobieranie kontaktu po ID
        public ActionResult<ContactAutorizedDto> GetAutorized([FromRoute] int id)
        {
            var retContact = _contactService.GetById<ContactAutorizedDto>(id); //Pobieranie kontaktu po ID

            if (retContact == null)
            {
                return NotFound(); //status 404 Not Found, jeśli kontakt nie został znaleziony
            }
            return Ok(retContact); //Zwracanie kontaktu w odpowiedzi HTTP
        }
    }
}
