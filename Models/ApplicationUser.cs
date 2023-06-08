using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PenguageMvc.Models
{
    public class ApplicationUser : IdentityUser 
    {
        [DefaultValue("Spanish")]
        [Required]
        public string LanguageToLearn { get; set; } = "Spanish";
    }
}
