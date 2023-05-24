using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employment.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class addProfileDetailColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Profiles",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "")
                .Annotation("SqlServer:Sparse", false);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Profiles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Profiles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaritalStatus",
                table: "Profiles",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "Profiles");
        }
    }
}
