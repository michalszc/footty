﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace footty.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Stadium");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
