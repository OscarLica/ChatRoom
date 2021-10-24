using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChatRoom.Data.Migrations
{
    public partial class add_field_descriptio_date_to_rooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "ChatRooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "ChatRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "ChatRooms");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "ChatRooms");
        }
    }
}
