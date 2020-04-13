using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Db.Authorization.Migrations
{
    public partial class CheckingForErrors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GroupRight",
                keyColumn: "GroupRightId",
                keyValue: new Guid("5721bed2-1929-449e-8cfc-5b09d56ab8d6"));

            migrationBuilder.DeleteData(
                table: "GroupRight",
                keyColumn: "GroupRightId",
                keyValue: new Guid("6e42d288-c917-490a-82da-3cafa10ee720"));

            migrationBuilder.DeleteData(
                table: "GroupRight",
                keyColumn: "GroupRightId",
                keyValue: new Guid("fe0bf773-fd37-40bd-9504-f45b5bee0c4b"));

            migrationBuilder.DeleteData(
                table: "RoleRight",
                keyColumn: "RoleRightId",
                keyValue: new Guid("01c6d0e1-6036-40dd-ba58-8e8e8545e099"));

            migrationBuilder.DeleteData(
                table: "RoleRight",
                keyColumn: "RoleRightId",
                keyValue: new Guid("05ba54bc-8adc-4634-bfdb-d4f9c6203cf7"));

            migrationBuilder.DeleteData(
                table: "RoleRight",
                keyColumn: "RoleRightId",
                keyValue: new Guid("2660709e-6fc1-4ff6-b0f2-ae214b630452"));

            migrationBuilder.DeleteData(
                table: "UserExtendedGroup",
                keyColumns: new[] { "UserExtendedId", "GroupId" },
                keyValues: new object[] { new Guid("e42b1599-b09b-4660-8f3b-9631e549eabc"), new Guid("42729b9e-e983-4385-af92-9ba8146797d0") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("7bd06515-3618-43d1-b5f4-c5734a5101e1"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: new Guid("42729b9e-e983-4385-af92-9ba8146797d0"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("e21854f4-9195-41bf-ab7e-8d67a3a9d13e"));

            migrationBuilder.DeleteData(
                table: "UsersExtended",
                keyColumn: "UserExtendedId",
                keyValue: new Guid("e42b1599-b09b-4660-8f3b-9631e549eabc"));

            migrationBuilder.InsertData(
                table: "Groups",
                column: "GroupId",
                value: new Guid("51c49557-d4f3-4b37-aa43-a69b8a6ee6f4"));

            migrationBuilder.InsertData(
                table: "UsersExtended",
                columns: new[] { "UserExtendedId", "FirstName", "LastName" },
                values: new object[] { new Guid("c1da285e-31d9-4b89-b245-9888df6cc1f8"), "Mickhail", "Koriaka" });

            migrationBuilder.InsertData(
                table: "GroupRight",
                columns: new[] { "GroupRightId", "GroupId", "Module", "Object", "Operator" },
                values: new object[,]
                {
                    { new Guid("ae7529a6-b28c-4e3f-9f71-4d37381a9b60"), new Guid("51c49557-d4f3-4b37-aa43-a69b8a6ee6f4"), 3, 4, 1 },
                    { new Guid("db075de3-444b-4a3a-94df-7fa1cf729ba7"), new Guid("51c49557-d4f3-4b37-aa43-a69b8a6ee6f4"), 1, 1, 3 },
                    { new Guid("ea4c93d3-1a90-45ab-b9d5-3ff4ec58cb89"), new Guid("51c49557-d4f3-4b37-aa43-a69b8a6ee6f4"), 3, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "UserExtendedId" },
                values: new object[] { new Guid("7b46b517-14f2-4c9b-b566-328a5485ca4a"), new Guid("c1da285e-31d9-4b89-b245-9888df6cc1f8") });

            migrationBuilder.InsertData(
                table: "UserExtendedGroup",
                columns: new[] { "UserExtendedId", "GroupId" },
                values: new object[] { new Guid("c1da285e-31d9-4b89-b245-9888df6cc1f8"), new Guid("51c49557-d4f3-4b37-aa43-a69b8a6ee6f4") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Login", "Password", "Token", "UserExtendedId" },
                values: new object[] { new Guid("83d66c54-222b-4a2a-907a-12be5b233ac2"), "Miha", "1234", "", new Guid("c1da285e-31d9-4b89-b245-9888df6cc1f8") });

            migrationBuilder.InsertData(
                table: "RoleRight",
                columns: new[] { "RoleRightId", "Module", "Object", "Operator", "RoleId", "UserExtendedId" },
                values: new object[] { new Guid("47b978a3-e627-41cd-95bc-4b37e57bd7b6"), 3, 4, 1, new Guid("7b46b517-14f2-4c9b-b566-328a5485ca4a"), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "RoleRight",
                columns: new[] { "RoleRightId", "Module", "Object", "Operator", "RoleId", "UserExtendedId" },
                values: new object[] { new Guid("8d2dd6f8-533c-4e31-a5e8-d95712850672"), 1, 1, 3, new Guid("7b46b517-14f2-4c9b-b566-328a5485ca4a"), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "RoleRight",
                columns: new[] { "RoleRightId", "Module", "Object", "Operator", "RoleId", "UserExtendedId" },
                values: new object[] { new Guid("8b159664-13a3-477a-b6f3-b812e5f83845"), 3, 4, 3, new Guid("7b46b517-14f2-4c9b-b566-328a5485ca4a"), new Guid("00000000-0000-0000-0000-000000000000") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GroupRight",
                keyColumn: "GroupRightId",
                keyValue: new Guid("ae7529a6-b28c-4e3f-9f71-4d37381a9b60"));

            migrationBuilder.DeleteData(
                table: "GroupRight",
                keyColumn: "GroupRightId",
                keyValue: new Guid("db075de3-444b-4a3a-94df-7fa1cf729ba7"));

            migrationBuilder.DeleteData(
                table: "GroupRight",
                keyColumn: "GroupRightId",
                keyValue: new Guid("ea4c93d3-1a90-45ab-b9d5-3ff4ec58cb89"));

            migrationBuilder.DeleteData(
                table: "RoleRight",
                keyColumn: "RoleRightId",
                keyValue: new Guid("47b978a3-e627-41cd-95bc-4b37e57bd7b6"));

            migrationBuilder.DeleteData(
                table: "RoleRight",
                keyColumn: "RoleRightId",
                keyValue: new Guid("8b159664-13a3-477a-b6f3-b812e5f83845"));

            migrationBuilder.DeleteData(
                table: "RoleRight",
                keyColumn: "RoleRightId",
                keyValue: new Guid("8d2dd6f8-533c-4e31-a5e8-d95712850672"));

            migrationBuilder.DeleteData(
                table: "UserExtendedGroup",
                keyColumns: new[] { "UserExtendedId", "GroupId" },
                keyValues: new object[] { new Guid("c1da285e-31d9-4b89-b245-9888df6cc1f8"), new Guid("51c49557-d4f3-4b37-aa43-a69b8a6ee6f4") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("83d66c54-222b-4a2a-907a-12be5b233ac2"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: new Guid("51c49557-d4f3-4b37-aa43-a69b8a6ee6f4"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("7b46b517-14f2-4c9b-b566-328a5485ca4a"));

            migrationBuilder.DeleteData(
                table: "UsersExtended",
                keyColumn: "UserExtendedId",
                keyValue: new Guid("c1da285e-31d9-4b89-b245-9888df6cc1f8"));

            migrationBuilder.InsertData(
                table: "Groups",
                column: "GroupId",
                value: new Guid("42729b9e-e983-4385-af92-9ba8146797d0"));

            migrationBuilder.InsertData(
                table: "UsersExtended",
                columns: new[] { "UserExtendedId", "FirstName", "LastName" },
                values: new object[] { new Guid("e42b1599-b09b-4660-8f3b-9631e549eabc"), "Mickhail", "Koriaka" });

            migrationBuilder.InsertData(
                table: "GroupRight",
                columns: new[] { "GroupRightId", "GroupId", "Module", "Object", "Operator" },
                values: new object[,]
                {
                    { new Guid("5721bed2-1929-449e-8cfc-5b09d56ab8d6"), new Guid("42729b9e-e983-4385-af92-9ba8146797d0"), 3, 4, 1 },
                    { new Guid("fe0bf773-fd37-40bd-9504-f45b5bee0c4b"), new Guid("42729b9e-e983-4385-af92-9ba8146797d0"), 1, 1, 3 },
                    { new Guid("6e42d288-c917-490a-82da-3cafa10ee720"), new Guid("42729b9e-e983-4385-af92-9ba8146797d0"), 3, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "UserExtendedId" },
                values: new object[] { new Guid("e21854f4-9195-41bf-ab7e-8d67a3a9d13e"), new Guid("e42b1599-b09b-4660-8f3b-9631e549eabc") });

            migrationBuilder.InsertData(
                table: "UserExtendedGroup",
                columns: new[] { "UserExtendedId", "GroupId" },
                values: new object[] { new Guid("e42b1599-b09b-4660-8f3b-9631e549eabc"), new Guid("42729b9e-e983-4385-af92-9ba8146797d0") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Login", "Password", "Token", "UserExtendedId" },
                values: new object[] { new Guid("7bd06515-3618-43d1-b5f4-c5734a5101e1"), "Miha", "1234", "", new Guid("e42b1599-b09b-4660-8f3b-9631e549eabc") });

            migrationBuilder.InsertData(
                table: "RoleRight",
                columns: new[] { "RoleRightId", "Module", "Object", "Operator", "RoleId", "UserExtendedId" },
                values: new object[] { new Guid("2660709e-6fc1-4ff6-b0f2-ae214b630452"), 3, 4, 1, new Guid("e21854f4-9195-41bf-ab7e-8d67a3a9d13e"), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "RoleRight",
                columns: new[] { "RoleRightId", "Module", "Object", "Operator", "RoleId", "UserExtendedId" },
                values: new object[] { new Guid("01c6d0e1-6036-40dd-ba58-8e8e8545e099"), 1, 1, 3, new Guid("e21854f4-9195-41bf-ab7e-8d67a3a9d13e"), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "RoleRight",
                columns: new[] { "RoleRightId", "Module", "Object", "Operator", "RoleId", "UserExtendedId" },
                values: new object[] { new Guid("05ba54bc-8adc-4634-bfdb-d4f9c6203cf7"), 3, 4, 3, new Guid("e21854f4-9195-41bf-ab7e-8d67a3a9d13e"), new Guid("00000000-0000-0000-0000-000000000000") });
        }
    }
}
