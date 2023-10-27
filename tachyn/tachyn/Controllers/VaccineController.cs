using Microsoft.AspNetCore.Mvc;
using Tachyon.Areas.Identity.Data;
using Tachyon.Models;

namespace Tachyon.Controllers
{
    public class VaccineController : Controller
    {
        private TachyonDbContext _context;
        public VaccineController(TachyonDbContext dbContext)
        {
            _context = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
		public IActionResult Index2()
		{
			return View();
		}
		public IActionResult Select()
        {
            return View();
        }
        public IActionResult Screening()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Screening(string? Q1, string? Q2, string? Q3, string? Q4)
        {
            if (string.IsNullOrEmpty(Q1) || string.IsNullOrEmpty(Q2) || string.IsNullOrEmpty(Q3) || string.IsNullOrEmpty(Q4))
            {
                TempData["Result"] = "You missed a question or two. Please answer all questions.";
                return View();
            }
            TempData["Result"] = "You are cleared";
            TempData["ResultT"] = "Test Result";
            return View("Success");
        }
        public IActionResult Feedback()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Feedback(Feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return View(feedback);
            }
            TempData["Result"] = "Feedback has been captured.";
            TempData["ResultT"] = "Feedback";
            await _context.feedbacks.AddAsync(feedback);
            await _context.SaveChangesAsync();
            return View("Success");
        }
        public IActionResult Appointment()
        {
            return View();
        }
        public IActionResult AppointmentHistory()
        {
            var list = _context.appointments.Where(model => model.Status != "Delete").ToList();
            return View(list);
        }
        [HttpPost]
        public IActionResult UpdateAppointment(int? AppointmentID)
        {
            if (AppointmentID == 0 || AppointmentID == null)
            {
                return NotFound();
            }
            var appointment = _context.appointments.Find(AppointmentID);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
            //return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAppointment1(Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                return View(appointment);
            }
            _context.appointments.Update(appointment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(AppointmentHistory));
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAppointment(int? AppointmentID)
        {
            if (AppointmentID == 0 || AppointmentID == null)
            {
                return NotFound();
            }
            var appointment = _context.appointments.Find(AppointmentID);
            if (appointment == null)
            {
                return NotFound();
            }
            appointment.Status = "Delete";
            _context.appointments.Update(appointment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(AppointmentHistory));
            //return View();
        }
        [HttpPost]
        public IActionResult Appointment(Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                return View(appointment);
            }
            _context.appointments.Add(appointment);
            _context.SaveChanges();
            TempData["Result"] = "You are cleared";
            TempData["ResultT"] = "Test Result";
            return View("Success");
        }
    }
}
