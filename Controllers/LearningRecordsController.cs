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
    public class LearningRecordsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LearningRecordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LearningRecords
        public async Task<IActionResult> Index()
        {
            return _context.LearningRecord != null ?
                        View(await _context.LearningRecord.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.LearningRecord'  is null.");
        }

        // GET: LearningRecords/Details/5
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

        // GET: LearningRecords/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LearningRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompleteDate")] LearningRecord learningRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(learningRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(learningRecord);
        }

        // GET: LearningRecords/Edit/5
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

        // POST: LearningRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompleteDate")] LearningRecord learningRecord)
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

        // GET: LearningRecords/Delete/5
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

        // POST: LearningRecords/Delete/5
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
