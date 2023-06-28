using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employment.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class removeLevelFromLanguageTblAndMoveToResumeLanguages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "Language");

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "ResumeLanguage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "ResumeLanguage");

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "Language",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
