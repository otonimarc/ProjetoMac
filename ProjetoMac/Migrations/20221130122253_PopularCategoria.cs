using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoMac.Migrations
{
    
    public partial class PopularCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categoria(CategoriaNome, Descricao)" +
                                 "VALUES('Normal', 'Lanche feito com ingredientes normais')");
            migrationBuilder.Sql("INSERT INTO Categoria(CategoriaNome, Descricao)" +
                                 "VALUES('Natural', 'Lanche feito com ingredientes naturais')");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categoria");
        }
    }
}
