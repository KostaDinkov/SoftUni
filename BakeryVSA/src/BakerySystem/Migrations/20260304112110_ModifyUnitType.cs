using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BakerySystem.Migrations
{
    /// <inheritdoc />
    public partial class ModifyUnitType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_materials_base_units_base_unit_id",
                table: "materials");

            migrationBuilder.DropTable(
                name: "base_units");

            migrationBuilder.DropIndex(
                name: "ix_materials_base_unit_id",
                table: "materials");

            migrationBuilder.RenameColumn(
                name: "base_unit_id",
                table: "materials",
                newName: "base_unit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "base_unit",
                table: "materials",
                newName: "base_unit_id");

            migrationBuilder.CreateTable(
                name: "base_units",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_base_units", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_materials_base_unit_id",
                table: "materials",
                column: "base_unit_id");

            migrationBuilder.AddForeignKey(
                name: "fk_materials_base_units_base_unit_id",
                table: "materials",
                column: "base_unit_id",
                principalTable: "base_units",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
