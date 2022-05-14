using Microsoft.EntityFrameworkCore.Migrations;

namespace POS.Data.Migrations
{
    public partial class _64378 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "A_Pay",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "AmountInCash",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "AmountInMachine",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "P_Pay",
                table: "Tasks");

            migrationBuilder.AddColumn<decimal>(
                name: "Admin_Pay",
                table: "Tasks",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountInCashAfter",
                table: "Tasks",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountInCashBefore",
                table: "Tasks",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountInMachineAfter",
                table: "Tasks",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountInMachineBefore",
                table: "Tasks",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "Close",
                table: "Tasks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Machine_Pay",
                table: "Tasks",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Rep_Pay",
                table: "Tasks",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Admin_Pay",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "AmountInCashAfter",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "AmountInCashBefore",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "AmountInMachineAfter",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "AmountInMachineBefore",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Close",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Machine_Pay",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Rep_Pay",
                table: "Tasks");

            migrationBuilder.AddColumn<decimal>(
                name: "A_Pay",
                table: "Tasks",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountInCash",
                table: "Tasks",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountInMachine",
                table: "Tasks",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "P_Pay",
                table: "Tasks",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
