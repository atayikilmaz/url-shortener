using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace urlShortener.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "url_mappings",
                columns: table => new
                {
                    ShortenedUrl = table.Column<string>(type: "text", nullable: false),
                    LongUrl = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_url_mappings", x => x.ShortenedUrl);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "url_mappings");
        }
    }
}
