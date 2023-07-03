using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeuProjetoApi.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoTabelaProjetos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projetos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCliente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tensao = table.Column<int>(type: "int", nullable: false),
                    Potencia = table.Column<double>(type: "float", nullable: false),
                    QntBobinas = table.Column<int>(type: "int", nullable: false),
                    ValorProjeto = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projetos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projetos");
        }
    }
}
