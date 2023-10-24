using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ContactsApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ContactsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactDbContext _dbcontext;

        public ContactController(ContactDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List()
        {
            List<Contact> list = await _dbcontext.Contacts.OrderByDescending(c => c.ContactId).ToListAsync();

            return StatusCode(StatusCodes.Status200OK, list);

        }

        [HttpPost]
        [Route("Save")]

        public async Task<IActionResult> Save([FromBody] Contact request)
        {
            await _dbcontext.Contacts.AddAsync(request);
            await _dbcontext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK);
        }


        [HttpPut]
        [Route("Edit")]

        public async Task<IActionResult> Edit([FromBody] Contact request)
        {
            _dbcontext.Contacts.Update(request);
            await _dbcontext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpDelete]
        [Route("Delete")]

        public async Task<IActionResult> Delete(int id)
        {
            Contact contact = await _dbcontext.Contacts.Find(id);
            _dbcontext.Contacts.Remove(contact);
            await _dbcontext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "Ok");
        }

    }
}
