using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projeto_api.Migrations
{
    /// <inheritdoc />
    public partial class id_endereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Endereco_EnderecoIdEndereco",
                table: "Cliente");

            migrationBuilder.RenameColumn(
                name: "EnderecoIdEndereco",
                table: "Cliente",
                newName: "IdEndereco");

            migrationBuilder.RenameIndex(
                name: "IX_Cliente_EnderecoIdEndereco",
                table: "Cliente",
                newName: "IX_Cliente_IdEndereco");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Endereco_IdEndereco",
                table: "Cliente",
                column: "IdEndereco",
                principalTable: "Endereco",
                principalColumn: "IdEndereco",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Endereco_IdEndereco",
                table: "Cliente");

            migrationBuilder.RenameColumn(
                name: "IdEndereco",
                table: "Cliente",
                newName: "EnderecoIdEndereco");

            migrationBuilder.RenameIndex(
                name: "IX_Cliente_IdEndereco",
                table: "Cliente",
                newName: "IX_Cliente_EnderecoIdEndereco");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Endereco_EnderecoIdEndereco",
                table: "Cliente",
                column: "EnderecoIdEndereco",
                principalTable: "Endereco",
                principalColumn: "IdEndereco",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
