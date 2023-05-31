using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Footty.Data
{
    public class FoottyContext : DbContext
    {
        public FoottyContext (DbContextOptions<FoottyContext> options)
            : base(options)
        {
        }

        public DbSet<footty.Models.Player> Player { get; set; } = default!;

        public DbSet<footty.Models.Match> Match { get; set; } = default!;

        public DbSet<footty.Models.Stadium> Stadium { get; set; } = default!;

        public DbSet<footty.Models.Team> Team { get; set; } = default!;
        
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     base.OnModelCreating(modelBuilder);
        // }

        public void Up(MigrationBuilder migrationBuilder)
        {
            string matches_sql = File.ReadAllText("./Data/matches.sql");
            string players_sql = File.ReadAllText("./Data/players.sql");
            string teams_sql = File.ReadAllText("./Data/teams.sql");
            string stadiums_sql = File.ReadAllText("./Data/stadiums.sql");
            List<String> sqlQueries = new List<string>();
            sqlQueries.AddRange(matches_sql.Split(";\r\n"));
            sqlQueries.AddRange(players_sql.Split(";\r\n"));
            sqlQueries.AddRange(teams_sql.Split(";\r\n"));
            sqlQueries.AddRange(stadiums_sql.Split(";\r\n"));
            foreach (string sqlQuery in sqlQueries)
            {
                migrationBuilder.Sql(sqlQuery);
            }
        }

    }
}
