using Microsoft.EntityFrameworkCore.Migrations;

namespace UltraPlayApi.Data.Migrations
{
    public partial class AddUpdateMessageTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BetUpdateMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueId = table.Column<int>(type: "int", nullable: false),
                    BetId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BetUpdateMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BetUpdateMessages_Bets_BetId",
                        column: x => x.BetId,
                        principalTable: "Bets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MatchUpdateMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueId = table.Column<int>(type: "int", nullable: false),
                    MatchId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchUpdateMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchUpdateMessages_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OddUpdateMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueId = table.Column<int>(type: "int", nullable: false),
                    OddId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OddUpdateMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OddUpdateMessages_Odds_OddId",
                        column: x => x.OddId,
                        principalTable: "Odds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BetUpdateMessages_BetId",
                table: "BetUpdateMessages",
                column: "BetId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchUpdateMessages_MatchId",
                table: "MatchUpdateMessages",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_OddUpdateMessages_OddId",
                table: "OddUpdateMessages",
                column: "OddId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BetUpdateMessages");

            migrationBuilder.DropTable(
                name: "MatchUpdateMessages");

            migrationBuilder.DropTable(
                name: "OddUpdateMessages");
        }
    }
}
