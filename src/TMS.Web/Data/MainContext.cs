using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TMS.Database;
using TMS.Database.Entities.Activities;
using TMS.Database.Entities.Areas;
using TMS.Database.Entities.People;
using TMS.Database.Entities.PeopleAreas;
using TMS.Database.Entities.Tags;
using Microsoft.EntityFrameworkCore.Metadata;
using TMS.Database.Entities.Activities.Comments;
using System;

namespace TMS.Web.Data
{
    public class MainContext : IdentityDbContext<PersonEntity, IdentityRole<long>, long>, 
        IDatabaseContext<PersonEntity>,
        IDatabaseContext<AreaEntity>,
        IDatabaseContext<ActivityEntity>,
        IDatabaseContext<TagEntity>,
        IDatabaseContext<ActivityCommentEntity>
    {
        public DbSet<AreaEntity> Areas { get; set; }
        public DbSet<ActivityEntity> Activities { get; set; }
        public DbSet<ActivityCommentEntity> ActivityComments { get; set; }

        public DbSet<TagEntity> Tags { get; set; }

        DbSet<PersonEntity> IDatabaseContext<PersonEntity>.Entities => Users;
        DbSet<AreaEntity> IDatabaseContext<AreaEntity>.Entities => Areas;
        DbSet<ActivityEntity> IDatabaseContext<ActivityEntity>.Entities => Activities;
        DbSet<TagEntity> IDatabaseContext<TagEntity>.Entities => Tags;

        public DbSet<ActivityCommentEntity> Entities => ActivityComments;

        public MainContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            DefineManyToManyForPeopleAreas(builder);
            DefineManyToManyForTagActivities(builder);
            DefineManyTomanyForTagToTags(builder);
            RestrictCascadeForAuthoredTags(builder);
            RestrictCascadeForAuthoredActivityComments(builder);
            RestrictCascadeForTagToTags(builder);
        }

        private void RestrictCascadeForTagToTags(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<TagToTagEntity>()
                .HasOne(t => t.ParentTag)
                .WithMany(p => p.ChildTags)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<TagToTagEntity>()
                .HasOne(t => t.ChildTag)
                .WithMany(p => p.ParentTags)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private static void RestrictCascadeForAuthoredTags(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<TagEntity>()
                .HasOne(t => t.Author)
                .WithMany(p => p.AuthoredTags)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private static void RestrictCascadeForAuthoredActivityComments(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ActivityCommentEntity>()
                .HasOne(t => t.Author)
                .WithMany(p => p.AuthoredActivityComments)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void DefineManyTomanyForTagToTags(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TagToTagEntity>()
                            .HasKey(tae => new { tae.ParentTagId, tae.ChildTagId });

            modelBuilder
                .Entity<TagToTagEntity>()
                .HasOne(tae => tae.ParentTag)
                .WithMany(a => a.ChildTags)
                .HasForeignKey(tae => tae.ChildTagId);

            modelBuilder
                .Entity<TagToTagEntity>()
                .HasOne(tae => tae.ChildTag)
                .WithMany(t => t.ParentTags)
                .HasForeignKey(tae => tae.ParentTagId);
        }

        private static void DefineManyToManyForTagActivities(ModelBuilder modelBuilder)
        {
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

        private static void DefineManyToManyForPeopleAreas(ModelBuilder modelBuilder)
        {
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
