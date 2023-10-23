using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Metadata.Ecma335;
using Tachyon.Areas.Identity.Data;
using Tachyon.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Tachyon.Controllers
{
    public class ChronicController : Controller
    {
		private readonly TachyonDbContext _context;//this line is from the dbset

		public ChronicController(TachyonDbContext Dbcontext)// Constructor .allows you to have access to the DBset
		{
			_context = Dbcontext;
		}

        public IActionResult MedicationIndex()
        {

            IEnumerable<MedicationRecords> records =_context.medicationRecords;
            return View(records);
        }
        [HttpPost]
        public IActionResult MedRecords(MedicationRecords medicationRecords)
        {
            if (ModelState.IsValid)
            {
                _context.medicationRecords.Add(medicationRecords);
                _context.SaveChanges();
                return RedirectToAction("MedicationIndex");

            }
            return View(medicationRecords);
        }


        public IActionResult FillingIndex()
        {

            IEnumerable<FillingPrescription>prescriptions=_context.fillingPrescriptions;
            return View(prescriptions);
        }

        [HttpPost]
        public IActionResult Fillmed(FillingPrescription fillingPrescription)
        {
            if (ModelState.IsValid)
            {
                _context.fillingPrescriptions.Add(fillingPrescription);
                _context.SaveChanges();
                return RedirectToAction("FillingIndex");

            }
            return View(fillingPrescription);
        }

        public IActionResult CollectionIndex()
        {

            IEnumerable<Collection> collections = _context.collection;
            return View(collections);
        }

     
        public IActionResult CollectMed(Collection collection)
		{
            if (ModelState.IsValid)
            {
                _context.collection.Add(collection);
                _context.SaveChanges();
                return RedirectToAction("CollectionIndex");

            }
            return View(collection);
        }
		//[HttpPost]
		//[ValidateAntiForgeryToken]
  //      public IActionResult Create()
  //      {
  //          return View();
  //      }



        public IActionResult Chronic_Dashboard()
        {
            return View();
        }
		public async Task<IActionResult> MedicationReport(dynamic Alerts)
		{
			var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
			ViewBag.Date = DateTime.Now.ToString("dd/MMMM/yyyyy");
			ViewBag.Time = DateTime.Now.ToString(" HH:mm");



			//if (Alerts.Count() > 0)
			//{
			//	ViewBag.Alerts = Alerts;
			//	TempData["Alerts"] = "Not null";

			//}
			ViewBag.Booking = await _context.collection.ToListAsync();
			return View();
		}









	}
}
