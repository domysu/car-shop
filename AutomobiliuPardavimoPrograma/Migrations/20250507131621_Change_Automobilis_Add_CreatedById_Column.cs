using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomobiliuPardavimoPrograma.Migrations
{
    /// <inheritdoc />
    public partial class Change_Automobilis_Add_CreatedById_Column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Automobiliai",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Automobiliai");
        }
    }
}
