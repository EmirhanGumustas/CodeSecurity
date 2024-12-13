using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Party.Data.Migrations
{
    /// <inheritdoc />
    public partial class MigStart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invitation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invitation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<byte>(type: "tinyint", nullable: true),
                    NumberOfPeople = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvitationParticipants",
                columns: table => new
                {
                    InvitationId = table.Column<int>(type: "int", nullable: false),
                    ParticipantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvitationParticipants", x => new { x.InvitationId, x.ParticipantId });
                    table.ForeignKey(
                        name: "FK_InvitationParticipants_Invitation_InvitationId",
                        column: x => x.InvitationId,
                        principalTable: "Invitation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvitationParticipants_Participant_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Participant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Invitation",
                columns: new[] { "Id", "EventDate", "EventName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test" },
                    { 2, new DateTime(2024, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test1" }
                });

            migrationBuilder.InsertData(
                table: "Participant",
                columns: new[] { "Id", "Age", "Email", "FullName", "NumberOfPeople", "Phone" },
                values: new object[,]
                {
                    { 1, (byte)1, "sadad@gmail.com", "TestİSİM", 1, "asşldkasdş" },
                    { 2, (byte)2, "sadad@gmail.com", "TestİSİM2", 1, "asşldkasdş2" },
                    { 3, (byte)3, "sadad@gmail.com", "TestİSİ4", 3, "asşldkasdş3" },
                    { 4, (byte)4, "sadad@gmail.com", "TestİSİM4", 1, "asşldkasdş4" },
                    { 5, (byte)5, "sadad@gmail.com", "TestİSİM5", 2, "asşldkasdş5" },
                    { 6, (byte)6, "sadad@gmail.com", "TestİSİM6", 1, "asşldkasdş6" }
                });

            migrationBuilder.InsertData(
                table: "InvitationParticipants",
                columns: new[] { "InvitationId", "ParticipantId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 6 },
                    { 2, 1 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvitationParticipants_ParticipantId",
                table: "InvitationParticipants",
                column: "ParticipantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvitationParticipants");

            migrationBuilder.DropTable(
                name: "Invitation");

            migrationBuilder.DropTable(
                name: "Participant");
        }
    }
}
