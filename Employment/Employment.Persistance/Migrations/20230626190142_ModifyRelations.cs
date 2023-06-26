using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employment.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class ModifyRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobExperience_Resumes_ResumeId",
                table: "JobExperience");

            migrationBuilder.AddForeignKey(
                name: "FK_JobExperience_Resumes_ResumeId",
                table: "JobExperience",
                column: "ResumeId",
                principalTable: "Resumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobExperience_Resumes_ResumeId",
                table: "JobExperience");

            migrationBuilder.AddForeignKey(
                name: "FK_JobExperience_Resumes_ResumeId",
                table: "JobExperience",
                column: "ResumeId",
                principalTable: "Resumes",
                principalColumn: "Id");
        }
    }
}
