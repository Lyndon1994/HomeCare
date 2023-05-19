using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HomeCare.Data;
using HomeCare.Models;

namespace HomeCare.Controllers
{
    public class ZhanghusController : Controller
    {
        private readonly HomeCareContext _context;

        public ZhanghusController(HomeCareContext context)
        {
            _context = context;
        }

        // GET: Zhanghus
        public async Task<IActionResult> Index()
        {
              return _context.Zhanghu != null ? 
                          View(await _context.Zhanghu.ToListAsync()) :
                          Problem("Entity set 'HomeCareContext.Zhanghu'  is null.");
        }

        // GET: Zhanghus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Zhanghu == null)
            {
                return NotFound();
            }

            var zhanghu = await _context.Zhanghu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zhanghu == null)
            {
                return NotFound();
            }

            return View(zhanghu);
        }

        // GET: Zhanghus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zhanghus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Userpassword,Phone,Type,Phone_zinv,Address,Image,Age,Zinv_name")] Zhanghu zhanghu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zhanghu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zhanghu);
        }

        // GET: Zhanghus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Zhanghu == null)
            {
                return NotFound();
            }

            var zhanghu = await _context.Zhanghu.FindAsync(id);
            if (zhanghu == null)
            {
                return NotFound();
            }
            return View(zhanghu);
        }

        // POST: Zhanghus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Userpassword,Phone,Type,Phone_zinv,Address,Image,Age,Zinv_name")] Zhanghu zhanghu)
        {
            if (id != zhanghu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zhanghu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZhanghuExists(zhanghu.Id))
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
            return View(zhanghu);
        }

        // GET: Zhanghus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Zhanghu == null)
            {
                return NotFound();
            }

            var zhanghu = await _context.Zhanghu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zhanghu == null)
            {
                return NotFound();
            }

            return View(zhanghu);
        }

        // POST: Zhanghus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Zhanghu == null)
            {
                return Problem("Entity set 'HomeCareContext.Zhanghu'  is null.");
            }
            var zhanghu = await _context.Zhanghu.FindAsync(id);
            if (zhanghu != null)
            {
                _context.Zhanghu.Remove(zhanghu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZhanghuExists(int id)
        {
          return (_context.Zhanghu?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
