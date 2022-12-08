using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using csharp_diary.Data;
using csharp_diary.Models;

namespace csharp_diary.Controllers
{
    public class DiaryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DiaryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Diary
        public async Task<IActionResult> Index()
        {
              return _context.Diary != null ? 
                          View(await _context.Diary.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Diary'  is null.");
        }

        // GET: Diary/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Diary == null)
            {
                return NotFound();
            }

            var diary = await _context.Diary
                .FirstOrDefaultAsync(m => m.ID == id);
            if (diary == null)
            {
                return NotFound();
            }

            return View(diary);
        }

        // GET: Diary/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Diary/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,EntryTitle,EntiryDesc,EntryDate")] Diary diary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diary);
        }

        // GET: Diary/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Diary == null)
            {
                return NotFound();
            }

            var diary = await _context.Diary.FindAsync(id);
            if (diary == null)
            {
                return NotFound();
            }
            return View(diary);
        }

        // POST: Diary/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,EntryTitle,EntiryDesc,EntryDate")] Diary diary)
        {
            if (id != diary.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiaryExists(diary.ID))
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
            return View(diary);
        }

        // GET: Diary/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Diary == null)
            {
                return NotFound();
            }

            var diary = await _context.Diary
                .FirstOrDefaultAsync(m => m.ID == id);
            if (diary == null)
            {
                return NotFound();
            }

            return View(diary);
        }

        // POST: Diary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Diary == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Diary'  is null.");
            }
            var diary = await _context.Diary.FindAsync(id);
            if (diary != null)
            {
                _context.Diary.Remove(diary);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiaryExists(int id)
        {
          return (_context.Diary?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
