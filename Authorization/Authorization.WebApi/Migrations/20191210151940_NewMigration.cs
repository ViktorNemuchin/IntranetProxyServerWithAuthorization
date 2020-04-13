using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Authorization.WebApi.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GroupRight",
                keyColumn: "GroupRightId",
                keyValue: new Guid("4a7462fb-2842-49db-a65a-7bb95e5ce4bb"));

            migrationBuilder.DeleteData(
                table: "GroupRight",
                keyColumn: "GroupRightId",
                keyValue: new Guid("bfe9b3b4-b933-43a1-8731-8043c25d6ad3"));

            migrationBuilder.DeleteData(
                table: "GroupRight",
                keyColumn: "GroupRightId",
                keyValue: new Guid("f19f1770-574c-4ed4-a29a-e012bc974004"));

            migrationBuilder.DeleteData(
                table: "RoleRight",
                keyColumn: "RoleRightId",
                keyValue: new Guid("5511c0c5-f1b1-4219-8daa-6f31181a2688"));

            migrationBuilder.DeleteData(
                table: "RoleRight",
                keyColumn: "RoleRightId",
                keyValue: new Guid("665a39ea-fb30-48f1-b673-4450a0304128"));

            migrationBuilder.DeleteData(
                table: "RoleRight",
                keyColumn: "RoleRightId",
                keyValue: new Guid("d4b5dcad-0a3d-4f27-9aac-2dd586f71fff"));

            migrationBuilder.DeleteData(
                table: "UserExtendedGroup",
                keyColumns: new[] { "UserExtendedId", "GroupId" },
                keyValues: new object[] { new Guid("97cc4976-47e9-49dc-a441-be6e28df17b9"), new Guid("ea0cbef8-f9b4-46cb-a72e-762bb8aa3066") });

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: new Guid("ea0cbef8-f9b4-46cb-a72e-762bb8aa3066"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("9f7b8f9e-2877-4b0a-9904-c204d7de7667"));

            migrationBuilder.DeleteData(
                table: "UsersExtended",
                keyColumn: "UserExtendedId",
                keyValue: new Guid("97cc4976-47e9-49dc-a441-be6e28df17b9"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
