using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QueenCar.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "Services",
                newName: "ServiceID");

            migrationBuilder.AddColumn<string>(
                name: "IconUrl",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconUrl",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "ServiceID",
                table: "Services",
                newName: "ServiceId");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Services",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
