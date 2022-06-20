using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EtdCrm.Migrations
{
    public partial class Added_RequestFormTreatment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EtdDocument_EtdRequestForm_RequestFormId",
                table: "EtdDocument");

            migrationBuilder.DropForeignKey(
                name: "FK_EtdNote_EtdRequestForm_RequestFormId",
                table: "EtdNote");

            migrationBuilder.RenameColumn(
                name: "RequestFormId",
                table: "EtdNote",
                newName: "RequestFormTreatmentId");

            migrationBuilder.RenameIndex(
                name: "IX_EtdNote_RequestFormId",
                table: "EtdNote",
                newName: "IX_EtdNote_RequestFormTreatmentId");

            migrationBuilder.RenameColumn(
                name: "RequestFormId",
                table: "EtdDocument",
                newName: "RequestFormTreatmentId");

            migrationBuilder.RenameIndex(
                name: "IX_EtdDocument_RequestFormId",
                table: "EtdDocument",
                newName: "IX_EtdDocument_RequestFormTreatmentId");

            migrationBuilder.CreateTable(
                name: "EtdRequestFormTreatment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestFormId = table.Column<long>(type: "bigint", nullable: false),
                    TreatmentId = table.Column<long>(type: "bigint", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtdRequestFormTreatment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EtdRequestFormTreatment_EtdRequestForm_RequestFormId",
                        column: x => x.RequestFormId,
                        principalTable: "EtdRequestForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EtdRequestFormTreatment_EtdTreatment_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "EtdTreatment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EtdRequestFormTreatment_RequestFormId",
                table: "EtdRequestFormTreatment",
                column: "RequestFormId");

            migrationBuilder.CreateIndex(
                name: "IX_EtdRequestFormTreatment_TreatmentId",
                table: "EtdRequestFormTreatment",
                column: "TreatmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_EtdDocument_EtdRequestFormTreatment_RequestFormTreatmentId",
                table: "EtdDocument",
                column: "RequestFormTreatmentId",
                principalTable: "EtdRequestFormTreatment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EtdNote_EtdRequestFormTreatment_RequestFormTreatmentId",
                table: "EtdNote",
                column: "RequestFormTreatmentId",
                principalTable: "EtdRequestFormTreatment",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EtdDocument_EtdRequestFormTreatment_RequestFormTreatmentId",
                table: "EtdDocument");

            migrationBuilder.DropForeignKey(
                name: "FK_EtdNote_EtdRequestFormTreatment_RequestFormTreatmentId",
                table: "EtdNote");

            migrationBuilder.DropTable(
                name: "EtdRequestFormTreatment");

            migrationBuilder.RenameColumn(
                name: "RequestFormTreatmentId",
                table: "EtdNote",
                newName: "RequestFormId");

            migrationBuilder.RenameIndex(
                name: "IX_EtdNote_RequestFormTreatmentId",
                table: "EtdNote",
                newName: "IX_EtdNote_RequestFormId");

            migrationBuilder.RenameColumn(
                name: "RequestFormTreatmentId",
                table: "EtdDocument",
                newName: "RequestFormId");

            migrationBuilder.RenameIndex(
                name: "IX_EtdDocument_RequestFormTreatmentId",
                table: "EtdDocument",
                newName: "IX_EtdDocument_RequestFormId");

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
    }
}
