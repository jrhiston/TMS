﻿using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using TMS.Database.Entities.Activities;
using TMS.Database.Entities.Areas;
using TMS.Database.Entities.Identity;
using TMS.Database.Entities.People;
using TMS.Database.Entities.PeopleAreas;

namespace TMS.Database.Contexts
{
    public class MainContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<PersonEntity> Persons { get; set; }
        public DbSet<AreaEntity> Areas { get; set; }
        public DbSet<ActivityEntity> Activities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PeopleAreasEntity>()
                .HasKey(pat => new { pat.PersonId, pat.AreaId });

            modelBuilder
                .Entity<PeopleAreasEntity>()
                .HasOne(pat => pat.Person)
                .WithMany(p => p.PersonAreas)
                .HasForeignKey(pat => pat.PersonId);

            modelBuilder
                .Entity<PeopleAreasEntity>()
                .HasOne(pat => pat.Area)
                .WithMany(a => a.AreaPersons)
                .HasForeignKey(pat => pat.AreaId);
        }
    }
}
