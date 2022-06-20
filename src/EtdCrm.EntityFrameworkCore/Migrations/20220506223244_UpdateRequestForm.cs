using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EtdCrm.Migrations
{
    public partial class UpdateRequestForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address1",
                table: "EtdRequestForm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address2",
                table: "EtdRequestForm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "EtdRequestForm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email1",
                table: "EtdRequestForm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email2",
                table: "EtdRequestForm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "EtdRequestForm",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Iban1",
                table: "EtdRequestForm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Iban2",
                table: "EtdRequestForm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "EtdRequestForm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IpLocation",
                table: "EtdRequestForm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Language",
                table: "EtdRequestForm",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "EtdRequestForm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone1",
                table: "EtdRequestForm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone2",
                table: "EtdRequestForm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneCode1",
                table: "EtdRequestForm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneCode2",
                table: "EtdRequestForm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SocialMediaUrl1",
                table: "EtdRequestForm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SocialMediaUrl2",
                table: "EtdRequestForm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "EtdRequestForm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "EtdRequestForm",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "EtdRequestForm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RequestFormId",
                table: "EtdNote",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RequestFormId",
                table: "EtdDocument",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EtdNote_RequestFormId",
                table: "EtdNote",
                column: "RequestFormId");

            migrationBuilder.CreateIndex(
                name: "IX_EtdDocument_RequestFormId",
                table: "EtdDocument",
                column: "RequestFormId");

            migrationBuilder.AddForeignKey(
                name: "FK_EtdDocument_EtdRequestForm_RequestFormId",
                table: "EtdDocument",
                column: "RequestFormId",
                principalTable: "EtdRequestForm",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EtdNote_EtdRequestForm_RequestFormId",
                table: "EtdNote",
                column: "RequestFormId",
                principalTable: "EtdRequestForm",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EtdDocument_EtdRequestForm_RequestFormId",
                table: "EtdDocument");

            migrationBuilder.DropForeignKey(
                name: "FK_EtdNote_EtdRequestForm_RequestFormId",
                table: "EtdNote");

            migrationBuilder.DropIndex(
                name: "IX_EtdNote_RequestFormId",
                table: "EtdNote");

            migrationBuilder.DropIndex(
                name: "IX_EtdDocument_RequestFormId",
                table: "EtdDocument");

            migrationBuilder.DropColumn(
                name: "Address1",
                table: "EtdRequestForm");

            migrationBuilder.DropColumn(
                name: "Address2",
                table: "EtdRequestForm");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "EtdRequestForm");

            migrationBuilder.DropColumn(
                name: "Email1",
                table: "EtdRequestForm");

            migrationBuilder.DropColumn(
                name: "Email2",
                table: "EtdRequestForm");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "EtdRequestForm");

            migrationBuilder.DropColumn(
                name: "Iban1",
                table: "EtdRequestForm");

            migrationBuilder.DropColumn(
                name: "Iban2",
                table: "EtdRequestForm");

            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "EtdRequestForm");

            migrationBuilder.DropColumn(
                name: "IpLocation",
                table: "EtdRequestForm");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "EtdRequestForm");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "EtdRequestForm");

            migrationBuilder.DropColumn(
                name: "Phone1",
                table: "EtdRequestForm");

            migrationBuilder.DropColumn(
                name: "Phone2",
                table: "EtdRequestForm");

            migrationBuilder.DropColumn(
                name: "PhoneCode1",
                table: "EtdRequestForm");

            migrationBuilder.DropColumn(
                name: "PhoneCode2",
                table: "EtdRequestForm");

            migrationBuilder.DropColumn(
                name: "SocialMediaUrl1",
                table: "EtdRequestForm");

            migrationBuilder.DropColumn(
                name: "SocialMediaUrl2",
                table: "EtdRequestForm");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "EtdRequestForm");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "EtdRequestForm");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "EtdRequestForm");

            migrationBuilder.DropColumn(
                name: "RequestFormId",
                table: "EtdNote");

            migrationBuilder.DropColumn(
                name: "RequestFormId",
                table: "EtdDocument");
        }
    }
}
