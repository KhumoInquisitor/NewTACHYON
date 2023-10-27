using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tachyon.Areas.Identity.Data;
using Tachyon.Models;
using System.Linq;
using System.Threading.Tasks;


namespace Tachyon.Controllers
{
	public class ProcedureController : Controller
	{
		private readonly TachyonDbContext _db;
		private readonly UserManager<TachyonUser> _userManager;
		public ProcedureController(TachyonDbContext db, UserManager<TachyonUser> userManager)
		{
			_db = db;
			_userManager = userManager;
		}
		public IActionResult Index()
		{
			return View();
		}
        public IActionResult before()
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
        public IActionResult electro()
        {
            return View();
        }
        public IActionResult MinorSurgery()
		{
			return View();
		}
        public IActionResult Screenings()
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
		public IActionResult CreateReferral()
		{
			return View();
		}
		public IActionResult ReferralList()
		{
			IEnumerable<Referral> ReferralList = _db.Referral;
			return View(ReferralList);
		}
		
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult CreateReferral(Referral Referral)
		{
			if (ModelState.IsValid)
			{
				_db.Referral.Add(Referral);
				_db.SaveChanges();
				return RedirectToAction("ReferralList");
			}
			return View(Referral);
		}
		public IActionResult updateReferral(int? ID)
		{
			if (ID == null || ID == 0)
			{
				return NotFound();
			}
			var ReferralList = _db.Referral.Find(ID);
			if (ReferralList == null)
			{
				return NotFound();
			}
			return View(ReferralList);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult updateReferral(Referral Referral)
		{
			_db.Referral.Update(Referral);
			_db.SaveChanges();
			return RedirectToAction("ReferralList");
		}

		public IActionResult DeleteReferral(int? ID)
		{
			var ReferralList = _db.Referral.Find(ID);
			if (ReferralList == null)
			{
				return NotFound();
			}
			_db.Referral.Remove(ReferralList);
			_db.SaveChanges();
			return RedirectToAction("ReferralList");
		}

	}
}
