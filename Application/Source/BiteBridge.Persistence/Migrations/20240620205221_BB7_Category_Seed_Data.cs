using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BiteBridge.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BB7_Category_Seed_Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "ParentId" },
                values: new object[,]
                {
                    { 1, "Categories based on dietary restrictions and preferences.", "Dietary Preferences", null },
                    { 15, "Categories based on different meal times of the day.", "Meal Times", null },
                    { 19, "Categories based on different courses of a meal.", "Course Types", null },
                    { 25, "Categories based on different culinary traditions.", "Cuisines", null },
                    { 76, "Categories based on different types of food.", "Food Types", null },
                    { 2, "Meals and foods that do not contain meat.", "Vegetarian", 1 },
                    { 3, "Meals and foods free from any animal products.", "Vegan", 1 },
                    { 4, "Meals and foods that do not contain gluten.", "Gluten Free", 1 },
                    { 5, "Meals and foods free from dairy products.", "Dairy Free", 1 },
                    { 6, "Meals and foods that are low-carb and high-fat.", "Keto", 1 },
                    { 7, "Foods that mimic the diet of our hunter-gatherer ancestors.", "Paleo", 1 },
                    { 8, "Foods that are low in certain types of carbohydrates.", "Low FODMAP", 1 },
                    { 9, "Vegetarian diet that includes seafood but excludes other meats.", "Pescatarian", 1 },
                    { 10, "Foods that are permissible for Muslims to consume under Islamic law.", "Halal", 1 },
                    { 11, "Foods that conform to Jewish dietary laws.", "Kosher", 1 },
                    { 12, "Meals and foods that do not contain nuts or nut products.", "Nut Free", 1 },
                    { 13, "Meals and foods that do not contain soy or soy products.", "Soy Free", 1 },
                    { 14, "Meals and foods that do not contain added sugars.", "Sugar Free", 1 },
                    { 16, "Meals typically eaten in the morning.", "Breakfast", 15 },
                    { 17, "Meals typically eaten in the afternoon.", "Lunch", 15 },
                    { 18, "Meals typically eaten in the evening.", "Dinner", 15 },
                    { 21, "Small dishes served before the main course.", "Appetizers", 19 },
                    { 22, "The main dish of a meal.", "Main Course", 19 },
                    { 23, "Sweet foods typically eaten after meals.", "Desserts", 19 },
                    { 24, "Drinks including soft drinks, juices, and more.", "Beverages", 19 },
                    { 26, "Asian cuisine including Chinese, Japanese, Thai, etc.", "Asian", 25 },
                    { 27, "Mexican cuisine including tacos, burritos, etc.", "Mexican", 25 },
                    { 29, "Mediterranean cuisine including Greek, Italian, etc.", "Mediterranean", 25 },
                    { 31, "French cuisine including pastries, sauces, etc.", "French", 25 },
                    { 32, "American cuisine including burgers, BBQ, etc.", "American", 25 },
                    { 33, "Middle Eastern cuisine including falafel, hummus, etc.", "Middle Eastern", 25 },
                    { 34, "African cuisine including Ethiopian, Moroccan, etc.", "African", 25 },
                    { 35, "South American cuisine including Brazilian, Peruvian, etc.", "South American", 25 },
                    { 75, "Australian cuisine including iconic dishes and ingredients.", "Australian", 25 },
                    { 77, "Various seafood dishes including fish, shrimp, etc.", "Seafood", 76 },
                    { 78, "Italian pasta dishes including spaghetti, lasagna, etc.", "Pasta", 76 },
                    { 79, "Different types of pizzas including Margherita, Pepperoni, etc.", "Pizza", 76 },
                    { 80, "Various burger options including cheeseburgers, veggie burgers, etc.", "Burgers", 76 },
                    { 81, "Healthy salad options including Caesar salad, Greek salad, etc.", "Salads", 76 },
                    { 82, "Different soup varieties including chicken noodle soup, tomato soup, etc.", "Soups", 76 },
                    { 83, "Various sandwich options including club sandwich, BLT, etc.", "Sandwiches", 76 },
                    { 84, "Grilled food items including grilled chicken, grilled vegetables, etc.", "Grilled", 76 },
                    { 85, "Different cuts of steak including ribeye, sirloin, etc.", "Steak", 76 },
                    { 86, "Various chicken dishes including roasted chicken, chicken wings, etc.", "Chicken", 76 },
                    { 87, "Different rice-based dishes including biryani, risotto, etc.", "Rice Dishes", 76 },
                    { 88, "Various noodle dishes including ramen, pad Thai, etc.", "Noodles", 76 },
                    { 89, "Japanese sushi rolls including nigiri, sashimi, etc.", "Sushi", 76 },
                    { 90, "Mexican tacos including beef, chicken, fish tacos, etc.", "Tacos", 76 },
                    { 91, "Various curry dishes including Indian, Thai, etc.", "Curries", 76 },
                    { 92, "Barbecue dishes including ribs, pulled pork, brisket, etc.", "BBQ", 76 },
                    { 93, "Chinese dim sum including dumplings, buns, spring rolls, etc.", "Dim Sum", 76 },
                    { 94, "Spanish tapas including small plates like patatas bravas, croquettes, etc.", "Tapas", 76 },
                    { 95, "Various steamed dishes including dim sum, steamed fish, etc.", "Steamed", 76 },
                    { 96, "Food typically served in bars including nachos, wings, etc.", "Bar Food", 76 },
                    { 97, "Home-style comforting dishes including mac and cheese, meatloaf, etc.", "Comfort Food", 76 },
                    { 98, "Popular foods sold on streets including kebabs, hot dogs, etc.", "Street Food", 76 },
                    { 99, "Small, easy-to-eat foods served at parties including mini sandwiches, skewers, etc.", "Finger Food", 76 },
                    { 100, "Dishes that blend culinary traditions from different cultures.", "Fusion Cuisine", 25 },
                    { 101, "Local dishes specific to a particular region or country.", "Regional Specialties", 25 },
                    { 36, "Chinese cuisine including dishes like stir-fries, dim sum, etc.", "Chinese", 26 },
                    { 37, "Japanese cuisine including sushi, ramen, etc.", "Japanese", 26 },
                    { 38, "Thai cuisine including dishes like pad Thai, green curry, etc.", "Thai", 26 },
                    { 39, "Indian cuisine including curry dishes, naan, etc.", "Indian", 26 },
                    { 40, "Korean cuisine including dishes like kimchi, bulgogi, etc.", "Korean", 26 },
                    { 41, "Vietnamese cuisine including pho, banh mi, etc.", "Vietnamese", 26 },
                    { 42, "Malaysian cuisine including laksa, nasi lemak, etc.", "Malaysian", 26 },
                    { 43, "Indonesian cuisine including nasi goreng, rendang, etc.", "Indonesian", 26 },
                    { 44, "Greek cuisine including dishes like moussaka, souvlaki, etc.", "Greek", 29 },
                    { 45, "Italian cuisine including pasta dishes, pizza, etc.", "Italian", 29 },
                    { 46, "Spanish cuisine including paella, tapas, etc.", "Spanish", 29 },
                    { 51, "Lebanese cuisine including dishes like hummus, falafel, etc.", "Lebanese", 33 },
                    { 52, "Turkish cuisine including dishes like kebabs, baklava, etc.", "Turkish", 33 },
                    { 53, "Israeli cuisine including dishes like falafel, shakshuka, etc.", "Israeli", 33 },
                    { 54, "Persian cuisine including dishes like kebabs, rice dishes, etc.", "Persian", 33 },
                    { 55, "Armenian cuisine including dishes like dolma, lavash bread, etc.", "Armenian", 33 },
                    { 56, "Egyptian cuisine including dishes like koshari, falafel, etc.", "Egyptian", 33 },
                    { 57, "Iraqi cuisine including dishes like biryani, kebabs, etc.", "Iraqi", 33 },
                    { 58, "Syrian cuisine including dishes like kibbeh, fattoush, etc.", "Syrian", 33 },
                    { 59, "Ethiopian cuisine including dishes like injera, doro wat, etc.", "Ethiopian", 34 },
                    { 60, "Moroccan cuisine including dishes like tagine, couscous, etc.", "Moroccan", 34 },
                    { 61, "South African cuisine including dishes like braai, bobotie, etc.", "South African", 34 },
                    { 62, "Nigerian cuisine including dishes like jollof rice, suya, etc.", "Nigerian", 34 },
                    { 63, "Ghanaian cuisine including dishes like banku, fufu, etc.", "Ghanaian", 34 },
                    { 64, "Kenyan cuisine including dishes like ugali, nyama choma, etc.", "Kenyan", 34 },
                    { 65, "Senegalese cuisine including dishes like thiéboudienne, yassa, etc.", "Senegalese", 34 },
                    { 66, "Tanzanian cuisine including dishes like pilau, ugali, etc.", "Tanzanian", 34 },
                    { 67, "Brazilian cuisine including dishes like feijoada, coxinha, etc.", "Brazilian", 35 },
                    { 68, "Peruvian cuisine including dishes like ceviche, lomo saltado, etc.", "Peruvian", 35 },
                    { 69, "Argentinian cuisine including dishes like asado, empanadas, etc.", "Argentinian", 35 },
                    { 70, "Colombian cuisine including dishes like bandeja paisa, arepas, etc.", "Colombian", 35 },
                    { 71, "Chilean cuisine including dishes like empanadas de pino, pastel de choclo, etc.", "Chilean", 35 },
                    { 72, "Ecuadorian cuisine including dishes like ceviche, encebollado, etc.", "Ecuadorian", 35 },
                    { 73, "Venezuelan cuisine including dishes like arepas, pabellón criollo, etc.", "Venezuelan", 35 },
                    { 74, "Bolivian cuisine including dishes like salteñas, pique macho, etc.", "Bolivian", 35 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);
        }
    }
}
