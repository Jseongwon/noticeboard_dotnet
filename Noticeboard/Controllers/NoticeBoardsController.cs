using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Noticeboard.Data;
using Noticeboard.Models;

namespace Noticeboard.Controllers
{
    public class NoticeBoardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NoticeBoardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NoticeBoards
        public async Task<IActionResult> Index()
        {
              return _context.NoticeBoard != null ? 
                          View(await _context.NoticeBoard.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.NoticeBoard'  is null.");
        }

        // GET: NoticeBoards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NoticeBoard == null)
            {
                return NotFound();
            }

            var noticeBoard = await _context.NoticeBoard
                .FirstOrDefaultAsync(m => m.ID == id);
            if (noticeBoard == null)
            {
                return NotFound();
            }

            return View(noticeBoard);
        }

        // GET: NoticeBoards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NoticeBoards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Content,CreatedUtc")] NoticeBoard noticeBoard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(noticeBoard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(noticeBoard);
        }

        // GET: NoticeBoards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NoticeBoard == null)
            {
                return NotFound();
            }

            var noticeBoard = await _context.NoticeBoard.FindAsync(id);
            if (noticeBoard == null)
            {
                return NotFound();
            }
            return View(noticeBoard);
        }

        // POST: NoticeBoards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Content,CreatedUtc")] NoticeBoard noticeBoard)
        {
            if (id != noticeBoard.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(noticeBoard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoticeBoardExists(noticeBoard.ID))
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
            return View(noticeBoard);
        }

        // GET: NoticeBoards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NoticeBoard == null)
            {
                return NotFound();
            }

            var noticeBoard = await _context.NoticeBoard
                .FirstOrDefaultAsync(m => m.ID == id);
            if (noticeBoard == null)
            {
                return NotFound();
            }

            return View(noticeBoard);
        }

        // POST: NoticeBoards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NoticeBoard == null)
            {
                return Problem("Entity set 'ApplicationDbContext.NoticeBoard'  is null.");
            }
            var noticeBoard = await _context.NoticeBoard.FindAsync(id);
            if (noticeBoard != null)
            {
                _context.NoticeBoard.Remove(noticeBoard);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoticeBoardExists(int id)
        {
          return (_context.NoticeBoard?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
