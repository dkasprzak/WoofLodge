using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WoofLodge.Api.Migrations
{
    /// <inheritdoc />
    public partial class Insert_data_to_breedsV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Breeds",
                columns: new[] { "Id", "BreedName" },
                values: new object[,]
                {
                    { 1, "Kundel" },
                    { 2, "Owczarek szwajcarski" },
                    { 3, "Pekińczyk" },
                    { 4, "Mops" },
                    { 5, "Golden retriever" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
