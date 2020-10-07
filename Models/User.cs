using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotNetCoreWebAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        [Required]
        public string Role { get; set; }

        public List<Character> Characters { get; set; }

    }
}