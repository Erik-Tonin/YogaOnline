using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace YogaOnline.Infra.Migrations
{
    /// <inheritdoc />
    public partial class includeImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Segmentation_SegmentationId",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "Segmentation");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_SegmentationId",
                table: "Teachers");

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Users",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "Segmentation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Segmentation", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_SegmentationId",
                table: "Teachers",
                column: "SegmentationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Segmentation_SegmentationId",
                table: "Teachers",
                column: "SegmentationId",
                principalTable: "Segmentation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
