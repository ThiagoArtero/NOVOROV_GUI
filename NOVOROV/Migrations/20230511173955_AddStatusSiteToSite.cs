using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOVOROV.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusSiteToSite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusSiteId",
                table: "Site",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StatusSite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeStatusSite = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusSite", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Site_StatusSiteId",
                table: "Site",
                column: "StatusSiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Site_StatusSite_StatusSiteId",
                table: "Site",
                column: "StatusSiteId",
                principalTable: "StatusSite",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Site_StatusSite_StatusSiteId",
                table: "Site");

            migrationBuilder.DropTable(
                name: "StatusSite");

            migrationBuilder.DropIndex(
                name: "IX_Site_StatusSiteId",
                table: "Site");

            migrationBuilder.DropColumn(
                name: "StatusSiteId",
                table: "Site");
        }
    }
}
