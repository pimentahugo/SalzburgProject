using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalzburgProject.Migrations
{
    public partial class AtributoParcelaAtual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ParcelaAtual",
                table: "Custos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParcelaAtual",
                table: "Custos");
        }
    }
}
