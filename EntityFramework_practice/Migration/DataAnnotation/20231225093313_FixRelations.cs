using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EntityFramework_practice.Migration.DataAnnotation
{
    /// <inheritdoc />
    public partial class FixRelations : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Garages_Car",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Garages_Users_UserId",
                table: "Garages");

            migrationBuilder.DropIndex(
                name: "IX_Cars_Car",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Car",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Garages",
                newName: "Garages");

            migrationBuilder.RenameIndex(
                name: "IX_Garages_UserId",
                table: "Garages",
                newName: "IX_Garages_Garages");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Garages",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Cars",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Garages_Cars",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Garages_Id",
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

            migrationBuilder.RenameColumn(
                name: "Garages",
                table: "Garages",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Garages_Garages",
                table: "Garages",
                newName: "IX_Garages_UserId");

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

            migrationBuilder.AddColumn<int>(
                name: "Car",
                table: "Cars",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_Car",
                table: "Cars",
                column: "Car");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Garages_Car",
                table: "Cars",
                column: "Car",
                principalTable: "Garages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Garages_Users_UserId",
                table: "Garages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
