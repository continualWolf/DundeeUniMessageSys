using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityMessagingSystem.Migrations
{
    public partial class MessageTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fromEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fromUser = table.Column<int>(type: "int", nullable: false),
                    toEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    toUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messages", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "messages");
        }
    }
}
