using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet.Migrations
{
    /// <inheritdoc />
    public partial class alteracaoItemXUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Itens_Usuarios_usuarioIDId",
                table: "Itens");

            migrationBuilder.RenameColumn(
                name: "usuarioIDId",
                table: "Itens",
                newName: "usuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Itens_usuarioIDId",
                table: "Itens",
                newName: "IX_Itens_usuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Itens_Usuarios_usuarioId",
                table: "Itens",
                column: "usuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Itens_Usuarios_usuarioId",
                table: "Itens");

            migrationBuilder.RenameColumn(
                name: "usuarioId",
                table: "Itens",
                newName: "usuarioIDId");

            migrationBuilder.RenameIndex(
                name: "IX_Itens_usuarioId",
                table: "Itens",
                newName: "IX_Itens_usuarioIDId");

            migrationBuilder.AddForeignKey(
                name: "FK_Itens_Usuarios_usuarioIDId",
                table: "Itens",
                column: "usuarioIDId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
