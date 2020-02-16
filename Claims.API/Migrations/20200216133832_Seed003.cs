using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Claims.API.Migrations
{
    public partial class Seed003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Claim",
                columns: new[] { "Id", "ClaimAmmount", "ClaimCaseNumber", "Created", "Email", "FirstName", "InterruptionConsequence", "InterruptionReason", "IsFinished", "IsProcessed", "LastName", "Modified", "NewFlightDate", "NewFlightNumber", "OriginalFlightDate", "OriginalFlightNumber", "PolicyNumber" },
                values: new object[] { 1, 0m, "1", new DateTime(2020, 2, 14, 14, 38, 31, 897, DateTimeKind.Local).AddTicks(883), "pperic@mail.com", "Pero", "C", "WEATHER", null, null, "Peric", null, new DateTime(2020, 2, 14, 14, 38, 31, 896, DateTimeKind.Local).AddTicks(9904), "OB123", new DateTime(2020, 2, 13, 14, 38, 31, 887, DateTimeKind.Local).AddTicks(9136), "OA123", "1111111" });

            migrationBuilder.InsertData(
                table: "InterruptionConsequence",
                columns: new[] { "Id", "Active", "Consequence", "ConsequenceId" },
                values: new object[] { 1, true, "Cancellation", "C" });

            migrationBuilder.InsertData(
                table: "InterruptionResaon",
                columns: new[] { "Id", "Active", "Reason", "ReasonId" },
                values: new object[] { 1, true, "Weather", "WEATHER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Claim",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "InterruptionConsequence",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "InterruptionResaon",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
