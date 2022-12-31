using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsManagementForm.WebApi.Migrations
{
    public partial class newscat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "NewsCategories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "this is economy", "Economy" });

            migrationBuilder.InsertData(
                table: "NewsCategories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "this is politics", "Politics" });

            migrationBuilder.InsertData(
                table: "NewsCategories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 3, "this is agriculture", "Agriculture" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NewsCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NewsCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "NewsCategories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
