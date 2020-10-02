using System.Threading.Tasks;
using DotNetCoreWebAPI.Models;
using DotNetCoreWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreWebAPI.Controllers {
    [ApiController]
    [Route ("[controller]")]
    public class CharacterController : ControllerBase {
        private readonly ICharacterService _characterService;
        public CharacterController (ICharacterService characterService) {
            _characterService = characterService;

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> AddCharacter(int id){
            var character = await _characterService.GetById(id);
            return Ok(character);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAllCharacters(){
            var charactersList = await _characterService.GetAllCharacters();
            return Ok(charactersList);
        }
        
        [HttpGet("Add")]
        public async Task<ActionResult> AddCharacter([FromBody]Character newCharacter){
            var character = await _characterService.AddCharacter(newCharacter);
            return Ok(character);
        }


    }
}