using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TMS.Database;
using TMS.Database.Entities.Activities;
using TMS.Database.Entities.Areas;
using TMS.Database.Entities.People;
using TMS.Database.Entities.PeopleAreas;
using TMS.Database.Entities.Tags;

namespace TMS.Web.Data
{
    public class MainContext : IdentityDbContext<PersonEntity, IdentityRole<long>, long>, 
        IDatabaseContext<PersonEntity>,
        IDatabaseContext<AreaEntity>,
        IDatabaseContext<ActivityEntity>,
        IDatabaseContext<TagEntity>
    {
        public DbSet<AreaEntity> Areas { get; set; }
        public DbSet<ActivityEntity> Activities { get; set; }

        public DbSet<TagEntity> Tags { get; set; }

        DbSet<PersonEntity> IDatabaseContext<PersonEntity>.Entities => Users;
        DbSet<AreaEntity> IDatabaseContext<AreaEntity>.Entities => Areas;
        DbSet<ActivityEntity> IDatabaseContext<ActivityEntity>.Entities => Activities;
        DbSet<TagEntity> IDatabaseContext<TagEntity>.Entities => Tags;

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

            modelBuilder.Entity<TagActivityEntity>()
                .HasKey(tae => new { tae.TagId, tae.ActivityId });

            modelBuilder
                .Entity<TagActivityEntity>()
                .HasOne(tae => tae.Activity)
                .WithMany(a => a.Tags)
                .HasForeignKey(tae => tae.ActivityId);

            modelBuilder
                .Entity<TagActivityEntity>()
                .HasOne(tae => tae.Tag)
                .WithMany(t => t.Activities)
                .HasForeignKey(tae => tae.TagId);
        }
    }
}
