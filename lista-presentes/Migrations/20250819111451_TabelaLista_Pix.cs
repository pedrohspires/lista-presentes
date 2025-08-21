using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace lista_presentes.Migrations
{
    /// <inheritdoc />
    public partial class TabelaLista_Pix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "link",
                table: "lista");

            migrationBuilder.AddColumn<string>(
                name: "chave_pix",
                table: "lista",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "id_tipo_chave_pix",
                table: "lista",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "valor_pix",
                table: "lista",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "tipo_chave_pix",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descricao = table.Column<string>(type: "text", nullable: false),
                    data_cadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data_edicao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_chave_pix", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_lista_id_tipo_chave_pix",
                table: "lista",
                column: "id_tipo_chave_pix");

            migrationBuilder.AddForeignKey(
                name: "FK_lista_tipo_chave_pix_id_tipo_chave_pix",
                table: "lista",
                column: "id_tipo_chave_pix",
                principalTable: "tipo_chave_pix",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lista_tipo_chave_pix_id_tipo_chave_pix",
                table: "lista");

            migrationBuilder.DropTable(
                name: "tipo_chave_pix");

            migrationBuilder.DropIndex(
                name: "IX_lista_id_tipo_chave_pix",
                table: "lista");

            migrationBuilder.DropColumn(
                name: "chave_pix",
                table: "lista");

            migrationBuilder.DropColumn(
                name: "id_tipo_chave_pix",
                table: "lista");

            migrationBuilder.DropColumn(
                name: "valor_pix",
                table: "lista");

            migrationBuilder.AddColumn<string>(
                name: "link",
                table: "lista",
                type: "text",
                nullable: true);
        }
    }
}
