using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Db.Authorization.Migrations
{
    public partial class UpdateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_UsersExtended_UserExtendedId",
                table: "Group");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExtendedGroup_Group_GroupId",
                table: "UserExtendedGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExtendedGroup_Users_UserId",
                table: "UserExtendedGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersExtended_Role_RoleId",
                table: "UsersExtended");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersExtended_Users_UserCredentialsUserId",
                table: "UsersExtended");

            migrationBuilder.DropTable(
                name: "Right");

            migrationBuilder.DropIndex(
                name: "IX_UsersExtended_RoleId",
                table: "UsersExtended");

            migrationBuilder.DropIndex(
                name: "IX_UsersExtended_UserCredentialsUserId",
                table: "UsersExtended");

            migrationBuilder.DropIndex(
                name: "IX_UserExtendedGroup_UserId",
                table: "UserExtendedGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Group",
                table: "Group");

            migrationBuilder.DropIndex(
                name: "IX_Group_UserExtendedId",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "UsersExtended");

            migrationBuilder.DropColumn(
                name: "UserCredentialsUserId",
                table: "UsersExtended");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserExtendedGroup");

            migrationBuilder.DropColumn(
                name: "UserExtendedId",
                table: "Group");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "Group",
                newName: "Groups");

            migrationBuilder.AddColumn<Guid>(
                name: "UserExtendedId",
                table: "Users",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserExtendedId",
                table: "Roles",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "GroupId");

            migrationBuilder.CreateTable(
                name: "GroupRight",
                columns: table => new
                {
                    GroupRightId = table.Column<Guid>(nullable: false),
                    Module = table.Column<int>(nullable: false),
                    Object = table.Column<int>(nullable: false),
                    Operator = table.Column<int>(nullable: false),
                    GroupId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupRight", x => x.GroupRightId);
                    table.ForeignKey(
                        name: "FK_GroupRight_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleRight",
                columns: table => new
                {
                    RoleRightId = table.Column<Guid>(nullable: false),
                    Module = table.Column<int>(nullable: false),
                    Object = table.Column<int>(nullable: false),
                    Operator = table.Column<int>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    UserExtendedId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleRight", x => x.RoleRightId);
                    table.ForeignKey(
                        name: "FK_RoleRight_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserExtendedId",
                table: "Users",
                column: "UserExtendedId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UserExtendedId",
                table: "Roles",
                column: "UserExtendedId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupRight_GroupId",
                table: "GroupRight",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleRight_RoleId",
                table: "RoleRight",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_UsersExtended_UserExtendedId",
                table: "Roles",
                column: "UserExtendedId",
                principalTable: "UsersExtended",
                principalColumn: "UserExtendedId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserExtendedGroup_Groups_GroupId",
                table: "UserExtendedGroup",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserExtendedGroup_UsersExtended_UserExtendedId",
                table: "UserExtendedGroup",
                column: "UserExtendedId",
                principalTable: "UsersExtended",
                principalColumn: "UserExtendedId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UsersExtended_UserExtendedId",
                table: "Users",
                column: "UserExtendedId",
                principalTable: "UsersExtended",
                principalColumn: "UserExtendedId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_UsersExtended_UserExtendedId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExtendedGroup_Groups_GroupId",
                table: "UserExtendedGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExtendedGroup_UsersExtended_UserExtendedId",
                table: "UserExtendedGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UsersExtended_UserExtendedId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "GroupRight");

            migrationBuilder.DropTable(
                name: "RoleRight");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserExtendedId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_UserExtendedId",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("e21854f4-9195-41bf-ab7e-8d67a3a9d13e"));

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
                table: "UsersExtended",
                keyColumn: "UserExtendedId",
                keyValue: new Guid("e42b1599-b09b-4660-8f3b-9631e549eabc"));

            migrationBuilder.DropColumn(
                name: "UserExtendedId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserExtendedId",
                table: "Roles");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "Group");

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "UsersExtended",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserCredentialsUserId",
                table: "UsersExtended",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserExtendedGroup",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserExtendedId",
                table: "Group",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Group",
                table: "Group",
                column: "GroupId");

            migrationBuilder.CreateTable(
                name: "Right",
                columns: table => new
                {
                    RightId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Module = table.Column<int>(type: "int", nullable: false),
                    Object = table.Column<int>(type: "int", nullable: false),
                    Operator = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Right", x => x.RightId);
                    table.ForeignKey(
                        name: "FK_Right_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Right_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersExtended_RoleId",
                table: "UsersExtended",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersExtended_UserCredentialsUserId",
                table: "UsersExtended",
                column: "UserCredentialsUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserExtendedGroup_UserId",
                table: "UserExtendedGroup",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_UserExtendedId",
                table: "Group",
                column: "UserExtendedId");

            migrationBuilder.CreateIndex(
                name: "IX_Right_GroupId",
                table: "Right",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Right_RoleId",
                table: "Right",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Group_UsersExtended_UserExtendedId",
                table: "Group",
                column: "UserExtendedId",
                principalTable: "UsersExtended",
                principalColumn: "UserExtendedId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserExtendedGroup_Group_GroupId",
                table: "UserExtendedGroup",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserExtendedGroup_Users_UserId",
                table: "UserExtendedGroup",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersExtended_Role_RoleId",
                table: "UsersExtended",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersExtended_Users_UserCredentialsUserId",
                table: "UsersExtended",
                column: "UserCredentialsUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
