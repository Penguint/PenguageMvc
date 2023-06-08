using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using PenguageMvc.Data;
using PenguageMvc.Models;

namespace PenguageMvc.Controllers
{
    public class GrammarController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public GrammarController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
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
                return Redirect("https://diagnostic-increase-8d0.notion.site/Spanish-Grammar-74dba5c31ccb4086988d0e2bd53a5980?pvs=4");
            }
            if (user.LanguageToLearn == "Japanese")
            {
                return Redirect("https://diagnostic-increase-8d0.notion.site/Japanese-Grammar-9988eddf5c4e4e6caa3f20e64867b011?pvs=4");
            }
            if (user.LanguageToLearn == "Chinese")
            {
                return Redirect("https://diagnostic-increase-8d0.notion.site/Chinese-Grammar-ab27010fb8684058834f45f274450ba8?pvs=4");
            }
            return NotFound();
        }
    }
}
