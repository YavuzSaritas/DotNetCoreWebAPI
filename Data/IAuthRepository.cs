using System.Threading.Tasks;
using DotNetCoreWebAPI.Models;

namespace DotNetCoreWebAPI.Data
{
    public interface IAuthRepository
    {
         Task<ServiceResponse<int>> Register(User user, string password);
         Task<ServiceResponse<string>> Login(string username , string password);
         Task<bool> UserExist(string username);
    }
}