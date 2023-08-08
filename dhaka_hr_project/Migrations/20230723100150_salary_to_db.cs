using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dhaka_hr_project.Migrations
{
    /// <inheritdoc />
    public partial class salary_to_db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Salarys",
                columns: table => new
                {
                    SalId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    dtYear = table.Column<int>(type: "int", nullable: false),
                    dtMonth = table.Column<int>(type: "int", nullable: false),
                    Gross = table.Column<double>(type: "float", nullable: false),
                    Basic = table.Column<double>(type: "float", nullable: false),
                    HRent = table.Column<double>(type: "float", nullable: false),
                    Medical = table.Column<double>(type: "float", nullable: false),
                    AbsentAmount = table.Column<double>(type: "float", nullable: false),
                    PayableAmount = table.Column<double>(type: "float", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    PaidAmount = table.Column<double>(type: "float", nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmpId = table.Column<string>(type: "nvarchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salarys", x => x.SalId);
                    table.ForeignKey(
                        name: "FK_Salarys_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "ComId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Salarys_Employees_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employees",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Salarys_CompanyId",
                table: "Salarys",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Salarys_EmpId",
                table: "Salarys",
                column: "EmpId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Salarys");
        }
    }
}
