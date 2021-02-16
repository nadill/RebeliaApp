using Microsoft.EntityFrameworkCore.Migrations;

namespace RebeliaApp.Web.Migrations
{
    public partial class ModifiedGameResults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BattleResult",
                table: "FriendlyGameResults");

            migrationBuilder.AddColumn<int>(
                name: "BattleResult",
                table: "PlayerScores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BattleResult",
                table: "PlayerScores");

            migrationBuilder.AddColumn<int>(
                name: "BattleResult",
                table: "FriendlyGameResults",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
