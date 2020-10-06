using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCoreWebAPI.Dtos;
using DotNetCoreWebAPI.Models;

namespace DotNetCoreWebAPI.Services
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<CharacterDto>>> GetAllCharacters();
        Task<ServiceResponse<CharacterDto>> GetById(int id);
        Task<ServiceResponse<CharacterDto>> AddCharacter(Character newCharacter);
        Task<ServiceResponse<Character>> UpdateCharacter(Character character); 
        Task<ServiceResponse<Character>> DeletedCharacter(Character character); 
        
    }
}