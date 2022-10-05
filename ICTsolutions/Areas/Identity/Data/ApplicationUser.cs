using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICTsolutions.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace ICTsolutions.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
     

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public ICollection<Project> Projects { get; set; }
}
