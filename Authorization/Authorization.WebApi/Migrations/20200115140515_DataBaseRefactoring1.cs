using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Authorization.WebApi.Migrations
{
    public partial class DataBaseRefactoring1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GroupRight",
                keyColumn: "GroupRightId",
                keyValue: new Guid("a955accf-27ac-4c6b-8023-fee749dc1dd0"));

            migrationBuilder.DeleteData(
                table: "Rights",
                keyColumn: "RightId",
                keyValue: new Guid("f2e126d5-fed2-48ca-adaa-2ca51bda1761"));

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
