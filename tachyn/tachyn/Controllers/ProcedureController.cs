using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tachyon.Areas.Identity.Data;
using Tachyon.Models;

namespace Tachyon.Controllers
{
	public class ProcedureController : Controller
	{
		private readonly TachyonDbContext _db;
		public ProcedureController(TachyonDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Land()
		{
			return View();
		}
		public IActionResult JointInjection()
		{
			return View();
		}
		public IActionResult Lung()
		{
			return View();
		}
		public IActionResult MinorSurgery()
		{
			return View();
		}

		public IActionResult ProcedureList()
		{
			IEnumerable<Procedure> proList = _db.Procedure;
			return View(proList);
		}
		public IActionResult CreateProcedure()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult CreateProcedure(Procedure Procedure)
		{
			if (ModelState.IsValid)
			{
                _db.Procedure.Add(Procedure);
                _db.SaveChanges();
				return RedirectToAction("ProcedureList");
			}
			return View(Procedure);
		}
		public IActionResult updateProcedure(int? ID)
		{
			if (ID == null || ID == 0)
			{
				return NotFound();
			}
			var proList = _db.Procedure.Find(ID);
			if (proList == null)
			{
				return NotFound();
			}
			return View(proList);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult updateProcedure(Procedure Procedure)
		{
            _db.Procedure.Update(Procedure);
            _db.SaveChanges();
			return RedirectToAction("ProcedureList");
		}

		public IActionResult DeleteProcedure(int? ID)
		{
			var proList = _db.Procedure.Find(ID);
			if (proList == null)
			{
				return NotFound();
			}
            _db.Procedure.Remove(proList);
            _db.SaveChanges();
			return RedirectToAction("ProcedureList");

		}
	}
}
