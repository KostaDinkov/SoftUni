using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BakerySystem.Migrations
{
    /// <inheritdoc />
    public partial class VendorAddInfos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "banking_info_bank_name",
                table: "vendors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "banking_info_iban",
                table: "vendors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "banking_info_swift",
                table: "vendors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "contact_info_address",
                table: "vendors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "contact_info_city",
                table: "vendors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "contact_info_country",
                table: "vendors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "contact_info_email",
                table: "vendors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "contact_info_phone_number",
                table: "vendors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "legal_info_legal_address",
                table: "vendors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "legal_info_mol",
                table: "vendors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "legal_info_uic",
                table: "vendors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "legal_info_vat_number",
                table: "vendors",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "banking_info_bank_name",
                table: "vendors");

            migrationBuilder.DropColumn(
                name: "banking_info_iban",
                table: "vendors");

            migrationBuilder.DropColumn(
                name: "banking_info_swift",
                table: "vendors");

            migrationBuilder.DropColumn(
                name: "contact_info_address",
                table: "vendors");

            migrationBuilder.DropColumn(
                name: "contact_info_city",
                table: "vendors");

            migrationBuilder.DropColumn(
                name: "contact_info_country",
                table: "vendors");

            migrationBuilder.DropColumn(
                name: "contact_info_email",
                table: "vendors");

            migrationBuilder.DropColumn(
                name: "contact_info_phone_number",
                table: "vendors");

            migrationBuilder.DropColumn(
                name: "legal_info_legal_address",
                table: "vendors");

            migrationBuilder.DropColumn(
                name: "legal_info_mol",
                table: "vendors");

            migrationBuilder.DropColumn(
                name: "legal_info_uic",
                table: "vendors");

            migrationBuilder.DropColumn(
                name: "legal_info_vat_number",
                table: "vendors");
        }
    }
}
