using HospitalManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Data
{
    public class HospitalDbContext : IdentityDbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> dboptions) : base(dboptions)
        {
            
        }

        //The OnModelCreating method is used to customize the database tables and columns.
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityUser>().Ignore(c => c.AccessFailedCount)
                                  .Ignore(c => c.ConcurrencyStamp)
                                  .Ignore(c => c.NormalizedEmail)
                                  .Ignore(c => c.PhoneNumber)
                                  .Ignore(c => c.PhoneNumberConfirmed)
                                  .Ignore(c => c.SecurityStamp)
                                  .Ignore(c => c.TwoFactorEnabled);
            builder.Entity<IdentityRole>().Ignore(d => d.ConcurrencyStamp);
            builder.Entity<IdentityUser>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");

            //used a foreach loop to loop through each foreignkey for each table
            foreach (var foreignkey in builder.Model.GetEntityTypes()
                                        .SelectMany(e => e.GetForeignKeys()))
            {
                //set the delete behaviour to restrict for each foreignkey.
                foreignkey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        public DbSet<Doctors> Doctors { set; get; }
        public DbSet<Departments> Departments { set; get; }
        public DbSet<Patients> Patients { set; get; }
        public DbSet<Employees> Employees { set; get; }
        public DbSet<Genders> Genders { set; get; }
        public DbSet<BloodGroups> BloodGroups { set; get; }
        public DbSet<Room> Room { set; get; }
        public DbSet<Booking> Bookings { set; get; }
        public DbSet<OPD> Opds { set; get; }
    }
}
