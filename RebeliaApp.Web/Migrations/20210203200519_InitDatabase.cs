using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RebeliaApp.Web.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_Scenario_SystemID",
                table: "Scenario",
                column: "SystemID");

            migrationBuilder.CreateIndex(
                name: "IX_Themes_ArmyID",
                table: "Themes",
                column: "ArmyID");

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Caster");

            migrationBuilder.DropTable(
                name: "MapFormat");

            migrationBuilder.DropTable(
                name: "Scenario");

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
