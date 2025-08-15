using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lista_presentes.Migrations
{
    /// <inheritdoc />
    public partial class TabelaLista_UsuarioId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id_usuario",
                table: "lista",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "link",
                table: "lista",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_lista_id_usuario",
                table: "lista",
                column: "id_usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_lista_usuario_id_usuario",
                table: "lista",
                column: "id_usuario",
                principalTable: "usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lista_usuario_id_usuario",
                table: "lista");

            migrationBuilder.DropIndex(
                name: "IX_lista_id_usuario",
                table: "lista");

            migrationBuilder.DropColumn(
                name: "id_usuario",
                table: "lista");

            migrationBuilder.DropColumn(
                name: "link",
                table: "lista");
        }
    }
}
