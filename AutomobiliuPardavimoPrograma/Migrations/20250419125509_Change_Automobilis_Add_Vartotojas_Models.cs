using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomobiliuPardavimoPrograma.Migrations
{
    /// <inheritdoc />
    public partial class Change_Automobilis_Add_Vartotojas_Models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Automobiliai",
                keyColumn: "Modelis",
                keyValue: null,
                column: "Modelis",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Modelis",
                table: "Automobiliai",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Automobiliai",
                keyColumn: "Marke",
                keyValue: null,
                column: "Marke",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Marke",
                table: "Automobiliai",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "KuroTipas",
                table: "Automobiliai",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Metai",
                table: "Automobiliai",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nuotrauka",
                table: "Automobiliai",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PavaruDeze",
                table: "Automobiliai",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Rida",
                table: "Automobiliai",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KuroTipas",
                table: "Automobiliai");

            migrationBuilder.DropColumn(
                name: "Metai",
                table: "Automobiliai");

            migrationBuilder.DropColumn(
                name: "Nuotrauka",
                table: "Automobiliai");

            migrationBuilder.DropColumn(
                name: "PavaruDeze",
                table: "Automobiliai");

            migrationBuilder.DropColumn(
                name: "Rida",
                table: "Automobiliai");

            migrationBuilder.AlterColumn<string>(
                name: "Modelis",
                table: "Automobiliai",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Marke",
                table: "Automobiliai",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
