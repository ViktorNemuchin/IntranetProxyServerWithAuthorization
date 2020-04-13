using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Authorization.WebApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupId = table.Column<Guid>(nullable: false),
                    GroupName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "UsersExtended",
                columns: table => new
                {
                    UserExtendedId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersExtended", x => x.UserExtendedId);
                });

            migrationBuilder.CreateTable(
                name: "GroupRight",
                columns: table => new
                {
                    GroupRightId = table.Column<Guid>(nullable: false),
                    Module = table.Column<int>(nullable: false),
                    Object = table.Column<int>(nullable: false),
                    Operator = table.Column<int>(nullable: false),
                    GroupId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupRight", x => x.GroupRightId);
                    table.ForeignKey(
                        name: "FK_GroupRight_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(nullable: false),
                    RoleName = table.Column<string>(nullable: true),
                    UserExtendedId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                    table.ForeignKey(
                        name: "FK_Roles_UsersExtended_UserExtendedId",
                        column: x => x.UserExtendedId,
                        principalTable: "UsersExtended",
                        principalColumn: "UserExtendedId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserExtendedGroup",
                columns: table => new
                {
                    UserExtendedId = table.Column<Guid>(nullable: false),
                    GroupId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExtendedGroup", x => new { x.UserExtendedId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_UserExtendedGroup_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserExtendedGroup_UsersExtended_UserExtendedId",
                        column: x => x.UserExtendedId,
                        principalTable: "UsersExtended",
                        principalColumn: "UserExtendedId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleRight",
                columns: table => new
                {
                    RoleRightId = table.Column<Guid>(nullable: false),
                    Module = table.Column<int>(nullable: false),
                    Object = table.Column<int>(nullable: false),
                    Operator = table.Column<int>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleRight", x => x.RoleRightId);
                    table.ForeignKey(
                        name: "FK_RoleRight_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "GroupName" },
                values: new object[] { new Guid("ea0cbef8-f9b4-46cb-a72e-762bb8aa3066"), "NewGroup" });

            migrationBuilder.InsertData(
                table: "UsersExtended",
                columns: new[] { "UserExtendedId", "FirstName", "LastName", "Login", "Password", "Token" },
                values: new object[] { new Guid("97cc4976-47e9-49dc-a441-be6e28df17b9"), "Mickhail", "Koriaka", "Miha", "1234", "" });

            migrationBuilder.InsertData(
                table: "GroupRight",
                columns: new[] { "GroupRightId", "GroupId", "Module", "Object", "Operator" },
                values: new object[,]
                {
                    { new Guid("bfe9b3b4-b933-43a1-8731-8043c25d6ad3"), new Guid("ea0cbef8-f9b4-46cb-a72e-762bb8aa3066"), 3, 4, 1 },
                    { new Guid("f19f1770-574c-4ed4-a29a-e012bc974004"), new Guid("ea0cbef8-f9b4-46cb-a72e-762bb8aa3066"), 1, 1, 3 },
                    { new Guid("4a7462fb-2842-49db-a65a-7bb95e5ce4bb"), new Guid("ea0cbef8-f9b4-46cb-a72e-762bb8aa3066"), 3, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName", "UserExtendedId" },
                values: new object[] { new Guid("9f7b8f9e-2877-4b0a-9904-c204d7de7667"), "NewRole", new Guid("97cc4976-47e9-49dc-a441-be6e28df17b9") });

            migrationBuilder.InsertData(
                table: "UserExtendedGroup",
                columns: new[] { "UserExtendedId", "GroupId" },
                values: new object[] { new Guid("97cc4976-47e9-49dc-a441-be6e28df17b9"), new Guid("ea0cbef8-f9b4-46cb-a72e-762bb8aa3066") });

            migrationBuilder.InsertData(
                table: "RoleRight",
                columns: new[] { "RoleRightId", "Module", "Object", "Operator", "RoleId" },
                values: new object[,]
                {
                    { new Guid("665a39ea-fb30-48f1-b673-4450a0304128"), 3, 4, 1, new Guid("9f7b8f9e-2877-4b0a-9904-c204d7de7667") },
                    { new Guid("d4b5dcad-0a3d-4f27-9aac-2dd586f71fff"), 1, 1, 3, new Guid("9f7b8f9e-2877-4b0a-9904-c204d7de7667") },
                    { new Guid("5511c0c5-f1b1-4219-8daa-6f31181a2688"), 3, 4, 3, new Guid("9f7b8f9e-2877-4b0a-9904-c204d7de7667") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupRight_GroupId",
                table: "GroupRight",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleRight_RoleId",
                table: "RoleRight",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UserExtendedId",
                table: "Roles",
                column: "UserExtendedId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserExtendedGroup_GroupId",
                table: "UserExtendedGroup",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupRight");

            migrationBuilder.DropTable(
                name: "RoleRight");

            migrationBuilder.DropTable(
                name: "UserExtendedGroup");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "UsersExtended");
        }
    }
}
