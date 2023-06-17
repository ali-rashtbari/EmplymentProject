using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employment.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class modifySimpleModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Provinces",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Provinces",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Provinces",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Provinces",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "JobSeniorityLevels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "JobSeniorityLevels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "JobSeniorityLevels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "JobSeniorityLevels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "JobTitle",
                table: "JobExperience",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1200)",
                oldMaxLength: 1200);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "JobCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "JobCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "JobCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "JobCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Inductries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Inductries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Inductries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Inductries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Countries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Countries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Countries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Countries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Cities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Cities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Cities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Cities",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "JobSeniorityLevels");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "JobSeniorityLevels");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "JobSeniorityLevels");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "JobSeniorityLevels");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "JobCategories");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "JobCategories");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "JobCategories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "JobCategories");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Inductries");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Inductries");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Inductries");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Inductries");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Cities");

            migrationBuilder.AlterColumn<string>(
                name: "JobTitle",
                table: "JobExperience",
                type: "nvarchar(1200)",
                maxLength: 1200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
