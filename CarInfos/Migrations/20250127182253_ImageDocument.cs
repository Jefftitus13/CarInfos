using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarInfos.Migrations
{
    /// <inheritdoc />
    public partial class ImageDocument : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageBase64",
                table: "Cars",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "DocumentBase64",
                table: "Cars",
                newName: "DocumentPath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Cars",
                newName: "ImageBase64");

            migrationBuilder.RenameColumn(
                name: "DocumentPath",
                table: "Cars",
                newName: "DocumentBase64");
        }
    }
}
