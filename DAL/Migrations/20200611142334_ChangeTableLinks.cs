using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ChangeTableLinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_RolesId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_BooksHistory_BooksId",
                table: "BooksHistory");

            migrationBuilder.DropIndex(
                name: "IX_BooksHistory_UsersId",
                table: "BooksHistory");

            migrationBuilder.DropIndex(
                name: "IX_Books_GenresId",
                table: "Books");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RolesId",
                table: "Users",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksHistory_BooksId",
                table: "BooksHistory",
                column: "BooksId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksHistory_UsersId",
                table: "BooksHistory",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenresId",
                table: "Books",
                column: "GenresId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_RolesId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_BooksHistory_BooksId",
                table: "BooksHistory");

            migrationBuilder.DropIndex(
                name: "IX_BooksHistory_UsersId",
                table: "BooksHistory");

            migrationBuilder.DropIndex(
                name: "IX_Books_GenresId",
                table: "Books");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RolesId",
                table: "Users",
                column: "RolesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BooksHistory_BooksId",
                table: "BooksHistory",
                column: "BooksId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BooksHistory_UsersId",
                table: "BooksHistory",
                column: "UsersId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenresId",
                table: "Books",
                column: "GenresId",
                unique: true);
        }
    }
}
