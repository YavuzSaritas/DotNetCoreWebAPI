using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DotNetCoreWebAPI.Context;
using DotNetCoreWebAPI.Dtos;
using DotNetCoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreWebAPI.Services {
    public class CharacterService : ICharacterService {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public CharacterService(IMapper mapper,DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

       

        public async Task<ServiceResponse<Character>> AddCharacter (Character newCharacter) {
            var serviceResponse = new ServiceResponse<Character>();
            await _context.Character.AddAsync(newCharacter);
            await _context.SaveChangesAsync();
            serviceResponse.Data = newCharacter;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CharacterDto>>> GetAllCharacters () {
            var serviceResponse = new ServiceResponse<List<CharacterDto>>();
            var characters = await _context.Character.Where(p=>!p.IsDeleted).ToListAsync();
            serviceResponse.Data = (characters.Select(p=> _mapper.Map<CharacterDto>(p))).ToList();
           return serviceResponse;
        }

        public async Task<ServiceResponse<CharacterDto>> GetById (int id) {
            var serviceResponse = new ServiceResponse<CharacterDto>();
            var character = await _context.Character.FirstOrDefaultAsync(p=>p.Id == id && !p.IsDeleted);
            serviceResponse.Data = _mapper.Map<CharacterDto>(character);
            return serviceResponse;
        }

        public async Task<ServiceResponse<Character>> UpdateCharacter(Character character)
        {
            var serviceResponse = new ServiceResponse<Character>();
            _context.Entry(character).State=EntityState.Modified;
            _context.SaveChanges();
            serviceResponse.Data = character;
            return serviceResponse;
        }
        

        public async Task<ServiceResponse<Character>> DeletedCharacter(Character character)
        {
             var serviceResponse = new ServiceResponse<Character>();
             character.IsDeleted = true;
            _context.Entry(character).State=EntityState.Modified;
            _context.SaveChanges();
            serviceResponse.Data = character;
            return serviceResponse;
        }
    }
}