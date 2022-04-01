using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanchesMac.Migrations
{
    public partial class PopularCategorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias(Nome, Descricao) VALUES('Normal','Lanche Feito com Ingredientes Normais')");
            migrationBuilder.Sql("INSERT INTO Categorias(Nome, Descricao) VALUES('Natural','Lanche Feito com Ingredientes Integrais e Naturais')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
        }
    }
}
