using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tachyon.Areas.Identity.Data;
using Tachyon.Models;

namespace Tachyon.Controllers
{
    public class walkinController : Controller
    {
        private readonly TachyonDbContext _context;
        public static int Result = 0;

        public walkinController(TachyonDbContext context)
        {
            _context = context;
        }

        // GET: walkin
        public IActionResult Index()
        {
            return View();

            //return _context.Booking != null ?
            //            View() :
            //            Problem("Entity set 'TachyonDbContext.Booking'  is null.");
        }
        public IActionResult ManageFiles()
        {
            return View();
        }
        public IActionResult FileList()
        {

            IEnumerable<ManageFile> list = _context.manageFiles;
            return View(list);
        }
        public IActionResult Doctors()
        {
            return View();
        }
        public IActionResult Booking()
        {
            var Boking = new Booking();
            return View(Boking);
        }
        [HttpPost]
        //public IActionResult InsertBooking(Booking booking) 
        //{ 
        //  if (ModelState.IsValid) 
        //    {
        //     _Booking.booking.Add(booking);
        //     _Booking.SaveChanges();
        //        return RedirectToAction("Details");
        //    }
        //}
        public IActionResult Prescription()
        {
            return View();
        }
        public IActionResult Screening()
        {
            return View();
        }
        public IActionResult Ticking(walkincheckboxes check)
        {
            Result = 0;
            bool breath = false;
            bool cough = false;
            bool smell = false;
            bool covid = false;
            bool head = false;

            for (int i = 0; i < 6; i++)
            {
                cough = check.cough;
                smell = check.smell;
                breath = check.breath;
                covid = check.covid;
                head = check.head;
            }
            if (cough == true)
            {
                Result += 1;
            }
            if (breath == true)
            {
                Result += 1;
            }
            if (smell == true)
            {
                Result += 1;
            }
            if (head == true)
            {
                Result += 1;
            }
            if (covid == true)
            {
                Result += 1;
            }

            return RedirectToAction("Screening2");
        }
        public IActionResult Screening2(walkincheckboxes check)
        {
            if (Result < 3)
            {
                check.message = "Low Risk";
            }
            else if (Result > 2)
            {
                check.message = "High Risk";
            }

            return View(check);

        }



        // GET: walkin/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || _context.Booking == null)
            {
                return NotFound();
            }

            var booking = _context.Booking;

            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: walkin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: walkin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("id,name,lastname,email,datetimevalue,Department")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                _context.SaveChangesAsync();
                return RedirectToAction("View Appointment");
            }
            return View(booking);
        }
        public IActionResult ViewAppointment()
        {
            IEnumerable<Booking> booking = _context.Booking;
            return View(booking);
        }

        // GET: walkin/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || _context.Booking == null)
            {
                return NotFound();
            }

            var booking = _context.Booking.Find(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }


        // POST: walkin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, [Bind("id,name,lastname,email,datetimevalue,subsystem")] Booking booking)
        {
            if (id != booking.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("ViewAppointment");
            }
            return View(booking);
        }

        // GET: walkin/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || _context.Booking == null)
            {
                return NotFound();
            }

            var booking = _context.Booking
                .FirstOrDefaultAsync(m => m.id == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: walkin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_context.Booking == null)
            {
                return Problem("Entity set 'TachyonDbContext.Booking'  is null.");
            }
            var booking = _context.Booking.Find(id);
            if (booking != null)
            {
                _context.Booking.Remove(booking);
            }

            _context.SaveChangesAsync();
            return RedirectToAction("ViewAppointment");
        }

        private bool BookingExists(int id)
        {
            return (_context.Booking?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}

