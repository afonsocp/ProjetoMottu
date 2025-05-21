using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoPatioAPI.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarColunaSenha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TELEFONE",
                table: "Usuarios",
                newName: "SENHA");

            migrationBuilder.RenameColumn(
                name: "CARGO",
                table: "Usuarios",
                newName: "EMAIL");

            migrationBuilder.RenameColumn(
                name: "VAGA",
                table: "Localizacoes",
                newName: "Estado");

            migrationBuilder.RenameColumn(
                name: "SETOR",
                table: "Localizacoes",
                newName: "ENDERECO");

            migrationBuilder.RenameColumn(
                name: "PATIO",
                table: "Localizacoes",
                newName: "Cidade");

            migrationBuilder.AddColumn<string>(
                name: "CEP",
                table: "Localizacoes",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CEP",
                table: "Localizacoes");

            migrationBuilder.RenameColumn(
                name: "SENHA",
                table: "Usuarios",
                newName: "TELEFONE");

            migrationBuilder.RenameColumn(
                name: "EMAIL",
                table: "Usuarios",
                newName: "CARGO");

            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "Localizacoes",
                newName: "VAGA");

            migrationBuilder.RenameColumn(
                name: "ENDERECO",
                table: "Localizacoes",
                newName: "SETOR");

            migrationBuilder.RenameColumn(
                name: "Cidade",
                table: "Localizacoes",
                newName: "PATIO");
        }
    }
}
