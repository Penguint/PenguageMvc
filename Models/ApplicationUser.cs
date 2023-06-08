using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace PenguageMvc.Models
{
    public class ApplicationUser : IdentityUser 
    {
        [DefaultValue("Spanish")]
        public string? LanguageToLearn { get; set; }
    }
}
