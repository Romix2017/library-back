using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class RelationBooksToGenres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GenresFK",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "GenresId",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenresId",
                table: "Books",
                column: "GenresId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Genres_GenresId",
                table: "Books",
                column: "GenresId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Genres_GenresId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_GenresId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "GenresId",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "GenresFK",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
