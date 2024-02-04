using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class Hospital_20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Opds",
                columns: table => new
                {
                    OPDId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100, 1"),
                    FulName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    Disease = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opds", x => x.OPDId);
                    table.ForeignKey(
                        name: "FK_Opds_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Opds_Doctors_UserId",
                        column: x => x.UserId,
                        principalTable: "Doctors",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Opds_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Opds_DepartmentId",
                table: "Opds",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Opds_PatientId",
                table: "Opds",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Opds_UserId",
                table: "Opds",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Opds");
        }
    }
}
