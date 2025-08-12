using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoAspNet.Migrations
{
    /// <inheritdoc />
    public partial class M02FieldsTokenAndUserPrefsJsonInUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "TokenExpireIn",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserPrefsJson",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TokenExpireIn",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserPrefsJson",
                table: "Users");
        }
    }
}
