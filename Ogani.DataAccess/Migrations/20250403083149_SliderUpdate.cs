    using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ogani.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SliderUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Sliders");
        }
    }
}
