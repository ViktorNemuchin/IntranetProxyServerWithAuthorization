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
    [Migration("20191025134550_DeleteUserOneMoreTime")]
    partial class DeleteUserOneMoreTime
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
                            GroupId = new Guid("d3a16f52-4fac-4c43-a935-71b1cfb884a5")
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
                            GroupRightId = new Guid("ecfa6321-fe87-4214-9409-a9ab86409a2a"),
                            GroupId = new Guid("d3a16f52-4fac-4c43-a935-71b1cfb884a5"),
                            Module = 3,
                            Object = 4,
                            Operator = 1
                        },
                        new
                        {
                            GroupRightId = new Guid("2b440333-d067-46e6-b294-e05d2de8c456"),
                            GroupId = new Guid("d3a16f52-4fac-4c43-a935-71b1cfb884a5"),
                            Module = 1,
                            Object = 1,
                            Operator = 3
                        },
                        new
                        {
                            GroupRightId = new Guid("9c10233c-ce63-43cc-9027-cc55ec417c64"),
                            GroupId = new Guid("d3a16f52-4fac-4c43-a935-71b1cfb884a5"),
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
                            RoleId = new Guid("67e6f9a1-abd8-4242-a6d7-3d7af6ae50e5"),
                            UserExtendedId = new Guid("f3941aa2-64a5-4de3-99f1-805c4af17d86")
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
                            RoleRightId = new Guid("b3dbd4a8-253b-4cbe-bb11-4e4ef9da1d4c"),
                            Module = 3,
                            Object = 4,
                            Operator = 1,
                            RoleId = new Guid("67e6f9a1-abd8-4242-a6d7-3d7af6ae50e5"),
                            UserExtendedId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            RoleRightId = new Guid("bf48845e-1522-409c-851c-7751c29f14f8"),
                            Module = 1,
                            Object = 1,
                            Operator = 3,
                            RoleId = new Guid("67e6f9a1-abd8-4242-a6d7-3d7af6ae50e5"),
                            UserExtendedId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            RoleRightId = new Guid("0be23894-3b3d-4fd9-ba1d-20327ae2e2a3"),
                            Module = 3,
                            Object = 4,
                            Operator = 3,
                            RoleId = new Guid("67e6f9a1-abd8-4242-a6d7-3d7af6ae50e5"),
                            UserExtendedId = new Guid("00000000-0000-0000-0000-000000000000")
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

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserExtendedId");

                    b.ToTable("UsersExtended");

                    b.HasData(
                        new
                        {
                            UserExtendedId = new Guid("f3941aa2-64a5-4de3-99f1-805c4af17d86"),
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
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserExtendedId", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("UserExtendedGroup");

                    b.HasData(
                        new
                        {
                            UserExtendedId = new Guid("f3941aa2-64a5-4de3-99f1-805c4af17d86"),
                            GroupId = new Guid("d3a16f52-4fac-4c43-a935-71b1cfb884a5")
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
