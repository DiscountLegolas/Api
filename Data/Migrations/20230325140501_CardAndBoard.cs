using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class CardAndBoard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Cards",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "BoardMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Admin = table.Column<bool>(type: "boolean", nullable: false),
                    WorkplaceMemberId = table.Column<int>(type: "integer", nullable: false),
                    BoardId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoardMembers_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardMembers_WorkplaceMembers_WorkplaceMemberId",
                        column: x => x.WorkplaceMemberId,
                        principalTable: "WorkplaceMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardAssingments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Admin = table.Column<bool>(type: "boolean", nullable: false),
                    MemberId = table.Column<int>(type: "integer", nullable: false),
                    CardId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardAssingments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardAssingments_BoardMembers_MemberId",
                        column: x => x.MemberId,
                        principalTable: "BoardMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardAssingments_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardMembers_BoardId",
                table: "BoardMembers",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardMembers_WorkplaceMemberId",
                table: "BoardMembers",
                column: "WorkplaceMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_CardAssingments_CardId",
                table: "CardAssingments",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_CardAssingments_MemberId",
                table: "CardAssingments",
                column: "MemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardAssingments");

            migrationBuilder.DropTable(
                name: "BoardMembers");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Cards");
        }
    }
}
