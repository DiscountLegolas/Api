using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Description : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardLists_Boards_BoardId",
                table: "CardLists");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_CardLists_CardListId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId1",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Cards_CardId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Details_Cards_CardId",
                table: "Details");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkplaceMembers_AspNetUsers_UserId1",
                table: "WorkplaceMembers");

            migrationBuilder.DropIndex(
                name: "IX_WorkplaceMembers_UserId1",
                table: "WorkplaceMembers");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserId1",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "WorkplaceMembers");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Workplaces",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "WorkplaceMembers",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "CardId",
                table: "Details",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Comments",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "CardId",
                table: "Comments",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CardListId",
                table: "Cards",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BoardId",
                table: "CardLists",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkplaceId",
                table: "Boards",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WorkplaceMembers_UserId",
                table: "WorkplaceMembers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Boards_WorkplaceId",
                table: "Boards",
                column: "WorkplaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boards_Workplaces_WorkplaceId",
                table: "Boards",
                column: "WorkplaceId",
                principalTable: "Workplaces",
                principalColumn: "WorkplaceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CardLists_Boards_BoardId",
                table: "CardLists",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_CardLists_CardListId",
                table: "Cards",
                column: "CardListId",
                principalTable: "CardLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Cards_CardId",
                table: "Comments",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Details_Cards_CardId",
                table: "Details",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkplaceMembers_AspNetUsers_UserId",
                table: "WorkplaceMembers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boards_Workplaces_WorkplaceId",
                table: "Boards");

            migrationBuilder.DropForeignKey(
                name: "FK_CardLists_Boards_BoardId",
                table: "CardLists");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_CardLists_CardListId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Cards_CardId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Details_Cards_CardId",
                table: "Details");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkplaceMembers_AspNetUsers_UserId",
                table: "WorkplaceMembers");

            migrationBuilder.DropIndex(
                name: "IX_WorkplaceMembers_UserId",
                table: "WorkplaceMembers");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Boards_WorkplaceId",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Workplaces");

            migrationBuilder.DropColumn(
                name: "WorkplaceId",
                table: "Boards");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "WorkplaceMembers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "WorkplaceMembers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "CardId",
                table: "Details",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Comments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "CardId",
                table: "Comments",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Comments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "CardListId",
                table: "Cards",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<Guid>(
                name: "BoardId",
                table: "CardLists",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateIndex(
                name: "IX_WorkplaceMembers_UserId1",
                table: "WorkplaceMembers",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId1",
                table: "Comments",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CardLists_Boards_BoardId",
                table: "CardLists",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_CardLists_CardListId",
                table: "Cards",
                column: "CardListId",
                principalTable: "CardLists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId1",
                table: "Comments",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Cards_CardId",
                table: "Comments",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Details_Cards_CardId",
                table: "Details",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkplaceMembers_AspNetUsers_UserId1",
                table: "WorkplaceMembers",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
