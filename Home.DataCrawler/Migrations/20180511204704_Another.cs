using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Home.DataCrawler.Migrations
{
    public partial class Another : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeasurePoints",
                columns: table => new
                {
                    Guid = table.Column<string>(nullable: false),
                    ChannelId = table.Column<string>(nullable: true),
                    PointName = table.Column<string>(nullable: true),
                    PointValue = table.Column<double>(nullable: false),
                    Create = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurePoints", x => x.Guid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeasurePoints");
        }
    }
}
