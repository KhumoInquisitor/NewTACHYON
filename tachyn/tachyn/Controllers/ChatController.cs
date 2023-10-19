using Microsoft.AspNetCore.Mvc;
using Tachyon.Areas.Identity.Data;
using Tachyon.Models;

namespace Tachyon.Controllers
{
	public class ChatController : Controller
	{
        private readonly TachyonDbContext _db;
        public ChatController(TachyonDbContext db)
        {
            _db = db;
        }
        // This could use a database or in-memory list for demo purposes
        private static List<Message> _messages = new List<Message>();

		[HttpPost]
		public ActionResult SendMessage(string text)
		{
			// Add the message to the database or in-memory list
			_messages.Add(new Message
			{
				UserName = User.Identity.Name,
				Text = text,
				Timestamp = DateTime.Now
			});

			return Json(new { success = true });
		}

		public ActionResult GetMessages()
		{
			return View(_messages);
		}
	}

}
