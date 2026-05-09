using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moving.Infra.Migrations
{
    /// <inheritdoc />
    public partial class UniqueName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                                 DELETE FROM "Items"
                                 WHERE "Id" NOT IN (
                                     SELECT MIN("Id")
                                     FROM "Items"
                                     GROUP BY "Name"
                                 );
                                 """);

            migrationBuilder.CreateIndex(
                name: "IX_Items_Name",
                table: "Items",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Items_Name",
                table: "Items");
        }
    }
}
