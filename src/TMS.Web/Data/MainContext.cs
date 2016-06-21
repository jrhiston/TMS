using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TMS.Database;
using TMS.Database.Entities.Activities;
using TMS.Database.Entities.Areas;
using TMS.Database.Entities.People;
using TMS.Database.Entities.PeopleAreas;

namespace TMS.Web.Data
{
    public class MainContext : IdentityDbContext<PersonEntity, IdentityRole<long>, long>, 
        IDatabaseContext<PersonEntity>,
        IDatabaseContext<AreaEntity>
    {
        public DbSet<AreaEntity> Areas { get; set; }
        public DbSet<ActivityEntity> Activities { get; set; }

        DbSet<PersonEntity> IDatabaseContext<PersonEntity>.Entities => Users;
        DbSet<AreaEntity> IDatabaseContext<AreaEntity>.Entities => Areas;

        public MainContext(DbContextOptions options) : base(options)
        {
        }

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
