using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TMS.Web.Data;

namespace TMS.Web.Migrations
{
    [DbContext(typeof(MainContext))]
    [Migration("20160812215925_AddedTagParentChildRelationship")]
    partial class AddedTagParentChildRelationship
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<long>", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<long>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<long>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<long>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<long>", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<long>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<long>", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TMS.Database.Entities.Activities.ActivityEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("AreaId");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("DeliveryTime");

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 255);

                    b.Property<long>("OwnerId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 255);

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Activity");
                });

            modelBuilder.Entity("TMS.Database.Entities.Activities.Comments.ActivityCommentEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("ActivityId");

                    b.Property<long>("AuthorId");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("AuthorId");

                    b.ToTable("ActivityComment");
                });

            modelBuilder.Entity("TMS.Database.Entities.Areas.AreaEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 255);

                    b.HasKey("Id");

                    b.ToTable("Area");
                });

            modelBuilder.Entity("TMS.Database.Entities.People.PersonEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .HasAnnotation("MaxLength", 255);

                    b.Property<string>("LastName")
                        .HasAnnotation("MaxLength", 255);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("TMS.Database.Entities.PeopleAreas.PeopleAreasEntity", b =>
                {
                    b.Property<long>("PersonId");

                    b.Property<long>("AreaId");

                    b.HasKey("PersonId", "AreaId");

                    b.HasIndex("AreaId");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonArea");
                });

            modelBuilder.Entity("TMS.Database.Entities.Tags.TagActivityEntity", b =>
                {
                    b.Property<long>("TagId");

                    b.Property<long>("ActivityId");

                    b.HasKey("TagId", "ActivityId");

                    b.HasIndex("ActivityId");

                    b.HasIndex("TagId");

                    b.ToTable("TagActivity");
                });

            modelBuilder.Entity("TMS.Database.Entities.Tags.TagEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("AuthorId");

                    b.Property<bool>("CanSetOnActivity");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name");

                    b.Property<bool>("Reusable");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("TMS.Database.Entities.Tags.TagToTagEntity", b =>
                {
                    b.Property<long>("ParentTagId");

                    b.Property<long>("ChildTagId");

                    b.HasKey("ParentTagId", "ChildTagId");

                    b.HasIndex("ChildTagId");

                    b.HasIndex("ParentTagId");

                    b.ToTable("TagToTagEntity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<long>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<long>")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<long>", b =>
                {
                    b.HasOne("TMS.Database.Entities.People.PersonEntity")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<long>", b =>
                {
                    b.HasOne("TMS.Database.Entities.People.PersonEntity")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<long>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole<long>")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TMS.Database.Entities.People.PersonEntity")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TMS.Database.Entities.Activities.ActivityEntity", b =>
                {
                    b.HasOne("TMS.Database.Entities.Areas.AreaEntity", "Area")
                        .WithMany("Activities")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TMS.Database.Entities.People.PersonEntity", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TMS.Database.Entities.Activities.Comments.ActivityCommentEntity", b =>
                {
                    b.HasOne("TMS.Database.Entities.Activities.ActivityEntity", "Activity")
                        .WithMany("Comments")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TMS.Database.Entities.People.PersonEntity", "Author")
                        .WithMany("AuthoredActivityComments")
                        .HasForeignKey("AuthorId");
                });

            modelBuilder.Entity("TMS.Database.Entities.PeopleAreas.PeopleAreasEntity", b =>
                {
                    b.HasOne("TMS.Database.Entities.Areas.AreaEntity", "Area")
                        .WithMany("AreaPersons")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TMS.Database.Entities.People.PersonEntity", "Person")
                        .WithMany("PersonAreas")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TMS.Database.Entities.Tags.TagActivityEntity", b =>
                {
                    b.HasOne("TMS.Database.Entities.Activities.ActivityEntity", "Activity")
                        .WithMany("Tags")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TMS.Database.Entities.Tags.TagEntity", "Tag")
                        .WithMany("Activities")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TMS.Database.Entities.Tags.TagEntity", b =>
                {
                    b.HasOne("TMS.Database.Entities.People.PersonEntity", "Author")
                        .WithMany("AuthoredTags")
                        .HasForeignKey("AuthorId");
                });

            modelBuilder.Entity("TMS.Database.Entities.Tags.TagToTagEntity", b =>
                {
                    b.HasOne("TMS.Database.Entities.Tags.TagEntity", "ParentTag")
                        .WithMany("ChildTags")
                        .HasForeignKey("ChildTagId");

                    b.HasOne("TMS.Database.Entities.Tags.TagEntity", "ChildTag")
                        .WithMany("ParentTags")
                        .HasForeignKey("ParentTagId");
                });
        }
    }
}
