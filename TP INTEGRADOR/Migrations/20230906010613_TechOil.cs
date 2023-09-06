using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP_INTEGRADOR.Migrations
{
    public partial class TechOil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    CodProject = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(40)", nullable: false),
                    Direction = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.CodProject);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    CodService = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    HourValue = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.CodService);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    CodUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(60)", nullable: false),
                    DNI = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(15)", nullable: false),
                    UserRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.CodUser);
                });

            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    CodWork = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "DATE", nullable: false),
                    CodProject = table.Column<int>(type: "int", nullable: false),
                    CodService = table.Column<int>(type: "int", nullable: false),
                    AmountHours = table.Column<int>(type: "int", nullable: false),
                    ValuePerHour = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: false),
                    Cost = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.CodWork);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "CodProject", "Direction", "Name", "State" },
                values: new object[] { 1, "Calle xD 1234", "Project number 1", false });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "CodService", "Description", "HourValue", "State" },
                values: new object[] { 1, "Un servicio que hace bla bla bla", 123m, true });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "CodUser", "DNI", "Name", "Password", "UserRole" },
                values: new object[] { 1, 12345678, "Maximiliano Viand", "admin1234", 1 });

            migrationBuilder.InsertData(
                table: "Works",
                columns: new[] { "CodWork", "AmountHours", "CodProject", "CodService", "Cost", "Date", "ValuePerHour" },
                values: new object[] { 1, 35, 1, 1, 420m, new DateTime(2023, 9, 5, 22, 6, 13, 502, DateTimeKind.Local).AddTicks(2286), 12m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Works");
        }
    }
}
