using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Home.DataCrawler.Migrations
{
    public partial class HmStatesSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HomeMaticStates",
                columns: new[] { "Pk", "LastEdit", "Name", "State" },
                values: new object[] { new Guid("ac0d8cd0-7106-41e5-ab06-f087f41b5b96"), new DateTimeOffset(new DateTime(2018, 5, 13, 1, 42, 11, 674, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "SteckdoseTv", false });

            migrationBuilder.InsertData(
                table: "HomeMaticStates",
                columns: new[] { "Pk", "LastEdit", "Name", "State" },
                values: new object[] { new Guid("b4d133d9-5074-4d69-b7b5-28814fbf4d1c"), new DateTimeOffset(new DateTime(2018, 5, 13, 1, 42, 11, 678, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Alarmanlage", false });

            migrationBuilder.InsertData(
                table: "HomeMaticStates",
                columns: new[] { "Pk", "LastEdit", "Name", "State" },
                values: new object[] { new Guid("1f27d435-c462-4f15-9c1b-f4542d4541bd"), new DateTimeOffset(new DateTime(2018, 5, 13, 1, 42, 11, 678, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Fenster Bad hinten", false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HomeMaticStates",
                keyColumn: "Pk",
                keyValue: new Guid("1f27d435-c462-4f15-9c1b-f4542d4541bd"));

            migrationBuilder.DeleteData(
                table: "HomeMaticStates",
                keyColumn: "Pk",
                keyValue: new Guid("ac0d8cd0-7106-41e5-ab06-f087f41b5b96"));

            migrationBuilder.DeleteData(
                table: "HomeMaticStates",
                keyColumn: "Pk",
                keyValue: new Guid("b4d133d9-5074-4d69-b7b5-28814fbf4d1c"));
        }
    }
}
