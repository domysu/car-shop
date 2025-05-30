using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AutomobiliuPardavimoPrograma.Migrations
{
    /// <inheritdoc />
    public partial class InitialPostgres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Automobiliai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Marke = table.Column<string>(type: "text", nullable: false),
                    Modelis = table.Column<string>(type: "text", nullable: false),
                    Metai = table.Column<int>(type: "integer", nullable: false),
                    Rida = table.Column<int>(type: "integer", nullable: false),
                    Kaina = table.Column<decimal>(type: "numeric", nullable: false),
                    PavaruDeze = table.Column<string>(type: "text", nullable: false),
                    KuroTipas = table.Column<string>(type: "text", nullable: false),
                    Nuotraukos = table.Column<List<string>>(type: "text[]", nullable: false),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    Aprasymas = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automobiliai", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vartotojai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Vardas = table.Column<string>(type: "text", nullable: false),
                    ElPastas = table.Column<string>(type: "text", nullable: false),
                    SlaptazodisHash = table.Column<string>(type: "text", nullable: false),
                    YraAdmin = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vartotojai", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPostLikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    PostId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPostLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPostLikes_Automobiliai_PostId",
                        column: x => x.PostId,
                        principalTable: "Automobiliai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPostLikes_Vartotojai_UserId",
                        column: x => x.UserId,
                        principalTable: "Vartotojai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPostLikes_PostId",
                table: "UserPostLikes",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPostLikes_UserId",
                table: "UserPostLikes",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPostLikes");

            migrationBuilder.DropTable(
                name: "Automobiliai");

            migrationBuilder.DropTable(
                name: "Vartotojai");
        }
    }
}
