using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica_JohanFranco.Server.Repositories;
using PruebaTecnica_JohanFranco.Shared;

namespace PruebaTecnica_JohanFranco.Server.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ContactoController : ControllerBase
    {
        private readonly IContactoRepository contactoRepository;

        public ContactoController(IContactoRepository contactoRepository)
        {
            this.contactoRepository = contactoRepository;
        }

        [HttpGet("{IdUser}")]
        public async Task<ActionResult<List<ContactDTO>>> GetContactsByUser(int IdUser)
        {
            try
            {
                var contactos = await contactoRepository.GetContactsByIdUser(IdUser);
                if(contactos == null) return NotFound();
                return contactos;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<bool>> SaveContact(ContactDTO contact)
        {
            try
            {
                return await contactoRepository.SaveContact(contact);   
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{idContact}")]
        public async Task<ActionResult<bool>> DeleteContact(int idContact)
        {
            try
            {
                return await contactoRepository.DeleteContact(idContact);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateContact(ContactDTO contact)
        {
            try
            {
                return await contactoRepository.UpdateContact(contact);  
            }
            catch( Exception ex)
            {
                return BadRequest(ex.Message );
            }
        }
    }
}
