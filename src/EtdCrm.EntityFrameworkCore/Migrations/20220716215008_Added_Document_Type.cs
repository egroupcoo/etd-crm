using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EtdCrm.Migrations
{
    public partial class Added_Document_Type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "EtdDocument",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "EtdDocument");
        }
    }
}
