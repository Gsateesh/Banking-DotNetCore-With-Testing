using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank_DotnetCore.Migrations
{
    /// <inheritdoc />
    public partial class accountsdbadded3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Accounts");
        }
    }
}
