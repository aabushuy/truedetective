using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.EFCore.Migrations
{
    public partial class Teams2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetectiveId",
                table: "DetectiveTeamParticipants");

            migrationBuilder.AddColumn<string>(
                name: "DetectiveGameUserId",
                table: "DetectiveTeamParticipants",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DetectiveTeamId",
                table: "DetectiveTeamParticipants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DetectiveTeamParticipants_DetectiveGameUserId",
                table: "DetectiveTeamParticipants",
                column: "DetectiveGameUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DetectiveTeamParticipants_DetectiveTeamId",
                table: "DetectiveTeamParticipants",
                column: "DetectiveTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_DetectiveTeamParticipants_DetectiveTeamRoleId",
                table: "DetectiveTeamParticipants",
                column: "DetectiveTeamRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetectiveTeamParticipants_DetectiveGameUsers_DetectiveGameUserId",
                table: "DetectiveTeamParticipants",
                column: "DetectiveGameUserId",
                principalTable: "DetectiveGameUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetectiveTeamParticipants_DetectiveTeamRoles_DetectiveTeamRoleId",
                table: "DetectiveTeamParticipants",
                column: "DetectiveTeamRoleId",
                principalTable: "DetectiveTeamRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetectiveTeamParticipants_DetectiveTeams_DetectiveTeamId",
                table: "DetectiveTeamParticipants",
                column: "DetectiveTeamId",
                principalTable: "DetectiveTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetectiveTeamParticipants_DetectiveGameUsers_DetectiveGameUserId",
                table: "DetectiveTeamParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_DetectiveTeamParticipants_DetectiveTeamRoles_DetectiveTeamRoleId",
                table: "DetectiveTeamParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_DetectiveTeamParticipants_DetectiveTeams_DetectiveTeamId",
                table: "DetectiveTeamParticipants");

            migrationBuilder.DropIndex(
                name: "IX_DetectiveTeamParticipants_DetectiveGameUserId",
                table: "DetectiveTeamParticipants");

            migrationBuilder.DropIndex(
                name: "IX_DetectiveTeamParticipants_DetectiveTeamId",
                table: "DetectiveTeamParticipants");

            migrationBuilder.DropIndex(
                name: "IX_DetectiveTeamParticipants_DetectiveTeamRoleId",
                table: "DetectiveTeamParticipants");

            migrationBuilder.DropColumn(
                name: "DetectiveGameUserId",
                table: "DetectiveTeamParticipants");

            migrationBuilder.DropColumn(
                name: "DetectiveTeamId",
                table: "DetectiveTeamParticipants");

            migrationBuilder.AddColumn<string>(
                name: "DetectiveId",
                table: "DetectiveTeamParticipants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
