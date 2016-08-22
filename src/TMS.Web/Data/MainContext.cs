using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TMS.Layer.Data;
using TMS.Data.Entities.Activities.Comments;
using TMS.Data.Entities.Tags;
using TMS.Data.Entities.Activities;
using TMS.Data.Entities.Areas;
using TMS.Data.Entities.People;
using TMS.Data.Entities.PeopleAreas;

namespace TMS.Web.Data
{
    public class MainContext : IdentityDbContext<PersonEntity, IdentityRole<long>, long>, 
        IDataContext<PersonEntity>,
        IDataContext<AreaEntity>,
        IDataContext<ActivityEntity>,
        IDataContext<TagEntity>,
        IDataContext<ActivityCommentEntity>
    {
        public DbSet<AreaEntity> Areas { get; set; }
        public DbSet<ActivityEntity> Activities { get; set; }
        public DbSet<ActivityCommentEntity> ActivityComments { get; set; }

        public DbSet<TagEntity> Tags { get; set; }

        DbSet<PersonEntity> IDataContext<PersonEntity>.Entities => Users;
        DbSet<AreaEntity> IDataContext<AreaEntity>.Entities => Areas;
        DbSet<ActivityEntity> IDataContext<ActivityEntity>.Entities => Activities;
        DbSet<TagEntity> IDataContext<TagEntity>.Entities => Tags;

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
                .HasForeignKey(tae => tae.ParentTagId);

            modelBuilder
                .Entity<TagToTagEntity>()
                .HasOne(tae => tae.ChildTag)
                .WithMany(t => t.ParentTags)
                .HasForeignKey(tae => tae.ChildTagId);
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
