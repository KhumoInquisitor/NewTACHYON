using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
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
        public FamilyController(TachyonDbContext dBD)
        {
            _Context = dBD;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult viewReport()
        {
            return View();
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
            IEnumerable<FamilyAppointment> list = _Context.familyAppointments;
            return View(list);
        }
        public IActionResult listAppointments()
        {
			var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
			IEnumerable<FamilyAppointment> list = _Context.familyAppointments.Where(a => a.PatientID == user);
            return View(list);
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

        public IActionResult updateAppointment(FamilyAppointment familyAppointment)
        {
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


        public IActionResult FeedbackList()
        {
            IEnumerable<FamilyFeedBack> list = _Context.familyFeedBacks;
            return View(list);
        }
        public IActionResult CreateFeedBack()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateFeedBack(FamilyFeedBack familyFeedback)
        {
            if (ModelState.IsValid)
            {
                _Context.familyFeedBacks.Add(familyFeedback);
                _Context.SaveChanges();
                return RedirectToAction("FeedbackList");
            }
            return View(familyFeedback);
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
                return RedirectToAction("Index");
            }
            return View(trackMenstruation);
        }
        public IActionResult ScreeningList()
        {
            IEnumerable<FamilyScrenning> list = _Context.familyScrenning;
            return View(list);
        }
        //public async Task <IActionResult> Sreening()
        //{
        //    var applicationDBContext = _Context.familyScrenning.Include(f >= f.mainUser);
        //    return View (awail)
        //}
        public IActionResult CreateScreening()
        {
            return View();
        }
        //     [HttpPost]
        //     [ValidateAntiForgeryToken]
        //     public async IActionResult CreateScreening(FamilyScrenning familyScrenning)
        //     {
        //var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //         familyScrenning.PatientID = user;
        //if (ModelState.IsValid)
        //         {
        //             _Context.familyScrenning.Add(familyScrenning);
        //             _Context.SaveChanges();
        //             return RedirectToAction("ScreeningList");
        //         }
        //         return View(familyScrenning);



        //     }

        [HttpPost]
        [ValidateAntiForgeryToken]
         public async Task<IActionResult> CreateScreening([Bind("screnningID,date,PatientID,status,Drink,Period,active,Child,intercourse," +
            "allergies,medication,contraceptive")] FamilyScrenning familyScrenning)
         {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            familyScrenning.PatientID = user;
            int total = 0;
            if (ModelState.IsValid)
            {
                total += Convert.ToInt32(familyScrenning.Drink);
                total += Convert.ToInt32(familyScrenning.Period);
                total += Convert.ToInt32(familyScrenning.active);
                total += Convert.ToInt32(familyScrenning.Child);
                total += Convert.ToInt32(familyScrenning.intercourse);
                total += Convert.ToInt32(familyScrenning.allergies);
                total += Convert.ToInt32(familyScrenning.medication);
                total += Convert.ToInt32(familyScrenning.contraceptive);
                if (total < 30)
                {
                    TempData["Result"] = "Injection will be a perfect choice for you";
                }
                else if(total >=30 && total <61)
                {
                    TempData["Result"] = "pill will be a perfect choice for you";
                }
                else if (total >61)
                {
                    TempData["Result"] = "implant will be a perfect choice for you";
                }
                _Context.familyScrenning.Add(familyScrenning);
                _Context.SaveChanges();
                return RedirectToAction("ScreeningList");
            }
            ViewData["PatientID"] = new SelectList(_Context.Users, "Id", "Id", familyScrenning.PatientID);
            return View(familyScrenning);


         }
    }
}
