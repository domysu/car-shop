using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomobiliuPardavimoPrograma.Migrations
{
    /// <inheritdoc />
    public partial class Change_Automobilis_Change_Nuotraukos_To_List : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Aprasymas",
                table: "Automobiliai",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aprasymas",
                table: "Automobiliai");
        }
    }
}
