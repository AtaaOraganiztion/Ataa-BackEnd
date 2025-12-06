using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class News : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    category = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    image_url = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    qoute = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    published_on_utc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    created_on_utc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    last_modified_by = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    last_modified_on_utc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    deleted_on_utc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    news_id = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    heading = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    content = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    created_on_utc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    last_modified_by = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    last_modified_on_utc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    deleted_on_utc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sections", x => x.id);
                    table.ForeignKey(
                        name: "fk_sections_news_news_id",
                        column: x => x.news_id,
                        principalTable: "News",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_news_category",
                table: "News",
                column: "category");

            migrationBuilder.CreateIndex(
                name: "ix_news_image_url",
                table: "News",
                column: "image_url");

            migrationBuilder.CreateIndex(
                name: "ix_news_qoute",
                table: "News",
                column: "qoute");

            migrationBuilder.CreateIndex(
                name: "ix_news_title",
                table: "News",
                column: "title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_sections_content",
                table: "Sections",
                column: "content");

            migrationBuilder.CreateIndex(
                name: "ix_sections_heading",
                table: "Sections",
                column: "heading");

            migrationBuilder.CreateIndex(
                name: "ix_sections_news_id",
                table: "Sections",
                column: "news_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "News");
        }
    }
}
