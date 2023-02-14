using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission06_rcroft1.Migrations
{
    public partial class New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "responses",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(nullable: false),
                    year = table.Column<int>(nullable: false),
                    director = table.Column<string>(nullable: false),
                    rating = table.Column<string>(nullable: false),
                    edited = table.Column<bool>(nullable: false),
                    lentTo = table.Column<string>(nullable: true),
                    notes = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_responses", x => x.MovieId);
                });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "MovieId", "director", "edited", "lentTo", "notes", "rating", "title", "year" },
                values: new object[] { 1, "Joel Crawford", false, null, null, "Pg", "Puss in Boots", 2023 });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "MovieId", "director", "edited", "lentTo", "notes", "rating", "title", "year" },
                values: new object[] { 2, "Andrew Adamson", false, null, "Best movie ever", "Pg", "Shreck", 2001 });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "MovieId", "director", "edited", "lentTo", "notes", "rating", "title", "year" },
                values: new object[] { 3, "Conrad Vernon", false, null, "Second best movie ever", "Pg", "Shreck 2", 2004 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "responses");
        }
    }
}
