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
	public class ProcedureName
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
