using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RebeliaApp.Web.Migrations
{
    public partial class InitDatabase : Migration
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
                    PointFormat = table.Column<int>(type: "int", nullable: false),
                    Rounds = table.Column<int>(type: "int", nullable: false),
                    SystemID = table.Column<int>(type: "int", nullable: false),
                    ScenarioID = table.Column<int>(type: "int", nullable: false),
                    WinnerID = table.Column<int>(type: "int", nullable: false),
                    CastrKill = table.Column<bool>(type: "bit", nullable: false),
                    DeathClock = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendlyGameResults", x => x.GameID);
                });

            migrationBuilder.CreateTable(
                name: "GameSystems",
                columns: table => new
                {
                    SystemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SystemImage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSystems", x => x.SystemID);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Nick = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerID);
                });

            migrationBuilder.CreateTable(
                name: "PlayerScore",
                columns: table => new
                {
                    PlayerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameID = table.Column<int>(type: "int", nullable: false),
                    ArmyID = table.Column<int>(type: "int", nullable: false),
                    ThemeID = table.Column<int>(type: "int", nullable: false),
                    CasterID = table.Column<int>(type: "int", nullable: false),
                    ObjectivePoints = table.Column<int>(type: "int", nullable: false),
                    ArmyPoints = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerScore", x => x.PlayerID);
                    table.ForeignKey(
                        name: "FK_PlayerScore_FriendlyGameResults_GameID",
                        column: x => x.GameID,
                        principalTable: "FriendlyGameResults",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Armies",
                columns: table => new
                {
                    ArmyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemID = table.Column<int>(type: "int", nullable: false),
                    ArmyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ArmyImage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armies", x => x.ArmyID);
                    table.ForeignKey(
                        name: "FK_Armies_GameSystems_SystemID",
                        column: x => x.SystemID,
                        principalTable: "GameSystems",
                        principalColumn: "SystemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scenario",
                columns: table => new
                {
                    ScenarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemID = table.Column<int>(type: "int", nullable: false),
                    ScenarioName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scenario", x => x.ScenarioID);
                    table.ForeignKey(
                        name: "FK_Scenario_GameSystems_SystemID",
                        column: x => x.SystemID,
                        principalTable: "GameSystems",
                        principalColumn: "SystemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Caster",
                columns: table => new
                {
                    CasterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArmyID = table.Column<int>(type: "int", nullable: false),
                    CasterName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CasterImg = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caster", x => x.CasterID);
                    table.ForeignKey(
                        name: "FK_Caster_Armies_ArmyID",
                        column: x => x.ArmyID,
                        principalTable: "Armies",
                        principalColumn: "ArmyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Themes",
                columns: table => new
                {
                    ThemeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArmyID = table.Column<int>(type: "int", nullable: false),
                    SystemID = table.Column<int>(type: "int", nullable: false),
                    ThemeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ThemeImage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themes", x => x.ThemeID);
                    table.ForeignKey(
                        name: "FK_Themes_Armies_ArmyID",
                        column: x => x.ArmyID,
                        principalTable: "Armies",
                        principalColumn: "ArmyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MapFormat",
                columns: table => new
                {
                    MapID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScenarioID = table.Column<int>(type: "int", nullable: false),
                    SystemID = table.Column<int>(type: "int", nullable: false),
                    SmallFormat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MediumFormat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StandardFormat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapFormat", x => x.MapID);
                    table.ForeignKey(
                        name: "FK_MapFormat_Scenario_ScenarioID",
                        column: x => x.ScenarioID,
                        principalTable: "Scenario",
                        principalColumn: "ScenarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TournamentSoloGameResults",
                columns: table => new
                {
                    GameID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BattleID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlayerID = table.Column<int>(type: "int", nullable: true),
                    TournamentPoints = table.Column<int>(type: "int", nullable: false),
                    ObjectivePoints = table.Column<int>(type: "int", nullable: false),
                    ArmyPoints = table.Column<int>(type: "int", nullable: false),
                    PointSize = table.Column<int>(type: "int", nullable: false),
                    Rounds = table.Column<int>(type: "int", nullable: false),
                    DefetedBy = table.Column<int>(type: "int", nullable: false),
                    SystemID = table.Column<int>(type: "int", nullable: true),
                    ArmyID = table.Column<int>(type: "int", nullable: true),
                    ThemeID = table.Column<int>(type: "int", nullable: true),
                    ScenarioName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BattleResult = table.Column<int>(type: "int", nullable: false),
                    Bye = table.Column<bool>(type: "bit", nullable: false)
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
                name: "IX_Armies_SystemID",
                table: "Armies",
                column: "SystemID");

            migrationBuilder.CreateIndex(
                name: "IX_Caster_ArmyID",
                table: "Caster",
                column: "ArmyID");

            migrationBuilder.CreateIndex(
                name: "IX_MapFormat_ScenarioID",
                table: "MapFormat",
                column: "ScenarioID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerScore_GameID",
                table: "PlayerScore",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Scenario_SystemID",
                table: "Scenario",
                column: "SystemID");

            migrationBuilder.CreateIndex(
                name: "IX_Themes_ArmyID",
                table: "Themes",
                column: "ArmyID");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Caster");

            migrationBuilder.DropTable(
                name: "MapFormat");

            migrationBuilder.DropTable(
                name: "PlayerScore");

            migrationBuilder.DropTable(
                name: "TournamentSoloGameResults");

            migrationBuilder.DropTable(
                name: "Scenario");

            migrationBuilder.DropTable(
                name: "FriendlyGameResults");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Themes");

            migrationBuilder.DropTable(
                name: "Armies");

            migrationBuilder.DropTable(
                name: "GameSystems");
        }
    }
}
