using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employment.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class addCategoryTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTimeSent",
                table: "ConfirmationEamils",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 9, 22, 13, 31, 177, DateTimeKind.Local).AddTicks(1650),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 7, 20, 21, 57, 49, DateTimeKind.Local).AddTicks(3240));

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTimeAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateTimeDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Category_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentId",
                table: "Category",
                column: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTimeSent",
                table: "ConfirmationEamils",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 7, 20, 21, 57, 49, DateTimeKind.Local).AddTicks(3240),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 9, 22, 13, 31, 177, DateTimeKind.Local).AddTicks(1650));
        }
    }
}
