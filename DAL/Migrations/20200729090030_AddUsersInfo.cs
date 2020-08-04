using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddUsersInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Superuser" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DOB", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "RolesId", "UserName" },
                values: new object[] { 1, null, "Superuser", "Superuser", new byte[] { 99, 160, 97, 58, 35, 121, 184, 182, 55, 182, 191, 175, 214, 88, 22, 239, 62, 13, 143, 131, 161, 243, 77, 121, 183, 25, 246, 77, 88, 146, 252, 15, 171, 107, 63, 47, 24, 26, 200, 142, 66, 234, 117, 206, 111, 226, 250, 0, 76, 42, 192, 237, 86, 80, 99, 91, 107, 87, 8, 31, 203, 184, 215, 150 }, new byte[] { 196, 244, 51, 16, 200, 220, 128, 201, 227, 12, 89, 92, 145, 54, 56, 217, 25, 252, 202, 245, 218, 167, 160, 32, 241, 95, 136, 56, 169, 138, 245, 153, 178, 124, 221, 38, 25, 99, 151, 173, 231, 59, 72, 230, 200, 149, 19, 39, 169, 201, 75, 64, 108, 146, 37, 233, 43, 181, 198, 63, 59, 52, 232, 8, 246, 149, 8, 31, 179, 211, 197, 191, 118, 238, 131, 214, 83, 152, 115, 42, 134, 73, 169, 89, 230, 97, 71, 67, 32, 60, 157, 92, 126, 122, 125, 106, 50, 171, 204, 233, 69, 65, 238, 51, 147, 95, 205, 20, 17, 132, 116, 25, 172, 255, 255, 15, 208, 202, 229, 37, 95, 0, 229, 135, 205, 20, 135, 40 }, 1, "Superuser" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
