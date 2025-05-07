using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomobiliuPardavimoPrograma.Migrations
{
    /// <inheritdoc />
    public partial class Add_UserPostLikes_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserPostLikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
        }
    }
}
