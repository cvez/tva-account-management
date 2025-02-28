using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTransactionAmountType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Alter the column type for 'amount' in 'Transactions' table
            migrationBuilder.AlterColumn<decimal>(
                name: "amount",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Revert the column type for 'amount' in 'Transactions' table
            migrationBuilder.AlterColumn<float>(
                name: "amount",
                table: "Transactions",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}