using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.EFCore.Migrations
{
    public partial class Teams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DetectiveTeamParticipants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DetectiveId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DetectiveTeamRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetectiveTeamParticipants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DetectiveTeamRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetectiveTeamRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DetectiveTeams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetectiveTeams", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DetectiveTeamRoles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "owner" });

            migrationBuilder.InsertData(
                table: "DetectiveTeamRoles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "detective" });

            migrationBuilder.InsertData(
                table: "DetectiveTeamRoles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "pending" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetectiveTeamParticipants");

            migrationBuilder.DropTable(
                name: "DetectiveTeamRoles");

            migrationBuilder.DropTable(
                name: "DetectiveTeams");
        }
    }
}
