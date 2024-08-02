using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CellManagerAPI.Infraestructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class NullableMemberBirthDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Cells_CellId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Visitors_Cells_CellId",
                table: "Visitors");

            migrationBuilder.AlterColumn<int>(
                name: "CellId",
                table: "Visitors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CellId",
                table: "Members",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "BirthDate",
                table: "Members",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Cells_CellId",
                table: "Members",
                column: "CellId",
                principalTable: "Cells",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visitors_Cells_CellId",
                table: "Visitors",
                column: "CellId",
                principalTable: "Cells",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Cells_CellId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Visitors_Cells_CellId",
                table: "Visitors");

            migrationBuilder.AlterColumn<int>(
                name: "CellId",
                table: "Visitors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CellId",
                table: "Members",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "BirthDate",
                table: "Members",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Cells_CellId",
                table: "Members",
                column: "CellId",
                principalTable: "Cells",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Visitors_Cells_CellId",
                table: "Visitors",
                column: "CellId",
                principalTable: "Cells",
                principalColumn: "Id");
        }
    }
}
