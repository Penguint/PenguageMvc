using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PenguageMvc.Data;
using PenguageMvc.Models;

namespace PenguageMvc.Controllers
{
    public class ProgressController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProgressController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Progress
        public async Task<IActionResult> Index()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
				return NotFound();
			}

            var learningRecord = _context.LearningRecord
                .Where(m => m.User == user)
                .ToListAsync();

            return _context.LearningRecord != null ? 
                          View(await learningRecord) :
                          Problem("Entity set 'ApplicationDbContext.LearningRecord'  is null.");
        }

        // GET: Progress/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LearningRecord == null)
            {
                return NotFound();
            }

            var learningRecord = await _context.LearningRecord
                .FirstOrDefaultAsync(m => m.Id == id);
            if (learningRecord == null)
            {
                return NotFound();
            }

            return View(learningRecord);
        }

        // GET: Progress/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Progress/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompleteDate,Correct")] LearningRecord learningRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(learningRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(learningRecord);
        }

        // GET: Progress/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LearningRecord == null)
            {
                return NotFound();
            }

            var learningRecord = await _context.LearningRecord.FindAsync(id);
            if (learningRecord == null)
            {
                return NotFound();
            }
            return View(learningRecord);
        }

        // POST: Progress/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompleteDate,Correct")] LearningRecord learningRecord)
        {
            if (id != learningRecord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(learningRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LearningRecordExists(learningRecord.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(learningRecord);
        }

        // GET: Progress/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LearningRecord == null)
            {
                return NotFound();
            }

            var learningRecord = await _context.LearningRecord
                .FirstOrDefaultAsync(m => m.Id == id);
            if (learningRecord == null)
            {
                return NotFound();
            }

            return View(learningRecord);
        }

        // POST: Progress/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LearningRecord == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LearningRecord'  is null.");
            }
            var learningRecord = await _context.LearningRecord.FindAsync(id);
            if (learningRecord != null)
            {
                _context.LearningRecord.Remove(learningRecord);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LearningRecordExists(int id)
        {
          return (_context.LearningRecord?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
