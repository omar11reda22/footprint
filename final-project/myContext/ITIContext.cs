using final_project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;


namespace final_project.myContext
{
    public class ITIContext : DbContext
    {
        public ITIContext()
        {

        }
        public ITIContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=project-ecological;Integrated Security=True; TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityUser>()
                .Ignore(e => e.PhoneNumberConfirmed)
                .Ignore(e => e.NormalizedEmail)
                .Ignore(e => e.PhoneNumber)
                .Ignore(e => e.PasswordHash)
                .Ignore(e => e.ConcurrencyStamp)
            .Ignore(e => e.TwoFactorEnabled);

            builder.Entity<result>().HasKey(s => new { s.Question_ID, s.user_Id });

        }
        public DbSet<Category> categories { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<Country> countries { get; set; }
        public DbSet<Governorate> governorates { get; set; }
        public DbSet<question> questions { get; set; }
        public DbSet<result> results { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<address> addresses { get; set; }   

    }
    }
