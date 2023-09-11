using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP_INTEGRADOR.Migrations
{
    public partial class FKsImplementadas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LeavingDate",
                table: "Works",
                type: "DATE",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LeavingDate",
                table: "Users",
                type: "DATE",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LeavingDate",
                table: "Services",
                type: "DATE",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LeavingDate",
                table: "Projects",
                type: "DATE",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Works_CodProject",
                table: "Works",
                column: "CodProject");

            migrationBuilder.CreateIndex(
                name: "IX_Works_CodService",
                table: "Works",
                column: "CodService");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Projects_CodProject",
                table: "Works",
                column: "CodProject",
                principalTable: "Projects",
                principalColumn: "CodProject",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Services_CodService",
                table: "Works",
                column: "CodService",
                principalTable: "Services",
                principalColumn: "CodService",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_Projects_CodProject",
                table: "Works");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Services_CodService",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Works_CodProject",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Works_CodService",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "LeavingDate",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "LeavingDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LeavingDate",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "LeavingDate",
                table: "Projects");

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "CodWork",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 9, 10, 16, 54, 3, 48, DateTimeKind.Local).AddTicks(9796));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "CodWork",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 9, 10, 16, 54, 3, 48, DateTimeKind.Local).AddTicks(9827));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "CodWork",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 9, 10, 16, 54, 3, 48, DateTimeKind.Local).AddTicks(9832));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "CodWork",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2023, 9, 10, 16, 54, 3, 48, DateTimeKind.Local).AddTicks(9836));
        }
    }
}
