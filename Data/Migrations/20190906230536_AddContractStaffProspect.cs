using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NET_React_Auth_New.Data.Migrations
{
    public partial class AddContractStaffProspect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    ContractID = table.Column<Guid>(nullable: false),
                    ContractDescription = table.Column<string>(nullable: true),
                    ContractStartDate = table.Column<DateTime>(nullable: false),
                    ContractEndDate = table.Column<DateTime>(nullable: false),
                    ContractCustomerID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.ContractID);
                });

            migrationBuilder.CreateTable(
                name: "Prospects",
                columns: table => new
                {
                    ProspectID = table.Column<Guid>(nullable: false),
                    ProspectDescription = table.Column<string>(nullable: true),
                    ProspectRcvdDate = table.Column<DateTime>(nullable: false),
                    ProspectLastUpdateDate = table.Column<string>(nullable: true),
                    ProspectLastUpdateStaff = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prospects", x => x.ProspectID);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffID = table.Column<Guid>(nullable: false),
                    StaffFirstName = table.Column<string>(nullable: true),
                    StaffLastName = table.Column<string>(nullable: true),
                    StaffEmail = table.Column<string>(nullable: true),
                    StaffRole = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Prospects");

            migrationBuilder.DropTable(
                name: "Staff");
        }
    }
}
