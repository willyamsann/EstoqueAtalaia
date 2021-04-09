using Microsoft.EntityFrameworkCore.Migrations;

namespace EstoqueAtalaia.Migrations
{
    public partial class Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IMEI",
                table: "OrdemDeServicos",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Resta",
                table: "OrdemDeServicos",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Sinal",
                table: "OrdemDeServicos",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "CheckLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckLists", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckLists");

            migrationBuilder.DropColumn(
                name: "IMEI",
                table: "OrdemDeServicos");

            migrationBuilder.DropColumn(
                name: "Resta",
                table: "OrdemDeServicos");

            migrationBuilder.DropColumn(
                name: "Sinal",
                table: "OrdemDeServicos");
        }
    }
}
