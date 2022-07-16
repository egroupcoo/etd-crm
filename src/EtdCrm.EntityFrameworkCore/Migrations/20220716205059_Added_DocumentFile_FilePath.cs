using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EtdCrm.Migrations
{
    public partial class Added_DocumentFile_FilePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "EtdDocumentFile",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "EtdDocumentFile");
        }
    }
}
