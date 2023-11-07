using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddDataAcionamentoOperacionalToOcorrencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAcionamentoOperacional",
                table: "Ocorrencia",
                type: "datetime",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAcionamentoOperacional",
                table: "Ocorrencia");

        }
    }
}
