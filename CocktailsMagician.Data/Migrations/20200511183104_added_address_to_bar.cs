using Microsoft.EntityFrameworkCore.Migrations;

namespace CocktailsMagician.Data.Migrations
{
    public partial class added_address_to_bar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Bars",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Bars");
        }
    }
}
