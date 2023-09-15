using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalzburgProject.Migrations
{
    public partial class FieldValorCusto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "Custos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Custos");
        }
    }
}
