using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Db.Authorization.Migrations
{
    public partial class DeleteUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DeleteData(
                table: "GroupRight",
                keyColumn: "GroupRightId",
                keyValue: new Guid("ae7529a6-b28c-4e3f-9f71-4d37381a9b60"));

            migrationBuilder.DeleteData(
                table: "GroupRight",
                keyColumn: "GroupRightId",
                keyValue: new Guid("db075de3-444b-4a3a-94df-7fa1cf729ba7"));

            migrationBuilder.DeleteData(
                table: "GroupRight",
                keyColumn: "GroupRightId",
                keyValue: new Guid("ea4c93d3-1a90-45ab-b9d5-3ff4ec58cb89"));

            migrationBuilder.DeleteData(
                table: "RoleRight",
                keyColumn: "RoleRightId",
                keyValue: new Guid("47b978a3-e627-41cd-95bc-4b37e57bd7b6"));

            migrationBuilder.DeleteData(
                table: "RoleRight",
                keyColumn: "RoleRightId",
                keyValue: new Guid("8b159664-13a3-477a-b6f3-b812e5f83845"));

            migrationBuilder.DeleteData(
                table: "RoleRight",
                keyColumn: "RoleRightId",
                keyValue: new Guid("8d2dd6f8-533c-4e31-a5e8-d95712850672"));

            migrationBuilder.DeleteData(
                table: "UserExtendedGroup",
                keyColumns: new[] { "UserExtendedId", "GroupId" },
                keyValues: new object[] { new Guid("c1da285e-31d9-4b89-b245-9888df6cc1f8"), new Guid("51c49557-d4f3-4b37-aa43-a69b8a6ee6f4") });

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: new Guid("51c49557-d4f3-4b37-aa43-a69b8a6ee6f4"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("7b46b517-14f2-4c9b-b566-328a5485ca4a"));

            migrationBuilder.DeleteData(
                table: "UsersExtended",
                keyColumn: "UserExtendedId",
                keyValue: new Guid("c1da285e-31d9-4b89-b245-9888df6cc1f8"));

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "UsersExtended",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "UsersExtended",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "UsersExtended",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Groups",
                column: "GroupId",
                value: new Guid("c54083b8-b895-4cda-83fc-ed954bd79709"));

            migrationBuilder.InsertData(
                table: "UsersExtended",
                columns: new[] { "UserExtendedId", "FirstName", "LastName", "Login", "Password", "Token" },
                values: new object[] { new Guid("41ebf740-2e52-41a1-9dbb-d71b3389f6e4"), "Mickhail", "Koriaka", "Miha", "1234", "" });

            migrationBuilder.InsertData(
                table: "GroupRight",
                columns: new[] { "GroupRightId", "GroupId", "Module", "Object", "Operator" },
                values: new object[,]
                {
                    { new Guid("2478dabe-a679-4400-a042-c94ef2e4b6a1"), new Guid("c54083b8-b895-4cda-83fc-ed954bd79709"), 3, 4, 1 },
                    { new Guid("e8440ed7-61fd-41d7-88a6-8607e2b6afaa"), new Guid("c54083b8-b895-4cda-83fc-ed954bd79709"), 1, 1, 3 },
                    { new Guid("17cf0164-f388-4c7c-a487-375aeb8aa3bd"), new Guid("c54083b8-b895-4cda-83fc-ed954bd79709"), 3, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "UserExtendedId" },
                values: new object[] { new Guid("b1596090-3830-4c51-81a6-c87bb043e976"), new Guid("41ebf740-2e52-41a1-9dbb-d71b3389f6e4") });

            migrationBuilder.InsertData(
                table: "UserExtendedGroup",
                columns: new[] { "UserExtendedId", "GroupId" },
                values: new object[] { new Guid("41ebf740-2e52-41a1-9dbb-d71b3389f6e4"), new Guid("c54083b8-b895-4cda-83fc-ed954bd79709") });

            migrationBuilder.InsertData(
                table: "RoleRight",
                columns: new[] { "RoleRightId", "Module", "Object", "Operator", "RoleId", "UserExtendedId" },
                values: new object[] { new Guid("ac419b3f-3052-4d60-bc86-b4c1fd810175"), 3, 4, 1, new Guid("b1596090-3830-4c51-81a6-c87bb043e976"), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "RoleRight",
                columns: new[] { "RoleRightId", "Module", "Object", "Operator", "RoleId", "UserExtendedId" },
                values: new object[] { new Guid("200ef3ee-2068-4765-816c-205ff2b23f80"), 1, 1, 3, new Guid("b1596090-3830-4c51-81a6-c87bb043e976"), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "RoleRight",
                columns: new[] { "RoleRightId", "Module", "Object", "Operator", "RoleId", "UserExtendedId" },
                values: new object[] { new Guid("2b7697db-54a0-4d95-af5c-c270f6c618c0"), 3, 4, 3, new Guid("b1596090-3830-4c51-81a6-c87bb043e976"), new Guid("00000000-0000-0000-0000-000000000000") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GroupRight",
                keyColumn: "GroupRightId",
                keyValue: new Guid("17cf0164-f388-4c7c-a487-375aeb8aa3bd"));

            migrationBuilder.DeleteData(
                table: "GroupRight",
                keyColumn: "GroupRightId",
                keyValue: new Guid("2478dabe-a679-4400-a042-c94ef2e4b6a1"));

            migrationBuilder.DeleteData(
                table: "GroupRight",
                keyColumn: "GroupRightId",
                keyValue: new Guid("e8440ed7-61fd-41d7-88a6-8607e2b6afaa"));

            migrationBuilder.DeleteData(
                table: "RoleRight",
                keyColumn: "RoleRightId",
                keyValue: new Guid("200ef3ee-2068-4765-816c-205ff2b23f80"));

            migrationBuilder.DeleteData(
                table: "RoleRight",
                keyColumn: "RoleRightId",
                keyValue: new Guid("2b7697db-54a0-4d95-af5c-c270f6c618c0"));

            migrationBuilder.DeleteData(
                table: "RoleRight",
                keyColumn: "RoleRightId",
                keyValue: new Guid("ac419b3f-3052-4d60-bc86-b4c1fd810175"));

            migrationBuilder.DeleteData(
                table: "UserExtendedGroup",
                keyColumns: new[] { "UserExtendedId", "GroupId" },
                keyValues: new object[] { new Guid("41ebf740-2e52-41a1-9dbb-d71b3389f6e4"), new Guid("c54083b8-b895-4cda-83fc-ed954bd79709") });

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: new Guid("c54083b8-b895-4cda-83fc-ed954bd79709"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("b1596090-3830-4c51-81a6-c87bb043e976"));

            migrationBuilder.DeleteData(
                table: "UsersExtended",
                keyColumn: "UserExtendedId",
                keyValue: new Guid("41ebf740-2e52-41a1-9dbb-d71b3389f6e4"));

            migrationBuilder.DropColumn(
                name: "Login",
                table: "UsersExtended");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "UsersExtended");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "UsersExtended");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserExtendedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_UsersExtended_UserExtendedId",
                        column: x => x.UserExtendedId,
                        principalTable: "UsersExtended",
                        principalColumn: "UserExtendedId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Groups",
                column: "GroupId",
                value: new Guid("51c49557-d4f3-4b37-aa43-a69b8a6ee6f4"));

            migrationBuilder.InsertData(
                table: "UsersExtended",
                columns: new[] { "UserExtendedId", "FirstName", "LastName" },
                values: new object[] { new Guid("c1da285e-31d9-4b89-b245-9888df6cc1f8"), "Mickhail", "Koriaka" });

            migrationBuilder.InsertData(
                table: "GroupRight",
                columns: new[] { "GroupRightId", "GroupId", "Module", "Object", "Operator" },
                values: new object[,]
                {
                    { new Guid("ae7529a6-b28c-4e3f-9f71-4d37381a9b60"), new Guid("51c49557-d4f3-4b37-aa43-a69b8a6ee6f4"), 3, 4, 1 },
                    { new Guid("db075de3-444b-4a3a-94df-7fa1cf729ba7"), new Guid("51c49557-d4f3-4b37-aa43-a69b8a6ee6f4"), 1, 1, 3 },
                    { new Guid("ea4c93d3-1a90-45ab-b9d5-3ff4ec58cb89"), new Guid("51c49557-d4f3-4b37-aa43-a69b8a6ee6f4"), 3, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "UserExtendedId" },
                values: new object[] { new Guid("7b46b517-14f2-4c9b-b566-328a5485ca4a"), new Guid("c1da285e-31d9-4b89-b245-9888df6cc1f8") });

            migrationBuilder.InsertData(
                table: "UserExtendedGroup",
                columns: new[] { "UserExtendedId", "GroupId" },
                values: new object[] { new Guid("c1da285e-31d9-4b89-b245-9888df6cc1f8"), new Guid("51c49557-d4f3-4b37-aa43-a69b8a6ee6f4") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Login", "Password", "Token", "UserExtendedId" },
                values: new object[] { new Guid("83d66c54-222b-4a2a-907a-12be5b233ac2"), "Miha", "1234", "", new Guid("c1da285e-31d9-4b89-b245-9888df6cc1f8") });

            migrationBuilder.InsertData(
                table: "RoleRight",
                columns: new[] { "RoleRightId", "Module", "Object", "Operator", "RoleId", "UserExtendedId" },
                values: new object[] { new Guid("47b978a3-e627-41cd-95bc-4b37e57bd7b6"), 3, 4, 1, new Guid("7b46b517-14f2-4c9b-b566-328a5485ca4a"), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "RoleRight",
                columns: new[] { "RoleRightId", "Module", "Object", "Operator", "RoleId", "UserExtendedId" },
                values: new object[] { new Guid("8d2dd6f8-533c-4e31-a5e8-d95712850672"), 1, 1, 3, new Guid("7b46b517-14f2-4c9b-b566-328a5485ca4a"), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "RoleRight",
                columns: new[] { "RoleRightId", "Module", "Object", "Operator", "RoleId", "UserExtendedId" },
                values: new object[] { new Guid("8b159664-13a3-477a-b6f3-b812e5f83845"), 3, 4, 3, new Guid("7b46b517-14f2-4c9b-b566-328a5485ca4a"), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserExtendedId",
                table: "Users",
                column: "UserExtendedId",
                unique: true);
        }
    }
}
