using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Tachyon.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;

namespace Tachyon.Models
{
	public class Message
	{
		[Key] 
		public string Id { get; set; }
		public string UserName { get; set; }
		public string Text { get; set; }
		public DateTime Timestamp { get; set; }
	}

}
