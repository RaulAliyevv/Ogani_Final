using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ogani.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SliderNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SliderRightLefts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RightImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeftImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SliderRightLefts", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SliderRightLefts");
        }
    }
}
