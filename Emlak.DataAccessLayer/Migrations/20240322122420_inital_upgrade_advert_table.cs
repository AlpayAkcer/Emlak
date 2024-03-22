using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emlak.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class inital_upgrade_advert_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Adverts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Adverts");
        }
    }
}
