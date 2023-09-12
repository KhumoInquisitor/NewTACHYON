using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Tachyon.Areas.Identity.Data;

// Add profile data for application users by adding properties to the TachyonUser class
public class TachyonUser : IdentityUser
{
    public string? FirstName { set; get; }
    public string? LastName { set; get; }
}

