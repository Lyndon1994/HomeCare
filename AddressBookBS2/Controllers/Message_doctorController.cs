using HomeCare.Data;
using HomeCare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeCare.Controllers
{
    public class Message_doctorController : Controller
    {
        private readonly HomeCareContext _context;

        public Message_doctorController(HomeCareContext context)
        {
            _context = context;
        }

        // GET: Message_doctor
        public async Task<IActionResult> Index()
        {
            return _context.Message_doctor != null ?
                        View(await _context.Message_doctor.ToListAsync()) :
                        Problem("Entity set 'HomeCareContext.Message_doctor'  is null.");
        }

        // GET: Message_doctor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Message_doctor == null)
            {
                return NotFound();
            }

            var message_doctor = await _context.Message_doctor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (message_doctor == null)
            {
                return NotFound();
            }

            return View(message_doctor);
        }

        // GET: Message_doctor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Message_doctor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Zh_name,Context,Age,Image,Createtime,Oldman")] Message_doctor message_doctor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(message_doctor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(message_doctor);
        }

        // GET: Message_doctor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Message_doctor == null)
            {
                return NotFound();
            }

            var message_doctor = await _context.Message_doctor.FindAsync(id);
            if (message_doctor == null)
            {
                return NotFound();
            }
            return View(message_doctor);
        }

        // POST: Message_doctor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Zh_name,Context,Age,Image,Createtime,Oldman")] Message_doctor message_doctor)
        {
            if (id != message_doctor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(message_doctor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Message_doctorExists(message_doctor.Id))
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
            return View(message_doctor);
        }

        // GET: Message_doctor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Message_doctor == null)
            {
                return NotFound();
            }

            var message_doctor = await _context.Message_doctor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (message_doctor == null)
            {
                return NotFound();
            }

            return View(message_doctor);
        }

        // POST: Message_doctor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Message_doctor == null)
            {
                return Problem("Entity set 'HomeCareContext.Message_doctor'  is null.");
            }
            var message_doctor = await _context.Message_doctor.FindAsync(id);
            if (message_doctor != null)
            {
                _context.Message_doctor.Remove(message_doctor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Message_doctorExists(int id)
        {
            return (_context.Message_doctor?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
