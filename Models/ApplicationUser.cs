using Microsoft.AspNetCore.Identity;

namespace PenguageMvc.Models
{
    public class ApplicationUser : IdentityUser 
    {
        public string? LanguageToLearn { get; set; }
    }
}
