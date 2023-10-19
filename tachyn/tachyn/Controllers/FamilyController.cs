using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Xml.Schema;
using Tachyon.Areas.Identity.Data;
using Tachyon.Models;

namespace Tachyon.Controllers
{
    [Authorize]
    public class FamilyController : Controller
    {


        private readonly TachyonDbContext _Context;
        private readonly IEmailSender _emailSender;
        public FamilyController(TachyonDbContext dBD, IEmailSender emailSender)
        {
            _Context = dBD;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async  Task< IActionResult> viewReport()
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.Date = DateTime.Now.ToString("dd/MMMM/yyyyy HH:mm");
            var applicationDBContext = _Context.familyAppointments.Include(f => f.User).ToList();
            return View( applicationDBContext);
        }
        public IActionResult Dash()
        {
            return View();
        }
        public IActionResult Admin()
        {
            return View();
        }
        public IActionResult List()
        {
            return View();
        }
        public IActionResult Doctor()
        {
            return View();
        }

        public IActionResult PreventationTypeList()
        {
            return View();
        }
        public IActionResult NurselistAppointments()
        {
           
                var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ViewBag.Date = DateTime.Now.ToString("dd/MMMM/yyyyy HH:mm");
                var applicationDBContext = _Context.familyAppointments.Include(f => f.User).ToList();
                return View(applicationDBContext);
           
        }
        public async Task<IActionResult> listAppointments()
        {
            var applicationDBContext = _Context.familyAppointments.Include(f => f.User);
            return View( applicationDBContext);
        }
        public IActionResult CreateAppointment()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAppointment(FamilyAppointment familyAppointment)
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            familyAppointment.PatientID = user;

            if (ModelState.IsValid)
            {
                _Context.familyAppointments.Add(familyAppointment);
                _Context.SaveChanges();
                return RedirectToAction("listAppointments");
            }
            return View(familyAppointment);
        }
        public IActionResult updateAppointment(int? ID)
        {
            if (ID == null || ID == 0)
            {
                return NotFound();
            }
            var list = _Context.familyAppointments.Find(ID);
            if (list == null)
            {
                return NotFound();
            }

            return View(list);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult updateAppointment(FamilyAppointment  familyAppointment)
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            familyAppointment.PatientID = user;
            _Context.familyAppointments.Update(familyAppointment);
            _Context.SaveChanges();
            return RedirectToAction("listAppointments");
        }

        public IActionResult DeleteAppointment(int? ID)
        {
            var list = _Context.familyAppointments.Find(ID);
            if (list == null)
            {
                return NotFound();
            }
            _Context.familyAppointments.Remove(list);
            _Context.SaveChanges();
            return RedirectToAction("listAppointments");

        }
        public IActionResult PrescriptionList()
        {
            IEnumerable<FamilyPrescription> list = _Context.familyPrescriptions;
            return View(list);
        }
        public IActionResult CreatePrescription()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePrescription(FamilyPrescription familyPrescription)
        {
            if (ModelState.IsValid)
            {
                _Context.familyPrescriptions.Add(familyPrescription);
                _Context.SaveChanges();
                return RedirectToAction("PrescriptionList");
            }
            return View(familyPrescription);
        }
        public IActionResult updatePrescription(int? ID)
        {
            if (ID == null || ID == 0)
            {
                return NotFound();
            }
            var list = _Context.familyPrescriptions.Find(ID);
            if (list == null)
            {
                return NotFound();
            }
            return View(list);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult updatePrescription(FamilyPrescription familyPrescription)
        {
            _Context.familyPrescriptions.Update(familyPrescription);
            _Context.SaveChanges();
            return RedirectToAction("PrescriptionList");
        }


        public async Task<IActionResult> FeedbackList()
        {
            var applicationDBContext = _Context.familyFeedBacks.Include(f => f.ttUser);
            return View(await applicationDBContext.ToListAsync());
        }
        public IActionResult CreateFeedBack()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateFeedBack(FamilyFeedBack familyFeedBack)
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            familyFeedBack.PatientID = user;

            if (ModelState.IsValid)
            {
                _Context.familyFeedBacks.Add(familyFeedBack);
                _Context.SaveChanges();
                return RedirectToAction("FeedbackList");
            }
            return View(familyFeedBack);
        }
        public IActionResult updateFeedBack(int? ID)
        {
            if (ID == null || ID == 0)
            {
                return NotFound();
            }
            var list = _Context.familyFeedBacks.Find(ID);
            if (list == null)
            {
                return NotFound();
            }
            return View(list);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult updateFeedBack(FamilyFeedBack familyFeedBack)
        {
            _Context.familyFeedBacks.Update(familyFeedBack);
            _Context.SaveChanges();
            return RedirectToAction("FeedbackList");
        }

        public IActionResult DeleteFeedBack(int? ID)
        {
            var list = _Context.familyFeedBacks.Find(ID);
            if (list == null)
            {
                return NotFound();
            }
            _Context.familyFeedBacks.Remove(list);
            _Context.SaveChanges();
            return RedirectToAction("FeedbackList");

        }
        public IActionResult ReferralsList()
        {
            IEnumerable<FamilyReferrals> list = _Context.familyReferrals;
            return View(list);
        }
        public IActionResult CreateFamilyReferrals()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateFamilyReferrals(FamilyReferrals familyReferrals)
        {
            if (ModelState.IsValid)
            {
                _Context.familyReferrals.Add(familyReferrals);
                _Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(familyReferrals);
        }
        public IActionResult TrackMenstruactioList()
        {
            IEnumerable<TrackMenstruation> list = _Context.trackMenstruations;
            return View(list);
        }
        public IActionResult CreateTrackMenstruation()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTrackMenstruation(TrackMenstruation trackMenstruation)
        {
            if (ModelState.IsValid)
            {
                _Context.trackMenstruations.Add(trackMenstruation);
                _Context.SaveChanges();
                return RedirectToAction("TrackMenstruactioList");
            }
            return View(trackMenstruation);
        }
        public IActionResult CreateScreening()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> CreateScreening(Screening screening)
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            screening.PatientID = user;
            int totalReg = 0;
            if (ModelState.IsValid)
            {
                totalReg += Convert.ToInt32(screening.intercourse);
                totalReg += Convert.ToInt32(screening.period);
                totalReg += Convert.ToInt32(screening.child);
                totalReg += Convert.ToInt32(screening.experience);
                totalReg += Convert.ToInt32(screening.allergies);
                totalReg += Convert.ToInt32(screening.medication);
                totalReg += Convert.ToInt32(screening.contraceptives);
                totalReg += Convert.ToInt32(screening.condom);
                totalReg += Convert.ToInt32(screening.normal);
                //if (totalReg <= 30)
                //{
                //    TempData["Result"] = "Pills will be ";
                //    TempData["_Image"] = "1";
                //}
                //else if (totalReg <= 40)
                //{
                //    TempData["Result"] = "1 month";
                //    TempData["_Image"] = "2";
                //}
                //else if (totalReg <= 50)
                //{
                //    TempData["Result"] = "3 months";
                //    TempData["_Image"] = "3";
                //}
                //else if (totalReg <= 60)
                //{
                //    TempData["Result"] = "1 implant";
                //    TempData["_Image"] = "4";
                //}
                //else if (totalReg <= 70)
                //{
                //    TempData["Result"] = "3 loop";
                //    TempData["_Image"] = "5";
                //}
                //else if (totalReg >= 80)
                //{
                //    TempData["Result"] = "Viginal Ring";
                //    TempData["_Image"] = "6";
                //}
                ////familyReg .Total = totalReg;

                _Context.Screenings.Add(screening);
                _Context.SaveChanges();
                return RedirectToAction("ScreeningList");

            }
            ViewData["PatientID"] = new SelectList(_Context.Users, "Id", "Id", screening.PatientID);
            return View(screening);
        }
        public async Task<IActionResult> ScreeningList()
        {
            var ApplicationDbContext = _Context.Screenings.Include(f => f.MainUser);
            return View(await ApplicationDbContext.ToListAsync());
            //IEnumerable<FamilyReg> list = dbContext.FamilyReg;
            //return View(list);
        }
    }

         
}

