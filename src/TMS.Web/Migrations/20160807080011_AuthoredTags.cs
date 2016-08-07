using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TMS.Web.Migrations
{
    public partial class AuthoredTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AuthorId",
                table: "Tag",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Tag_AuthorId",
                table: "Tag",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_AspNetUsers_AuthorId",
                table: "Tag",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tag_AspNetUsers_AuthorId",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_Tag_AuthorId",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Tag");
        }
    }
}
