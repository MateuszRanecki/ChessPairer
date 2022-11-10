using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChessPairer.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tournament",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TournamentType = table.Column<int>(type: "int", nullable: false),
                    PairingType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournament", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PlayerGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BigPointsCount = table.Column<int>(type: "int", nullable: false),
                    SmallPointsCount = table.Column<double>(type: "float", nullable: false),
                    FirstBoardPointsCount = table.Column<double>(type: "float", nullable: false),
                    Bucholz = table.Column<double>(type: "float", nullable: false),
                    startNumber = table.Column<int>(type: "int", nullable: false),
                    TournamentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerGroup_Tournament_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournament",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Round",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TournamentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Round", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Round_Tournament_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournament",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PointsCount = table.Column<double>(type: "float", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    Board = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TournamentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    startNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Player_PlayerGroup_GroupId",
                        column: x => x.GroupId,
                        principalTable: "PlayerGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Player_Tournament_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournament",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WhitePlayer = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlackPlayer = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: true),
                    RoundId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Game_Round_RoundId",
                        column: x => x.RoundId,
                        principalTable: "Round",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Game_RoundId",
                table: "Game",
                column: "RoundId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_GroupId",
                table: "Player",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_TournamentId",
                table: "Player",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGroup_TournamentId",
                table: "PlayerGroup",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Round_TournamentId",
                table: "Round",
                column: "TournamentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Round");

            migrationBuilder.DropTable(
                name: "PlayerGroup");

            migrationBuilder.DropTable(
                name: "Tournament");
        }
    }
}
