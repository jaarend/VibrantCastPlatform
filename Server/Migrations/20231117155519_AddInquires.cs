using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VibrantCastPlatform.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddInquires : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inquiries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ArtworkId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InteractionId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOpened = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inquiries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inquiries_Artworks_ArtworkId",
                        column: x => x.ArtworkId,
                        principalTable: "Artworks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inquiries_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inquiries_ArtworkId",
                table: "Inquiries",
                column: "ArtworkId");

            migrationBuilder.CreateIndex(
                name: "IX_Inquiries_UsersId",
                table: "Inquiries",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inquiries");
        }
    }
}
