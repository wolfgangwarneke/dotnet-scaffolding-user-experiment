using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelTestBlog.Data.Migrations
{
    public partial class VirtualUserToModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Location",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ExperiencePerson",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Experience",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_UserId",
                table: "Person",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_UserId",
                table: "Location",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperiencePerson_UserId",
                table: "ExperiencePerson",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Experience_UserId",
                table: "Experience",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Experience_AspNetUsers_UserId",
                table: "Experience",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExperiencePerson_AspNetUsers_UserId",
                table: "ExperiencePerson",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Location_AspNetUsers_UserId",
                table: "Location",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_AspNetUsers_UserId",
                table: "Person",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experience_AspNetUsers_UserId",
                table: "Experience");

            migrationBuilder.DropForeignKey(
                name: "FK_ExperiencePerson_AspNetUsers_UserId",
                table: "ExperiencePerson");

            migrationBuilder.DropForeignKey(
                name: "FK_Location_AspNetUsers_UserId",
                table: "Location");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_AspNetUsers_UserId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_UserId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Location_UserId",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_ExperiencePerson_UserId",
                table: "ExperiencePerson");

            migrationBuilder.DropIndex(
                name: "IX_Experience_UserId",
                table: "Experience");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ExperiencePerson");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Experience");
        }
    }
}
