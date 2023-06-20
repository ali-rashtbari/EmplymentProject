using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employment.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class addIsActiveProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Resumes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Provinces",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Profiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "JobSeniorityLevels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "JobExperience",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "JobCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Inductries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "EducationHistories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Countries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Cities",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "JobSeniorityLevels");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "JobExperience");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "JobCategories");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Inductries");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "EducationHistories");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Cities");
        }
    }
}
