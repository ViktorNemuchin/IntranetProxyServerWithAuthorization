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
    [Migration("20200121095738_RoleId")]
    partial class RoleId
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
                            GroupId = new Guid("2b26bba5-1482-4e1e-b734-74928bae413b"),
                            GroupName = "DefaultGroup"
                        });
                });

            modelBuilder.Entity("Db.Authorization.Model.GroupRight", b =>
                {
                    b.Property<Guid>("GroupRightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RightId")
                        .HasColumnType("uuid");

                    b.HasKey("GroupRightId");

                    b.HasIndex("GroupId");

                    b.ToTable("GroupRights");

                    b.HasData(
                        new
                        {
                            GroupRightId = new Guid("2b26bba5-1482-4e1e-b734-74928bae413b"),
                            GroupId = new Guid("2b26bba5-1482-4e1e-b734-74928bae413b"),
                            RightId = new Guid("4324a040-9f65-4bf9-8dca-fe9cb6c7aff5")
                        });
                });

            modelBuilder.Entity("Db.Authorization.Model.Right", b =>
                {
                    b.Property<Guid>("RightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Module")
                        .HasColumnType("integer");

                    b.Property<int>("Object")
                        .HasColumnType("integer");

                    b.Property<int>("Operator")
                        .HasColumnType("integer");

                    b.HasKey("RightId");

                    b.ToTable("Rights");

                    b.HasData(
                        new
                        {
                            RightId = new Guid("4324a040-9f65-4bf9-8dca-fe9cb6c7aff5"),
                            Module = 0,
                            Object = 0,
                            Operator = 0
                        });
                });

            modelBuilder.Entity("Db.Authorization.Model.Role", b =>
                {
                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("RoleName")
                        .HasColumnType("text");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = new Guid("ceace335-f1f9-43e6-8a89-c0f4d06d0187"),
                            RoleName = "DefaultRole"
                        });
                });

            modelBuilder.Entity("Db.Authorization.Model.RoleRight", b =>
                {
                    b.Property<Guid>("RoleRightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("RightId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("RoleRightId");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleRights");

                    b.HasData(
                        new
                        {
                            RoleRightId = new Guid("47f38af7-cea8-47b8-bd1c-3646fc60f18c"),
                            RightId = new Guid("4324a040-9f65-4bf9-8dca-fe9cb6c7aff5"),
                            RoleId = new Guid("ceace335-f1f9-43e6-8a89-c0f4d06d0187")
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

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.HasKey("UserExtendedId");

                    b.HasIndex("RoleId");

                    b.ToTable("UsersExtended");
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
                });

            modelBuilder.Entity("Db.Authorization.Model.GroupRight", b =>
                {
                    b.HasOne("Db.Authorization.Model.Group", "Group")
                        .WithMany("GroupRights")
                        .HasForeignKey("GroupId")
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

            modelBuilder.Entity("Db.Authorization.Model.UserExtended", b =>
                {
                    b.HasOne("Db.Authorization.Model.Role", "Role")
                        .WithMany("User")
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
