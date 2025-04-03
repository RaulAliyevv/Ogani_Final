using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ogani.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Slider : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GreenWrite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoldWrite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LightWrite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ButtonWrite = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sliders");
        }
    }
}
