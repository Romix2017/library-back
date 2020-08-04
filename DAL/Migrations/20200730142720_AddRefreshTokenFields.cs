using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddRefreshTokenFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 116, 21, 196, 24, 180, 38, 238, 60, 220, 49, 38, 56, 107, 128, 253, 32, 107, 229, 241, 79, 72, 85, 143, 182, 181, 222, 19, 64, 186, 171, 108, 233, 95, 87, 48, 13, 120, 232, 176, 226, 219, 73, 171, 51, 241, 13, 219, 254, 193, 99, 148, 26, 147, 127, 112, 4, 225, 148, 155, 73, 190, 148, 243, 7 }, new byte[] { 134, 194, 23, 0, 167, 23, 172, 251, 221, 139, 50, 94, 5, 41, 78, 133, 101, 68, 80, 121, 86, 200, 104, 100, 14, 117, 94, 136, 119, 196, 137, 119, 24, 151, 224, 8, 199, 47, 78, 16, 158, 151, 151, 235, 140, 201, 62, 73, 144, 163, 81, 130, 130, 168, 2, 113, 128, 136, 173, 143, 69, 159, 178, 134, 201, 72, 163, 117, 106, 112, 53, 178, 71, 79, 243, 182, 135, 250, 136, 117, 181, 217, 55, 237, 163, 91, 227, 206, 107, 72, 52, 140, 50, 69, 226, 226, 58, 160, 169, 200, 1, 110, 72, 98, 92, 164, 224, 102, 157, 130, 202, 85, 17, 185, 113, 90, 71, 171, 201, 145, 162, 162, 55, 197, 193, 177, 193, 75 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 99, 160, 97, 58, 35, 121, 184, 182, 55, 182, 191, 175, 214, 88, 22, 239, 62, 13, 143, 131, 161, 243, 77, 121, 183, 25, 246, 77, 88, 146, 252, 15, 171, 107, 63, 47, 24, 26, 200, 142, 66, 234, 117, 206, 111, 226, 250, 0, 76, 42, 192, 237, 86, 80, 99, 91, 107, 87, 8, 31, 203, 184, 215, 150 }, new byte[] { 196, 244, 51, 16, 200, 220, 128, 201, 227, 12, 89, 92, 145, 54, 56, 217, 25, 252, 202, 245, 218, 167, 160, 32, 241, 95, 136, 56, 169, 138, 245, 153, 178, 124, 221, 38, 25, 99, 151, 173, 231, 59, 72, 230, 200, 149, 19, 39, 169, 201, 75, 64, 108, 146, 37, 233, 43, 181, 198, 63, 59, 52, 232, 8, 246, 149, 8, 31, 179, 211, 197, 191, 118, 238, 131, 214, 83, 152, 115, 42, 134, 73, 169, 89, 230, 97, 71, 67, 32, 60, 157, 92, 126, 122, 125, 106, 50, 171, 204, 233, 69, 65, 238, 51, 147, 95, 205, 20, 17, 132, 116, 25, 172, 255, 255, 15, 208, 202, 229, 37, 95, 0, 229, 135, 205, 20, 135, 40 } });
        }
    }
}
