using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CommanLayer.Migrations
{
    public partial class MeasurementDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comparision",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MeasurementType = table.Column<string>(nullable: false),
                    First_Value_Unit = table.Column<string>(nullable: false),
                    First_Value = table.Column<double>(nullable: false),
                    Second_Value_Unit = table.Column<string>(nullable: false),
                    Second_Value = table.Column<double>(nullable: false),
                    Result = table.Column<string>(nullable: true),
                    DateOnCreation = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comparision", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quantities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MeasurementType = table.Column<string>(nullable: false),
                    ConversionType = table.Column<string>(nullable: false),
                    Value = table.Column<double>(nullable: false),
                    Result = table.Column<double>(nullable: false),
                    DateOfCreation = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quantities", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comparision");

            migrationBuilder.DropTable(
                name: "Quantities");
        }
    }
}
