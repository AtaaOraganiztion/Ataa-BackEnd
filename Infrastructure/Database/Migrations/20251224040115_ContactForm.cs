using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class ContactForm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactForm",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    entity_name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    request_type = table.Column<int>(type: "int", nullable: false),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    created_on_utc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    last_modified_by = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    last_modified_on_utc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    deleted_on_utc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_contact_form", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_contact_form_email",
                table: "ContactForm",
                column: "email");

            migrationBuilder.CreateIndex(
                name: "ix_contact_form_entity_name",
                table: "ContactForm",
                column: "entity_name");

            migrationBuilder.CreateIndex(
                name: "ix_contact_form_name",
                table: "ContactForm",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "ix_contact_form_phone",
                table: "ContactForm",
                column: "phone");

            migrationBuilder.CreateIndex(
                name: "ix_contact_form_request_type",
                table: "ContactForm",
                column: "request_type");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactForm");
        }
    }
}
