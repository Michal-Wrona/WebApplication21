using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication21.Core.Data.Migrations
{
    public partial class DataTimeInReservartion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateReservation",
                table: "BooksReservation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateReservation",
                table: "BooksReservation");
        }
    }
}
