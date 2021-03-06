﻿// <auto-generated />
using System;
using Db.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Db.Authorization.Migrations
{
    [DbContext(typeof(EntitiesContext))]
    [Migration("20191025131705_CheckingForErrors")]
    partial class CheckingForErrors
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Db.Authorization.Model.Group", b =>
                {
                    b.Property<Guid>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GroupId");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            GroupId = new Guid("51c49557-d4f3-4b37-aa43-a69b8a6ee6f4")
                        });
                });

            modelBuilder.Entity("Db.Authorization.Model.GroupRight", b =>
                {
                    b.Property<Guid>("GroupRightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Module")
                        .HasColumnType("int");

                    b.Property<int>("Object")
                        .HasColumnType("int");

                    b.Property<int>("Operator")
                        .HasColumnType("int");

                    b.HasKey("GroupRightId");

                    b.HasIndex("GroupId");

                    b.ToTable("GroupRight");

                    b.HasData(
                        new
                        {
                            GroupRightId = new Guid("ae7529a6-b28c-4e3f-9f71-4d37381a9b60"),
                            GroupId = new Guid("51c49557-d4f3-4b37-aa43-a69b8a6ee6f4"),
                            Module = 3,
                            Object = 4,
                            Operator = 1
                        },
                        new
                        {
                            GroupRightId = new Guid("db075de3-444b-4a3a-94df-7fa1cf729ba7"),
                            GroupId = new Guid("51c49557-d4f3-4b37-aa43-a69b8a6ee6f4"),
                            Module = 1,
                            Object = 1,
                            Operator = 3
                        },
                        new
                        {
                            GroupRightId = new Guid("ea4c93d3-1a90-45ab-b9d5-3ff4ec58cb89"),
                            GroupId = new Guid("51c49557-d4f3-4b37-aa43-a69b8a6ee6f4"),
                            Module = 3,
                            Object = 4,
                            Operator = 3
                        });
                });

            modelBuilder.Entity("Db.Authorization.Model.Role", b =>
                {
                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserExtendedId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoleId");

                    b.HasIndex("UserExtendedId")
                        .IsUnique();

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = new Guid("7b46b517-14f2-4c9b-b566-328a5485ca4a"),
                            UserExtendedId = new Guid("c1da285e-31d9-4b89-b245-9888df6cc1f8")
                        });
                });

            modelBuilder.Entity("Db.Authorization.Model.RoleRight", b =>
                {
                    b.Property<Guid>("RoleRightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Module")
                        .HasColumnType("int");

                    b.Property<int>("Object")
                        .HasColumnType("int");

                    b.Property<int>("Operator")
                        .HasColumnType("int");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserExtendedId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoleRightId");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleRight");

                    b.HasData(
                        new
                        {
                            RoleRightId = new Guid("47b978a3-e627-41cd-95bc-4b37e57bd7b6"),
                            Module = 3,
                            Object = 4,
                            Operator = 1,
                            RoleId = new Guid("7b46b517-14f2-4c9b-b566-328a5485ca4a"),
                            UserExtendedId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            RoleRightId = new Guid("8d2dd6f8-533c-4e31-a5e8-d95712850672"),
                            Module = 1,
                            Object = 1,
                            Operator = 3,
                            RoleId = new Guid("7b46b517-14f2-4c9b-b566-328a5485ca4a"),
                            UserExtendedId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            RoleRightId = new Guid("8b159664-13a3-477a-b6f3-b812e5f83845"),
                            Module = 3,
                            Object = 4,
                            Operator = 3,
                            RoleId = new Guid("7b46b517-14f2-4c9b-b566-328a5485ca4a"),
                            UserExtendedId = new Guid("00000000-0000-0000-0000-000000000000")
                        });
                });

            modelBuilder.Entity("Db.Authorization.Model.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserExtendedId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId");

                    b.HasIndex("UserExtendedId")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("83d66c54-222b-4a2a-907a-12be5b233ac2"),
                            Login = "Miha",
                            Password = "1234",
                            Token = "",
                            UserExtendedId = new Guid("c1da285e-31d9-4b89-b245-9888df6cc1f8")
                        });
                });

            modelBuilder.Entity("Db.Authorization.Model.UserExtended", b =>
                {
                    b.Property<Guid>("UserExtendedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserExtendedId");

                    b.ToTable("UsersExtended");

                    b.HasData(
                        new
                        {
                            UserExtendedId = new Guid("c1da285e-31d9-4b89-b245-9888df6cc1f8"),
                            FirstName = "Mickhail",
                            LastName = "Koriaka"
                        });
                });

            modelBuilder.Entity("Db.Authorization.Model.UserExtendedGroup", b =>
                {
                    b.Property<Guid>("UserExtendedId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserExtendedId", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("UserExtendedGroup");

                    b.HasData(
                        new
                        {
                            UserExtendedId = new Guid("c1da285e-31d9-4b89-b245-9888df6cc1f8"),
                            GroupId = new Guid("51c49557-d4f3-4b37-aa43-a69b8a6ee6f4")
                        });
                });

            modelBuilder.Entity("Db.Authorization.Model.GroupRight", b =>
                {
                    b.HasOne("Db.Authorization.Model.Group", "Group")
                        .WithMany("GroupRights")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Db.Authorization.Model.Role", b =>
                {
                    b.HasOne("Db.Authorization.Model.UserExtended", "User")
                        .WithOne("Role")
                        .HasForeignKey("Db.Authorization.Model.Role", "UserExtendedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Db.Authorization.Model.RoleRight", b =>
                {
                    b.HasOne("Db.Authorization.Model.Role", "Role")
                        .WithMany("RoleRights")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Db.Authorization.Model.User", b =>
                {
                    b.HasOne("Db.Authorization.Model.UserExtended", null)
                        .WithOne("User")
                        .HasForeignKey("Db.Authorization.Model.User", "UserExtendedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Db.Authorization.Model.UserExtendedGroup", b =>
                {
                    b.HasOne("Db.Authorization.Model.Group", "Group")
                        .WithMany("UserExtendedGroups")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Db.Authorization.Model.UserExtended", "User")
                        .WithMany("UserExtendedGroups")
                        .HasForeignKey("UserExtendedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
