using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoItemApi.Migrations
{
    public partial class FieldsWhenEntitiesDeletedAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "PointOfInterests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "PointOfInterests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                table: "PointOfInterests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Cities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Cities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Cities",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "PointOfInterests");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "PointOfInterests");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                table: "PointOfInterests");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                table: "Cities");
        }
    }
}
