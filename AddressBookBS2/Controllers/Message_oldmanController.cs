using HomeCare.Data;
using HomeCare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeCare.Controllers
{
    public class Message_oldmanController : Controller
    {
        private readonly HomeCareContext _context;

        public Message_oldmanController(HomeCareContext context)
        {
            _context = context;
        }

        // GET: Message_oldman
        public async Task<IActionResult> Index()
        {
            return _context.Message_oldman != null ?
                        View(await _context.Message_oldman.ToListAsync()) :
                        Problem("Entity set 'HomeCareContext.Message_oldman'  is null.");
        }

        // GET: Message_oldman/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Message_oldman == null)
            {
                return NotFound();
            }

            var message_oldman = await _context.Message_oldman
                .FirstOrDefaultAsync(m => m.Id == id);
            if (message_oldman == null)
            {
                return NotFound();
            }

            return View(message_oldman);
        }

        // GET: Message_oldman/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Message_oldman/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Zh_name,Context,Age,Image,Createtime")] Message_oldman message_oldman)
        {
            if (ModelState.IsValid)
            {
                _context.Add(message_oldman);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(message_oldman);
        }

        // GET: Message_oldman/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Message_oldman == null)
            {
                return NotFound();
            }

            var message_oldman = await _context.Message_oldman.FindAsync(id);
            if (message_oldman == null)
            {
                return NotFound();
            }
            return View(message_oldman);
        }

        // POST: Message_oldman/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Zh_name,Context,Age,Image,Createtime")] Message_oldman message_oldman)
        {
            if (id != message_oldman.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(message_oldman);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Message_oldmanExists(message_oldman.Id))
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
            return View(message_oldman);
        }

        // GET: Message_oldman/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Message_oldman == null)
            {
                return NotFound();
            }

            var message_oldman = await _context.Message_oldman
                .FirstOrDefaultAsync(m => m.Id == id);
            if (message_oldman == null)
            {
                return NotFound();
            }

            return View(message_oldman);
        }

        // POST: Message_oldman/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Message_oldman == null)
            {
                return Problem("Entity set 'HomeCareContext.Message_oldman'  is null.");
            }
            var message_oldman = await _context.Message_oldman.FindAsync(id);
            if (message_oldman != null)
            {
                _context.Message_oldman.Remove(message_oldman);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Message_oldmanExists(int id)
        {
            return (_context.Message_oldman?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
