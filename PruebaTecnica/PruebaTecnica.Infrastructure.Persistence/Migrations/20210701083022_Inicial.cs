using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PruebaTecnica.Infrastructure.Persistence.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    PositionTitle = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PositionNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PositionDescription = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PostionArea = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PostionType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PositionSalary = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    CreatedBy = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Created = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
