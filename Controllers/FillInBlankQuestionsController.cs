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
    public class FillInBlankQuestionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FillInBlankQuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FillInBlankQuestions
        public async Task<IActionResult> Index()
        {
            return _context.FillInBlankQuestion != null ?
                        View(await _context.FillInBlankQuestion.ToListAsync()) :
                        Problem("Entity set 'PenguageMvcContext.FillInBlankQuestion'  is null.");
        }

        // GET: FillInBlankQuestions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FillInBlankQuestion == null)
            {
                return NotFound();
            }

            var fillInBlankQuestion = await _context.FillInBlankQuestion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fillInBlankQuestion == null)
            {
                return NotFound();
            }

            return View(fillInBlankQuestion);
        }

        // GET: FillInBlankQuestions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FillInBlankQuestions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StemBeforeBlank,BlankAnswer,StemAfterBlank,Id,Language,Explanation")] FillInBlankQuestion fillInBlankQuestion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fillInBlankQuestion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fillInBlankQuestion);
        }

        // GET: FillInBlankQuestions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FillInBlankQuestion == null)
            {
                return NotFound();
            }

            var fillInBlankQuestion = await _context.FillInBlankQuestion.FindAsync(id);
            if (fillInBlankQuestion == null)
            {
                return NotFound();
            }
            return View(fillInBlankQuestion);
        }

        // POST: FillInBlankQuestions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StemBeforeBlank,BlankAnswer,StemAfterBlank,Id,Language,Explanation")] FillInBlankQuestion fillInBlankQuestion)
        {
            if (id != fillInBlankQuestion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fillInBlankQuestion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FillInBlankQuestionExists(fillInBlankQuestion.Id))
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
            return View(fillInBlankQuestion);
        }

        // GET: FillInBlankQuestions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FillInBlankQuestion == null)
            {
                return NotFound();
            }

            var fillInBlankQuestion = await _context.FillInBlankQuestion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fillInBlankQuestion == null)
            {
                return NotFound();
            }

            return View(fillInBlankQuestion);
        }

        // POST: FillInBlankQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FillInBlankQuestion == null)
            {
                return Problem("Entity set 'PenguageMvcContext.FillInBlankQuestion'  is null.");
            }
            var fillInBlankQuestion = await _context.FillInBlankQuestion.FindAsync(id);
            if (fillInBlankQuestion != null)
            {
                _context.FillInBlankQuestion.Remove(fillInBlankQuestion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FillInBlankQuestionExists(int id)
        {
            return (_context.FillInBlankQuestion?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
