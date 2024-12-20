using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrgManagmentApp.Migrations
{
    /// <inheritdoc />
    public partial class ticketlevelsFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Levels_LevelID",
                table: "Tickets");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_EventTicketLevels_LevelID",
                table: "Tickets",
                column: "LevelID",
                principalTable: "EventTicketLevels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_EventTicketLevels_LevelID",
                table: "Tickets");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Levels_LevelID",
                table: "Tickets",
                column: "LevelID",
                principalTable: "Levels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
