using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoPatioAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Localizacoes",
                columns: table => new
                {
                    ID_LOCALIZACAO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PATIO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    VAGA = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SETOR = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizacoes", x => x.ID_LOCALIZACAO);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    ID_USUARIO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CARGO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TELEFONE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.ID_USUARIO);
                });

            migrationBuilder.CreateTable(
                name: "Motos",
                columns: table => new
                {
                    ID_MOTO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PLACA = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    MODELO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ANO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    STATUS = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ID_LOCALIZACAO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motos", x => x.ID_MOTO);
                    table.ForeignKey(
                        name: "FK_Motos_Localizacoes_ID_LOCALIZACAO",
                        column: x => x.ID_LOCALIZACAO,
                        principalTable: "Localizacoes",
                        principalColumn: "ID_LOCALIZACAO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manutencoes",
                columns: table => new
                {
                    ID_MANUTENCAO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DATA = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DESCRICAO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CUSTO = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ID_MOTO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manutencoes", x => x.ID_MANUTENCAO);
                    table.ForeignKey(
                        name: "FK_Manutencoes_Motos_ID_MOTO",
                        column: x => x.ID_MOTO,
                        principalTable: "Motos",
                        principalColumn: "ID_MOTO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    ID_RESERVA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DATA_RESERVA = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DATA_DEVOLUCAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ID_USUARIO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ID_MOTO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.ID_RESERVA);
                    table.ForeignKey(
                        name: "FK_Reservas_Motos_ID_MOTO",
                        column: x => x.ID_MOTO,
                        principalTable: "Motos",
                        principalColumn: "ID_MOTO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Usuarios_ID_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "Usuarios",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Manutencoes_ID_MOTO",
                table: "Manutencoes",
                column: "ID_MOTO");

            migrationBuilder.CreateIndex(
                name: "IX_Motos_ID_LOCALIZACAO",
                table: "Motos",
                column: "ID_LOCALIZACAO");

            migrationBuilder.CreateIndex(
                name: "IX_Motos_PLACA",
                table: "Motos",
                column: "PLACA",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_ID_MOTO",
                table: "Reservas",
                column: "ID_MOTO");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_ID_USUARIO",
                table: "Reservas",
                column: "ID_USUARIO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Manutencoes");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Motos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Localizacoes");
        }
    }
}
