using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoAspNet.Migrations
{
    /// <inheritdoc />
    public partial class M04AddCodeinUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Users");
        }
    }
}
