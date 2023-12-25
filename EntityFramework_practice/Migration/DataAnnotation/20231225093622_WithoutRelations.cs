using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EntityFramework_practice.Migration.DataAnnotation
{
    /// <inheritdoc />
    public partial class WithoutRelations : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Garages_Cars",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Garages_Id",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Users_Cars",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Users_Id",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Garages_Users_Garages",
                table: "Garages");

            migrationBuilder.DropForeignKey(
                name: "FK_Garages_Users_Id",
                table: "Garages");

            migrationBuilder.DropIndex(
                name: "IX_Garages_Garages",
                table: "Garages");

            migrationBuilder.DropIndex(
                name: "IX_Cars_Cars",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Garages",
                table: "Garages");

            migrationBuilder.DropColumn(
                name: "Cars",
                table: "Cars");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Garages",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Cars",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Garages",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "Garages",
                table: "Garages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Cars",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "Cars",
                table: "Cars",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Garages_Garages",
                table: "Garages",
                column: "Garages");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_Cars",
                table: "Cars",
                column: "Cars");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Garages_Cars",
                table: "Cars",
                column: "Cars",
                principalTable: "Garages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Garages_Id",
                table: "Cars",
                column: "Id",
                principalTable: "Garages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Users_Cars",
                table: "Cars",
                column: "Cars",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Users_Id",
                table: "Cars",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Garages_Users_Garages",
                table: "Garages",
                column: "Garages",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Garages_Users_Id",
                table: "Garages",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
