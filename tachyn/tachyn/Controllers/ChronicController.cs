using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Metadata.Ecma335;
using Tachyon.Areas.Identity.Data;
using Tachyon.Models;

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
        public IActionResult FillingIndex()
        {

            IEnumerable<FillingPrescription>prescriptions=_context.fillingPrescriptions;
            return View(prescriptions);
        }
        public IActionResult CollectionIndex()
        {

            IEnumerable<Collection> collections = _context.collection;
            return View(collections);
        }

        //public IActionResult CreateCollection()
        //{
        //    return View();
        //}
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
		[HttpPost]//you are able to post the data
		[ValidateAntiForgeryToken]
        public IActionResult Create()
        {
            return View();
        }
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
       
        public IActionResult MediUpdate(int? ID)//the ID on this will look for that certain ID to update
		{
			if (ID == null || ID == 0)
			{
				return NotFound();
			}
			var Med = _context.medicationRecords.Find(ID);// will look for the ID

			if (Med == null)
			{
				return NotFound();
			}

			return View(Med);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]

        //public IActionResult UpdateMed()
        //{
        //    return View();
        //}
        public IActionResult MediUpdate(MedicationRecords records) //Post updated data to the table
		{
			_context.medicationRecords.Update(records);
			_context.SaveChanges();
			return RedirectToAction("MedicationIndex");
		}
		public IActionResult Fillupdate(int? ID)//the ID on this will look for that certain ID to update
		{
			if (ID == null || ID == 0)
			{
				return NotFound();
			}
			var filling = _context.fillingPrescriptions.Find(ID);// will look for the ID

			if (filling == null)
			{
				return NotFound();
			}

			return View(filling);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]

		//public IActionResult Fillupdate()
		//{
		//	return View();
		//}
		public IActionResult Fillupdate(FillingPrescription prescription) //Post updated data to the table
		{
			_context.fillingPrescriptions.Update(prescription);
			_context.SaveChanges();
			return RedirectToAction("FillingIndex");
		}

		//public IActionResult Delete(int? ID)
		//{

		//	var fighter = context.Fighters.Find(ID);

		//	if (fighter == null)
		//	{
		//		return NotFound();
		//	}
		//	context.Fighters.Remove(fighter);
		//	context.SaveChanges();
		//	return RedirectToAction("Index");

		//}

		//}

		public IActionResult Chronic_Dashboard()
        {
            return View();
        }
    }
}
