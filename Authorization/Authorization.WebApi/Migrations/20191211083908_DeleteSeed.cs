using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Authorization.WebApi.Migrations
{
    public partial class DeleteSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_UsersExtended_UserExtendedId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_UserExtendedId",
                table: "Roles");

            migrationBuilder.DeleteData(
                table: "GroupRight",
                keyColumn: "GroupRightId",
                keyValue: new Guid("5ffbad26-ee9f-4593-8eee-dd3585c28c8d"));

            migrationBuilder.DeleteData(
                table: "GroupRight",
                keyColumn: "GroupRightId",
                keyValue: new Guid("d24aa262-d745-412a-9f59-90cb40e9f815"));

            migrationBuilder.DeleteData(
                table: "GroupRight",
                keyColumn: "GroupRightId",
                keyValue: new Guid("fdce30c8-e4af-451d-b577-59fae7ea2311"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: new Guid("a8cf3e22-8764-4abd-b45b-80eb01ea0f10"));

            migrationBuilder.DeleteData(
                table: "RoleRight",
                keyColumn: "RoleRightId",
                keyValue: new Guid("7a288b63-0403-4031-be0c-b9498193f57c"));

            migrationBuilder.DeleteData(
                table: "RoleRight",
                keyColumn: "RoleRightId",
                keyValue: new Guid("a7e1cd5b-0f21-4f0a-9128-47537fc090fa"));

            migrationBuilder.DeleteData(
                table: "RoleRight",
                keyColumn: "RoleRightId",
                keyValue: new Guid("c5719763-9de3-4bfc-ae21-f60648610493"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("e5df431a-891b-4da8-a903-36892d114a01"));

            migrationBuilder.DeleteData(
                table: "UserExtendedGroup",
                keyColumns: new[] { "UserExtendedId", "GroupId" },
                keyValues: new object[] { new Guid("78f3a6d3-54f1-4449-bdc9-f8a509cba632"), new Guid("af843462-b5bf-4b6f-a77e-e9421c574362") });

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: new Guid("af843462-b5bf-4b6f-a77e-e9421c574362"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("40853edc-8795-4671-805e-bfdffc2eff10"));

            migrationBuilder.DeleteData(
                table: "UsersExtended",
                keyColumn: "UserExtendedId",
                keyValue: new Guid("78f3a6d3-54f1-4449-bdc9-f8a509cba632"));

            migrationBuilder.DropColumn(
                name: "UserExtendedId",
                table: "Roles");

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "UsersExtended",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersExtended_RoleId",
                table: "UsersExtended",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersExtended_Roles_RoleId",
                table: "UsersExtended",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersExtended_Roles_RoleId",
                table: "UsersExtended");

            migrationBuilder.DropIndex(
                name: "IX_UsersExtended_RoleId",
                table: "UsersExtended");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "UsersExtended");

            migrationBuilder.AddColumn<Guid>(
                name: "UserExtendedId",
                table: "Roles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "GroupName" },
                values: new object[,]
                {
                    { new Guid("af843462-b5bf-4b6f-a77e-e9421c574362"), "NewGroup" },
                    { new Guid("a8cf3e22-8764-4abd-b45b-80eb01ea0f10"), "DefaultGroup" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName", "UserExtendedId" },
                values: new object[] { new Guid("e5df431a-891b-4da8-a903-36892d114a01"), "NewRole", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "UsersExtended",
                columns: new[] { "UserExtendedId", "FirstName", "LastName", "Login", "Password", "Token" },
                values: new object[] { new Guid("78f3a6d3-54f1-4449-bdc9-f8a509cba632"), "Mickhail", "Koriaka", "Miha", "1234", "" });

            migrationBuilder.InsertData(
                table: "GroupRight",
                columns: new[] { "GroupRightId", "GroupId", "Module", "Object", "Operator" },
                values: new object[,]
                {
                    { new Guid("5ffbad26-ee9f-4593-8eee-dd3585c28c8d"), new Guid("af843462-b5bf-4b6f-a77e-e9421c574362"), 3, 4, 1 },
                    { new Guid("d24aa262-d745-412a-9f59-90cb40e9f815"), new Guid("af843462-b5bf-4b6f-a77e-e9421c574362"), 1, 1, 3 },
                    { new Guid("fdce30c8-e4af-451d-b577-59fae7ea2311"), new Guid("af843462-b5bf-4b6f-a77e-e9421c574362"), 3, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName", "UserExtendedId" },
                values: new object[] { new Guid("40853edc-8795-4671-805e-bfdffc2eff10"), "NewRole", new Guid("78f3a6d3-54f1-4449-bdc9-f8a509cba632") });

            migrationBuilder.InsertData(
                table: "UserExtendedGroup",
                columns: new[] { "UserExtendedId", "GroupId" },
                values: new object[] { new Guid("78f3a6d3-54f1-4449-bdc9-f8a509cba632"), new Guid("af843462-b5bf-4b6f-a77e-e9421c574362") });

            migrationBuilder.InsertData(
                table: "RoleRight",
                columns: new[] { "RoleRightId", "Module", "Object", "Operator", "RoleId" },
                values: new object[,]
                {
                    { new Guid("a7e1cd5b-0f21-4f0a-9128-47537fc090fa"), 3, 4, 1, new Guid("40853edc-8795-4671-805e-bfdffc2eff10") },
                    { new Guid("c5719763-9de3-4bfc-ae21-f60648610493"), 1, 1, 3, new Guid("40853edc-8795-4671-805e-bfdffc2eff10") },
                    { new Guid("7a288b63-0403-4031-be0c-b9498193f57c"), 3, 4, 3, new Guid("40853edc-8795-4671-805e-bfdffc2eff10") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UserExtendedId",
                table: "Roles",
                column: "UserExtendedId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_UsersExtended_UserExtendedId",
                table: "Roles",
                column: "UserExtendedId",
                principalTable: "UsersExtended",
                principalColumn: "UserExtendedId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
