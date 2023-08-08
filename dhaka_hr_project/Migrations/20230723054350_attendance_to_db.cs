using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dhaka_hr_project.Migrations
{
    /// <inheritdoc />
    public partial class attendance_to_db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attendanses",
                columns: table => new
                {
                    AttId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    dtDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AttStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OutTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmpId = table.Column<string>(type: "nvarchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendanses", x => x.AttId);
                    table.ForeignKey(
                        name: "FK_Attendanses_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "ComId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Attendanses_Employees_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employees",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendanses_CompanyId",
                table: "Attendanses",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendanses_EmpId",
                table: "Attendanses",
                column: "EmpId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendanses");
        }
    }
}
