using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace MessageBoard.Models
{
    public class ApplicationUser : IdentityUser
    {
        
        public int UserId {get; set;}
        public string Password { get; set; }
        public string Role { get; set; }
        public string Surname { get; set; }
        public string GivenName { get; set; }

    }
}