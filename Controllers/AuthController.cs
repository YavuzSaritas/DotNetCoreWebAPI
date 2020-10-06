using System.Threading.Tasks;
using DotNetCoreWebAPI.Data;
using DotNetCoreWebAPI.Dtos;
using DotNetCoreWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDto registerDto){
            var response = await _authRepository.Register(
            new User(){
                Username = registerDto.UserName
            },registerDto.Password);
            if(!response.Success){
                return BadRequest(response);
            }
            return Ok(response);

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto loginDto){
            var response = await _authRepository.Login(loginDto.UserName,loginDto.PassWord);
            if(!response.Success){
                return BadRequest(response);
            }
            return Ok(response);

        }
    }
}