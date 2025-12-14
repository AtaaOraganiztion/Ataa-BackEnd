using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class Auth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    password_hash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    normalized_user_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    normalized_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email_confirmed = table.Column<bool>(type: "bit", nullable: false),
                    security_stamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    concurrency_stamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone_number_confirmed = table.Column<bool>(type: "bit", nullable: false),
                    two_factor_enabled = table.Column<bool>(type: "bit", nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    lockout_enabled = table.Column<bool>(type: "bit", nullable: false),
                    access_failed_count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_device",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    device_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    device_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    device_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_agent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    login_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    last_activity_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    access_token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    token_expiry_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ip_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_id1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    created_on_utc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    last_modified_by = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    last_modified_on_utc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_device", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_device_user_user_id1",
                        column: x => x.user_id1,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_user_device_user_id1",
                table: "user_device",
                column: "user_id1");

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                table: "Users",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_device");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
