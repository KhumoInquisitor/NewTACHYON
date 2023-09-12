using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Metadata.Ecma335;
using Tachyon.Areas.Identity.Data;
using Tachyon.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Tachyon.Controllers
{
	public class SpecialisedController : Controller
	{
		private readonly TachyonDbContext _context;
		public SpecialisedController(TachyonDbContext context)
		{
			_context = context;
		}
		// GET: SpecialisedController

		public ActionResult Index()
		{
			return View();
		}
        public ActionResult specialIndex()
        {
            return View();
        }

        // GET: SpecialisedController/Details/5
        public ActionResult Details(int id)
		{
			return View();
		}

		// GET: SpecialisedController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: SpecialisedController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: SpecialisedController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: SpecialisedController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: SpecialisedController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: SpecialisedController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}



		///Evaluations <summary>
        /// Evaluations
        /// 
        /// 
        /// 
        /// 
        /// </summary>
        /// <returns></returns>
        // GET: Evaluations
        public async Task<IActionResult> EvalIndex()
        {
            return _context.Evaluation != null ?
                        View(await _context.Evaluation.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.evaluation'  is null.");
        }

        // GET: Evaluations/Details/5
        public async Task<IActionResult> EvalDetails(int? id)
        {
            if (id == null || _context.Evaluation == null)
            {
                return NotFound();
            }

            var evaluation = await _context.Evaluation
                .FirstOrDefaultAsync(m => m.id == id);
            if (evaluation == null)
            {
                return NotFound();
            }

            return View(evaluation);
        }

        // GET: Evaluations/Create
        public IActionResult EvalCreate()
        {
            return View();
        }

        // POST: Evaluations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EvalCreate([Bind("Id,Name,dob,Age,Gender,Date,physician,vitals,medHistory,physicalTest,riskAssessment,notes,addInfo")]  PatientEvaluation evaluation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evaluation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(evaluation);
        }

        // GET: Evaluations/Edit/5
        public async Task<IActionResult> EvalEdit(int? id)
        {
            if (id == null || _context.Evaluation == null)
            {
                return NotFound();
            }

            var evaluation = await _context.Evaluation.FindAsync(id);
            if (evaluation == null)
            {
                return NotFound();
            }
            return View(evaluation);
        }

        // POST: Evaluations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EvalEdit(int id, [Bind("Id,Name,dob,Age,Gender,Date,physician,vitals,medHistory,physicalTest,riskAssessment,notes,addInfo")] PatientEvaluation evaluation)
        {
            if (id != evaluation.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evaluation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvalExists(evaluation.id))
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
            return View(evaluation);
        }

        // GET: Evaluations/Delete/5
        public async Task<IActionResult> EvalDelete(int? id)
        {
            if (id == null || _context.Evaluation == null)
            {
                return NotFound();
            }

            var evaluation = await _context.Evaluation
                .FirstOrDefaultAsync(m => m.id == id);
            if (evaluation == null)
            {
                return NotFound();
            }

            return View(evaluation);
        }

        // POST: Evaluations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EvalDeleteConfirmed(int id)
        {
            if (_context.Evaluation == null)
            {
                return Problem("Entity set 'ApplicationDbContext.evaluation'  is null.");
            }
            var evaluation = await _context.Evaluation.FindAsync(id);
            if (evaluation != null)
            {
                _context.Evaluation.Remove(evaluation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvalExists(int id)
        {
            return (_context.Evaluation?.Any(e => e.id == id)).GetValueOrDefault();
        }





		//LabTests





		// GET: LabTests
		public async Task<IActionResult> LabIndex()
		{
			return _context.Lab != null ?
						View(await _context.Lab.ToListAsync()) :
						Problem("Entity set 'ApplicationDbContext.labTests'  is null.");
		}

		// GET: LabTests/Details/5
		public async Task<IActionResult> LabDetails(int? id)
		{
			if (id == null || _context.Lab == null)
			{
				return NotFound();
			}

			var labTests = await _context.Lab
				.FirstOrDefaultAsync(m => m.id == id);
			if (labTests == null)
			{
				return NotFound();
			}

			return View(labTests);
		}

		// GET: LabTests/Create
		public IActionResult LabCreate()
		{
			return View();
		}

		// POST: LabTests/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CreateL([Bind("Id,Name,dob,Age,Gender,Date,physician,testName,results,interpretation,recommendations")] LabTest Lab)
		{
			if (ModelState.IsValid)
			{
				_context.Add(Lab);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(Lab);
		}

		// GET: LabTests/Edit/5
		public async Task<IActionResult> LabEdit(int? id)
		{
			if (id == null || _context.Lab == null)
			{
				return NotFound();
			}

			var labTests = await _context.Lab.FindAsync(id);
			if (labTests == null)
			{
				return NotFound();
			}
			return View(labTests);
		}

		// POST: LabTests/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> LabEdit(int id, [Bind("Id,Name,dob,Age,Gender,Date,physician,testName,results,interpretation,recommendations")] LabTest Lab)
		{
			if (id != Lab.id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(Lab);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!LabTestsExists(Lab.id))
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
			return View(Lab);
		}

		// GET: LabTests/Delete/5
		public async Task<IActionResult> LabDelete(int? id)
		{
			if (id == null || _context.Lab == null)
			{
				return NotFound();
			}

			var labTests = await _context.Lab
				.FirstOrDefaultAsync(m => m.id == id);
			if (labTests == null)
			{
				return NotFound();
			}

			return View(labTests);
		}

		// POST: LabTests/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> LabDeleteConfirmed(int id)
		{
			if (_context.Lab == null)
			{
				return Problem("Entity set 'ApplicationDbContext.labTests'  is null.");
			}
			var labTests = await _context.Lab.FindAsync(id);
			if (labTests != null)
			{
				_context.Lab.Remove(labTests);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool LabTestsExists(int id)
		{
			return (_context.Lab?.Any(e => e.id == id)).GetValueOrDefault();
		}




		///Procedures <summary>
		/// Procedures
		/// 
		/// 
		/// </summary>
		/// <returns></returns>
		public async Task<IActionResult> ProcedureIndex()
		{
			return _context.Procedure != null ?
						View(await _context.Procedure.ToListAsync()) :
						Problem("Entity set 'ApplicationDbContext.procedure'  is null.");
		}

		// GET: Procedures/Details/5
		public async Task<IActionResult> ProceduresDetails(int? id)
		{
			if (id == null || _context.Procedure == null)
			{
				return NotFound();
			}

			var procedure = await _context.Procedure
				.FirstOrDefaultAsync(m => m.id == id);
			if (procedure == null)
			{
				return NotFound();
			}

			return View(procedure);
		}

		// GET: Procedures/Create
		public IActionResult ProcedureCreate()
		{
			return View();
		}

		// POST: Procedures/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ProcedureCreate([Bind("Id,Name,dob,Age,Gender,phone,Date,StartTime,EndTime,Room,Anesthesia,anesthesiaType,physician,Anesthesiologist,Assistant,InstrumentOperator,description,complications,postProcedure,instructions,disposition,notes")] Procedure procedure)
		{
			if (ModelState.IsValid)
			{
				_context.Add(procedure);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(procedure);
		}

		// GET: Procedures/Edit/5
		public async Task<IActionResult> ProcedureEdit(int? id)
		{
			if (id == null || _context.Procedure == null)
			{
				return NotFound();
			}

			var procedure = await _context.Procedure.FindAsync(id);
			if (procedure == null)
			{
				return NotFound();
			}
			return View(procedure);
		}

		// POST: Procedures/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ProcedureEdit(int id, [Bind("Id,Name,dob,Age,Gender,phone,Date,StartTime,EndTime,Room,Anesthesia,anesthesiaType,physician,Anesthesiologist,Assistant,InstrumentOperator,description,complications,postProcedure,instructions,disposition,notes")] Procedure procedure)
		{
			if (id != procedure.id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(procedure);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!ProcedureExists(procedure.id))
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
			return View(procedure);
		}

		// GET: Procedures/Delete/5
		public async Task<IActionResult> ProcedureDelete(int? id)
		{
			if (id == null || _context.Procedure == null)
			{
				return NotFound();
			}

			var procedure = await _context.Procedure
				.FirstOrDefaultAsync(m => m.id == id);
			if (procedure == null)
			{
				return NotFound();
			}

			return View(procedure);
		}

		// POST: Procedures/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ProcedureDeleteConfirmed(int id)
		{
			if (_context.Procedure == null)
			{
				return Problem("Entity set 'ApplicationDbContext.procedure'  is null.");
			}
			var procedure = await _context.Procedure.FindAsync(id);
			if (procedure != null)
			{
				_context.Procedure.Remove(procedure);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool ProcedureExists(int id)
		{
			return (_context.Procedure?.Any(e => e.id == id)).GetValueOrDefault();
		}

		//public ActionResult Details(int Id)
		//{
		//	Procedure procedure = _context.Procedure.Find(Id);
		//	return View(procedure);
		//}

		public async Task<ActionResult> Details1Async(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			//Procedure procedure = _context.procedure.Find(id);
			//Procedure procedure = _context.procedure.FirstOrDefault(m => m.Id == id);
			Procedure procedure = await _context.Procedure.FirstOrDefaultAsync(m => m.id == id);
			//Movie movie = db.Movies.Find(id);
			if (procedure == null)
			{
				return NotFound();
			}
			return View(procedure);
		}



		///Progess <summary>
		/// Progess
		/// 
		/// 
		/// 
		/// </summary>
		/// <returns></returns>
		// GET: Progresses
		public async Task<IActionResult> ProgressIndex()
		{
			return _context.Progress != null ?
						View(await _context.Progress.ToListAsync()) :
						Problem("Entity set 'ApplicationDbContext.progress'  is null.");
		}

		// GET: Progresses/Details/5
		public async Task<IActionResult> ProgressDetails(int? id)
		{
			if (id == null || _context.Progress == null)
			{
				return NotFound();
			}

			var progress = await _context.Progress
				.FirstOrDefaultAsync(m => m.id == id);
			if (progress == null)
			{
				return NotFound();
			}

			return View(progress);
		}

		// GET: Progresses/Create
		public IActionResult ProgressCreate()
		{
			return View();
		}

		// POST: Progresses/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ProgressCreate([Bind("Id,Name,age,room,Day,Breakfast,Lunch,Dinner,Snacks,Color,Consistency,Amount,Weight,Saturation,FluidBalance,Intake,Output,Temperature,BloodPressure,HeartRate,Transfusion,AntibioticTreatment")] PatientProgress Progress)
		{
			if (ModelState.IsValid)
			{
				_context.Add(Progress);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(Progress);
		}

		// GET: Progresses/Edit/5
		public async Task<IActionResult> ProgressEdit(int? id)
		{
			if (id == null || _context.Progress == null)
			{
				return NotFound();
			}

			var progress = await _context.Progress.FindAsync(id);
			if (progress == null)
			{
				return NotFound();
			}
			return View(progress);
		}

		// POST: Progresses/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ProgressEdit(int id, [Bind("Id,Name,age,room,Day,Breakfast,Lunch,Dinner,Snacks,Color,Consistency,Amount,Weight,Saturation,FluidBalance,Intake,Output,Temperature,BloodPressure,HeartRate,Transfusion,AntibioticTreatment")] PatientProgress Progress)
		{
			if (id != Progress.id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(Progress);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!ProgressExists(Progress.id))
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
			return View(Progress);
		}

		// GET: Progresses/Delete/5
		public async Task<IActionResult> ProgressDelete(int? id)
		{
			if (id == null || _context.Progress == null)
			{
				return NotFound();
			}

			var progress = await _context.Progress
				.FirstOrDefaultAsync(m => m.id == id);
			if (progress == null)
			{
				return NotFound();
			}

			return View(progress);
		}

		// POST: Progresses/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ProgressDeleteConfirmedG(int id)
		{
			if (_context.Progress == null)
			{
				return Problem("Entity set 'ApplicationDbContext.progress'  is null.");
			}
			var progress = await _context.Progress.FindAsync(id);
			if (progress != null)
			{
				_context.Progress.Remove(progress);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool ProgressExists(int id)
		{
			return (_context.Progress?.Any(e => e.id == id)).GetValueOrDefault();
		}




		///Treatment <summary>
		/// Treatment
		/// 
		/// 
		/// 
		/// </summary>
		/// <returns></returns>
		// GET: Treatments
		public async Task<IActionResult> TreatmentIndex()
		{
			return _context.Treatment != null ?
						View(await _context.Treatment.ToListAsync()) :
						Problem("Entity set 'ApplicationDbContext.treatment'  is null.");
		}

		// GET: Treatments/Details/5
		public async Task<IActionResult> TreatmentDetails(int? id)
		{
			if (id == null || _context.Treatment == null)
			{
				return NotFound();
			}

			var treatment = await _context.Treatment
				.FirstOrDefaultAsync(m => m.id == id);
			if (treatment == null)
			{
				return NotFound();
			}

			return View(treatment);
		}

		// GET: Treatments/Create
		public IActionResult TreatmentCreate()
		{
			return View();
		}

		// POST: Treatments/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> TreatmentCreate([Bind("Id,Name,dob,Age,Gender,procedureName,patientInfo,procedure,postProcedure,recovery,complicationManagement,followup")] TreatmentPlan Treatment)
		{
			if (ModelState.IsValid)
			{
				_context.Add(Treatment);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(Treatment);
		}

		// GET: Treatments/Edit/5
		public async Task<IActionResult> TreatmentEdit(int? id)
		{
			if (id == null || _context.Treatment == null)
			{
				return NotFound();
			}

			var treatment = await _context.Treatment.FindAsync(id);
			if (treatment == null)
			{
				return NotFound();
			}
			return View(treatment);
		}

		// POST: Treatments/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> TreatmentEdit(int id, [Bind("Id,Name,dob,Age,Gender,procedureName,patientInfo,procedure,postProcedure,recovery,complicationManagement,followup")] TreatmentPlan Treatment)
		{
			if (id != Treatment.id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(Treatment);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!TreatmentExists(Treatment.id))
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
			return View(Treatment);
		}

		// GET: Treatments/Delete/5
		public async Task<IActionResult> TreatmentDelete(int? id)
		{
			if (id == null || _context.Treatment == null)
			{
				return NotFound();
			}

			var treatment = await _context.Treatment
				.FirstOrDefaultAsync(m => m.id == id);
			if (treatment == null)
			{
				return NotFound();
			}

			return View(treatment);
		}

		// POST: Treatments/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> TreatmentDeleteConfirmedT(int id)
		{
			if (_context.Treatment == null)
			{
				return Problem("Entity set 'ApplicationDbContext.treatment'  is null.");
			}
			var treatment = await _context.Treatment.FindAsync(id);
			if (treatment != null)
			{
				_context.Treatment.Remove(treatment);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool TreatmentExists(int id)
		{
			return (_context.Treatment?.Any(e => e.id == id)).GetValueOrDefault();
		}
	}
}
