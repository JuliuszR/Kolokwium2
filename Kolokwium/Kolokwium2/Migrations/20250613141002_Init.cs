using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kolokwium2.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Nurseries",
                columns: table => new
                {
                    NurseryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EstablishedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nurseries", x => x.NurseryId);
                });

            migrationBuilder.CreateTable(
                name: "TreeSpecies",
                columns: table => new
                {
                    SpeciesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LatinName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GrowthTimeInYears = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeSpecies", x => x.SpeciesId);
                });

            migrationBuilder.CreateTable(
                name: "SeedingBatches",
                columns: table => new
                {
                    BatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NurseryId = table.Column<int>(type: "int", nullable: false),
                    SpeciesId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SownDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReadyDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeedingBatches", x => x.BatchId);
                    table.ForeignKey(
                        name: "FK_SeedingBatches_Nurseries_NurseryId",
                        column: x => x.NurseryId,
                        principalTable: "Nurseries",
                        principalColumn: "NurseryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeedingBatches_TreeSpecies_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "TreeSpecies",
                        principalColumn: "SpeciesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Responsibles",
                columns: table => new
                {
                    BatchId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsibles", x => new { x.BatchId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_Responsibles_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Responsibles_SeedingBatches_BatchId",
                        column: x => x.BatchId,
                        principalTable: "SeedingBatches",
                        principalColumn: "BatchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "FirstName", "HireDate", "LastName" },
                values: new object[] { 1, "John", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smith" });

            migrationBuilder.InsertData(
                table: "Nurseries",
                columns: new[] { "NurseryId", "EstablishedDate", "Name" },
                values: new object[] { 1, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lesniczowka" });

            migrationBuilder.InsertData(
                table: "TreeSpecies",
                columns: new[] { "SpeciesId", "GrowthTimeInYears", "LatinName" },
                values: new object[] { 1, 100, "Lorem Ipsum" });

            migrationBuilder.InsertData(
                table: "SeedingBatches",
                columns: new[] { "BatchId", "NurseryId", "Quantity", "ReadyDate", "SownDate", "SpeciesId" },
                values: new object[] { 1, 1, 50, new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Responsibles",
                columns: new[] { "BatchId", "EmployeeId", "Role" },
                values: new object[] { 1, 1, "Zbieranie" });

            migrationBuilder.CreateIndex(
                name: "IX_Responsibles_EmployeeId",
                table: "Responsibles",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SeedingBatches_NurseryId",
                table: "SeedingBatches",
                column: "NurseryId");

            migrationBuilder.CreateIndex(
                name: "IX_SeedingBatches_SpeciesId",
                table: "SeedingBatches",
                column: "SpeciesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responsibles");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "SeedingBatches");

            migrationBuilder.DropTable(
                name: "Nurseries");

            migrationBuilder.DropTable(
                name: "TreeSpecies");
        }
    }
}
