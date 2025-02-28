using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SyncWithExistingSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Transactions",
                newName: "code");

            migrationBuilder.AlterColumn<DateTime>(
                name: "transaction_date",
                table: "Transactions",
                type: "datetime2(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Transactions",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "capture_date",
                table: "Transactions",
                type: "datetime2(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "code",
                table: "Transactions",
                newName: "Code");

            migrationBuilder.AlterColumn<DateTime>(
                name: "transaction_date",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(7)");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "capture_date",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(7)");
        }
    }
}
