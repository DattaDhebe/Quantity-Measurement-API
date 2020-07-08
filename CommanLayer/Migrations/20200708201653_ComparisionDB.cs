using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CommanLayer.Migrations
{
    public partial class ComparisionDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comparision",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    First_Value = table.Column<double>(nullable: false),
                    First_Value_Unit = table.Column<string>(nullable: false),
                    Second_Value = table.Column<double>(nullable: false),
                    Second_Value_Unit = table.Column<string>(nullable: false),
                    Result = table.Column<string>(nullable: true),
                    DateOnCreation = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comparision", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comparision");
        }
    }
}
