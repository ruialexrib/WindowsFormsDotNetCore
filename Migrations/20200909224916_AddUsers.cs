using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WindowsFormsDotNetCore.Migrations
{
    public partial class AddUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Comments", "CreatedDate", "CreatedUser", "Email", "IsDestroyed", "IsSystem", "LastDestroyedDate", "LastDestroyedUser", "LastModifiedDate", "LastModifiedUser", "Password", "SystemId", "Username" },
                values: new object[] { 1, null, null, null, "user1@server.com", false, false, null, null, null, null, "28495851-8d89-463f-a70b-e3a681d6fa2a", new Guid("d551b6f8-14fe-4a1f-9f4a-3bd4f0862727"), "User1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Comments", "CreatedDate", "CreatedUser", "Email", "IsDestroyed", "IsSystem", "LastDestroyedDate", "LastDestroyedUser", "LastModifiedDate", "LastModifiedUser", "Password", "SystemId", "Username" },
                values: new object[] { 2, null, null, null, "user2@server.com", false, false, null, null, null, null, "f4353cc7-988c-440a-8a38-9f0c672850bc", new Guid("b0949426-b433-4e65-86b8-bd879cb14cf3"), "User2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
