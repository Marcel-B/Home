using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Home.DataCrawler.Migrations
{
    public partial class HmStates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HomeMaticStates",
                columns: table => new
                {
                    Pk = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    State = table.Column<bool>(nullable: false),
                    LastEdit = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeMaticStates", x => x.Pk);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeMaticStates");
        }
    }
}
