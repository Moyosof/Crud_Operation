using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CRUD_Operation.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        [MaxLength(150, ErrorMessage = "Age must be below 150")]
        [MinLength(18, ErrorMessage = "You must be Above 18+")]
        public int Age { get; set; }
    }
}
