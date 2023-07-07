using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employment.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class editConfirmationEmailsTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConfirmationEmail_AspNetUsers_UserId",
                table: "ConfirmationEmail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConfirmationEmail",
                table: "ConfirmationEmail");

            migrationBuilder.RenameTable(
                name: "ConfirmationEmail",
                newName: "ConfirmationEamils");

            migrationBuilder.RenameIndex(
                name: "IX_ConfirmationEmail_UserId",
                table: "ConfirmationEamils",
                newName: "IX_ConfirmationEamils_UserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTimeSent",
                table: "ConfirmationEamils",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 7, 20, 21, 57, 49, DateTimeKind.Local).AddTicks(3240),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 7, 17, 15, 26, 923, DateTimeKind.Local).AddTicks(1395));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConfirmationEamils",
                table: "ConfirmationEamils",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfirmationEamils_AspNetUsers_UserId",
                table: "ConfirmationEamils",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConfirmationEamils_AspNetUsers_UserId",
                table: "ConfirmationEamils");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConfirmationEamils",
                table: "ConfirmationEamils");

            migrationBuilder.RenameTable(
                name: "ConfirmationEamils",
                newName: "ConfirmationEmail");

            migrationBuilder.RenameIndex(
                name: "IX_ConfirmationEamils_UserId",
                table: "ConfirmationEmail",
                newName: "IX_ConfirmationEmail_UserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTimeSent",
                table: "ConfirmationEmail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 7, 17, 15, 26, 923, DateTimeKind.Local).AddTicks(1395),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 7, 20, 21, 57, 49, DateTimeKind.Local).AddTicks(3240));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConfirmationEmail",
                table: "ConfirmationEmail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfirmationEmail_AspNetUsers_UserId",
                table: "ConfirmationEmail",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
