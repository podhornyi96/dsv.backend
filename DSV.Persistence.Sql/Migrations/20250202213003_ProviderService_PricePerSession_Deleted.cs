using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSV.Persistence.Sql.Migrations
{
    /// <inheritdoc />
    public partial class ProviderService_PricePerSession_Deleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PricePerSession",
                table: "ProviderServices");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PricePerSession",
                table: "ProviderServices",
                type: "TEXT",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }
    }
}
