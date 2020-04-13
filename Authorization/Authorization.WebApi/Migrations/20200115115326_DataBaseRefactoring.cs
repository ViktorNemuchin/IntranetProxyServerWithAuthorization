using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Authorization.WebApi.Migrations
{
    public partial class DataBaseRefactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Module",
                table: "RoleRight");

            migrationBuilder.DropColumn(
                name: "Object",
                table: "RoleRight");

            migrationBuilder.DropColumn(
                name: "Operator",
                table: "RoleRight");

            migrationBuilder.DropColumn(
                name: "Module",
                table: "GroupRight");

            migrationBuilder.DropColumn(
                name: "Object",
                table: "GroupRight");

            migrationBuilder.DropColumn(
                name: "Operator",
                table: "GroupRight");

            migrationBuilder.AddColumn<Guid>(
                name: "RightId",
                table: "RoleRight",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RightId",
                table: "GroupRight",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Rights",
                columns: table => new
                {
                    RightId = table.Column<Guid>(nullable: false),
                    Module = table.Column<int>(nullable: false),
                    Object = table.Column<int>(nullable: false),
                    Operator = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rights", x => x.RightId);
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "GroupName" },
                values: new object[] { new Guid("a955accf-27ac-4c6b-8023-fee749dc1dd0"), "DefaultGroup" });

            migrationBuilder.InsertData(
                table: "Rights",
                columns: new[] { "RightId", "Module", "Object", "Operator" },
                values: new object[] { new Guid("f2e126d5-fed2-48ca-adaa-2ca51bda1761"), 0, 0, 0 });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("dfdfd02f-8fd3-4032-8121-8dce6b5df257"), "DefaultRole" });

            migrationBuilder.InsertData(
                table: "GroupRight",
                columns: new[] { "GroupRightId", "GroupId", "RightId" },
                values: new object[] { new Guid("a955accf-27ac-4c6b-8023-fee749dc1dd0"), new Guid("a955accf-27ac-4c6b-8023-fee749dc1dd0"), new Guid("f2e126d5-fed2-48ca-adaa-2ca51bda1761") });

            migrationBuilder.InsertData(
                table: "RoleRight",
                columns: new[] { "RoleRightId", "RightId", "RoleId" },
                values: new object[] { new Guid("bbf3a7c3-51f1-40f2-b8c1-14de0bcfc95f"), new Guid("f2e126d5-fed2-48ca-adaa-2ca51bda1761"), new Guid("dfdfd02f-8fd3-4032-8121-8dce6b5df257") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rights");

            migrationBuilder.DeleteData(
                table: "GroupRight",
                keyColumn: "GroupRightId",
                keyValue: new Guid("a955accf-27ac-4c6b-8023-fee749dc1dd0"));

            migrationBuilder.DeleteData(
                table: "RoleRight",
                keyColumn: "RoleRightId",
                keyValue: new Guid("bbf3a7c3-51f1-40f2-b8c1-14de0bcfc95f"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: new Guid("a955accf-27ac-4c6b-8023-fee749dc1dd0"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("dfdfd02f-8fd3-4032-8121-8dce6b5df257"));

            migrationBuilder.DropColumn(
                name: "RightId",
                table: "RoleRight");

            migrationBuilder.DropColumn(
                name: "RightId",
                table: "GroupRight");

            migrationBuilder.AddColumn<int>(
                name: "Module",
                table: "RoleRight",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Object",
                table: "RoleRight",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Operator",
                table: "RoleRight",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Module",
                table: "GroupRight",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Object",
                table: "GroupRight",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Operator",
                table: "GroupRight",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "GroupName" },
                values: new object[] { new Guid("7db660fd-c8f8-45ff-bd16-211ad15e5c85"), "DefaultGroup" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("887d364f-b55e-4149-a1ef-be9f02ad86d6"), "DefaultRole" });

            migrationBuilder.InsertData(
                table: "GroupRight",
                columns: new[] { "GroupRightId", "GroupId", "Module", "Object", "Operator" },
                values: new object[] { new Guid("293280fa-416e-476f-bad4-79b47a0286af"), new Guid("7db660fd-c8f8-45ff-bd16-211ad15e5c85"), 0, 0, 0 });

            migrationBuilder.InsertData(
                table: "RoleRight",
                columns: new[] { "RoleRightId", "Module", "Object", "Operator", "RoleId" },
                values: new object[] { new Guid("993f92bb-c80e-4545-8a84-57fa375eaa58"), 0, 0, 0, new Guid("887d364f-b55e-4149-a1ef-be9f02ad86d6") });
        }
    }
}
