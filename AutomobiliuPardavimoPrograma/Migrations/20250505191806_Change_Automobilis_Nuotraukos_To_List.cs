using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomobiliuPardavimoPrograma.Migrations
{
    /// <inheritdoc />
    public partial class Change_Automobilis_Nuotraukos_To_List : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nuotrauka",
                table: "Automobiliai",
                newName: "Nuotraukos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nuotraukos",
                table: "Automobiliai",
                newName: "Nuotrauka");
        }
    }
}
