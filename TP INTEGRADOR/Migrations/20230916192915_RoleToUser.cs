using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP_INTEGRADOR.Migrations
{
    public partial class RoleToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "VARCHAR(250)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(15)");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    CodRole = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "VARCHAR(60)", nullable: false),
                    LeavingDate = table.Column<DateTime>(type: "DATE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.CodRole);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "CodRole", "Description", "LeavingDate" },
                values: new object[,]
                {
                    { 1, "Consultant", null },
                    { 2, "Administrator", null }
                });

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "CodWork",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 9, 16, 16, 29, 15, 44, DateTimeKind.Local).AddTicks(9931));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "CodWork",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 9, 16, 16, 29, 15, 44, DateTimeKind.Local).AddTicks(9955));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "CodWork",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 9, 16, 16, 29, 15, 44, DateTimeKind.Local).AddTicks(9958));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "CodWork",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2023, 9, 16, 16, 29, 15, 44, DateTimeKind.Local).AddTicks(9961));

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRole",
                table: "Users",
                column: "UserRole");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_UserRole",
                table: "Users",
                column: "UserRole",
                principalTable: "Roles",
                principalColumn: "CodRole",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_UserRole",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserRole",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "VARCHAR(15)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(250)");

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "CodWork",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 9, 11, 11, 39, 22, 923, DateTimeKind.Local).AddTicks(6587));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "CodWork",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 9, 11, 11, 39, 22, 923, DateTimeKind.Local).AddTicks(6607));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "CodWork",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 9, 11, 11, 39, 22, 923, DateTimeKind.Local).AddTicks(6609));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "CodWork",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2023, 9, 11, 11, 39, 22, 923, DateTimeKind.Local).AddTicks(6610));
        }
    }
}
