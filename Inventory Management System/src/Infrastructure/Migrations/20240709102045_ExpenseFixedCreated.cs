using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ExpenseFixedCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpenseFixed",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IntervalDays = table.Column<int>(type: "INTEGER", nullable: false),
                    CostPerDay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseFixed", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ExpenseFixed",
                columns: new[] { "Id", "Amount", "CostPerDay", "InsertDate", "IntervalDays", "Name" },
                values: new object[,]
                {
                    { 1, 1200.00m, 40.00m, new DateTime(2024, 7, 9, 16, 20, 45, 481, DateTimeKind.Local).AddTicks(1958), 30, "Rent" },
                    { 2, 50.00m, 1.67m, new DateTime(2024, 7, 9, 16, 20, 45, 481, DateTimeKind.Local).AddTicks(1970), 30, "Internet" },
                    { 3, 100.00m, 3.33m, new DateTime(2024, 7, 9, 16, 20, 45, 481, DateTimeKind.Local).AddTicks(1972), 30, "Electricity" },
                    { 4, 300.00m, 0.82m, new DateTime(2024, 7, 9, 16, 20, 45, 481, DateTimeKind.Local).AddTicks(1974), 365, "Insurance" },
                    { 5, 150.00m, 1.67m, new DateTime(2024, 7, 9, 16, 20, 45, 481, DateTimeKind.Local).AddTicks(1975), 90, "Maintenance" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpenseFixed");
        }
    }
}
