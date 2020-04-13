using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Authorization.WebApi.Migrations
{
    public partial class AddMany_ToOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GroupRight",
                keyColumn: "GroupRightId",
                keyValue: new Guid("310d1597-b89c-43af-a244-9feaec02016c"));

            migrationBuilder.DeleteData(
                table: "GroupRight",
                keyColumn: "GroupRightId",
                keyValue: new Guid("5f8ad21e-ab0c-40f4-b191-a18518ccc7cd"));

            migrationBuilder.DeleteData(
                table: "GroupRight",
                keyColumn: "GroupRightId",
                keyValue: new Guid("d4ed1114-49bb-4b24-b171-cd5016a2be95"));

            migrationBuilder.DeleteData(
                table: "RoleRight",
                keyColumn: "RoleRightId",
                keyValue: new Guid("57247c5b-f036-4eef-8a49-fd6641210ca0"));

            migrationBuilder.DeleteData(
                table: "RoleRight",
                keyColumn: "RoleRightId",
                keyValue: new Guid("dc97bac6-f213-4666-b92e-061da46e6efc"));

            migrationBuilder.DeleteData(
                table: "RoleRight",
                keyColumn: "RoleRightId",
                keyValue: new Guid("f47e4004-8579-4e19-b9f8-43191b6ca62e"));

            migrationBuilder.DeleteData(
                table: "UserExtendedGroup",
                keyColumns: new[] { "UserExtendedId", "GroupId" },
                keyValues: new object[] { new Guid("bdf4b2c3-63a8-488d-8c4f-598e2f3c33e4"), new Guid("c810e61e-f94b-49bd-9b42-5f36cd011c36") });

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: new Guid("c810e61e-f94b-49bd-9b42-5f36cd011c36"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("01948bff-9fe2-44a0-bc00-71e134cf8e6d"));

            migrationBuilder.DeleteData(
                table: "UsersExtended",
                keyColumn: "UserExtendedId",
                keyValue: new Guid("bdf4b2c3-63a8-488d-8c4f-598e2f3c33e4"));

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "GroupName" },
                values: new object[,]
                {
                    { new Guid("af843462-b5bf-4b6f-a77e-e9421c574362"), "NewGroup" },
                });

         

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "GroupName" },
                values: new object[] { new Guid("c810e61e-f94b-49bd-9b42-5f36cd011c36"), "NewGroup" });

            migrationBuilder.InsertData(
                table: "UsersExtended",
                columns: new[] { "UserExtendedId", "FirstName", "LastName", "Login", "Password", "Token" },
                values: new object[] { new Guid("bdf4b2c3-63a8-488d-8c4f-598e2f3c33e4"), "Mickhail", "Koriaka", "Miha", "1234", "" });

            migrationBuilder.InsertData(
                table: "GroupRight",
                columns: new[] { "GroupRightId", "GroupId", "Module", "Object", "Operator" },
                values: new object[,]
                {
                    { new Guid("5f8ad21e-ab0c-40f4-b191-a18518ccc7cd"), new Guid("c810e61e-f94b-49bd-9b42-5f36cd011c36"), 3, 4, 1 },
                    { new Guid("d4ed1114-49bb-4b24-b171-cd5016a2be95"), new Guid("c810e61e-f94b-49bd-9b42-5f36cd011c36"), 1, 1, 3 },
                    { new Guid("310d1597-b89c-43af-a244-9feaec02016c"), new Guid("c810e61e-f94b-49bd-9b42-5f36cd011c36"), 3, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName", "UserExtendedId" },
                values: new object[] { new Guid("01948bff-9fe2-44a0-bc00-71e134cf8e6d"), "NewRole", new Guid("bdf4b2c3-63a8-488d-8c4f-598e2f3c33e4") });

            migrationBuilder.InsertData(
                table: "UserExtendedGroup",
                columns: new[] { "UserExtendedId", "GroupId" },
                values: new object[] { new Guid("bdf4b2c3-63a8-488d-8c4f-598e2f3c33e4"), new Guid("c810e61e-f94b-49bd-9b42-5f36cd011c36") });

            migrationBuilder.InsertData(
                table: "RoleRight",
                columns: new[] { "RoleRightId", "Module", "Object", "Operator", "RoleId" },
                values: new object[,]
                {
                    { new Guid("57247c5b-f036-4eef-8a49-fd6641210ca0"), 3, 4, 1, new Guid("01948bff-9fe2-44a0-bc00-71e134cf8e6d") },
                    { new Guid("f47e4004-8579-4e19-b9f8-43191b6ca62e"), 1, 1, 3, new Guid("01948bff-9fe2-44a0-bc00-71e134cf8e6d") },
                    { new Guid("dc97bac6-f213-4666-b92e-061da46e6efc"), 3, 4, 3, new Guid("01948bff-9fe2-44a0-bc00-71e134cf8e6d") }
                });
        }
    }
}
