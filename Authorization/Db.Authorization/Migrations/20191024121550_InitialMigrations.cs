using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Db.Authorization.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UsersExtended",
                columns: table => new
                {
                    UserExtendedId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UserCredentialsUserId = table.Column<Guid>(nullable: true),
                    RoleId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersExtended", x => x.UserExtendedId);
                    table.ForeignKey(
                        name: "FK_UsersExtended_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersExtended_Users_UserCredentialsUserId",
                        column: x => x.UserCredentialsUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    GroupId = table.Column<Guid>(nullable: false),
                    UserExtendedId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.GroupId);
                    table.ForeignKey(
                        name: "FK_Group_UsersExtended_UserExtendedId",
                        column: x => x.UserExtendedId,
                        principalTable: "UsersExtended",
                        principalColumn: "UserExtendedId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Right",
                columns: table => new
                {
                    RightId = table.Column<Guid>(nullable: false),
                    Module = table.Column<int>(nullable: false),
                    Object = table.Column<int>(nullable: false),
                    Operator = table.Column<int>(nullable: false),
                    GroupId = table.Column<Guid>(nullable: true),
                    RoleId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Right", x => x.RightId);
                    table.ForeignKey(
                        name: "FK_Right_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Right_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserExtendedGroup",
                columns: table => new
                {
                    UserExtendedId = table.Column<Guid>(nullable: false),
                    GroupId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExtendedGroup", x => new { x.UserExtendedId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_UserExtendedGroup_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserExtendedGroup_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Group_UserExtendedId",
                table: "Group",
                column: "UserExtendedId");

            migrationBuilder.CreateIndex(
                name: "IX_Right_GroupId",
                table: "Right",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Right_RoleId",
                table: "Right",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserExtendedGroup_GroupId",
                table: "UserExtendedGroup",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserExtendedGroup_UserId",
                table: "UserExtendedGroup",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersExtended_RoleId",
                table: "UsersExtended",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersExtended_UserCredentialsUserId",
                table: "UsersExtended",
                column: "UserCredentialsUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Right");

            migrationBuilder.DropTable(
                name: "UserExtendedGroup");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "UsersExtended");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
