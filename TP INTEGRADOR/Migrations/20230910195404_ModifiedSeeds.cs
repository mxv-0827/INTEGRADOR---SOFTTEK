using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP_INTEGRADOR.Migrations
{
    public partial class ModifiedSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "State",
                table: "Projects",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "CodProject",
                keyValue: 1,
                column: "State",
                value: 1);

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "CodProject", "Direction", "Name", "State" },
                values: new object[,]
                {
                    { 2, "Calle xD 5678", "Project number 2", 2 },
                    { 3, "Calle xD 9102", "Project number 3", 3 },
                    { 4, "Calle xD 3456", "Project number 4", 1 }
                });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "CodService",
                keyValue: 1,
                columns: new[] { "Description", "HourValue" },
                values: new object[] { "aaa", 80m });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "CodService", "Description", "HourValue", "State" },
                values: new object[,]
                {
                    { 2, "bbb", 12m, false },
                    { 3, "ccc", 20m, true },
                    { 4, "ddd", 65m, false }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "CodUser",
                keyValue: 1,
                column: "Name",
                value: "Maxi Viand");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "CodUser", "DNI", "Name", "Password", "UserRole" },
                values: new object[,]
                {
                    { 2, 13245678, "Cris Viand", "admin4321", 2 },
                    { 3, 87654321, "Gerardo Viand", "admin2468", 1 },
                    { 4, 67891234, "Adriana Neporadnyj", "admin1357", 2 }
                });

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "CodWork",
                keyValue: 1,
                columns: new[] { "AmountHours", "CodProject", "CodService", "Cost", "Date", "ValuePerHour" },
                values: new object[] { 1, 4, 4, 5m, new DateTime(2023, 9, 10, 16, 54, 3, 48, DateTimeKind.Local).AddTicks(9796), 5m });

            migrationBuilder.InsertData(
                table: "Works",
                columns: new[] { "CodWork", "AmountHours", "CodProject", "CodService", "Cost", "Date", "ValuePerHour" },
                values: new object[,]
                {
                    { 2, 2, 3, 3, 12m, new DateTime(2023, 9, 10, 16, 54, 3, 48, DateTimeKind.Local).AddTicks(9827), 6m },
                    { 3, 3, 2, 2, 21m, new DateTime(2023, 9, 10, 16, 54, 3, 48, DateTimeKind.Local).AddTicks(9832), 7m },
                    { 4, 4, 1, 1, 32m, new DateTime(2023, 9, 10, 16, 54, 3, 48, DateTimeKind.Local).AddTicks(9836), 8m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "CodProject",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "CodProject",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "CodProject",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "CodService",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "CodService",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "CodService",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "CodUser",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "CodUser",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "CodUser",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Works",
                keyColumn: "CodWork",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Works",
                keyColumn: "CodWork",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Works",
                keyColumn: "CodWork",
                keyValue: 4);

            migrationBuilder.AlterColumn<bool>(
                name: "State",
                table: "Projects",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "CodProject",
                keyValue: 1,
                column: "State",
                value: false);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "CodService",
                keyValue: 1,
                columns: new[] { "Description", "HourValue" },
                values: new object[] { "Un servicio que hace bla bla bla", 123m });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "CodUser",
                keyValue: 1,
                column: "Name",
                value: "Maximiliano Viand");

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "CodWork",
                keyValue: 1,
                columns: new[] { "AmountHours", "CodProject", "CodService", "Cost", "Date", "ValuePerHour" },
                values: new object[] { 35, 1, 1, 420m, new DateTime(2023, 9, 5, 22, 6, 13, 502, DateTimeKind.Local).AddTicks(2286), 12m });
        }
    }
}
