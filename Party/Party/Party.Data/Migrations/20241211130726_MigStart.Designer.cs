﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Party.Data.Concrate;

#nullable disable

namespace Party.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241211130726_MigStart")]
    partial class MigStart
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Part.Entity.Concrate.Invitation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasMaxLength(65)
                        .HasColumnType("nvarchar(65)");

                    b.HasKey("Id");

                    b.ToTable("Invitation", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EventDate = new DateTime(2024, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EventName = "Test"
                        },
                        new
                        {
                            Id = 2,
                            EventDate = new DateTime(2024, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EventName = "Test1"
                        });
                });

            modelBuilder.Entity("Part.Entity.Concrate.InvitationParticipant", b =>
                {
                    b.Property<int>("InvitationId")
                        .HasColumnType("int");

                    b.Property<int>("ParticipantId")
                        .HasColumnType("int");

                    b.HasKey("InvitationId", "ParticipantId");

                    b.HasIndex("ParticipantId");

                    b.ToTable("InvitationParticipants");

                    b.HasData(
                        new
                        {
                            InvitationId = 1,
                            ParticipantId = 2
                        },
                        new
                        {
                            InvitationId = 2,
                            ParticipantId = 4
                        },
                        new
                        {
                            InvitationId = 1,
                            ParticipantId = 3
                        },
                        new
                        {
                            InvitationId = 2,
                            ParticipantId = 5
                        },
                        new
                        {
                            InvitationId = 1,
                            ParticipantId = 6
                        },
                        new
                        {
                            InvitationId = 2,
                            ParticipantId = 1
                        },
                        new
                        {
                            InvitationId = 1,
                            ParticipantId = 4
                        },
                        new
                        {
                            InvitationId = 2,
                            ParticipantId = 3
                        },
                        new
                        {
                            InvitationId = 1,
                            ParticipantId = 5
                        },
                        new
                        {
                            InvitationId = 2,
                            ParticipantId = 6
                        });
                });

            modelBuilder.Entity("Part.Entity.Concrate.Participant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte?>("Age")
                        .HasColumnType("tinyint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("NumberOfPeople")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Participant", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = (byte)1,
                            Email = "sadad@gmail.com",
                            FullName = "TestİSİM",
                            NumberOfPeople = 1,
                            Phone = "asşldkasdş"
                        },
                        new
                        {
                            Id = 2,
                            Age = (byte)2,
                            Email = "sadad@gmail.com",
                            FullName = "TestİSİM2",
                            NumberOfPeople = 1,
                            Phone = "asşldkasdş2"
                        },
                        new
                        {
                            Id = 3,
                            Age = (byte)3,
                            Email = "sadad@gmail.com",
                            FullName = "TestİSİ4",
                            NumberOfPeople = 3,
                            Phone = "asşldkasdş3"
                        },
                        new
                        {
                            Id = 4,
                            Age = (byte)4,
                            Email = "sadad@gmail.com",
                            FullName = "TestİSİM4",
                            NumberOfPeople = 1,
                            Phone = "asşldkasdş4"
                        },
                        new
                        {
                            Id = 5,
                            Age = (byte)5,
                            Email = "sadad@gmail.com",
                            FullName = "TestİSİM5",
                            NumberOfPeople = 2,
                            Phone = "asşldkasdş5"
                        },
                        new
                        {
                            Id = 6,
                            Age = (byte)6,
                            Email = "sadad@gmail.com",
                            FullName = "TestİSİM6",
                            NumberOfPeople = 1,
                            Phone = "asşldkasdş6"
                        });
                });

            modelBuilder.Entity("Part.Entity.Concrate.InvitationParticipant", b =>
                {
                    b.HasOne("Part.Entity.Concrate.Invitation", "Invitation")
                        .WithMany("InvitationParticipants")
                        .HasForeignKey("InvitationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Part.Entity.Concrate.Participant", "Participant")
                        .WithMany("InvitationParticipants")
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invitation");

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("Part.Entity.Concrate.Invitation", b =>
                {
                    b.Navigation("InvitationParticipants");
                });

            modelBuilder.Entity("Part.Entity.Concrate.Participant", b =>
                {
                    b.Navigation("InvitationParticipants");
                });
#pragma warning restore 612, 618
        }
    }
}
