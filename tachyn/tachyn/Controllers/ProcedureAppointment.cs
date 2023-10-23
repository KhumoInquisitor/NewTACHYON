using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tachyon.Areas.Identity.Data;
using Tachyon.Models;

namespace Tachyon.Controllers
{
    public class ProcedureAppointment : Controller
    {
        private readonly TachyonDbContext _db;
        private readonly UserManager<TachyonUser> _userManager;
        public ProcedureAppointment(TachyonDbContext context, UserManager<TachyonUser> userManager)
        {
            _db = context;
            _userManager = userManager;
        }

        // GET: Appointments
        public IActionResult Index()
        {
            return View(_db.AppView.ToList());
        }

        // GET: Appointments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Appointments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AppointmentViewModel AppView)
        {
            if (ModelState.IsValid)
            {
                _db.Add(AppView);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(AppView);
        }

        // GET: Appointments/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var AppView = _db.AppView.Find(id);
            if (AppView == null)
            {
                return NotFound();
            }
            return View(AppView);
        }

        // POST: Appointments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, AppointmentViewModel AppView)
        {
            if (id != AppView.Id)  // Assuming you have an Id field on your appointment model
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(AppView);
                    _db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_db.AppView.Any(e => e.Id == id))
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
            return View(AppView);
        }

        // GET: Appointments/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = _db.AppView
                .FirstOrDefault(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var appointment = _db.AppView.Find(id);
            _db.AppView.Remove(appointment);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

// GET: Appointments
//public async Task<IActionResult> AppIndex()
//{
//    var appointments = await _db.appointments.ToListAsync();
//    return View(appointments);
//}
//// GET: Create Appointment
//public IActionResult CreateAppointment()
//{
//    return View();
//}

//// POST: Create Appointment
//[HttpPost]
//[ValidateAntiForgeryToken]
//public IActionResult CreateAppointment(AppointmentViewModel viewModel)
//{
//    if (ModelState.IsValid)
//    {
//        var appointment = new Appointment
//        {
//            Name = viewModel.Name,
//            Surname = viewModel.Surname,
//            Date = viewModel.Date,
//            PhoneNumber = viewModel.PhoneNumber,
//            Email = viewModel.Email,
//            Status = viewModel.Status,
//            IDNumber = viewModel.IDNumber
//        };

//        _db.appointments.Add(appointment);
//        _db.SaveChanges();

//        return RedirectToAction("AppIndex");
//    }

//    return View(viewModel);
//}

//public ActionResult ShowAppointment(int id)
//{
//    var appointment = _db.appointments.Find(id);

//    var viewModel = new AppointmentViewModel
//    {
//        AppointmentId = appointment.AppointmentId,
//        Name = appointment.Name + " " + appointment.Surname,
//        Date = appointment.Date,
//        PhoneNumber = appointment.PhoneNumber,
//        Email = appointment.Email,
//        Status = appointment.Status,
//        IDNumber = appointment.IDNumber
//    };

//    return View(viewModel);
//}
//// GET: Edit Appointment
//public IActionResult EditAppointment(int id)
//{
//    var appointment = _db.appointments.Find(id);

//    if (appointment == null)
//    {
//        return NotFound();
//    }

//    var viewModel = new AppointmentViewModel
//    {
//        AppointmentId = appointment.AppointmentId,
//        Name = appointment.Name + " " + appointment.Surname,
//        Date = appointment.Date,
//        PhoneNumber = appointment.PhoneNumber,
//        Email = appointment.Email,
//        Status = appointment.Status,
//        IDNumber = appointment.IDNumber
//    };

//    return View(viewModel);
//}

//// POST: Edit Appointment
//[HttpPost]
//[ValidateAntiForgeryToken]
//public IActionResult EditAppointment(AppointmentViewModel viewModel)
//{
//    if (ModelState.IsValid)
//    {
//        var appointment = _db.appointments.Find(viewModel.AppointmentId);

//        if (appointment == null)
//        {
//            return NotFound();
//        }

//        appointment.Name = viewModel.Name;
//        appointment.Surname = viewModel.Surname;
//        appointment.Date = viewModel.Date;
//        appointment.PhoneNumber = viewModel.PhoneNumber;
//        appointment.Email = viewModel.Email;
//        appointment.Status = viewModel.Status;
//        appointment.IDNumber = viewModel.IDNumber;

//        _db.appointments.Update(appointment);
//        _db.SaveChanges();

//        return RedirectToAction("AppIndex");
//    }

//    return View(viewModel);
//}
//// GET: Delete Appointment Confirmation
//public IActionResult DeleteAppointment(int? id)
//{
//    if (id == null)
//    {
//        return NotFound();
//    }

//    var appointment = _db.appointments.Find(id);
//    if (appointment == null)
//    {
//        return NotFound();
//    }

//    var viewModel = new AppointmentViewModel
//    {
//        AppointmentId = appointment.AppointmentId,
//        Name = appointment.Name + " " + appointment.Surname,
//        Date = appointment.Date,
//        PhoneNumber = appointment.PhoneNumber,
//        Email = appointment.Email,
//        Status = appointment.Status,
//        IDNumber = appointment.IDNumber
//    };

//    return View(viewModel);
//}

//// POST: Delete Appointment
//[HttpPost, ActionName("DeleteAppointment")]
//[ValidateAntiForgeryToken]
//public IActionResult DeleteConfirmed(int id)
//{
//    var appointment = _db.appointments.Find(id);
//    if (appointment == null)
//    {
//        return NotFound();
//    }
//    _db.appointments.Remove(appointment);
//    _db.SaveChanges();

//    return RedirectToAction("AppIndex");
//}