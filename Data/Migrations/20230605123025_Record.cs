using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PenguageMvc.Data.Migrations
{
    /// <inheritdoc />
    public partial class Record : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Correct",
                table: "LearningRecord",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Correct",
                table: "LearningRecord");
        }
    }
}
