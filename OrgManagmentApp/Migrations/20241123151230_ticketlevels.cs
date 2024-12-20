using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace OrgManagmentApp.Migrations
{
    /// <inheritdoc />
    public partial class ticketlevels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventTicketLevels",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventID = table.Column<int>(type: "integer", nullable: false),
                    LevelID = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTicketLevels", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EventTicketLevels_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventTicketLevels_Levels_LevelID",
                        column: x => x.LevelID,
                        principalTable: "Levels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventTicketLevels_EventID",
                table: "EventTicketLevels",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_EventTicketLevels_LevelID",
                table: "EventTicketLevels",
                column: "LevelID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventTicketLevels");
        }
    }
}
