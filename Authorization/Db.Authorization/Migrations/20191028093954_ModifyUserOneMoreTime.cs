using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Db.Authorization.Migrations
{
    public partial class ModifyUserOneMoreTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "UserExtendedId",
                table: "RoleRight");

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GroupName",
                table: "Groups",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "GroupName" },
                values: new object[] { new Guid("df247dcf-a81f-4b33-a7ca-1efc1a589973"), "NewGroup" });

            migrationBuilder.InsertData(
                table: "UsersExtended",
                columns: new[] { "UserExtendedId", "FirstName", "LastName", "Login", "Password", "Token" },
                values: new object[] { new Guid("a71c408e-2770-4262-98fa-78a83a26e336"), "Mickhail", "Koriaka", "Miha", "1234", "" });

            migrationBuilder.InsertData(
                table: "GroupRight",
                columns: new[] { "GroupRightId", "GroupId", "Module", "Object", "Operator" },
                values: new object[,]
                {
                    { new Guid("07507d8b-930f-4add-ac5c-6c11cf715bc1"), new Guid("df247dcf-a81f-4b33-a7ca-1efc1a589973"), 3, 4, 1 },
                    { new Guid("34639de1-6271-4b6f-940b-72b05fe699b6"), new Guid("df247dcf-a81f-4b33-a7ca-1efc1a589973"), 1, 1, 3 },
                    { new Guid("74d03bf2-7561-47b0-9f5b-671c38b93f62"), new Guid("df247dcf-a81f-4b33-a7ca-1efc1a589973"), 3, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName", "UserExtendedId" },
                values: new object[] { new Guid("29324d4f-4574-48ff-b516-21d645eac2ef"), "NewRole", new Guid("a71c408e-2770-4262-98fa-78a83a26e336") });

            migrationBuilder.InsertData(
                table: "UserExtendedGroup",
                columns: new[] { "UserExtendedId", "GroupId" },
                values: new object[] { new Guid("a71c408e-2770-4262-98fa-78a83a26e336"), new Guid("df247dcf-a81f-4b33-a7ca-1efc1a589973") });

            migrationBuilder.InsertData(
                table: "RoleRight",
                columns: new[] { "RoleRightId", "Module", "Object", "Operator", "RoleId" },
                values: new object[] { new Guid("b3558eff-47c9-4af0-8d64-0926a33aa2e2"), 3, 4, 1, new Guid("29324d4f-4574-48ff-b516-21d645eac2ef") });

            migrationBuilder.InsertData(
                table: "RoleRight",
                columns: new[] { "RoleRightId", "Module", "Object", "Operator", "RoleId" },
                values: new object[] { new Guid("2fa35f83-018e-4995-a1a8-5ae56bd0ea36"), 1, 1, 3, new Guid("29324d4f-4574-48ff-b516-21d645eac2ef") });

            migrationBuilder.InsertData(
                table: "RoleRight",
                columns: new[] { "RoleRightId", "Module", "Object", "Operator", "RoleId" },
                values: new object[] { new Guid("470f1fef-8e5e-4c9f-9145-fb59335ab198"), 3, 4, 3, new Guid("29324d4f-4574-48ff-b516-21d645eac2ef") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GroupRight",
                keyColumn: "GroupRightId",
                keyValue: new Guid("07507d8b-930f-4add-ac5c-6c11cf715bc1"));

            migrationBuilder.DeleteData(
                table: "GroupRight",
                keyColumn: "GroupRightId",
                keyValue: new Guid("34639de1-6271-4b6f-940b-72b05fe699b6"));

            migrationBuilder.DeleteData(
                table: "GroupRight",
                keyColumn: "GroupRightId",
                keyValue: new Guid("74d03bf2-7561-47b0-9f5b-671c38b93f62"));

            migrationBuilder.DeleteData(
                table: "RoleRight",
                keyColumn: "RoleRightId",
                keyValue: new Guid("2fa35f83-018e-4995-a1a8-5ae56bd0ea36"));

            migrationBuilder.DeleteData(
                table: "RoleRight",
                keyColumn: "RoleRightId",
                keyValue: new Guid("470f1fef-8e5e-4c9f-9145-fb59335ab198"));

            migrationBuilder.DeleteData(
                table: "RoleRight",
                keyColumn: "RoleRightId",
                keyValue: new Guid("b3558eff-47c9-4af0-8d64-0926a33aa2e2"));

            migrationBuilder.DeleteData(
                table: "UserExtendedGroup",
                keyColumns: new[] { "UserExtendedId", "GroupId" },
                keyValues: new object[] { new Guid("a71c408e-2770-4262-98fa-78a83a26e336"), new Guid("df247dcf-a81f-4b33-a7ca-1efc1a589973") });

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: new Guid("df247dcf-a81f-4b33-a7ca-1efc1a589973"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("29324d4f-4574-48ff-b516-21d645eac2ef"));

            migrationBuilder.DeleteData(
                table: "UsersExtended",
                keyColumn: "UserExtendedId",
                keyValue: new Guid("a71c408e-2770-4262-98fa-78a83a26e336"));

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "GroupName",
                table: "Groups");

            migrationBuilder.AddColumn<Guid>(
                name: "UserExtendedId",
                table: "RoleRight",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
    }
}
