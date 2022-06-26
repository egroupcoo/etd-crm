using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EtdCrm.Migrations
{
    public partial class Added_DoctorDocuments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DoctorId",
                table: "EtdDocument",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EtdDocument_DoctorId",
                table: "EtdDocument",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_EtdDocument_EtdDoctor_DoctorId",
                table: "EtdDocument",
                column: "DoctorId",
                principalTable: "EtdDoctor",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EtdDocument_EtdDoctor_DoctorId",
                table: "EtdDocument");

            migrationBuilder.DropIndex(
                name: "IX_EtdDocument_DoctorId",
                table: "EtdDocument");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "EtdDocument");
        }
    }
}
