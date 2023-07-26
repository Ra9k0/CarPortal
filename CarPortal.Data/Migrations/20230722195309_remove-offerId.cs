using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarPortal.Data.Migrations
{
    public partial class removeofferId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Offers_OfferId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Offers_CarId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Cars_OfferId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "OfferId",
                table: "Cars");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Offers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 22, 19, 53, 8, 742, DateTimeKind.Utc).AddTicks(5705),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 22, 19, 44, 38, 99, DateTimeKind.Utc).AddTicks(8621));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3ba0e94f-d15f-4911-9bd0-e10e9d89397f"),
                column: "ConcurrencyStamp",
                value: "8708ca08-e3b7-486e-9eae-ca632db782f7");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_CarId",
                table: "Offers",
                column: "CarId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Offers_CarId",
                table: "Offers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Offers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 22, 19, 44, 38, 99, DateTimeKind.Utc).AddTicks(8621),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 22, 19, 53, 8, 742, DateTimeKind.Utc).AddTicks(5705));

            migrationBuilder.AddColumn<Guid>(
                name: "OfferId",
                table: "Cars",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3ba0e94f-d15f-4911-9bd0-e10e9d89397f"),
                column: "ConcurrencyStamp",
                value: "e8e79cba-b045-4eef-a1cf-75e80309cef6");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_CarId",
                table: "Offers",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_OfferId",
                table: "Cars",
                column: "OfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Offers_OfferId",
                table: "Cars",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id");
        }
    }
}
