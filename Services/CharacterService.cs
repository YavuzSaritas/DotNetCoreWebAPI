using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using DotNetCoreWebAPI.Context;
using DotNetCoreWebAPI.Dtos;
using DotNetCoreWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreWebAPI.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CharacterService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _context = context;
        }

        private int GetUserId()=>int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)); //Yol2 Claimsden user id aılınıp işlemler bu id üzerinden yapılacak

        public async Task<ServiceResponse<CharacterDto>> AddCharacter(Character newCharacter)
        {
            var serviceResponse = new ServiceResponse<CharacterDto>();
            newCharacter.User = _context.User.FirstOrDefault(p=>p.Id == GetUserId());
            await _context.Character.AddAsync(newCharacter);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<CharacterDto>(newCharacter);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CharacterDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<CharacterDto>>();
            var characters = await _context.Character.Where(p => !p.IsDeleted && p.User.Id == GetUserId()).ToListAsync();
            serviceResponse.Data = (characters.Select(p => _mapper.Map<CharacterDto>(p))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<CharacterDto>> GetById(int id)
        {
            var serviceResponse = new ServiceResponse<CharacterDto>();
            var character = await _context.Character.FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
            serviceResponse.Data = _mapper.Map<CharacterDto>(character);
            return serviceResponse;
        }

        public async Task<ServiceResponse<Character>> UpdateCharacter(Character character)
        {
            var serviceResponse = new ServiceResponse<Character>();
            _context.Entry(character).State = EntityState.Modified;
            _context.SaveChanges();
            serviceResponse.Data = character;
            return serviceResponse;
        }


        public async Task<ServiceResponse<Character>> DeletedCharacter(Character character)
        {
            var serviceResponse = new ServiceResponse<Character>();
            character.IsDeleted = true;
            _context.Entry(character).State = EntityState.Modified;
            _context.SaveChanges();
            serviceResponse.Data = character;
            return serviceResponse;
        }
    }
}