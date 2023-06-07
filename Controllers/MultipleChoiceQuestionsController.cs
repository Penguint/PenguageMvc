using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PenguageMvc.Data;
using PenguageMvc.Models;

namespace PenguageMvc.Controllers
{
    public class MultipleChoiceQuestionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MultipleChoiceQuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MultipleChoiceQuestions
        public async Task<IActionResult> Index()
        {
            return _context.MultipleChoiceQuestion != null ?
                        View(await _context.MultipleChoiceQuestion.ToListAsync()) :
                        Problem("Entity set 'PenguageMvcContext.MultipleChoiceQuestion'  is null.");
        }

        // GET: MultipleChoiceQuestions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MultipleChoiceQuestion == null)
            {
                return NotFound();
            }

            var multipleChoiceQuestion = await _context.MultipleChoiceQuestion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (multipleChoiceQuestion == null)
            {
                return NotFound();
            }

            return View(multipleChoiceQuestion);
        }

        // GET: MultipleChoiceQuestions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MultipleChoiceQuestions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Stem,CorrectAnswer,Distractor1,Distractor2,Distractor3,Id,Language,Explanation")] MultipleChoiceQuestion multipleChoiceQuestion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(multipleChoiceQuestion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(multipleChoiceQuestion);
        }

        // GET: MultipleChoiceQuestions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MultipleChoiceQuestion == null)
            {
                return NotFound();
            }

            var multipleChoiceQuestion = await _context.MultipleChoiceQuestion.FindAsync(id);
            if (multipleChoiceQuestion == null)
            {
                return NotFound();
            }
            return View(multipleChoiceQuestion);
        }

        // POST: MultipleChoiceQuestions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Stem,CorrectAnswer,Distractor1,Distractor2,Distractor3,Id,Language,Explanation")] MultipleChoiceQuestion multipleChoiceQuestion)
        {
            if (id != multipleChoiceQuestion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(multipleChoiceQuestion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MultipleChoiceQuestionExists(multipleChoiceQuestion.Id))
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
            return View(multipleChoiceQuestion);
        }

        // GET: MultipleChoiceQuestions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MultipleChoiceQuestion == null)
            {
                return NotFound();
            }

            var multipleChoiceQuestion = await _context.MultipleChoiceQuestion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (multipleChoiceQuestion == null)
            {
                return NotFound();
            }

            return View(multipleChoiceQuestion);
        }

        // POST: MultipleChoiceQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MultipleChoiceQuestion == null)
            {
                return Problem("Entity set 'PenguageMvcContext.MultipleChoiceQuestion'  is null.");
            }
            var multipleChoiceQuestion = await _context.MultipleChoiceQuestion.FindAsync(id);
            if (multipleChoiceQuestion != null)
            {
                _context.MultipleChoiceQuestion.Remove(multipleChoiceQuestion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MultipleChoiceQuestionExists(int id)
        {
            return (_context.MultipleChoiceQuestion?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
