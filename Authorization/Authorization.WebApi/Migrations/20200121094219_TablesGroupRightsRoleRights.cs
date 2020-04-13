using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Authorization.WebApi.Migrations
{
    public partial class TablesGroupRightsRoleRights : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupRight_Groups_GroupId",
                table: "GroupRight");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleRight_Roles_RoleId",
                table: "RoleRight");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleRight",
                table: "RoleRight");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupRight",
                table: "GroupRight");

            migrationBuilder.DeleteData(
                table: "GroupRight",
                keyColumn: "GroupRightId",
                keyValue: new Guid("9d52647d-ce33-4999-a5fa-c0726467a4dd"));

            migrationBuilder.DeleteData(
                table: "Rights",
                keyColumn: "RightId",
                keyValue: new Guid("e358e394-4029-4a52-b774-ffa60ff47892"));

            migrationBuilder.DeleteData(
                table: "RoleRight",
                keyColumn: "RoleRightId",
                keyValue: new Guid("afde4a21-cf84-442d-8c5a-11a505a3d292"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: new Guid("9d52647d-ce33-4999-a5fa-c0726467a4dd"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("218db7a6-a4df-415b-8961-8df52d53f937"));

            migrationBuilder.RenameTable(
                name: "RoleRight",
                newName: "RoleRights");

            migrationBuilder.RenameTable(
                name: "GroupRight",
                newName: "GroupRights");

            migrationBuilder.RenameIndex(
                name: "IX_RoleRight_RoleId",
                table: "RoleRights",
                newName: "IX_RoleRights_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupRight_GroupId",
                table: "GroupRights",
                newName: "IX_GroupRights_GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleRights",
                table: "RoleRights",
                column: "RoleRightId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupRights",
                table: "GroupRights",
                column: "GroupRightId");

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
                name: "FK_GroupRights_Groups_GroupId",
                table: "GroupRights",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleRights_Roles_RoleId",
                table: "RoleRights",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupRights_Groups_GroupId",
                table: "GroupRights");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleRights_Roles_RoleId",
                table: "RoleRights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleRights",
                table: "RoleRights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupRights",
                table: "GroupRights");

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

            migrationBuilder.RenameTable(
                name: "RoleRights",
                newName: "RoleRight");

            migrationBuilder.RenameTable(
                name: "GroupRights",
                newName: "GroupRight");

            migrationBuilder.RenameIndex(
                name: "IX_RoleRights_RoleId",
                table: "RoleRight",
                newName: "IX_RoleRight_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupRights_GroupId",
                table: "GroupRight",
                newName: "IX_GroupRight_GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleRight",
                table: "RoleRight",
                column: "RoleRightId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupRight",
                table: "GroupRight",
                column: "GroupRightId");

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "GroupName" },
                values: new object[] { new Guid("9d52647d-ce33-4999-a5fa-c0726467a4dd"), "DefaultGroup" });

            migrationBuilder.InsertData(
                table: "Rights",
                columns: new[] { "RightId", "Module", "Object", "Operator" },
                values: new object[] { new Guid("e358e394-4029-4a52-b774-ffa60ff47892"), 0, 0, 0 });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("218db7a6-a4df-415b-8961-8df52d53f937"), "DefaultRole" });

            migrationBuilder.InsertData(
                table: "GroupRight",
                columns: new[] { "GroupRightId", "GroupId", "RightId" },
                values: new object[] { new Guid("9d52647d-ce33-4999-a5fa-c0726467a4dd"), new Guid("9d52647d-ce33-4999-a5fa-c0726467a4dd"), new Guid("e358e394-4029-4a52-b774-ffa60ff47892") });

            migrationBuilder.InsertData(
                table: "RoleRight",
                columns: new[] { "RoleRightId", "RightId", "RoleId" },
                values: new object[] { new Guid("afde4a21-cf84-442d-8c5a-11a505a3d292"), new Guid("e358e394-4029-4a52-b774-ffa60ff47892"), new Guid("218db7a6-a4df-415b-8961-8df52d53f937") });

            migrationBuilder.AddForeignKey(
                name: "FK_GroupRight_Groups_GroupId",
                table: "GroupRight",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleRight_Roles_RoleId",
                table: "RoleRight",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
