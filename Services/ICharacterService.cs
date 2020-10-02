using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCoreWebAPI.Models;

namespace DotNetCoreWebAPI.Services
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<Character>>> GetAllCharacters();
        Task<ServiceResponse<Character>> GetById(int id);
        Task<ServiceResponse<Character>> AddCharacter(Character newCharacter);
        
    }
}