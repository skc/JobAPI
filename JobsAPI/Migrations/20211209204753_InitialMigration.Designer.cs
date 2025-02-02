﻿// <auto-generated />
using System;
using JobsAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JobsAPI.Migrations
{
    [DbContext(typeof(JobsDbContext))]
    [Migration("20211209204753_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JobsAPI.Data.Models.Attachment", b =>
                {
                    b.Property<int>("AttachmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Application")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UploadedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UploadedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AttachmentId");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("JobsAPI.Data.Models.InfoNote", b =>
                {
                    b.Property<int>("InfoNoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttachmentId")
                        .HasColumnType("int");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InfoNoteId");

                    b.HasIndex("AttachmentId");

                    b.HasIndex("JobId");

                    b.ToTable("InfoNotes");
                });

            modelBuilder.Entity("JobsAPI.Data.Models.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Application")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ChangedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ChangedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Group")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCritical")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("JobsAPI.Data.Models.OperatorsNote", b =>
                {
                    b.Property<int>("OperatorsNoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OperatorsNoteId");

                    b.HasIndex("JobId");

                    b.ToTable("OperatorsNotes");
                });

            modelBuilder.Entity("JobsAPI.Data.Models.Permission", b =>
                {
                    b.Property<int>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Application")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("GrantedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("GrantedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("MayGrant")
                        .HasColumnType("bit");

                    b.Property<string>("User")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PermissionId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("JobsAPI.Data.Models.ProgrammersNote", b =>
                {
                    b.Property<int>("ProgrammersNoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProgrammersNoteId");

                    b.HasIndex("JobId");

                    b.HasIndex("RoleId");

                    b.ToTable("ProgrammersNotes");
                });

            modelBuilder.Entity("JobsAPI.Data.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("AddedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Application")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("JobsAPI.Data.Models.Role_Programmer", b =>
                {
                    b.Property<int>("Role_programmerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("ProgarmmerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Role_programmerId");

                    b.HasIndex("RoleId");

                    b.ToTable("Role_Programmers");
                });

            modelBuilder.Entity("JobsAPI.Data.Models.InfoNote", b =>
                {
                    b.HasOne("JobsAPI.Data.Models.Attachment", "Attachment")
                        .WithMany()
                        .HasForeignKey("AttachmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobsAPI.Data.Models.Job", "Job")
                        .WithMany("InfoNotes")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attachment");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("JobsAPI.Data.Models.OperatorsNote", b =>
                {
                    b.HasOne("JobsAPI.Data.Models.Job", "Job")
                        .WithMany("OperatorsNotes")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");
                });

            modelBuilder.Entity("JobsAPI.Data.Models.ProgrammersNote", b =>
                {
                    b.HasOne("JobsAPI.Data.Models.Job", "Job")
                        .WithMany("ProgrammersNotes")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobsAPI.Data.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("JobsAPI.Data.Models.Role_Programmer", b =>
                {
                    b.HasOne("JobsAPI.Data.Models.Role", "Role")
                        .WithMany("Role_Programmers")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("JobsAPI.Data.Models.Job", b =>
                {
                    b.Navigation("InfoNotes");

                    b.Navigation("OperatorsNotes");

                    b.Navigation("ProgrammersNotes");
                });

            modelBuilder.Entity("JobsAPI.Data.Models.Role", b =>
                {
                    b.Navigation("Role_Programmers");
                });
#pragma warning restore 612, 618
        }
    }
}
