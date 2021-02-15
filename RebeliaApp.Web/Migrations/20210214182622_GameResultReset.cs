using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RebeliaApp.Web.Migrations
{
    public partial class GameResultReset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerScore_FriendlyGameResults_GameID",
                table: "PlayerScore");

            migrationBuilder.DropTable(
                name: "TournamentSoloGameResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerScore",
                table: "PlayerScore");

            migrationBuilder.DropIndex(
                name: "IX_PlayerScore_GameID",
                table: "PlayerScore");

            migrationBuilder.DropColumn(
                name: "CastrKill",
                table: "FriendlyGameResults");

            migrationBuilder.DropColumn(
                name: "DeathClock",
                table: "FriendlyGameResults");

            migrationBuilder.RenameTable(
                name: "PlayerScore",
                newName: "PlayerScores");

            migrationBuilder.AlterColumn<int>(
                name: "WinnerID",
                table: "FriendlyGameResults",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BattleResult",
                table: "FriendlyGameResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ThemeID",
                table: "PlayerScores",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CasterID",
                table: "PlayerScores",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerID",
                table: "PlayerScores",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PlayerScoreID",
                table: "PlayerScores",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "WinCondition",
                table: "PlayerScores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerScores",
                table: "PlayerScores",
                column: "PlayerScoreID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerScores",
                table: "PlayerScores");

            migrationBuilder.DropColumn(
                name: "BattleResult",
                table: "FriendlyGameResults");

            migrationBuilder.DropColumn(
                name: "PlayerScoreID",
                table: "PlayerScores");

            migrationBuilder.DropColumn(
                name: "WinCondition",
                table: "PlayerScores");

            migrationBuilder.RenameTable(
                name: "PlayerScores",
                newName: "PlayerScore");

            migrationBuilder.AlterColumn<int>(
                name: "WinnerID",
                table: "FriendlyGameResults",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CastrKill",
                table: "FriendlyGameResults",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DeathClock",
                table: "FriendlyGameResults",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "ThemeID",
                table: "PlayerScore",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlayerID",
                table: "PlayerScore",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "CasterID",
                table: "PlayerScore",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerScore",
                table: "PlayerScore",
                column: "PlayerID");

            migrationBuilder.CreateTable(
                name: "TournamentSoloGameResults",
                columns: table => new
                {
                    GameID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArmyID = table.Column<int>(type: "int", nullable: true),
                    ArmyPoints = table.Column<int>(type: "int", nullable: false),
                    BattleID = table.Column<int>(type: "int", nullable: false),
                    BattleResult = table.Column<int>(type: "int", nullable: false),
                    Bye = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DefetedBy = table.Column<int>(type: "int", nullable: false),
                    ObjectivePoints = table.Column<int>(type: "int", nullable: false),
                    PlayerID = table.Column<int>(type: "int", nullable: true),
                    PointSize = table.Column<int>(type: "int", nullable: false),
                    Rounds = table.Column<int>(type: "int", nullable: false),
                    ScenarioName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SystemID = table.Column<int>(type: "int", nullable: true),
                    ThemeID = table.Column<int>(type: "int", nullable: true),
                    TournamentPoints = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentSoloGameResults", x => x.GameID);
                    table.ForeignKey(
                        name: "FK_TournamentSoloGameResults_Armies_ArmyID",
                        column: x => x.ArmyID,
                        principalTable: "Armies",
                        principalColumn: "ArmyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TournamentSoloGameResults_GameSystems_SystemID",
                        column: x => x.SystemID,
                        principalTable: "GameSystems",
                        principalColumn: "SystemID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TournamentSoloGameResults_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TournamentSoloGameResults_Themes_ThemeID",
                        column: x => x.ThemeID,
                        principalTable: "Themes",
                        principalColumn: "ThemeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerScore_GameID",
                table: "PlayerScore",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentSoloGameResults_ArmyID",
                table: "TournamentSoloGameResults",
                column: "ArmyID");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentSoloGameResults_PlayerID",
                table: "TournamentSoloGameResults",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentSoloGameResults_SystemID",
                table: "TournamentSoloGameResults",
                column: "SystemID");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentSoloGameResults_ThemeID",
                table: "TournamentSoloGameResults",
                column: "ThemeID");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerScore_FriendlyGameResults_GameID",
                table: "PlayerScore",
                column: "GameID",
                principalTable: "FriendlyGameResults",
                principalColumn: "GameID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
