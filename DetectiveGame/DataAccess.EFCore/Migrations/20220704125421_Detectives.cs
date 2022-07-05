using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.EFCore.Migrations
{
    public partial class Detectives : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "SiteUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DetectiveTeams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetectiveTeams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Detectives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detectives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Detectives_DetectiveTeams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "DetectiveTeams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Detectives_SiteUsers_SiteUserId",
                        column: x => x.SiteUserId,
                        principalTable: "SiteUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detectives_SiteUserId",
                table: "Detectives",
                column: "SiteUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Detectives_TeamId",
                table: "Detectives",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detectives");

            migrationBuilder.DropTable(
                name: "DetectiveTeams");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "SiteUsers");
        }
    }
}
