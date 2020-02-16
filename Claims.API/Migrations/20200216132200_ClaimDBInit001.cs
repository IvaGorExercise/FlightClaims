using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Claims.API.Migrations
{
    public partial class ClaimDBInit001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Claim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    ClaimCaseNumber = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PolicyNumber = table.Column<string>(nullable: true),
                    OriginalFlightNumber = table.Column<string>(nullable: true),
                    OriginalFlightDate = table.Column<DateTime>(nullable: false),
                    InterruptionReason = table.Column<string>(nullable: true),
                    InterruptionConsequence = table.Column<string>(nullable: true),
                    NewFlightNumber = table.Column<string>(nullable: true),
                    NewFlightDate = table.Column<DateTime>(nullable: true),
                    ClaimAmmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsProcessed = table.Column<bool>(nullable: true),
                    IsFinished = table.Column<bool>(nullable: true),
                    Created = table.Column<DateTime>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InterruptionConsequence",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsequenceId = table.Column<string>(nullable: true),
                    Consequence = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterruptionConsequence", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InterruptionResaon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReasonId = table.Column<string>(nullable: true),
                    Reason = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterruptionResaon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(nullable: true),
                    ClientNameId = table.Column<int>(nullable: true),
                    AmoutCancellation = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmoutPerDayDellay = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Client_ClientNameId",
                        column: x => x.ClientNameId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_ClientNameId",
                table: "Product",
                column: "ClientNameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Claim");

            migrationBuilder.DropTable(
                name: "InterruptionConsequence");

            migrationBuilder.DropTable(
                name: "InterruptionResaon");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
