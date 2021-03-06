﻿// <auto-generated />
using System;
using Db.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Authorization.WebApi.Migrations
{
    [DbContext(typeof(EntitiesContext))]
    [Migration("20191210151940_NewMigration")]
    partial class NewMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Db.Authorization.Model.Group", b =>
                {
                    b.Property<Guid>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("GroupName")
                        .HasColumnType("text");

                    b.HasKey("GroupId");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            GroupId = new Guid("c810e61e-f94b-49bd-9b42-5f36cd011c36"),
                            GroupName = "NewGroup"
                        });
                });

            modelBuilder.Entity("Db.Authorization.Model.GroupRight", b =>
                {
                    b.Property<Guid>("GroupRightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uuid");

                    b.Property<int>("Module")
                        .HasColumnType("integer");

                    b.Property<int>("Object")
                        .HasColumnType("integer");

                    b.Property<int>("Operator")
                        .HasColumnType("integer");

                    b.HasKey("GroupRightId");

                    b.HasIndex("GroupId");

                    b.ToTable("GroupRight");

                    b.HasData(
                        new
                        {
                            GroupRightId = new Guid("5f8ad21e-ab0c-40f4-b191-a18518ccc7cd"),
                            GroupId = new Guid("c810e61e-f94b-49bd-9b42-5f36cd011c36"),
                            Module = 3,
                            Object = 4,
                            Operator = 1
                        },
                        new
                        {
                            GroupRightId = new Guid("d4ed1114-49bb-4b24-b171-cd5016a2be95"),
                            GroupId = new Guid("c810e61e-f94b-49bd-9b42-5f36cd011c36"),
                            Module = 1,
                            Object = 1,
                            Operator = 3
                        },
                        new
                        {
                            GroupRightId = new Guid("310d1597-b89c-43af-a244-9feaec02016c"),
                            GroupId = new Guid("c810e61e-f94b-49bd-9b42-5f36cd011c36"),
                            Module = 3,
                            Object = 4,
                            Operator = 3
                        });
                });

            modelBuilder.Entity("Db.Authorization.Model.Role", b =>
                {
                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("RoleName")
                        .HasColumnType("text");

                    b.Property<Guid>("UserExtendedId")
                        .HasColumnType("uuid");

                    b.HasKey("RoleId");

                    b.HasIndex("UserExtendedId")
                        .IsUnique();

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = new Guid("01948bff-9fe2-44a0-bc00-71e134cf8e6d"),
                            RoleName = "NewRole",
                            UserExtendedId = new Guid("bdf4b2c3-63a8-488d-8c4f-598e2f3c33e4")
                        });
                });

            modelBuilder.Entity("Db.Authorization.Model.RoleRight", b =>
                {
                    b.Property<Guid>("RoleRightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Module")
                        .HasColumnType("integer");

                    b.Property<int>("Object")
                        .HasColumnType("integer");

                    b.Property<int>("Operator")
                        .HasColumnType("integer");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("RoleRightId");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleRight");

                    b.HasData(
                        new
                        {
                            RoleRightId = new Guid("57247c5b-f036-4eef-8a49-fd6641210ca0"),
                            Module = 3,
                            Object = 4,
                            Operator = 1,
                            RoleId = new Guid("01948bff-9fe2-44a0-bc00-71e134cf8e6d")
                        },
                        new
                        {
                            RoleRightId = new Guid("f47e4004-8579-4e19-b9f8-43191b6ca62e"),
                            Module = 1,
                            Object = 1,
                            Operator = 3,
                            RoleId = new Guid("01948bff-9fe2-44a0-bc00-71e134cf8e6d")
                        },
                        new
                        {
                            RoleRightId = new Guid("dc97bac6-f213-4666-b92e-061da46e6efc"),
                            Module = 3,
                            Object = 4,
                            Operator = 3,
                            RoleId = new Guid("01948bff-9fe2-44a0-bc00-71e134cf8e6d")
                        });
                });

            modelBuilder.Entity("Db.Authorization.Model.UserExtended", b =>
                {
                    b.Property<Guid>("UserExtendedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.HasKey("UserExtendedId");

                    b.ToTable("UsersExtended");

                    b.HasData(
                        new
                        {
                            UserExtendedId = new Guid("bdf4b2c3-63a8-488d-8c4f-598e2f3c33e4"),
                            FirstName = "Mickhail",
                            LastName = "Koriaka",
                            Login = "Miha",
                            Password = "1234",
                            Token = ""
                        });
                });

            modelBuilder.Entity("Db.Authorization.Model.UserExtendedGroup", b =>
                {
                    b.Property<Guid>("UserExtendedId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uuid");

                    b.HasKey("UserExtendedId", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("UserExtendedGroup");

                    b.HasData(
                        new
                        {
                            UserExtendedId = new Guid("bdf4b2c3-63a8-488d-8c4f-598e2f3c33e4"),
                            GroupId = new Guid("c810e61e-f94b-49bd-9b42-5f36cd011c36")
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
