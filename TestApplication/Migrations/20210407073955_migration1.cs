using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApplication.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nomenclatures",
                columns: table => new
                {
                    Nomenclature_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nomenclatures", x => x.Nomenclature_Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Pass = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_Id);
                });

            migrationBuilder.InsertData(
                table: "Nomenclatures",
                columns: new[] { "Nomenclature_Id", "FromDate", "Name", "Price", "ToDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 4, 7, 10, 39, 52, 595, DateTimeKind.Local).AddTicks(3437), "Nom1", 10000m, new DateTime(2021, 4, 7, 10, 39, 52, 596, DateTimeKind.Local).AddTicks(800) },
                    { 2, new DateTime(2021, 4, 7, 10, 39, 52, 596, DateTimeKind.Local).AddTicks(1323), "Nom2", 20000m, new DateTime(2021, 4, 7, 10, 39, 52, 596, DateTimeKind.Local).AddTicks(1340) },
                    { 3, new DateTime(2021, 4, 7, 10, 39, 52, 596, DateTimeKind.Local).AddTicks(1348), "Nom3", 30000m, new DateTime(2021, 4, 7, 10, 39, 52, 596, DateTimeKind.Local).AddTicks(1349) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "User_Id", "Login", "Pass" },
                values: new object[,]
                {
                    { 1, "Login1", "password" },
                    { 2, "Login2", "qwerty" },
                    { 3, "Login3", "podsolnuh" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nomenclatures");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
