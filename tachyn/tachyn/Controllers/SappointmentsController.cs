using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tachyon.Areas.Identity.Data;
using Tachyon.Models;

namespace Tachyon.Controllers
{
    public class SappointmentsController : Controller
    {
        private readonly TachyonDbContext _context;

        public SappointmentsController(TachyonDbContext context)
        {
            _context = context;
        }

        // GET: Sappointments
        public async Task<IActionResult> Index()
        {
              return _context.Sappointments != null ? 
                          View(await _context.Sappointments.ToListAsync()) :
                          Problem("Entity set 'TachyonDbContext.Sappointments'  is null.");
        }

        // GET: Sappointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sappointments == null)
            {
                return NotFound();
            }

            var sappointments = await _context.Sappointments
                .FirstOrDefaultAsync(m => m.appointmentId == id);
            if (sappointments == null)
            {
                return NotFound();
            }

            return View(sappointments);
        }

        // GET: Sappointments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sappointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("appointmentId,Date,patientID,title,name,lastname,phone")] Sappointments sappointments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sappointments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sappointments);
        }

        // GET: Sappointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sappointments == null)
            {
                return NotFound();
            }

            var sappointments = await _context.Sappointments.FindAsync(id);
            if (sappointments == null)
            {
                return NotFound();
            }
            return View(sappointments);
        }

        // POST: Sappointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("appointmentId,Date,patientID,title,name,lastname,phone")] Sappointments sappointments)
        {
            if (id != sappointments.appointmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sappointments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SappointmentsExists(sappointments.appointmentId))
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
            return View(sappointments);
        }

        // GET: Sappointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sappointments == null)
            {
                return NotFound();
            }

            var sappointments = await _context.Sappointments
                .FirstOrDefaultAsync(m => m.appointmentId == id);
            if (sappointments == null)
            {
                return NotFound();
            }

            return View(sappointments);
        }

        // POST: Sappointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sappointments == null)
            {
                return Problem("Entity set 'TachyonDbContext.Sappointments'  is null.");
            }
            var sappointments = await _context.Sappointments.FindAsync(id);
            if (sappointments != null)
            {
                _context.Sappointments.Remove(sappointments);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SappointmentsExists(int id)
        {
          return (_context.Sappointments?.Any(e => e.appointmentId == id)).GetValueOrDefault();
        }
    }
}
