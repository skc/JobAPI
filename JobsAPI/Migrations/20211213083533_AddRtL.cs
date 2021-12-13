using Microsoft.EntityFrameworkCore.Migrations;

namespace JobsAPI.Migrations
{
    public partial class AddRtL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "RtL",
                table: "ProgrammersNotes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RtL",
                table: "OperatorsNotes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RtL",
                table: "InfoNotes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RtL",
                table: "ProgrammersNotes");

            migrationBuilder.DropColumn(
                name: "RtL",
                table: "OperatorsNotes");

            migrationBuilder.DropColumn(
                name: "RtL",
                table: "InfoNotes");
        }
    }
}
