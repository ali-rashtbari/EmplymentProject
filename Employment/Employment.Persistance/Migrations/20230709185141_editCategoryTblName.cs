using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employment.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class editCategoryTblName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Category_ParentId",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_Category_ParentId",
                table: "Categories",
                newName: "IX_Categories_ParentId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTimeSent",
                table: "ConfirmationEamils",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 9, 22, 21, 40, 648, DateTimeKind.Local).AddTicks(1458),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 9, 22, 13, 31, 177, DateTimeKind.Local).AddTicks(1650));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentId",
                table: "Categories",
                column: "ParentId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentId",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_ParentId",
                table: "Category",
                newName: "IX_Category_ParentId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTimeSent",
                table: "ConfirmationEamils",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 9, 22, 13, 31, 177, DateTimeKind.Local).AddTicks(1650),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 9, 22, 21, 40, 648, DateTimeKind.Local).AddTicks(1458));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Category_ParentId",
                table: "Category",
                column: "ParentId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
