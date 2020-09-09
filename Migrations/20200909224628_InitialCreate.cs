using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WindowsFormsDotNetCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Audit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemId = table.Column<Guid>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedUser = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    LastModifiedUser = table.Column<string>(nullable: true),
                    LastDestroyedDate = table.Column<DateTime>(nullable: true),
                    LastDestroyedUser = table.Column<string>(nullable: true),
                    IsSystem = table.Column<bool>(nullable: false),
                    IsDestroyed = table.Column<bool>(nullable: false),
                    ContentSystemId = table.Column<Guid>(nullable: false),
                    ContentId = table.Column<int>(nullable: false),
                    ContentType = table.Column<string>(nullable: true),
                    ContentFunction = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemId = table.Column<Guid>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedUser = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    LastModifiedUser = table.Column<string>(nullable: true),
                    LastDestroyedDate = table.Column<DateTime>(nullable: true),
                    LastDestroyedUser = table.Column<string>(nullable: true),
                    IsSystem = table.Column<bool>(nullable: false),
                    IsDestroyed = table.Column<bool>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrackChanges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemId = table.Column<Guid>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedUser = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    LastModifiedUser = table.Column<string>(nullable: true),
                    LastDestroyedDate = table.Column<DateTime>(nullable: true),
                    LastDestroyedUser = table.Column<string>(nullable: true),
                    IsSystem = table.Column<bool>(nullable: false),
                    IsDestroyed = table.Column<bool>(nullable: false),
                    AuditId = table.Column<int>(nullable: false),
                    FieldName = table.Column<string>(nullable: true),
                    OldValue = table.Column<string>(nullable: true),
                    NewValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackChanges_Audit_AuditId",
                        column: x => x.AuditId,
                        principalTable: "Audit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrackChanges_AuditId",
                table: "TrackChanges",
                column: "AuditId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrackChanges");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Audit");
        }
    }
}
