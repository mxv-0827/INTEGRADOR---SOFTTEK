using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP_INTEGRADOR.Migrations
{
    public partial class EncryptedPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "CodUser",
                keyValue: 1,
                column: "Password",
                value: "68b1fdd831e67a17b839e8d35bc0ab110b10914e9c602fef1776caa0ae4df9bb");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "CodUser",
                keyValue: 2,
                column: "Password",
                value: "fa43bbefe428b0942306a45056ab3b53ec69664b8164d87bed99446e007b0655");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "CodUser",
                keyValue: 3,
                column: "Password",
                value: "e39b73ba4331b0d9f7fc186acd9ca5397d90a0dc5e802a91c39330c8172e3714");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "CodUser",
                keyValue: 4,
                column: "Password",
                value: "6fe6b6fb7bcf17346c519f86599d72422d9e9cbdbe04ebb33d13804b4ef2740f");

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "CodWork",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 9, 16, 20, 27, 8, 888, DateTimeKind.Local).AddTicks(4450));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "CodWork",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 9, 16, 20, 27, 8, 888, DateTimeKind.Local).AddTicks(4472));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "CodWork",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 9, 16, 20, 27, 8, 888, DateTimeKind.Local).AddTicks(4474));

            migrationBuilder.UpdateData(
                table: "Works",
                keyColumn: "CodWork",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2023, 9, 16, 20, 27, 8, 888, DateTimeKind.Local).AddTicks(4475));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "CodUser",
                keyValue: 1,
                column: "Password",
                value: "admin1234");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "CodUser",
                keyValue: 2,
                column: "Password",
                value: "admin4321");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "CodUser",
                keyValue: 3,
                column: "Password",
                value: "admin2468");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "CodUser",
                keyValue: 4,
                column: "Password",
                value: "admin1357");

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
        }
    }
}
