using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Authorization.WebApi.Migrations
{
    public partial class RoleId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersExtended_Roles_RoleId",
                table: "UsersExtended");

            migrationBuilder.DeleteData(
                table: "GroupRights",
                keyColumn: "GroupRightId",
                keyValue: new Guid("13a367fd-ac61-4724-9d6a-030fe3a29032"));

            migrationBuilder.DeleteData(
                table: "Rights",
                keyColumn: "RightId",
                keyValue: new Guid("046e026d-aced-47d6-8369-e0a1edee1d13"));

            migrationBuilder.DeleteData(
                table: "RoleRights",
                keyColumn: "RoleRightId",
                keyValue: new Guid("3630673d-4d96-4184-9a46-27c57dfa47ba"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: new Guid("13a367fd-ac61-4724-9d6a-030fe3a29032"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("185e0875-96fe-40cf-9334-a523fcbe615e"));
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("e547216f-9a78-4850-83f8-393ee382709c"));
                

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "UsersExtended",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "GroupName" },
                values: new object[] { new Guid("2b26bba5-1482-4e1e-b734-74928bae413b"), "DefaultGroup" });

            migrationBuilder.InsertData(
                table: "Rights",
                columns: new[] { "RightId", "Module", "Object", "Operator" },
                values: new object[] { new Guid("4324a040-9f65-4bf9-8dca-fe9cb6c7aff5"), 0, 0, 0 });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("ceace335-f1f9-43e6-8a89-c0f4d06d0187"), "DefaultRole" });

            migrationBuilder.InsertData(
                table: "GroupRights",
                columns: new[] { "GroupRightId", "GroupId", "RightId" },
                values: new object[] { new Guid("2b26bba5-1482-4e1e-b734-74928bae413b"), new Guid("2b26bba5-1482-4e1e-b734-74928bae413b"), new Guid("4324a040-9f65-4bf9-8dca-fe9cb6c7aff5") });

            migrationBuilder.InsertData(
                table: "RoleRights",
                columns: new[] { "RoleRightId", "RightId", "RoleId" },
                values: new object[] { new Guid("47f38af7-cea8-47b8-bd1c-3646fc60f18c"), new Guid("4324a040-9f65-4bf9-8dca-fe9cb6c7aff5"), new Guid("ceace335-f1f9-43e6-8a89-c0f4d06d0187") });

            migrationBuilder.AddForeignKey(
                name: "FK_UsersExtended_Roles_RoleId",
                table: "UsersExtended",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersExtended_Roles_RoleId",
                table: "UsersExtended");

            migrationBuilder.DeleteData(
                table: "GroupRights",
                keyColumn: "GroupRightId",
                keyValue: new Guid("2b26bba5-1482-4e1e-b734-74928bae413b"));

            migrationBuilder.DeleteData(
                table: "Rights",
                keyColumn: "RightId",
                keyValue: new Guid("4324a040-9f65-4bf9-8dca-fe9cb6c7aff5"));

            migrationBuilder.DeleteData(
                table: "RoleRights",
                keyColumn: "RoleRightId",
                keyValue: new Guid("47f38af7-cea8-47b8-bd1c-3646fc60f18c"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: new Guid("2b26bba5-1482-4e1e-b734-74928bae413b"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("ceace335-f1f9-43e6-8a89-c0f4d06d0187"));

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "UsersExtended",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "GroupName" },
                values: new object[] { new Guid("13a367fd-ac61-4724-9d6a-030fe3a29032"), "DefaultGroup" });

            migrationBuilder.InsertData(
                table: "Rights",
                columns: new[] { "RightId", "Module", "Object", "Operator" },
                values: new object[] { new Guid("046e026d-aced-47d6-8369-e0a1edee1d13"), 0, 0, 0 });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("185e0875-96fe-40cf-9334-a523fcbe615e"), "DefaultRole" });

            migrationBuilder.InsertData(
                table: "GroupRights",
                columns: new[] { "GroupRightId", "GroupId", "RightId" },
                values: new object[] { new Guid("13a367fd-ac61-4724-9d6a-030fe3a29032"), new Guid("13a367fd-ac61-4724-9d6a-030fe3a29032"), new Guid("046e026d-aced-47d6-8369-e0a1edee1d13") });

            migrationBuilder.InsertData(
                table: "RoleRights",
                columns: new[] { "RoleRightId", "RightId", "RoleId" },
                values: new object[] { new Guid("3630673d-4d96-4184-9a46-27c57dfa47ba"), new Guid("046e026d-aced-47d6-8369-e0a1edee1d13"), new Guid("185e0875-96fe-40cf-9334-a523fcbe615e") });

            migrationBuilder.AddForeignKey(
                name: "FK_UsersExtended_Roles_RoleId",
                table: "UsersExtended",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
