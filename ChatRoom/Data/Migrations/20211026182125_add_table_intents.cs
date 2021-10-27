using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChatRoom.Data.Migrations
{
    public partial class add_table_intents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Intents",
                columns: table => new
                {
                    IntentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    intent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    response = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intents", x => x.IntentId);
                });

            migrationBuilder.InsertData(
                table: "ChatRooms",
                columns: new[] { "Id", "ChatRoomId", "ChatRoomName", "Descripcion", "Fecha" },
                values: new object[] { 1, "1319cc04-4e65-4879-895a-b66c4f3f4875", "#General", "Chat de generales, información de interes para toda la organización", new DateTime(2021, 10, 26, 12, 21, 24, 560, DateTimeKind.Local).AddTicks(9173) });

            migrationBuilder.InsertData(
                table: "Intents",
                columns: new[] { "IntentId", "intent", "response" },
                values: new object[] { 1, "Cotizacion", "https://stooq.com/q/l/?s=aapl.us&f=sd2t2ohlcv&h&e=csv" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Intents");

            migrationBuilder.DeleteData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
