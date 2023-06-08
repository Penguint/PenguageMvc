using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using PenguageMvc.Data;
using PenguageMvc.Models;

namespace PenguageMvc.Controllers
{
    public class VocabularyController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public VocabularyController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);  // Get the current user
            if (user == null)
            { 
                return NotFound();  // User not found
            }
            if (user.LanguageToLearn == "Spanish")
            {
                return Redirect("https://diagnostic-increase-8d0.notion.site/Learning-Materials-for-Spanish-0af0fe0b58bb4241baa1c98e2db07c8a");
            }
            if (user.LanguageToLearn == "Japanese")
            {
                return Redirect("https://diagnostic-increase-8d0.notion.site/Learning-Materials-for-Japanese-12f3625b9ebc495e8b45c58332625886?pvs=4");
            }
            if (user.LanguageToLearn == "Chinese")
            {
                return Redirect("https://www.notion.so/Learning-Materials-for-Chinese-4bf8524d8557498eb36d710cd0f35662?pvs=4");
            }
            return NotFound();
        }
    }
}
