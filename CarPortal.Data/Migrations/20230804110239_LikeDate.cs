using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarPortal.Data.Migrations
{
    public partial class LikeDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LikeDate",
                table: "Likes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3ba0e94f-d15f-4911-9bd0-e10e9d89397f"),
                column: "ConcurrencyStamp",
                value: "afd51c9c-1774-4a06-9721-d24f92ae6114");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LikeDate",
                table: "Likes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3ba0e94f-d15f-4911-9bd0-e10e9d89397f"),
                column: "ConcurrencyStamp",
                value: "94b79915-5ebe-418b-ba79-db5b405d8873");
        }
    }
}
