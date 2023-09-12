using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tachyon.Areas.Identity.Data;
using Tachyon.Models;

namespace Tachyon.Controllers
{
    public class ManageFileController : Controller
    {
        private readonly TachyonDbContext _Context;

        public ManageFileController(TachyonDbContext dBD)
        {
            _Context = dBD;
        }
        public IActionResult FileList()
        {

            IEnumerable<ManageFile> list = _Context.manageFiles;
            return View(list);
        }
        public IActionResult ManageFile()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ManageFile(ManageFile manageFile)
        {
            if (ModelState.IsValid)
            {
                _Context.manageFiles.Add(manageFile);
                _Context.SaveChanges();
                return RedirectToAction("FileList");
            }
            return View(manageFile);
        }
    }
}
