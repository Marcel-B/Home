using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Home.DataCrawler.Migrations
{
    public partial class HmStatesSeeding1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "HomeMaticStates",
                columns: new[] { "Pk", "LastEdit", "Name", "State" },
                values: new object[] { new Guid("af39e5b0-28c3-4968-b6bd-cbaf6076a0a3"), new DateTimeOffset(new DateTime(2018, 5, 13, 1, 45, 59, 86, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "SteckdoseTv", false });

            migrationBuilder.InsertData(
                table: "HomeMaticStates",
                columns: new[] { "Pk", "LastEdit", "Name", "State" },
                values: new object[] { new Guid("18cc2f3b-1d49-4cc4-8473-3ec2639ba352"), new DateTimeOffset(new DateTime(2018, 5, 13, 1, 45, 59, 90, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Alarmanlage", false });

            migrationBuilder.InsertData(
                table: "HomeMaticStates",
                columns: new[] { "Pk", "LastEdit", "Name", "State" },
                values: new object[] { new Guid("56adf1bb-cc83-431c-bc29-b14b22fe441a"), new DateTimeOffset(new DateTime(2018, 5, 13, 1, 45, 59, 90, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Deckenlampe", false });

            migrationBuilder.InsertData(
                table: "HomeMaticStates",
                columns: new[] { "Pk", "LastEdit", "Name", "State" },
                values: new object[] { new Guid("09ac2db5-b118-4627-beb2-28c4be698232"), new DateTimeOffset(new DateTime(2018, 5, 13, 1, 45, 59, 91, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Fenster Bad hinten", false });

            migrationBuilder.InsertData(
                table: "HomeMaticStates",
                columns: new[] { "Pk", "LastEdit", "Name", "State" },
                values: new object[] { new Guid("ede699f5-19e8-47e5-a2d4-7128d0ed20f6"), new DateTimeOffset(new DateTime(2018, 5, 13, 1, 45, 59, 91, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Fenster Kinderzimmer rechts", false });

            migrationBuilder.InsertData(
                table: "HomeMaticStates",
                columns: new[] { "Pk", "LastEdit", "Name", "State" },
                values: new object[] { new Guid("c731424d-cbef-4533-994e-b3fe10028afa"), new DateTimeOffset(new DateTime(2018, 5, 13, 1, 45, 59, 91, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Fenster Kinderzimmer links", false });

            migrationBuilder.InsertData(
                table: "HomeMaticStates",
                columns: new[] { "Pk", "LastEdit", "Name", "State" },
                values: new object[] { new Guid("0e56ebec-47ff-4382-8861-d3f18f660669"), new DateTimeOffset(new DateTime(2018, 5, 13, 1, 45, 59, 91, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Fenster Wohnzimmer rechts", false });

            migrationBuilder.InsertData(
                table: "HomeMaticStates",
                columns: new[] { "Pk", "LastEdit", "Name", "State" },
                values: new object[] { new Guid("93b6618a-fd6d-4238-8e22-c43ccf8aef55"), new DateTimeOffset(new DateTime(2018, 5, 13, 1, 45, 59, 91, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Fenster Wohnzimmer links", false });

            migrationBuilder.InsertData(
                table: "HomeMaticStates",
                columns: new[] { "Pk", "LastEdit", "Name", "State" },
                values: new object[] { new Guid("20b62533-23f2-4bfb-95d4-da3f780367bf"), new DateTimeOffset(new DateTime(2018, 5, 13, 1, 45, 59, 91, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Fenster Terrasse rechts", false });

            migrationBuilder.InsertData(
                table: "HomeMaticStates",
                columns: new[] { "Pk", "LastEdit", "Name", "State" },
                values: new object[] { new Guid("8de0c218-1a5c-4ac4-b19a-34c2c26445af"), new DateTimeOffset(new DateTime(2018, 5, 13, 1, 45, 59, 91, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Fenster Terrasse links", false });

            migrationBuilder.InsertData(
                table: "HomeMaticStates",
                columns: new[] { "Pk", "LastEdit", "Name", "State" },
                values: new object[] { new Guid("676229a9-5bf7-49a8-8a8b-62b937c3312e"), new DateTimeOffset(new DateTime(2018, 5, 13, 1, 45, 59, 91, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Fenster Schlafzimmer rechts", false });

            migrationBuilder.InsertData(
                table: "HomeMaticStates",
                columns: new[] { "Pk", "LastEdit", "Name", "State" },
                values: new object[] { new Guid("77ac877f-6d5b-4e1a-8c78-df07332f09e9"), new DateTimeOffset(new DateTime(2018, 5, 13, 1, 45, 59, 91, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Fenster Schlafzimmer links", false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HomeMaticStates",
                keyColumn: "Pk",
                keyValue: new Guid("09ac2db5-b118-4627-beb2-28c4be698232"));

            migrationBuilder.DeleteData(
                table: "HomeMaticStates",
                keyColumn: "Pk",
                keyValue: new Guid("0e56ebec-47ff-4382-8861-d3f18f660669"));

            migrationBuilder.DeleteData(
                table: "HomeMaticStates",
                keyColumn: "Pk",
                keyValue: new Guid("18cc2f3b-1d49-4cc4-8473-3ec2639ba352"));

            migrationBuilder.DeleteData(
                table: "HomeMaticStates",
                keyColumn: "Pk",
                keyValue: new Guid("20b62533-23f2-4bfb-95d4-da3f780367bf"));

            migrationBuilder.DeleteData(
                table: "HomeMaticStates",
                keyColumn: "Pk",
                keyValue: new Guid("56adf1bb-cc83-431c-bc29-b14b22fe441a"));

            migrationBuilder.DeleteData(
                table: "HomeMaticStates",
                keyColumn: "Pk",
                keyValue: new Guid("676229a9-5bf7-49a8-8a8b-62b937c3312e"));

            migrationBuilder.DeleteData(
                table: "HomeMaticStates",
                keyColumn: "Pk",
                keyValue: new Guid("77ac877f-6d5b-4e1a-8c78-df07332f09e9"));

            migrationBuilder.DeleteData(
                table: "HomeMaticStates",
                keyColumn: "Pk",
                keyValue: new Guid("8de0c218-1a5c-4ac4-b19a-34c2c26445af"));

            migrationBuilder.DeleteData(
                table: "HomeMaticStates",
                keyColumn: "Pk",
                keyValue: new Guid("93b6618a-fd6d-4238-8e22-c43ccf8aef55"));

            migrationBuilder.DeleteData(
                table: "HomeMaticStates",
                keyColumn: "Pk",
                keyValue: new Guid("af39e5b0-28c3-4968-b6bd-cbaf6076a0a3"));

            migrationBuilder.DeleteData(
                table: "HomeMaticStates",
                keyColumn: "Pk",
                keyValue: new Guid("c731424d-cbef-4533-994e-b3fe10028afa"));

            migrationBuilder.DeleteData(
                table: "HomeMaticStates",
                keyColumn: "Pk",
                keyValue: new Guid("ede699f5-19e8-47e5-a2d4-7128d0ed20f6"));

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
    }
}
