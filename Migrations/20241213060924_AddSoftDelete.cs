using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vp_back_end.Migrations
{
    /// <inheritdoc />
    public partial class AddSoftDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsHidden",
                table: "BillInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsHidden",
                table: "Bill",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsHidden",
                table: "Account",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "BillInfo");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "Bill");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "Account");
        }
    }
}
