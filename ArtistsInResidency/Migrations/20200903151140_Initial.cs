using Microsoft.EntityFrameworkCore.Migrations;

namespace ArtistsInResidency.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "artists",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fName = table.Column<string>(nullable: false),
                    lName = table.Column<string>(nullable: false),
                    alias = table.Column<string>(nullable: true),
                    summary = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_artists", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "worksOfArt",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(nullable: true),
                    medium = table.Column<string>(nullable: false),
                    description = table.Column<string>(maxLength: 300, nullable: false),
                    yearCompleted = table.Column<int>(nullable: false),
                    ArtistModelid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_worksOfArt", x => x.id);
                    table.ForeignKey(
                        name: "FK_worksOfArt_artists_ArtistModelid",
                        column: x => x.ArtistModelid,
                        principalTable: "artists",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_worksOfArt_ArtistModelid",
                table: "worksOfArt",
                column: "ArtistModelid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "worksOfArt");

            migrationBuilder.DropTable(
                name: "artists");
        }
    }
}
