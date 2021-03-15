using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BillManager.Data.Migrations
{
    public partial class addedBills : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Vendor = table.Column<string>(nullable: true),
                    PaymentType = table.Column<int>(nullable: false),
                    IsPaid = table.Column<bool>(nullable: false),
                    PaidDate = table.Column<DateTime>(nullable: true),
                    Document = table.Column<byte[]>(nullable: true),
                    Occurance = table.Column<int>(nullable: false),
                    Category = table.Column<int>(nullable: false),
                    BillDate = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: true),
                    PeriodFrom = table.Column<DateTime>(nullable: true),
                    PeriodTo = table.Column<DateTime>(nullable: true),
                    Price = table.Column<double>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bills");
        }
    }
}
