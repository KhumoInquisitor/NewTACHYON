using Microsoft.AspNetCore.Mvc;
using Tachyon.Areas.Identity.Data;
using Tachyon.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Tachyon.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly TachyonDbContext _db;

        public FeedbackController(TachyonDbContext db)
        {
            _db = db;
        }

        // GET: List of all feedback entries
        public async Task<IActionResult> Index()
        {
            return View(await _db.ProcedureFeedbacks.ToListAsync());
        }

        // GET: Create new feedback entry form
        public IActionResult Create()
        {
            return View();
        }

        // POST: Submit new feedback entry form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProcedureFeedback feedback)
        {
            if (ModelState.IsValid)
            {
                _db.Add(feedback);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(feedback);
        }

        // GET: Display details of a specific feedback entry
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedback = await _db.ProcedureFeedbacks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feedback == null)
            {
                return NotFound();
            }

            return View(feedback);
        }

        // GET: Edit specific feedback entry form
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedback = await _db.ProcedureFeedbacks.FindAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }
            return View(feedback);
        }

        // POST: Submit edits for a specific feedback entry
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProcedureFeedback feedback)
        {
            if (id != feedback.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Update(feedback);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(feedback);
        }

        // GET: Confirm delete of a specific feedback entry
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedback = await _db.ProcedureFeedbacks
                .FirstOrDefaultAsync(m => m.Id == id) ;
            if (feedback == null)
            {
                return NotFound();
            }

            return View(feedback);
        }

        // POST: Delete a specific feedback entry
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var feedback = await _db.ProcedureFeedbacks.FindAsync(id);
            _db.ProcedureFeedbacks.Remove(feedback);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult ProcedureReport()
        {
            // Calculate average rating.
            double averageRating = _db.ProcedureFeedbacks.Average(p => p.Rating);

            // Calculate highest and lowest rating.
            double highestRating = _db.ProcedureFeedbacks.Max(p => p.Rating);
            double lowestRating = _db.ProcedureFeedbacks.Min(p => p.Rating);

            // More calculations here...

            // Store all your results in a ViewModel or a dynamic object.
            var model = new
            {
                AverageRating = averageRating,
                HighestRating = highestRating,
                LowestRating = lowestRating,
                // ... other data points
            };

            return View(model); // Pass the results to your view.
        }
    }
}
