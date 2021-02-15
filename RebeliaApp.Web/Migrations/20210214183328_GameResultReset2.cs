using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RebeliaApp.Web.Migrations
{
    public partial class GameResultReset2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FriendlyGameResults",
                columns: table => new
                {
                    GameID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WinnerID = table.Column<int>(type: "int", nullable: true),
                    BattleResult = table.Column<int>(type: "int", nullable: false),
                    SystemID = table.Column<int>(type: "int", nullable: false),
                    ScenarioID = table.Column<int>(type: "int", nullable: false),
                    Rounds = table.Column<int>(type: "int", nullable: false),
                    PointFormat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendlyGameResults", x => x.GameID);
                });

            migrationBuilder.CreateTable(
                name: "PlayerScores",
                columns: table => new
                {
                    PlayerScoreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerID = table.Column<int>(type: "int", nullable: false),
                    GameID = table.Column<int>(type: "int", nullable: false),
                    ArmyID = table.Column<int>(type: "int", nullable: false),
                    ThemeID = table.Column<int>(type: "int", nullable: true),
                    CasterID = table.Column<int>(type: "int", nullable: true),
                    ObjectivePoints = table.Column<int>(type: "int", nullable: false),
                    ArmyPoints = table.Column<int>(type: "int", nullable: false),
                    WinCondition = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerScores", x => x.PlayerScoreID);
                    table.ForeignKey(
                        name: "FK_PlayerScores_FriendlyGameResults_GameID",
                        column: x => x.GameID,
                        principalTable: "FriendlyGameResults",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerScores_GameID",
                table: "PlayerScores",
                column: "GameID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerScores");

            migrationBuilder.DropTable(
                name: "FriendlyGameResults");
        }
    }
}
