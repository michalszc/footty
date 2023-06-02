using footty.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace footty.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string teams_sql = File.ReadAllText("./Data/teams.sql");
            string matches_sql = File.ReadAllText("./Data/matches.sql");
            string players_sql = File.ReadAllText("./Data/players.sql");
            string stadiums_sql = File.ReadAllText("./Data/stadiums.sql");
            List<String> sqlQueries = new List<string>();
            sqlQueries.AddRange(teams_sql.Split(";\r\n"));
            sqlQueries.AddRange(matches_sql.Split(";\r\n"));
            sqlQueries.AddRange(players_sql.Split(";\r\n"));
            sqlQueries.AddRange(stadiums_sql.Split(";\r\n"));
            foreach (string sqlQuery in sqlQueries)
            {
                migrationBuilder.Sql(sqlQuery);
            }
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    username = table.Column<string>(type: "TEXT", nullable: true),
                    password = table.Column<string>(type: "TEXT", nullable: true),
                    can_edit = table.Column<bool>(type: "INTEGER", nullable: false),
                    token = table.Column<string>(type: "TEXT", nullable: true),
                    favTeamid = table.Column<string>(type: "INTEGER",nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "can_edit", "password", "token", "username", "favTeamid" },
                values: new object[] { 1, true, "81dc9bdb52d04dc20036dbd8313ed055", "6Y4ne9npAJFyssinCYVY2GfC", "admin", "1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 1,
                column: "token",
                value: "gX5xDJd28sXlNVAPBAw9ARSY");
        }
    }
}
