using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dhaka_hr_project.Migrations
{
    /// <inheritdoc />
    public partial class p : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendanses_Companies_CompanyId",
                table: "Attendanses");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendanses_Employees_EmpId",
                table: "Attendanses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendanses",
                table: "Attendanses");

            migrationBuilder.RenameTable(
                name: "Attendanses",
                newName: "Attendances");

            migrationBuilder.RenameIndex(
                name: "IX_Attendanses_EmpId",
                table: "Attendances",
                newName: "IX_Attendances_EmpId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendanses_CompanyId",
                table: "Attendances",
                newName: "IX_Attendances_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances",
                column: "AttId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Companies_CompanyId",
                table: "Attendances",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "ComId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Employees_EmpId",
                table: "Attendances",
                column: "EmpId",
                principalTable: "Employees",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Companies_CompanyId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Employees_EmpId",
                table: "Attendances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances");

            migrationBuilder.RenameTable(
                name: "Attendances",
                newName: "Attendanses");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_EmpId",
                table: "Attendanses",
                newName: "IX_Attendanses_EmpId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_CompanyId",
                table: "Attendanses",
                newName: "IX_Attendanses_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendanses",
                table: "Attendanses",
                column: "AttId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendanses_Companies_CompanyId",
                table: "Attendanses",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "ComId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendanses_Employees_EmpId",
                table: "Attendanses",
                column: "EmpId",
                principalTable: "Employees",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
