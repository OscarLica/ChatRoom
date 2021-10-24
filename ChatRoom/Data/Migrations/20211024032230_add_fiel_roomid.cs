using Microsoft.EntityFrameworkCore.Migrations;

namespace ChatRoom.Data.Migrations
{
    public partial class add_fiel_roomid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserChatRooms_ChatRooms_ChatRoomId",
                table: "UserChatRooms");

            migrationBuilder.DropIndex(
                name: "IX_UserChatRooms_ChatRoomId",
                table: "UserChatRooms");

            migrationBuilder.AlterColumn<string>(
                name: "ChatRoomId",
                table: "UserChatRooms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChatRoomId1",
                table: "UserChatRooms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserChatRooms_ChatRoomId1",
                table: "UserChatRooms",
                column: "ChatRoomId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserChatRooms_ChatRooms_ChatRoomId1",
                table: "UserChatRooms",
                column: "ChatRoomId1",
                principalTable: "ChatRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserChatRooms_ChatRooms_ChatRoomId1",
                table: "UserChatRooms");

            migrationBuilder.DropIndex(
                name: "IX_UserChatRooms_ChatRoomId1",
                table: "UserChatRooms");

            migrationBuilder.DropColumn(
                name: "ChatRoomId1",
                table: "UserChatRooms");

            migrationBuilder.AlterColumn<int>(
                name: "ChatRoomId",
                table: "UserChatRooms",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserChatRooms_ChatRoomId",
                table: "UserChatRooms",
                column: "ChatRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserChatRooms_ChatRooms_ChatRoomId",
                table: "UserChatRooms",
                column: "ChatRoomId",
                principalTable: "ChatRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
