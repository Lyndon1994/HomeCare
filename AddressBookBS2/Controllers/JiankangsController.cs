using HomeCare.Data;
using HomeCare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeCare.Controllers
{
    public class JiankangsController : Controller
    {
        private readonly HomeCareContext _context;

        public JiankangsController(HomeCareContext context)
        {
            _context = context;
        }

        // GET: Jiankangs
        public async Task<IActionResult> Index()
        {
            return _context.Jiankang != null ?
                        View(await _context.Jiankang.ToListAsync()) :
                        Problem("Entity set 'HomeCareContext.Jiankang'  is null.");
        }

        // GET: Jiankangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Jiankang == null)
            {
                return NotFound();
            }

            var jiankang = await _context.Jiankang
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jiankang == null)
            {
                return NotFound();
            }

            return View(jiankang);
        }

        // GET: Jiankangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jiankangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Shousuoya,Shuzhangya,Xuetang,Xinlv,Xueyang,Age,Image,Createtime")] Jiankang jiankang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jiankang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jiankang);
        }

        // GET: Jiankangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Jiankang == null)
            {
                return NotFound();
            }

            var jiankang = await _context.Jiankang.FindAsync(id);
            if (jiankang == null)
            {
                return NotFound();
            }
            return View(jiankang);
        }

        // POST: Jiankangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Shousuoya,Shuzhangya,Xuetang,Xinlv,Xueyang,Age,Image,Createtime")] Jiankang jiankang)
        {
            if (id != jiankang.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jiankang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JiankangExists(jiankang.Id))
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
            return View(jiankang);
        }

        // GET: Jiankangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Jiankang == null)
            {
                return NotFound();
            }

            var jiankang = await _context.Jiankang
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jiankang == null)
            {
                return NotFound();
            }

            return View(jiankang);
        }

        // POST: Jiankangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Jiankang == null)
            {
                return Problem("Entity set 'HomeCareContext.Jiankang'  is null.");
            }
            var jiankang = await _context.Jiankang.FindAsync(id);
            if (jiankang != null)
            {
                _context.Jiankang.Remove(jiankang);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JiankangExists(int id)
        {
            return (_context.Jiankang?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
