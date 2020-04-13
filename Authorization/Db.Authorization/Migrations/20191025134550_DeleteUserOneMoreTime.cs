using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Db.Authorization.Migrations
{
    public partial class DeleteUserOneMoreTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Groups",
                column: "GroupId",
                value: new Guid("d3a16f52-4fac-4c43-a935-71b1cfb884a5"));

            migrationBuilder.InsertData(
                table: "UsersExtended",
                columns: new[] { "UserExtendedId", "FirstName", "LastName", "Login", "Password", "Token" },
                values: new object[] { new Guid("f3941aa2-64a5-4de3-99f1-805c4af17d86"), "Mickhail", "Koriaka", "Miha", "1234", "" });

            migrationBuilder.InsertData(
                table: "GroupRight",
                columns: new[] { "GroupRightId", "GroupId", "Module", "Object", "Operator" },
                values: new object[,]
                {
                    { new Guid("ecfa6321-fe87-4214-9409-a9ab86409a2a"), new Guid("d3a16f52-4fac-4c43-a935-71b1cfb884a5"), 3, 4, 1 },
                    { new Guid("2b440333-d067-46e6-b294-e05d2de8c456"), new Guid("d3a16f52-4fac-4c43-a935-71b1cfb884a5"), 1, 1, 3 },
                    { new Guid("9c10233c-ce63-43cc-9027-cc55ec417c64"), new Guid("d3a16f52-4fac-4c43-a935-71b1cfb884a5"), 3, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "UserExtendedId" },
                values: new object[] { new Guid("67e6f9a1-abd8-4242-a6d7-3d7af6ae50e5"), new Guid("f3941aa2-64a5-4de3-99f1-805c4af17d86") });

            migrationBuilder.InsertData(
                table: "UserExtendedGroup",
                columns: new[] { "UserExtendedId", "GroupId" },
                values: new object[] { new Guid("f3941aa2-64a5-4de3-99f1-805c4af17d86"), new Guid("d3a16f52-4fac-4c43-a935-71b1cfb884a5") });

            migrationBuilder.InsertData(
                table: "RoleRight",
                columns: new[] { "RoleRightId", "Module", "Object", "Operator", "RoleId", "UserExtendedId" },
                values: new object[] { new Guid("b3dbd4a8-253b-4cbe-bb11-4e4ef9da1d4c"), 3, 4, 1, new Guid("67e6f9a1-abd8-4242-a6d7-3d7af6ae50e5"), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "RoleRight",
                columns: new[] { "RoleRightId", "Module", "Object", "Operator", "RoleId", "UserExtendedId" },
                values: new object[] { new Guid("bf48845e-1522-409c-851c-7751c29f14f8"), 1, 1, 3, new Guid("67e6f9a1-abd8-4242-a6d7-3d7af6ae50e5"), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "RoleRight",
                columns: new[] { "RoleRightId", "Module", "Object", "Operator", "RoleId", "UserExtendedId" },
                values: new object[] { new Guid("0be23894-3b3d-4fd9-ba1d-20327ae2e2a3"), 3, 4, 3, new Guid("67e6f9a1-abd8-4242-a6d7-3d7af6ae50e5"), new Guid("00000000-0000-0000-0000-000000000000") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GroupRight",
                keyColumn: "GroupRightId",
                keyValue: new Guid("2b440333-d067-46e6-b294-e05d2de8c456"));

            migrationBuilder.DeleteData(
                table: "GroupRight",
                keyColumn: "GroupRightId",
                keyValue: new Guid("9c10233c-ce63-43cc-9027-cc55ec417c64"));

            migrationBuilder.DeleteData(
                table: "GroupRight",
                keyColumn: "GroupRightId",
                keyValue: new Guid("ecfa6321-fe87-4214-9409-a9ab86409a2a"));

            migrationBuilder.DeleteData(
                table: "RoleRight",
                keyColumn: "RoleRightId",
                keyValue: new Guid("0be23894-3b3d-4fd9-ba1d-20327ae2e2a3"));

            migrationBuilder.DeleteData(
                table: "RoleRight",
                keyColumn: "RoleRightId",
                keyValue: new Guid("b3dbd4a8-253b-4cbe-bb11-4e4ef9da1d4c"));

            migrationBuilder.DeleteData(
                table: "RoleRight",
                keyColumn: "RoleRightId",
                keyValue: new Guid("bf48845e-1522-409c-851c-7751c29f14f8"));

            migrationBuilder.DeleteData(
                table: "UserExtendedGroup",
                keyColumns: new[] { "UserExtendedId", "GroupId" },
                keyValues: new object[] { new Guid("f3941aa2-64a5-4de3-99f1-805c4af17d86"), new Guid("d3a16f52-4fac-4c43-a935-71b1cfb884a5") });

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: new Guid("d3a16f52-4fac-4c43-a935-71b1cfb884a5"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("67e6f9a1-abd8-4242-a6d7-3d7af6ae50e5"));

            migrationBuilder.DeleteData(
                table: "UsersExtended",
                keyColumn: "UserExtendedId",
                keyValue: new Guid("f3941aa2-64a5-4de3-99f1-805c4af17d86"));

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
    }
}
