using breaking_bad.domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace breaking_bad.api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/characters")]
    public class CharactersController : Controller
    {
        private readonly ILogger<CharactersController> _logger;
        private readonly ICharacterService _characterService;
        public CharactersController(ILogger<CharactersController> logger, ICharacterService characterService)
        {
            _logger = logger;
            _characterService = characterService;   
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var charactersResponse = _characterService.GetAllAsync();
                return Ok(charactersResponse);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
