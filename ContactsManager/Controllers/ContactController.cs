using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ContactManager.Infrastructure;
using ContactManager.Models;

namespace ContactManager.Controllers
{
    [Authorize]
    public class ContactController : ApiController
    {
        private const string InvalidEntity = "Contact entity is not valid";
        private IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        // GET: api/Contact
        public IEnumerable<Contact> Get()
        {
            return _contactRepository.GetAll();
        }

        // GET: api/Contact/5
        public IHttpActionResult Get(int id)
        {
            var contact = _contactRepository.Get(id);
            if (contact == null)
                return NotFound();

            return Ok(contact);
        }

        // POST: api/Contact
        public IHttpActionResult Post([FromBody]Contact value)
        {
            if (value == null)
                return BadRequest(InvalidEntity);

            _contactRepository.Insert(value);

            return CreatedAtRoute("DefaultApi", new { id = value.Id }, value);
        }

        // PUT: api/Contact/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]Contact value)
        {
            if (value == null)
                return BadRequest(InvalidEntity);

            _contactRepository.Update(value);

            return Content(HttpStatusCode.Accepted, value);
        }

        // DELETE: api/Contact/5
        public IHttpActionResult Delete(int id)
        {            
            Contact contact = _contactRepository.Get(id);
            if (contact == null)
                return NotFound();

            _contactRepository.Delete(contact);

            return Ok();
        }
    }
}
