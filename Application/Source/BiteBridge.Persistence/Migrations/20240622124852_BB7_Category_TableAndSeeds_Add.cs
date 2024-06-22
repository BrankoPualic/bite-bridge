using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BiteBridge.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BB7_Category_TableAndSeeds_Add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[,]
                {
                    { 1, "Dietary Preferences", null },
                    { 15, "Meal Times", null },
                    { 25, "Cuisines", null },
                    { 76, "Food Types", null },
                    { 2, "Vegetarian", 1 },
                    { 3, "Vegan", 1 },
                    { 6, "Keto", 1 },
                    { 9, "Pescatarian", 1 },
                    { 10, "Halal", 1 },
                    { 16, "Breakfast", 15 },
                    { 17, "Lunch", 15 },
                    { 18, "Dinner", 15 },
                    { 26, "Asian", 25 },
                    { 27, "Mexican", 25 },
                    { 29, "Mediterranean", 25 },
                    { 31, "French", 25 },
                    { 32, "American", 25 },
                    { 33, "Middle Eastern", 25 },
                    { 77, "Seafood", 76 },
                    { 78, "Pasta", 76 },
                    { 79, "Pizza", 76 },
                    { 80, "Burgers", 76 },
                    { 81, "Salads", 76 },
                    { 82, "Soups", 76 },
                    { 83, "Sandwiches", 76 },
                    { 84, "Grilled", 76 },
                    { 87, "Rice Dishes", 76 },
                    { 88, "Noodles", 76 },
                    { 89, "Sushi", 76 },
                    { 97, "Comfort Food", 76 },
                    { 98, "Street Food", 76 },
                    { 102, "Carnivore", 76 },
                    { 85, "Beef", 102 },
                    { 86, "Chicken", 102 },
                    { 103, "Pork", 102 },
                    { 104, "Turkey", 102 },
                    { 105, "Lamb", 102 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                column: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
