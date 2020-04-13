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
    [Migration("20200115140515_DataBaseRefactoring1")]
    partial class DataBaseRefactoring1
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
                            GroupId = new Guid("9d52647d-ce33-4999-a5fa-c0726467a4dd"),
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

                    b.ToTable("GroupRight");

                    b.HasData(
                        new
                        {
                            GroupRightId = new Guid("9d52647d-ce33-4999-a5fa-c0726467a4dd"),
                            GroupId = new Guid("9d52647d-ce33-4999-a5fa-c0726467a4dd"),
                            RightId = new Guid("e358e394-4029-4a52-b774-ffa60ff47892")
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
                            RightId = new Guid("e358e394-4029-4a52-b774-ffa60ff47892"),
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
                            RoleId = new Guid("218db7a6-a4df-415b-8961-8df52d53f937"),
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

                    b.ToTable("RoleRight");

                    b.HasData(
                        new
                        {
                            RoleRightId = new Guid("afde4a21-cf84-442d-8c5a-11a505a3d292"),
                            RightId = new Guid("e358e394-4029-4a52-b774-ffa60ff47892"),
                            RoleId = new Guid("218db7a6-a4df-415b-8961-8df52d53f937")
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

                    b.Property<Guid?>("RoleId")
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
                        .HasForeignKey("RoleId");
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
