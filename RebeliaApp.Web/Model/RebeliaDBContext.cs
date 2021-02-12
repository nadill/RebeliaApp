using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RebeliaApp.Web.Model
{
        public class RebeliaDBContext : DbContext
    {
        public DbSet<FriendlyGameResult> FriendlyGameResults { get; set; }
        public DbSet<TournamentSoloGameResult> TournamentSoloGameResults { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<GameSystem> GameSystems { get; set; }
        public DbSet<Army> Armies { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Scenario> Scenario { get; set; }
        public DbSet<MapFormat> MapFormat { get; set; }



        public RebeliaDBContext(DbContextOptions<RebeliaDBContext> options) : base(options)
        {
        }

    }
}
