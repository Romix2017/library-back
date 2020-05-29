using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddRelationsToBooksHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RolesFK",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BooksFK",
                table: "BooksHistory");

            migrationBuilder.DropColumn(
                name: "UsersFK",
                table: "BooksHistory");

            migrationBuilder.AddColumn<int>(
                name: "RolesId",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BooksId",
                table: "BooksHistory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "BooksHistory",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_BooksHistory_Books_BooksId",
                table: "BooksHistory",
                column: "BooksId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BooksHistory_Users_UsersId",
                table: "BooksHistory",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RolesId",
                table: "Users",
                column: "RolesId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BooksHistory_Books_BooksId",
                table: "BooksHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_BooksHistory_Users_UsersId",
                table: "BooksHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RolesId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RolesId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_BooksHistory_BooksId",
                table: "BooksHistory");

            migrationBuilder.DropIndex(
                name: "IX_BooksHistory_UsersId",
                table: "BooksHistory");

            migrationBuilder.DropColumn(
                name: "RolesId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BooksId",
                table: "BooksHistory");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "BooksHistory");

            migrationBuilder.AddColumn<int>(
                name: "RolesFK",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BooksFK",
                table: "BooksHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsersFK",
                table: "BooksHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
