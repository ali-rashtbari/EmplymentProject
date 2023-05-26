using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employment.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class addResumeLinkEducationHistoryMajorTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EducationHistories_Majors_MajorId",
                table: "EducationHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Rsumes_ResumeId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_ResumeId",
                table: "Profiles");

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "Majors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Links",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "Links",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Rsumes_ProfleId",
                table: "Resumes",
                column: "ProfleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EducationHistories_Majors_MajorId",
                table: "EducationHistories",
                column: "MajorId",
                principalTable: "Majors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rsumes_Profiles_ProfleId",
                table: "Resumes",
                column: "ProfleId",
                principalTable: "Profiles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EducationHistories_Majors_MajorId",
                table: "EducationHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Rsumes_Profiles_ProfleId",
                table: "Resumes");

            migrationBuilder.DropIndex(
                name: "IX_Rsumes_ProfleId",
                table: "Resumes");

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "Majors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Links",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "Links",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_ResumeId",
                table: "Profiles",
                column: "ResumeId",
                unique: true,
                filter: "[ResumeId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_EducationHistories_Majors_MajorId",
                table: "EducationHistories",
                column: "MajorId",
                principalTable: "Majors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Rsumes_ResumeId",
                table: "Profiles",
                column: "ResumeId",
                principalTable: "Resumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
