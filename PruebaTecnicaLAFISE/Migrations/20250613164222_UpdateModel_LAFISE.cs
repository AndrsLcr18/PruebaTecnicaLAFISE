using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnicaLAFISE.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModel_LAFISE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mensaje",
                table: "Transacciones",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mensaje",
                table: "Transacciones");
        }
    }
}
