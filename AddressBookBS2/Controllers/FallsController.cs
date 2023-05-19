using HomeCare.Data;
using HomeCare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeCare.Controllers
{
    public class FallsController : Controller
    {
        private readonly HomeCareContext _context;

        public FallsController(HomeCareContext context)
        {
            _context = context;
        }


        // GET: Falls
        public async Task<IActionResult> Index()
        {
            return _context.Fall != null ?
                        View(await _context.Fall.ToListAsync()) :
                        Problem("Entity set 'HomeCareContext.Fall'  is null.");
        }

        // GET: Falls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Fall == null)
            {
                return NotFound();
            }

            var fall = await _context.Fall
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fall == null)
            {
                return NotFound();
            }

            return View(fall);
        }

        // GET: Falls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Falls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Status")] Fall fall)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fall);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fall);
        }

        // GET: Falls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Fall == null)
            {
                return NotFound();
            }

            var fall = await _context.Fall.FindAsync(id);
            if (fall == null)
            {
                return NotFound();
            }
            return View(fall);
        }

        // POST: Falls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Status")] Fall fall)
        {
            if (id != fall.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fall);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FallExists(fall.Id))
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
            return View(fall);
        }

        // GET: Falls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Fall == null)
            {
                return NotFound();
            }

            var fall = await _context.Fall
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fall == null)
            {
                return NotFound();
            }

            return View(fall);
        }

        // POST: Falls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Fall == null)
            {
                return Problem("Entity set 'HomeCareContext.Fall'  is null.");
            }
            var fall = await _context.Fall.FindAsync(id);
            if (fall != null)
            {
                _context.Fall.Remove(fall);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FallExists(int id)
        {
            return (_context.Fall?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
