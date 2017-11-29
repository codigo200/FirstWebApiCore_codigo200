using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FirstWebApiCore.Data.Contract;
using AutoMapper;
using FirstWebApiCore.Models;
using FirstWebApiCore.Domain.Entities;
using FirstWebApiCore.App_Start;

namespace FirstWebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ServiceFilter(typeof(CustomActionFilter))]
    public class ContactsController : Controller
    {
        private IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var result = _contactRepository.List();
            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var contact = _contactRepository.FindBy(id);
            if (contact == null)
                return NotFound();
            else
                return Ok(contact);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]ContactModel model)
        {
            var contact = Mapper.Map<Contact>(model);
            _contactRepository.Add(contact);
            return Ok(contact);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ContactModel model)
        {
            var contact = _contactRepository.FindBy(id);
            if (contact == null)
                return NotFound();
            else
            {
                var newContact = Mapper.Map<Contact>(model);
                contact.Age = newContact.Age;
                contact.Name = newContact.Name;
                contact.LastNames = newContact.LastNames;
                _contactRepository.Update(contact);
                return Ok(contact);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var contact = _contactRepository.FindBy(id);
            if (contact == null)
                return NotFound();
            else
            {
                _contactRepository.Delete(contact);
                return NoContent();
            }
        }
    }
}
