using Microsoft.AspNetCore.Mvc;
using PruebaTecnica_JohanFranco.Server.Repositories;
using PruebaTecnica_JohanFranco.Shared;
using PruebaTecnica_JohanFranco.Shared.Access;

namespace PruebaTecnica_JohanFranco.Server.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccessController : ControllerBase
    {
        private readonly IAccesRepository accessRepository;

        public AccessController(IAccesRepository accessRepository)
        {
            this.accessRepository = accessRepository;
        }

        [HttpPost]
        public async Task<ActionResult<UserToken>> GetTokenLogin(UserCredentials credentials)
        {
            try
            {
                var token = await accessRepository.GetUserToken(credentials);
                if (token == null) return NotFound();
                return token;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("register")]
        public async Task<ActionResult<bool>> RegisterUser(UserDTO userDTO)
        {
            try
            {
                return await accessRepository.RegisterUser(userDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
