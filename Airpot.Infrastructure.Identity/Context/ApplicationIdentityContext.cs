using Airport.Infrastructure.Identity.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Infrastructure.Identity.Context;

public class ApplicationIdentityContext:IdentityDbContext<ApplicationUser>
{
   // public ApplicationIdentityContext(DbContextOptions<ApplicationIdentityContext> options) : base(options)
    //{

   // }
}
