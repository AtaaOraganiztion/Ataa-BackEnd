using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class Services : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_news_title",
                table: "News");

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    short_desc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    long_desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    main_image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    created_on_utc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    last_modified_by = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    last_modified_on_utc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    deleted_on_utc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_services", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    benifit = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    service_id = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    created_on_utc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    last_modified_by = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    last_modified_on_utc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    deleted_on_utc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_features", x => x.id);
                    table.ForeignKey(
                        name: "fk_features_services_service_id",
                        column: x => x.service_id,
                        principalTable: "Services",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gallery",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    service_id = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    image_url = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    created_on_utc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    last_modified_by = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    last_modified_on_utc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    deleted_on_utc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_gallery", x => x.id);
                    table.ForeignKey(
                        name: "fk_gallery_services_service_id",
                        column: x => x.service_id,
                        principalTable: "Services",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Statics",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    number = table.Column<int>(type: "int", nullable: false),
                    service_id = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    created_on_utc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    last_modified_by = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    last_modified_on_utc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    deleted_on_utc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_statics", x => x.id);
                    table.ForeignKey(
                        name: "fk_statics_services_service_id",
                        column: x => x.service_id,
                        principalTable: "Services",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_news_title",
                table: "News",
                column: "title");

            migrationBuilder.CreateIndex(
                name: "ix_features_benifit",
                table: "Features",
                column: "benifit");

            migrationBuilder.CreateIndex(
                name: "ix_features_service_id",
                table: "Features",
                column: "service_id");

            migrationBuilder.CreateIndex(
                name: "ix_features_title",
                table: "Features",
                column: "title");

            migrationBuilder.CreateIndex(
                name: "ix_gallery_image_url",
                table: "Gallery",
                column: "image_url");

            migrationBuilder.CreateIndex(
                name: "ix_gallery_service_id",
                table: "Gallery",
                column: "service_id");

            migrationBuilder.CreateIndex(
                name: "ix_services_short_desc",
                table: "Services",
                column: "short_desc");

            migrationBuilder.CreateIndex(
                name: "ix_services_title",
                table: "Services",
                column: "title");

            migrationBuilder.CreateIndex(
                name: "ix_statics_number",
                table: "Statics",
                column: "number");

            migrationBuilder.CreateIndex(
                name: "ix_statics_service_id",
                table: "Statics",
                column: "service_id");

            migrationBuilder.CreateIndex(
                name: "ix_statics_title",
                table: "Statics",
                column: "title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Gallery");

            migrationBuilder.DropTable(
                name: "Statics");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropIndex(
                name: "ix_news_title",
                table: "News");

            migrationBuilder.CreateIndex(
                name: "ix_news_title",
                table: "News",
                column: "title",
                unique: true);
        }
    }
}
