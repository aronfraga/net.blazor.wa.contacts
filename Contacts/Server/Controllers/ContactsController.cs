using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contacts.Repository;
using Microsoft.AspNetCore.Mvc;
using Contacts.Shared;
using Microsoft.AspNetCore.Authorization;

namespace Contacts.Server.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpPost]
        public async Task<IActionResult> InsertContact([FromBody] Contact contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _contactRepository.InsertContact(contact);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, [FromBody] Contact contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _contactRepository.UpdateContact(contact, id);
            return NoContent();
        }

        [HttpGet]
        public async Task<IEnumerable<Contact>> GetAllContact()
        {
            return await _contactRepository.GetAllContacts();
        }

        [HttpGet("{id}")]
        public async Task<Contact> GetContactDetails(int id)
        {
            return await _contactRepository.GetContactById(id);
        }

        [HttpDelete("{id}")]
        public async Task DeleteContact(int id)
        {
            await _contactRepository.DeleteContact(id);
        }

    }
}

