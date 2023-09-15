using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalzburgProject.Migrations
{
    public partial class NovosCamposCusto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Parcelado",
                table: "Custos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "QtdParcelamento",
                table: "Custos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoPagamento",
                table: "Custos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Parcelado",
                table: "Custos");

            migrationBuilder.DropColumn(
                name: "QtdParcelamento",
                table: "Custos");

            migrationBuilder.DropColumn(
                name: "TipoPagamento",
                table: "Custos");
        }
    }
}
