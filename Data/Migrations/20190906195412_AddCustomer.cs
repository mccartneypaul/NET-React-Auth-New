using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NET_React_Auth_New.Data.Migrations
{
    public partial class AddCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<Guid>(nullable: false),
                    CustomerFirstName = table.Column<string>(nullable: true),
                    CustomerLastName = table.Column<string>(nullable: true),
                    CustomerPhoneNumber = table.Column<string>(nullable: true),
                    CustomerFirstStreetAddress = table.Column<string>(nullable: true),
                    CustomerCompanyName = table.Column<string>(nullable: true),
                    CustomerScndStreetAddress = table.Column<string>(nullable: true),
                    CustomerCity = table.Column<string>(nullable: true),
                    CustomerState = table.Column<string>(nullable: true),
                    CustomerZipCode = table.Column<string>(nullable: true),
                    CustomerCountry = table.Column<string>(nullable: true),
                    CustomerEmail = table.Column<string>(nullable: true),
                    CustomerWebSite = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
