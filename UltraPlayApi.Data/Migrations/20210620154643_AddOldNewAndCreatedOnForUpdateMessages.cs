using Microsoft.EntityFrameworkCore.Migrations;

namespace UltraPlayApi.Data.Migrations
{
    public partial class AddOldNewAndCreatedOnForUpdateMessages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BetUpdateMessages_Bets_BetId",
                table: "BetUpdateMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchUpdateMessages_Matches_MatchId",
                table: "MatchUpdateMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_OddUpdateMessages_Odds_OddId",
                table: "OddUpdateMessages");

            migrationBuilder.AlterColumn<int>(
                name: "OddId",
                table: "OddUpdateMessages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NewValue",
                table: "OddUpdateMessages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OldValue",
                table: "OddUpdateMessages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MatchId",
                table: "MatchUpdateMessages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NewValue",
                table: "MatchUpdateMessages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OldValue",
                table: "MatchUpdateMessages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BetId",
                table: "BetUpdateMessages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NewValue",
                table: "BetUpdateMessages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OldValue",
                table: "BetUpdateMessages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BetUpdateMessages_Bets_BetId",
                table: "BetUpdateMessages",
                column: "BetId",
                principalTable: "Bets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchUpdateMessages_Matches_MatchId",
                table: "MatchUpdateMessages",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OddUpdateMessages_Odds_OddId",
                table: "OddUpdateMessages",
                column: "OddId",
                principalTable: "Odds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BetUpdateMessages_Bets_BetId",
                table: "BetUpdateMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchUpdateMessages_Matches_MatchId",
                table: "MatchUpdateMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_OddUpdateMessages_Odds_OddId",
                table: "OddUpdateMessages");

            migrationBuilder.DropColumn(
                name: "NewValue",
                table: "OddUpdateMessages");

            migrationBuilder.DropColumn(
                name: "OldValue",
                table: "OddUpdateMessages");

            migrationBuilder.DropColumn(
                name: "NewValue",
                table: "MatchUpdateMessages");

            migrationBuilder.DropColumn(
                name: "OldValue",
                table: "MatchUpdateMessages");

            migrationBuilder.DropColumn(
                name: "NewValue",
                table: "BetUpdateMessages");

            migrationBuilder.DropColumn(
                name: "OldValue",
                table: "BetUpdateMessages");

            migrationBuilder.AlterColumn<int>(
                name: "OddId",
                table: "OddUpdateMessages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MatchId",
                table: "MatchUpdateMessages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BetId",
                table: "BetUpdateMessages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BetUpdateMessages_Bets_BetId",
                table: "BetUpdateMessages",
                column: "BetId",
                principalTable: "Bets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchUpdateMessages_Matches_MatchId",
                table: "MatchUpdateMessages",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OddUpdateMessages_Odds_OddId",
                table: "OddUpdateMessages",
                column: "OddId",
                principalTable: "Odds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
