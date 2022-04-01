using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanchesMac.Migrations
{
    public partial class PopularLanches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO [dbo].[Lanches]
                                    ([Nome]
                                    ,[DescricaoCurta]
                                    ,[DescricaoDetalhada]
                                    ,[Preco]
                                    ,[imagemUrl]
                                    ,[imagemThumbNailUrl]
                                    ,[LanchePreferido]
                                    ,[EmEstoque]
                                    ,[CategoriaId])
                                VALUES
                                    ('Hamburguer de costela'
                                    ,'Hamburgeur de costela bovina assada no bafo'
                                    ,'Hamburgeur de costela bovina assada no bafo com tomates, alface, manjericão e pimenta'
                                    ,30.5
                                    ,'./images/Hamburger1.jpg'
                                    ,'./images/Hamburger1.jpg'
                                    ,1
                                    ,1
                                    ,1)");
            migrationBuilder.Sql(@"INSERT INTO [dbo].[Lanches]
                                    ([Nome]
                                    ,[DescricaoCurta]
                                    ,[DescricaoDetalhada]
                                    ,[Preco]
                                    ,[imagemUrl]
                                    ,[imagemThumbNailUrl]
                                    ,[LanchePreferido]
                                    ,[EmEstoque]
                                    ,[CategoriaId])
                                VALUES
                                    ('Hamburguer pig'
                                    ,'Hamburgeur de carne suina'
                                    ,'Hamburgeur de carne suina defumada com picles, alface, manjericão e pimenta'
                                    ,29.9
                                    ,'./images/Hamburger2.jpg'
                                    ,'./images/Hamburger2.jpg'
                                    ,1
                                    ,1
                                    ,1)");                                 
            migrationBuilder.Sql(@"INSERT INTO [dbo].[Lanches]
                                    ([Nome]
                                    ,[DescricaoCurta]
                                    ,[DescricaoDetalhada]
                                    ,[Preco]
                                    ,[imagemUrl]
                                    ,[imagemThumbNailUrl]
                                    ,[LanchePreferido]
                                    ,[EmEstoque]
                                    ,[CategoriaId])
                                VALUES
                                    ('Hamburguer Sarado'
                                    ,'Hamburgeur de carne de soja'
                                    ,'Hamburgeur de carne de soja com beringela, alface, manjericão e pimenta'
                                    ,61.89
                                    ,'./images/Hamburger3.jpg'
                                    ,'./images/Hamburger3.jpg'
                                    ,1
                                    ,1
                                    ,2)");                
            migrationBuilder.Sql(@"INSERT INTO [dbo].[Lanches]
                                    ([Nome]
                                    ,[DescricaoCurta]
                                    ,[DescricaoDetalhada]
                                    ,[Preco]
                                    ,[imagemUrl]
                                    ,[imagemThumbNailUrl]
                                    ,[LanchePreferido]
                                    ,[EmEstoque]
                                    ,[CategoriaId])
                                VALUES
                                    ('Sanduiche de mortadela'
                                    ,'Hamburgeur de mortadela'
                                    ,'Hamburgeur de mortadela com tomates em conserva, alface, manjericão e pimenta'
                                    ,45
                                    ,'./images/Hamburger3.jpg'
                                    ,'./images/Hamburger3.jpg'
                                    ,1
                                    ,1
                                    ,1)");                                                                 
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Lanches");

        }
    }
}
