using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework_practice.Migration.FluentApi
{
    /// <inheritdoc />
    public partial class AddJsonColumn : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Metadata",
                table: "BankAccount",
                type: "jsonb",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Metadata",
                table: "BankAccount");
        }
    }
}
