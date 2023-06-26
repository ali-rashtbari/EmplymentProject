using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employment.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class editRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EducationHistories_Majors_MajorId",
                table: "EducationHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_JobExperience_Countries_CountryId",
                table: "JobExperience");

            migrationBuilder.RenameColumn(
                name: "DateModified",
                table: "Resumes",
                newName: "DateTimeModified");

            migrationBuilder.RenameColumn(
                name: "DateDeleted",
                table: "Resumes",
                newName: "DateTimeDeleted");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Resumes",
                newName: "DateTimeAdded");

            migrationBuilder.RenameColumn(
                name: "DateModified",
                table: "Provinces",
                newName: "DateTimeModified");

            migrationBuilder.RenameColumn(
                name: "DateDeleted",
                table: "Provinces",
                newName: "DateTimeDeleted");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Provinces",
                newName: "DateTimeAdded");

            migrationBuilder.RenameColumn(
                name: "DateModified",
                table: "Profiles",
                newName: "DateTimeModified");

            migrationBuilder.RenameColumn(
                name: "DateDeleted",
                table: "Profiles",
                newName: "DateTimeDeleted");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Profiles",
                newName: "DateTimeAdded");

            migrationBuilder.RenameColumn(
                name: "DateModified",
                table: "JobSeniorityLevels",
                newName: "DateTimeModified");

            migrationBuilder.RenameColumn(
                name: "DateDeleted",
                table: "JobSeniorityLevels",
                newName: "DateTimeDeleted");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "JobSeniorityLevels",
                newName: "DateTimeAdded");

            migrationBuilder.RenameColumn(
                name: "DateModified",
                table: "JobExperience",
                newName: "DateTimeModified");

            migrationBuilder.RenameColumn(
                name: "DateDeleted",
                table: "JobExperience",
                newName: "DateTimeDeleted");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "JobExperience",
                newName: "DateTimeAdded");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "JobExperience",
                newName: "ResumeId");

            migrationBuilder.RenameIndex(
                name: "IX_JobExperience_CountryId",
                table: "JobExperience",
                newName: "IX_JobExperience_ResumeId");

            migrationBuilder.RenameColumn(
                name: "DateModified",
                table: "JobCategories",
                newName: "DateTimeModified");

            migrationBuilder.RenameColumn(
                name: "DateDeleted",
                table: "JobCategories",
                newName: "DateTimeDeleted");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "JobCategories",
                newName: "DateTimeAdded");

            migrationBuilder.RenameColumn(
                name: "DateModified",
                table: "Inductries",
                newName: "DateTimeModified");

            migrationBuilder.RenameColumn(
                name: "DateDeleted",
                table: "Inductries",
                newName: "DateTimeDeleted");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Inductries",
                newName: "DateTimeAdded");

            migrationBuilder.RenameColumn(
                name: "DateModified",
                table: "EducationHistories",
                newName: "DateTimeModified");

            migrationBuilder.RenameColumn(
                name: "DateDeleted",
                table: "EducationHistories",
                newName: "DateTimeDeleted");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "EducationHistories",
                newName: "DateTimeAdded");

            migrationBuilder.RenameColumn(
                name: "DateModified",
                table: "Countries",
                newName: "DateTimeModified");

            migrationBuilder.RenameColumn(
                name: "DateDeleted",
                table: "Countries",
                newName: "DateTimeDeleted");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Countries",
                newName: "DateTimeAdded");

            migrationBuilder.RenameColumn(
                name: "DateModified",
                table: "Cities",
                newName: "DateTimeModified");

            migrationBuilder.RenameColumn(
                name: "DateDeleted",
                table: "Cities",
                newName: "DateTimeDeleted");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Cities",
                newName: "DateTimeAdded");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeAdded",
                table: "Majors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeDeleted",
                table: "Majors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeModified",
                table: "Majors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeAdded",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeDeleted",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeModified",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EducationHistories_Majors_MajorId",
                table: "EducationHistories",
                column: "MajorId",
                principalTable: "Majors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobExperience_Resumes_ResumeId",
                table: "JobExperience",
                column: "ResumeId",
                principalTable: "Resumes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EducationHistories_Majors_MajorId",
                table: "EducationHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_JobExperience_Resumes_ResumeId",
                table: "JobExperience");

            migrationBuilder.DropColumn(
                name: "DateTimeAdded",
                table: "Majors");

            migrationBuilder.DropColumn(
                name: "DateTimeDeleted",
                table: "Majors");

            migrationBuilder.DropColumn(
                name: "DateTimeModified",
                table: "Majors");

            migrationBuilder.DropColumn(
                name: "DateTimeAdded",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateTimeDeleted",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateTimeModified",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "DateTimeModified",
                table: "Resumes",
                newName: "DateModified");

            migrationBuilder.RenameColumn(
                name: "DateTimeDeleted",
                table: "Resumes",
                newName: "DateDeleted");

            migrationBuilder.RenameColumn(
                name: "DateTimeAdded",
                table: "Resumes",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "DateTimeModified",
                table: "Provinces",
                newName: "DateModified");

            migrationBuilder.RenameColumn(
                name: "DateTimeDeleted",
                table: "Provinces",
                newName: "DateDeleted");

            migrationBuilder.RenameColumn(
                name: "DateTimeAdded",
                table: "Provinces",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "DateTimeModified",
                table: "Profiles",
                newName: "DateModified");

            migrationBuilder.RenameColumn(
                name: "DateTimeDeleted",
                table: "Profiles",
                newName: "DateDeleted");

            migrationBuilder.RenameColumn(
                name: "DateTimeAdded",
                table: "Profiles",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "DateTimeModified",
                table: "JobSeniorityLevels",
                newName: "DateModified");

            migrationBuilder.RenameColumn(
                name: "DateTimeDeleted",
                table: "JobSeniorityLevels",
                newName: "DateDeleted");

            migrationBuilder.RenameColumn(
                name: "DateTimeAdded",
                table: "JobSeniorityLevels",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "ResumeId",
                table: "JobExperience",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "DateTimeModified",
                table: "JobExperience",
                newName: "DateModified");

            migrationBuilder.RenameColumn(
                name: "DateTimeDeleted",
                table: "JobExperience",
                newName: "DateDeleted");

            migrationBuilder.RenameColumn(
                name: "DateTimeAdded",
                table: "JobExperience",
                newName: "DateCreated");

            migrationBuilder.RenameIndex(
                name: "IX_JobExperience_ResumeId",
                table: "JobExperience",
                newName: "IX_JobExperience_CountryId");

            migrationBuilder.RenameColumn(
                name: "DateTimeModified",
                table: "JobCategories",
                newName: "DateModified");

            migrationBuilder.RenameColumn(
                name: "DateTimeDeleted",
                table: "JobCategories",
                newName: "DateDeleted");

            migrationBuilder.RenameColumn(
                name: "DateTimeAdded",
                table: "JobCategories",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "DateTimeModified",
                table: "Inductries",
                newName: "DateModified");

            migrationBuilder.RenameColumn(
                name: "DateTimeDeleted",
                table: "Inductries",
                newName: "DateDeleted");

            migrationBuilder.RenameColumn(
                name: "DateTimeAdded",
                table: "Inductries",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "DateTimeModified",
                table: "EducationHistories",
                newName: "DateModified");

            migrationBuilder.RenameColumn(
                name: "DateTimeDeleted",
                table: "EducationHistories",
                newName: "DateDeleted");

            migrationBuilder.RenameColumn(
                name: "DateTimeAdded",
                table: "EducationHistories",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "DateTimeModified",
                table: "Countries",
                newName: "DateModified");

            migrationBuilder.RenameColumn(
                name: "DateTimeDeleted",
                table: "Countries",
                newName: "DateDeleted");

            migrationBuilder.RenameColumn(
                name: "DateTimeAdded",
                table: "Countries",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "DateTimeModified",
                table: "Cities",
                newName: "DateModified");

            migrationBuilder.RenameColumn(
                name: "DateTimeDeleted",
                table: "Cities",
                newName: "DateDeleted");

            migrationBuilder.RenameColumn(
                name: "DateTimeAdded",
                table: "Cities",
                newName: "DateCreated");

            migrationBuilder.AddForeignKey(
                name: "FK_EducationHistories_Majors_MajorId",
                table: "EducationHistories",
                column: "MajorId",
                principalTable: "Majors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobExperience_Countries_CountryId",
                table: "JobExperience",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");
        }
    }
}
