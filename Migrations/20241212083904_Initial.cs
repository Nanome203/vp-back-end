using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vp_back_end.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "FoodCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsHidden = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TableFood",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsHidden = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableFood", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Food",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdCategory = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    IsHidden = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Food_FoodCategory_IdCategory",
                        column: x => x.IdCategory,
                        principalTable: "FoodCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCheckOut = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdTable = table.Column<int>(type: "int", nullable: false),
                    IsServed = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bill_TableFood_IdTable",
                        column: x => x.IdTable,
                        principalTable: "TableFood",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBill = table.Column<int>(type: "int", nullable: false),
                    IdFood = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillInfo_Bill_IdBill",
                        column: x => x.IdBill,
                        principalTable: "Bill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillInfo_Food_IdFood",
                        column: x => x.IdFood,
                        principalTable: "Food",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bill_IdTable",
                table: "Bill",
                column: "IdTable");

            migrationBuilder.CreateIndex(
                name: "IX_BillInfo_IdBill",
                table: "BillInfo",
                column: "IdBill");

            migrationBuilder.CreateIndex(
                name: "IX_BillInfo_IdFood",
                table: "BillInfo",
                column: "IdFood");

            migrationBuilder.CreateIndex(
                name: "IX_Food_IdCategory",
                table: "Food",
                column: "IdCategory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "BillInfo");

            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "Food");

            migrationBuilder.DropTable(
                name: "TableFood");

            migrationBuilder.DropTable(
                name: "FoodCategory");
        }
    }
}
