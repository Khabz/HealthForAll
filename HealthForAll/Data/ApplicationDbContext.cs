using System;
using System.Collections.Generic;
using System.Text;
using HealthForAll.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthForAll.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Shelter> Shelters { get; set; }
        public DbSet<Meal> Meals { get; set; }
    }
}
