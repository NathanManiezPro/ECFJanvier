using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECFJanvier.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Evenement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Lieu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evenement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EvenementParticipant",
                columns: table => new
                {
                    ParticipantId = table.Column<int>(type: "int", nullable: false),
                    EvenementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvenementParticipant", x => new { x.ParticipantId, x.EvenementId });
                    table.ForeignKey(
                        name: "FK_EvenementParticipant_Evenement_EvenementId",
                        column: x => x.EvenementId,
                        principalTable: "Evenement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvenementParticipant_Participant_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Participant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EvenementParticipant_EvenementId",
                table: "EvenementParticipant",
                column: "EvenementId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EvenementParticipant");

            migrationBuilder.DropTable(
                name: "Evenement");

            migrationBuilder.DropTable(
                name: "Participant");
        }
    }
}
