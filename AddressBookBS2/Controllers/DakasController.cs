using HomeCare.Data;
using HomeCare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeCare.Controllers
{
    public class DakasController : Controller
    {
        private readonly HomeCareContext _context;

        public DakasController(HomeCareContext context)
        {
            _context = context;
        }

        // GET: Dakas
        public async Task<IActionResult> Index()
        {
            return _context.Daka != null ?
                        View(await _context.Daka.ToListAsync()) :
                        Problem("Entity set 'HomeCareContext.Daka'  is null.");
        }

        // GET: Dakas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Daka == null)
            {
                return NotFound();
            }

            var daka = await _context.Daka
                .FirstOrDefaultAsync(m => m.Id == id);
            if (daka == null)
            {
                return NotFound();
            }

            return View(daka);
        }

        // GET: Dakas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dakas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Zh_name,Createtime")] Daka daka)
        {
            if (ModelState.IsValid)
            {
                _context.Add(daka);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(daka);
        }

        // GET: Dakas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Daka == null)
            {
                return NotFound();
            }

            var daka = await _context.Daka.FindAsync(id);
            if (daka == null)
            {
                return NotFound();
            }
            return View(daka);
        }

        // POST: Dakas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Zh_name,Createtime")] Daka daka)
        {
            if (id != daka.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(daka);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DakaExists(daka.Id))
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
            return View(daka);
        }

        // GET: Dakas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Daka == null)
            {
                return NotFound();
            }

            var daka = await _context.Daka
                .FirstOrDefaultAsync(m => m.Id == id);
            if (daka == null)
            {
                return NotFound();
            }

            return View(daka);
        }

        // POST: Dakas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Daka == null)
            {
                return Problem("Entity set 'HomeCareContext.Daka'  is null.");
            }
            var daka = await _context.Daka.FindAsync(id);
            if (daka != null)
            {
                _context.Daka.Remove(daka);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DakaExists(int id)
        {
            return (_context.Daka?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
