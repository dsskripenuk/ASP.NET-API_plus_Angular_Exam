using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_927.API_Angular.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblAnime",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: false),
                    ReleaseDate = table.Column<string>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAnime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblAnime_tblCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "tblCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblEpisodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Season = table.Column<int>(nullable: false),
                    Img_URL = table.Column<string>(nullable: false),
                    Video_URL = table.Column<string>(nullable: false),
                    AnimeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEpisodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblEpisodes_tblAnime_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "tblAnime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblScreenshots",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(nullable: false),
                    AnimeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblScreenshots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblScreenshots_tblAnime_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "tblAnime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblAnime_CategoryId",
                table: "tblAnime",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEpisodes_AnimeId",
                table: "tblEpisodes",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblScreenshots_AnimeId",
                table: "tblScreenshots",
                column: "AnimeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblEpisodes");

            migrationBuilder.DropTable(
                name: "tblScreenshots");

            migrationBuilder.DropTable(
                name: "tblAnime");

            migrationBuilder.DropTable(
                name: "tblCategory");
        }
    }
}
