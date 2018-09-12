using System;
using System.Collections.Generic;
using System.Text;
using IntegrationProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace IntegrationProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Bar> Bars { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet <Match> Matches { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<ActivityItem> Activities { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Music> Musics { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
