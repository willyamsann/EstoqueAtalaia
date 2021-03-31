using Microsoft.EntityFrameworkCore.Migrations;

namespace EstoqueAtalaia.Migrations
{
    public partial class ValorTotal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ValorTotal",
                table: "Products",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "Products");
        }
    }
}
