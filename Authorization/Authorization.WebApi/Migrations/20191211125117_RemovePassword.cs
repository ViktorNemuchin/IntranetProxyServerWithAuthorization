using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Authorization.WebApi.Migrations
{
    public partial class RemovePassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GroupRight",
                keyColumn: "GroupRightId",
                keyValue: new Guid("d6a7f333-dd32-45b9-88c5-509094090121"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: new Guid("c14266ce-7990-4694-9500-27a2f573e794"));

            migrationBuilder.DropColumn(
                name: "Password",
                table: "UsersExtended");

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "GroupName" },
                values: new object[] { new Guid("7db660fd-c8f8-45ff-bd16-211ad15e5c85"), "DefaultGroup" });

            migrationBuilder.InsertData(
                table: "GroupRight",
                columns: new[] { "GroupRightId", "GroupId", "Module", "Object", "Operator" },
                values: new object[] { new Guid("293280fa-416e-476f-bad4-79b47a0286af"), new Guid("7db660fd-c8f8-45ff-bd16-211ad15e5c85"), 0, 0, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GroupRight",
                keyColumn: "GroupRightId",
                keyValue: new Guid("293280fa-416e-476f-bad4-79b47a0286af"));

            migrationBuilder.DeleteData(
                table: "RoleRight",
                keyColumn: "RoleRightId",
                keyValue: new Guid("993f92bb-c80e-4545-8a84-57fa375eaa58"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: new Guid("7db660fd-c8f8-45ff-bd16-211ad15e5c85"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("887d364f-b55e-4149-a1ef-be9f02ad86d6"));

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "UsersExtended",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "GroupName" },
                values: new object[] { new Guid("c14266ce-7990-4694-9500-27a2f573e794"), "DefaultGroup" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("e547216f-9a78-4850-83f8-393ee382709c"), "DefaultRole" });

            migrationBuilder.InsertData(
                table: "GroupRight",
                columns: new[] { "GroupRightId", "GroupId", "Module", "Object", "Operator" },
                values: new object[] { new Guid("d6a7f333-dd32-45b9-88c5-509094090121"), new Guid("c14266ce-7990-4694-9500-27a2f573e794"), 0, 0, 0 });

            migrationBuilder.InsertData(
                table: "RoleRight",
                columns: new[] { "RoleRightId", "Module", "Object", "Operator", "RoleId" },
                values: new object[] { new Guid("7d36f305-f13f-4818-8017-f63184b4c289"), 0, 0, 0, new Guid("e547216f-9a78-4850-83f8-393ee382709c") });
        }
    }
}
