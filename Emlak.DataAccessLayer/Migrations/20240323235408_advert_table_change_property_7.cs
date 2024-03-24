using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emlak.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class advert_table_change_property_7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Neighbourhoods");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Districts");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Cities");

            migrationBuilder.AddColumn<string>(
                name: "PostaCode",
                table: "Neighbourhoods",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostaCode",
                table: "Neighbourhoods");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Neighbourhoods",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Districts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Cities",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
