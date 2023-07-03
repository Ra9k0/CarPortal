using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarPortal.Data.Migrations
{
    public partial class ChangeImagePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Offers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 3, 21, 34, 11, 30, DateTimeKind.Utc).AddTicks(8368),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 3, 20, 6, 15, 914, DateTimeKind.Utc).AddTicks(2997));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3ba0e94f-d15f-4911-9bd0-e10e9d89397f"),
                column: "ConcurrencyStamp",
                value: "f54eb0d2-8be3-4663-92c6-8676c6ca8dba");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhotoPath",
                value: "OfferImages/test1.jpeg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "PhotoPath",
                value: "OfferImages/test2.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "PhotoPath",
                value: "OfferImages/test3.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Offers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 3, 20, 6, 15, 914, DateTimeKind.Utc).AddTicks(2997),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 3, 21, 34, 11, 30, DateTimeKind.Utc).AddTicks(8368));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3ba0e94f-d15f-4911-9bd0-e10e9d89397f"),
                column: "ConcurrencyStamp",
                value: "776598b8-cb40-4154-9168-641976e71cbf");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhotoPath",
                value: "~/OfferImages/test1.jpeg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "PhotoPath",
                value: "~/OfferImages/test2.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "PhotoPath",
                value: "~/OfferImages/test3.jpg");
        }
    }
}
