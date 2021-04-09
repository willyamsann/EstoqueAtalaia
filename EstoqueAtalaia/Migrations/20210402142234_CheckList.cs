using Microsoft.EntityFrameworkCore.Migrations;

namespace EstoqueAtalaia.Migrations
{
    public partial class CheckList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CheckList",
                table: "OrdemDeServicos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckList",
                table: "OrdemDeServicos");
        }
    }
}
