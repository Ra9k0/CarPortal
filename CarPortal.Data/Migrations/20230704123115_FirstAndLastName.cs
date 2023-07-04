using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarPortal.Data.Migrations
{
    public partial class FirstAndLastName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Offers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 4, 12, 31, 14, 525, DateTimeKind.Utc).AddTicks(7111),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 4, 11, 57, 58, 502, DateTimeKind.Utc).AddTicks(1985));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3ba0e94f-d15f-4911-9bd0-e10e9d89397f"),
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName" },
                values: new object[] { "8396ddb2-2418-43fc-a1c7-6e84e850a91f", "Ceca", "Lepa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Offers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 4, 11, 57, 58, 502, DateTimeKind.Utc).AddTicks(1985),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 4, 12, 31, 14, 525, DateTimeKind.Utc).AddTicks(7111));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3ba0e94f-d15f-4911-9bd0-e10e9d89397f"),
                column: "ConcurrencyStamp",
                value: "3d166fc4-95a4-4a7a-9844-e177f3f54af2");
        }
    }
}
