using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityMessagingSystem.Migrations
{
    public partial class sentAt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "sentAt",
                table: "messages",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sentAt",
                table: "messages");
        }
    }
}
