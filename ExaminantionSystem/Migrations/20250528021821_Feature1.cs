using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExaminantionSystem.Migrations
{
    /// <inheritdoc />
    public partial class Feature1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Feature",
                table: "RoleFeatures",
                newName: "feature");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "feature",
                table: "RoleFeatures",
                newName: "Feature");
        }
    }
}
