using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AlterPerfilFuncionalidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerfilFuncionaidades_Funcionalidade_FuncionalidadeId",
                table: "PerfilFuncionaidades");

            migrationBuilder.DropForeignKey(
                name: "FK_PerfilFuncionaidades_Perfil_PerfilId",
                table: "PerfilFuncionaidades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PerfilFuncionaidades",
                table: "PerfilFuncionaidades");

            migrationBuilder.RenameTable(
                name: "PerfilFuncionaidades",
                newName: "PerfilFuncionalidade");

            migrationBuilder.RenameIndex(
                name: "IX_PerfilFuncionaidades_PerfilId",
                table: "PerfilFuncionalidade",
                newName: "IX_PerfilFuncionalidade_PerfilId");

            migrationBuilder.RenameIndex(
                name: "IX_PerfilFuncionaidades_FuncionalidadeId",
                table: "PerfilFuncionalidade",
                newName: "IX_PerfilFuncionalidade_FuncionalidadeId");


            migrationBuilder.AddPrimaryKey(
                name: "PK_PerfilFuncionalidade",
                table: "PerfilFuncionalidade",
                column: "Id");


            migrationBuilder.AddForeignKey(
                name: "FK_PerfilFuncionalidade_Funcionalidade_FuncionalidadeId",
                table: "PerfilFuncionalidade",
                column: "FuncionalidadeId",
                principalTable: "Funcionalidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PerfilFuncionalidade_Perfil_PerfilId",
                table: "PerfilFuncionalidade",
                column: "PerfilId",
                principalTable: "Perfil",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);



        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerfilFuncionalidade_Funcionalidade_FuncionalidadeId",
                table: "PerfilFuncionalidade");

            migrationBuilder.DropForeignKey(
                name: "FK_PerfilFuncionalidade_Perfil_PerfilId",
                table: "PerfilFuncionalidade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PerfilFuncionalidade",
                table: "PerfilFuncionalidade");


            migrationBuilder.RenameTable(
                name: "PerfilFuncionalidade",
                newName: "PerfilFuncionaidades");

            migrationBuilder.RenameIndex(
                name: "IX_PerfilFuncionalidade_PerfilId",
                table: "PerfilFuncionaidades",
                newName: "IX_PerfilFuncionaidades_PerfilId");

            migrationBuilder.RenameIndex(
                name: "IX_PerfilFuncionalidade_FuncionalidadeId",
                table: "PerfilFuncionaidades",
                newName: "IX_PerfilFuncionaidades_FuncionalidadeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PerfilFuncionaidades",
                table: "PerfilFuncionaidades",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PerfilFuncionaidades_Funcionalidade_FuncionalidadeId",
                table: "PerfilFuncionaidades",
                column: "FuncionalidadeId",
                principalTable: "Funcionalidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PerfilFuncionaidades_Perfil_PerfilId",
                table: "PerfilFuncionaidades",
                column: "PerfilId",
                principalTable: "Perfil",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
