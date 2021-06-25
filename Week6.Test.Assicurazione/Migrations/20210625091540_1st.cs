using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Week6.Test.Assicurazione.Migrations
{
    public partial class _1st : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    CF = table.Column<string>(type: "nchar(16)", fixedLength: true, maxLength: 16, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.CF);
                });

            migrationBuilder.CreateTable(
                name: "Policy",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateDrafting = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsuredAmount = table.Column<float>(type: "real", nullable: false),
                    MonthlyRate = table.Column<float>(type: "real", nullable: false),
                    ClientCF = table.Column<string>(type: "nchar(16)", nullable: true),
                    Policytype = table.Column<string>(name: "Policy type", type: "nvarchar(max)", nullable: false),
                    Plate = table.Column<string>(type: "nchar(5)", fixedLength: true, maxLength: 5, nullable: true),
                    Displacement = table.Column<int>(type: "int", nullable: true),
                    AgeInsured = table.Column<int>(type: "int", nullable: true),
                    PercentageCovered = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policy", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Policy_Client_ClientCF",
                        column: x => x.ClientCF,
                        principalTable: "Client",
                        principalColumn: "CF",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "CF", "Address", "Name", "Surname" },
                values: new object[] { "DFNBLL67D56P874P", "via Bernabei, 50", "Dafne", "Bella" });

            migrationBuilder.InsertData(
                table: "Policy",
                columns: new[] { "Number", "ClientCF", "DateDrafting", "Displacement", "InsuredAmount", "MonthlyRate", "Plate", "Policy type" },
                values: new object[] { 1, null, new DateTime(2019, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 15000f, 145.87f, "CP026", "Car insurance" });

            migrationBuilder.InsertData(
                table: "Policy",
                columns: new[] { "Number", "AgeInsured", "ClientCF", "DateDrafting", "InsuredAmount", "MonthlyRate", "Policy type" },
                values: new object[] { 3, 55, null, new DateTime(2019, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 15000f, 145.87f, "Life policy" });

            migrationBuilder.InsertData(
                table: "Policy",
                columns: new[] { "Number", "ClientCF", "DateDrafting", "InsuredAmount", "MonthlyRate", "PercentageCovered", "Policy type" },
                values: new object[] { 2, null, new DateTime(2019, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 15000f, 145.87f, 15, "Threft policy" });

            migrationBuilder.CreateIndex(
                name: "IX_Policy_ClientCF",
                table: "Policy",
                column: "ClientCF");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Policy");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
