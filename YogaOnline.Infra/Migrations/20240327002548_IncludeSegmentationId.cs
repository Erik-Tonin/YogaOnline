using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YogaOnline.Infra.Migrations
{
    /// <inheritdoc />
    public partial class IncludeSegmentationId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "SegmentationId",
                table: "Teachers",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SegmentationId",
                table: "Teachers",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)");
        }
    }
}
