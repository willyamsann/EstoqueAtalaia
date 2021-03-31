using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstoqueAtalaia.Migrations
{
    public partial class ORdemDeSerivco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrdemDeServicos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCliente = table.Column<string>(nullable: true),
                    EmailCliente = table.Column<string>(nullable: true),
                    TelefoneCliente = table.Column<string>(nullable: true),
                    Aparelho = table.Column<string>(nullable: true),
                    Detalhes = table.Column<string>(nullable: true),
                    Reclamacao = table.Column<string>(nullable: true),
                    Diagnostico = table.Column<string>(nullable: true),
                    Garantia = table.Column<string>(nullable: true),
                    ValorServico = table.Column<float>(nullable: false),
                    ValorPeca = table.Column<float>(nullable: false),
                    ValorTotal = table.Column<float>(nullable: false),
                    DataAbertura = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemDeServicos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdemDeServicos");
        }
    }
}
