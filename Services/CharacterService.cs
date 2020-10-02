using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreWebAPI.Models;

namespace DotNetCoreWebAPI.Services {
    public class CharacterService : ICharacterService {

        private List<Character> characters = new List<Character>{new Character(){Id=1,Name="deneme"}};
        
        public async Task<ServiceResponse<Character>> AddCharacter (Character newCharacter) {
            var serviceResponse = new ServiceResponse<Character>();
            characters.Add(newCharacter);
            serviceResponse.Data = newCharacter;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Character>>> GetAllCharacters () {
            var serviceResponse = new ServiceResponse<List<Character>>();
            serviceResponse.Data = characters;
           return serviceResponse;
        }

        public async Task<ServiceResponse<Character>> GetById (int id) {
            var serviceResponse = new ServiceResponse<Character>();
            serviceResponse.Data = characters.FirstOrDefault(p=>p.Id == id);
            return serviceResponse;
        }

    }
}