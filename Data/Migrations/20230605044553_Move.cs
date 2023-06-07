using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PenguageMvc.Data.Migrations
{
    /// <inheritdoc />
    public partial class Move : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StemBeforeBlank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlankAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StemAfterBlank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrectAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Distractor1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Distractor2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Distractor3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Question");
        }
    }
}
