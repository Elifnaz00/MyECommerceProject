using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class defaultguid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AspNetRoles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "CreateDate",
                value: new DateTime(2025, 11, 18, 0, 10, 56, 565, DateTimeKind.Local).AddTicks(2500));

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                column: "CreateDate",
                value: new DateTime(2025, 11, 18, 0, 10, 56, 565, DateTimeKind.Local).AddTicks(2504));

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"),
                column: "CreateDate",
                value: new DateTime(2025, 11, 18, 0, 10, 56, 565, DateTimeKind.Local).AddTicks(2506));

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"),
                column: "CreateDate",
                value: new DateTime(2025, 11, 18, 0, 10, 56, 565, DateTimeKind.Local).AddTicks(2520));

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                column: "CreateDate",
                value: new DateTime(2025, 11, 18, 0, 10, 56, 565, DateTimeKind.Local).AddTicks(2522));

            migrationBuilder.UpdateData(
                table: "PaymentStatuses",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "CreateDate",
                value: new DateTime(2025, 11, 18, 0, 10, 56, 565, DateTimeKind.Local).AddTicks(2320));

            migrationBuilder.UpdateData(
                table: "PaymentStatuses",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "CreateDate",
                value: new DateTime(2025, 11, 18, 0, 10, 56, 565, DateTimeKind.Local).AddTicks(2341));

            migrationBuilder.UpdateData(
                table: "PaymentStatuses",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                column: "CreateDate",
                value: new DateTime(2025, 11, 18, 0, 10, 56, 565, DateTimeKind.Local).AddTicks(2348));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AspNetRoles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "CreateDate",
                value: new DateTime(2025, 11, 18, 0, 5, 21, 978, DateTimeKind.Local).AddTicks(1401));

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                column: "CreateDate",
                value: new DateTime(2025, 11, 18, 0, 5, 21, 978, DateTimeKind.Local).AddTicks(1405));

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"),
                column: "CreateDate",
                value: new DateTime(2025, 11, 18, 0, 5, 21, 978, DateTimeKind.Local).AddTicks(1407));

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"),
                column: "CreateDate",
                value: new DateTime(2025, 11, 18, 0, 5, 21, 978, DateTimeKind.Local).AddTicks(1409));

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                column: "CreateDate",
                value: new DateTime(2025, 11, 18, 0, 5, 21, 978, DateTimeKind.Local).AddTicks(1412));

            migrationBuilder.UpdateData(
                table: "PaymentStatuses",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "CreateDate",
                value: new DateTime(2025, 11, 18, 0, 5, 21, 978, DateTimeKind.Local).AddTicks(1248));

            migrationBuilder.UpdateData(
                table: "PaymentStatuses",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "CreateDate",
                value: new DateTime(2025, 11, 18, 0, 5, 21, 978, DateTimeKind.Local).AddTicks(1264));

            migrationBuilder.UpdateData(
                table: "PaymentStatuses",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                column: "CreateDate",
                value: new DateTime(2025, 11, 18, 0, 5, 21, 978, DateTimeKind.Local).AddTicks(1266));
        }
    }
}
