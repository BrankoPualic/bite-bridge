using BiteBridge.Domain.Entities.Application;
using BiteBridge.Persistence.Configurations.Seeds.Interfaces;

namespace BiteBridge.Persistence.Configurations.Seeds.Application;

public class CategorySeed : ISeedData<Category>
{
    public IEnumerable<Category> SeedData()
    {
        return
        [
            // Main Category
            new() { Id = 1, ParentId = null, Name = "Dietary Preferences", Description = "Categories based on dietary restrictions and preferences." },

                // Subcategories
                new() { Id = 2, ParentId = 1, Name = "Vegetarian", Description = "Meals and foods that do not contain meat." },
                new() { Id = 3, ParentId = 1, Name = "Vegan", Description = "Meals and foods free from any animal products." },
                new() { Id = 4, ParentId = 1, Name = "Gluten Free", Description = "Meals and foods that do not contain gluten." },
                new() { Id = 5, ParentId = 1, Name = "Dairy Free", Description = "Meals and foods free from dairy products." },
                new() { Id = 6, ParentId = 1, Name = "Keto", Description = "Meals and foods that are low-carb and high-fat." },
                new() { Id = 7, ParentId = 1, Name = "Paleo", Description = "Foods that mimic the diet of our hunter-gatherer ancestors." },
                new() { Id = 8, ParentId = 1, Name = "Low FODMAP", Description = "Foods that are low in certain types of carbohydrates." },
                new() { Id = 9, ParentId = 1, Name = "Pescatarian", Description = "Vegetarian diet that includes seafood but excludes other meats." },
                new() { Id = 10, ParentId = 1, Name = "Halal", Description = "Foods that are permissible for Muslims to consume under Islamic law." },
                new() { Id = 11, ParentId = 1, Name = "Kosher", Description = "Foods that conform to Jewish dietary laws." },
                new() { Id = 12, ParentId = 1, Name = "Nut Free", Description = "Meals and foods that do not contain nuts or nut products." },
                new() { Id = 13, ParentId = 1, Name = "Soy Free", Description = "Meals and foods that do not contain soy or soy products." },
                new() { Id = 14, ParentId = 1, Name = "Sugar Free", Description = "Meals and foods that do not contain added sugars." },

            // Main Category
             new() { Id = 15, ParentId = null, Name = "Meal Times", Description = "Categories based on different meal times of the day." },

                // Subcategories under "Meal Times"
                new() { Id = 16, ParentId = 15, Name = "Breakfast", Description = "Meals typically eaten in the morning." },
                new() { Id = 17, ParentId = 15, Name = "Lunch", Description = "Meals typically eaten in the afternoon." },
                new() { Id = 18, ParentId = 15, Name = "Dinner", Description = "Meals typically eaten in the evening." },

            // Main Category
            new() { Id = 19, ParentId = null, Name = "Course Types", Description = "Categories based on different courses of a meal." },

                // Subcategories under "Course Types"
                new() { Id = 21, ParentId = 19, Name = "Appetizers", Description = "Small dishes served before the main course." },
                new() { Id = 22, ParentId = 19, Name = "Main Course", Description = "The main dish of a meal." },
                new() { Id = 23, ParentId = 19, Name = "Desserts", Description = "Sweet foods typically eaten after meals." },
                new() { Id = 24, ParentId = 19, Name = "Beverages", Description = "Drinks including soft drinks, juices, and more." },

            // Main Category
            new() { Id = 25, ParentId = null, Name = "Cuisines", Description = "Categories based on different culinary traditions." },

            // Subcategories under "Cuisines"
                new() { Id = 100, ParentId = 25, Name = "Fusion Cuisine", Description = "Dishes that blend culinary traditions from different cultures." },
                new() { Id = 101, ParentId = 25, Name = "Regional Specialties", Description = "Local dishes specific to a particular region or country." },

                new() { Id = 26, ParentId = 25, Name = "Asian", Description = "Asian cuisine including Chinese, Japanese, Thai, etc." },

                // Subcategories under "Asian" cuisine
                    new() { Id = 36, ParentId = 26, Name = "Chinese", Description = "Chinese cuisine including dishes like stir-fries, dim sum, etc." },
                    new() { Id = 37, ParentId = 26, Name = "Japanese", Description = "Japanese cuisine including sushi, ramen, etc." },
                    new() { Id = 38, ParentId = 26, Name = "Thai", Description = "Thai cuisine including dishes like pad Thai, green curry, etc." },
                    new() { Id = 39, ParentId = 26, Name = "Indian", Description = "Indian cuisine including curry dishes, naan, etc." },
                    new() { Id = 40, ParentId = 26, Name = "Korean", Description = "Korean cuisine including dishes like kimchi, bulgogi, etc." },
                    new() { Id = 41, ParentId = 26, Name = "Vietnamese", Description = "Vietnamese cuisine including pho, banh mi, etc." },
                    new() { Id = 42, ParentId = 26, Name = "Malaysian", Description = "Malaysian cuisine including laksa, nasi lemak, etc." },
                    new() { Id = 43, ParentId = 26, Name = "Indonesian", Description = "Indonesian cuisine including nasi goreng, rendang, etc." },

                new() { Id = 27, ParentId = 25, Name = "Mexican", Description = "Mexican cuisine including tacos, burritos, etc." },
                new() { Id = 29, ParentId = 25, Name = "Mediterranean", Description = "Mediterranean cuisine including Greek, Italian, etc." },

                    // Subcategories under "Mediterranean" cuisine
                    new() { Id = 44, ParentId = 29, Name = "Greek", Description = "Greek cuisine including dishes like moussaka, souvlaki, etc." },
                    new() { Id = 45, ParentId = 29, Name = "Italian", Description = "Italian cuisine including pasta dishes, pizza, etc." },
                    new() { Id = 46, ParentId = 29, Name = "Spanish", Description = "Spanish cuisine including paella, tapas, etc." },

                new() { Id = 31, ParentId = 25, Name = "French", Description = "French cuisine including pastries, sauces, etc." },
                new() { Id = 32, ParentId = 25, Name = "American", Description = "American cuisine including burgers, BBQ, etc." },
                new() { Id = 33, ParentId = 25, Name = "Middle Eastern", Description = "Middle Eastern cuisine including falafel, hummus, etc." },

                    // Subcategories under "Middle Eastern" cuisine
                    new() { Id = 51, ParentId = 33, Name = "Lebanese", Description = "Lebanese cuisine including dishes like hummus, falafel, etc." },
                    new() { Id = 52, ParentId = 33, Name = "Turkish", Description = "Turkish cuisine including dishes like kebabs, baklava, etc." },
                    new() { Id = 53, ParentId = 33, Name = "Israeli", Description = "Israeli cuisine including dishes like falafel, shakshuka, etc." },
                    new() { Id = 54, ParentId = 33, Name = "Persian", Description = "Persian cuisine including dishes like kebabs, rice dishes, etc." },
                    new() { Id = 55, ParentId = 33, Name = "Armenian", Description = "Armenian cuisine including dishes like dolma, lavash bread, etc." },
                    new() { Id = 56, ParentId = 33, Name = "Egyptian", Description = "Egyptian cuisine including dishes like koshari, falafel, etc." },
                    new() { Id = 57, ParentId = 33, Name = "Iraqi", Description = "Iraqi cuisine including dishes like biryani, kebabs, etc." },
                    new() { Id = 58, ParentId = 33, Name = "Syrian", Description = "Syrian cuisine including dishes like kibbeh, fattoush, etc." },

                new() { Id = 34, ParentId = 25, Name = "African", Description = "African cuisine including Ethiopian, Moroccan, etc." },

                    // Subcategories under "African" cuisine
                    new() { Id = 59, ParentId = 34, Name = "Ethiopian", Description = "Ethiopian cuisine including dishes like injera, doro wat, etc." },
                    new() { Id = 60, ParentId = 34, Name = "Moroccan", Description = "Moroccan cuisine including dishes like tagine, couscous, etc." },
                    new() { Id = 61, ParentId = 34, Name = "South African", Description = "South African cuisine including dishes like braai, bobotie, etc." },
                    new() { Id = 62, ParentId = 34, Name = "Nigerian", Description = "Nigerian cuisine including dishes like jollof rice, suya, etc." },
                    new() { Id = 63, ParentId = 34, Name = "Ghanaian", Description = "Ghanaian cuisine including dishes like banku, fufu, etc." },
                    new() { Id = 64, ParentId = 34, Name = "Kenyan", Description = "Kenyan cuisine including dishes like ugali, nyama choma, etc." },
                    new() { Id = 65, ParentId = 34, Name = "Senegalese", Description = "Senegalese cuisine including dishes like thiéboudienne, yassa, etc." },
                    new() { Id = 66, ParentId = 34, Name = "Tanzanian", Description = "Tanzanian cuisine including dishes like pilau, ugali, etc." },

                new() { Id = 35, ParentId = 25, Name = "South American", Description = "South American cuisine including Brazilian, Peruvian, etc." },

                    // Subcategories under "South American" cuisine
                    new() { Id = 67, ParentId = 35, Name = "Brazilian", Description = "Brazilian cuisine including dishes like feijoada, coxinha, etc." },
                    new() { Id = 68, ParentId = 35, Name = "Peruvian", Description = "Peruvian cuisine including dishes like ceviche, lomo saltado, etc." },
                    new() { Id = 69, ParentId = 35, Name = "Argentinian", Description = "Argentinian cuisine including dishes like asado, empanadas, etc." },
                    new() { Id = 70, ParentId = 35, Name = "Colombian", Description = "Colombian cuisine including dishes like bandeja paisa, arepas, etc." },
                    new() { Id = 71, ParentId = 35, Name = "Chilean", Description = "Chilean cuisine including dishes like empanadas de pino, pastel de choclo, etc." },
                    new() { Id = 72, ParentId = 35, Name = "Ecuadorian", Description = "Ecuadorian cuisine including dishes like ceviche, encebollado, etc." },
                    new() { Id = 73, ParentId = 35, Name = "Venezuelan", Description = "Venezuelan cuisine including dishes like arepas, pabellón criollo, etc." },
                    new() { Id = 74, ParentId = 35, Name = "Bolivian", Description = "Bolivian cuisine including dishes like salteñas, pique macho, etc." },

                new() { Id = 75, ParentId = 25, Name = "Australian", Description = "Australian cuisine including iconic dishes and ingredients." },

            // Main Category
            new() { Id = 76, ParentId = null, Name = "Food Types", Description = "Categories based on different types of food." },

                // Subcategories under "Food Types"
                new() { Id = 77, ParentId = 76, Name = "Seafood", Description = "Various seafood dishes including fish, shrimp, etc." },

                    // Subcategories under "Seafood"
                    new() { Id = 114, ParentId = 77, Name = "Fish", Description = "Various fish dishes including grilled fish, fish and chips, etc." },
                    new() { Id = 115, ParentId = 77, Name = "Shrimp", Description = "Various shrimp dishes including shrimp cocktail, shrimp scampi, etc." },
                    new() { Id = 116, ParentId = 77, Name = "Crab", Description = "Various crab dishes including crab cakes, crab legs, etc." },
                    new() { Id = 117, ParentId = 77, Name = "Lobster", Description = "Various lobster dishes including lobster rolls, grilled lobster, etc." },
                    new() { Id = 118, ParentId = 77, Name = "Oysters", Description = "Various oyster dishes including raw oysters, fried oysters, etc." },
                    new() { Id = 119, ParentId = 77, Name = "Clams", Description = "Various clam dishes including clam chowder, steamed clams, etc." },
                    new() { Id = 120, ParentId = 77, Name = "Mussels", Description = "Various mussel dishes including steamed mussels, mussels marinara, etc." },
                    new() { Id = 121, ParentId = 77, Name = "Scallops", Description = "Various scallop dishes including seared scallops, scallop pasta, etc." },
                    new() { Id = 122, ParentId = 77, Name = "Octopus", Description = "Various octopus dishes including grilled octopus, octopus salad, etc." },
                    new() { Id = 123, ParentId = 77, Name = "Squid", Description = "Various squid dishes including calamari, stuffed squid, etc." },

                new() { Id = 78, ParentId = 76, Name = "Pasta", Description = "Italian pasta dishes including spaghetti, lasagna, etc." },
                new() { Id = 79, ParentId = 76, Name = "Pizza", Description = "Different types of pizzas including Margherita, Pepperoni, etc." },
                new() { Id = 80, ParentId = 76, Name = "Burgers", Description = "Various burger options including cheeseburgers, veggie burgers, etc." },
                new() { Id = 81, ParentId = 76, Name = "Salads", Description = "Healthy salad options including Caesar salad, Greek salad, etc." },
                new() { Id = 82, ParentId = 76, Name = "Soups", Description = "Different soup varieties including chicken noodle soup, tomato soup, etc." },
                new() { Id = 83, ParentId = 76, Name = "Sandwiches", Description = "Various sandwich options including club sandwich, BLT, etc." },
                new() { Id = 84, ParentId = 76, Name = "Grilled", Description = "Grilled food items including grilled chicken, grilled vegetables, etc." },
                new() { Id = 102, ParentId = 76, Name = "Carnivore", Description = "Various meat dishes including chicken, beef, pork, turkey, etc." },

                    // Subcategories under "Carnivore"
                     new() { Id = 86, ParentId = 102, Name = "Chicken", Description = "Various chicken dishes including roasted chicken, chicken wings, etc." },
                    new() { Id = 85, ParentId = 102, Name = "Beef", Description = "Various beef dishes including steak, beef stew, etc." },
                    new() { Id = 103, ParentId = 102, Name = "Pork", Description = "Various pork dishes including pork chops, pulled pork, etc." },
                    new() { Id = 104, ParentId = 102, Name = "Turkey", Description = "Various turkey dishes including roasted turkey, turkey sandwiches, etc." },
                    new() { Id = 105, ParentId = 102, Name = "Lamb", Description = "Various lamb dishes including lamb chops, lamb stew, etc." },
                    new() { Id = 106, ParentId = 102, Name = "Duck", Description = "Various duck dishes including roasted duck, duck confit, etc." },
                    new() { Id = 107, ParentId = 102, Name = "Game Meat", Description = "Various game meats including venison, bison, rabbit, etc." },

                        // Subcategories under "Game Meat"
                        new() { Id = 108, ParentId = 107, Name = "Venison", Description = "Deer meat including steaks, sausages, and stews." },
                        new() { Id = 109, ParentId = 107, Name = "Bison", Description = "Bison meat including burgers, steaks, and roasts." },
                        new() { Id = 110, ParentId = 107, Name = "Rabbit", Description = "Rabbit meat including stews, roasts, and pies." },
                        new() { Id = 111, ParentId = 107, Name = "Wild Boar", Description = "Wild boar meat including sausages, roasts, and stews." },
                        new() { Id = 112, ParentId = 107, Name = "Pheasant", Description = "Pheasant meat including roasted, grilled, and stews." },
                        new() { Id = 113, ParentId = 107, Name = "Quail", Description = "Quail meat including roasted, grilled, and stews." },
                        new() { Id = 112, ParentId = 107, Name = "Alligator", Description = "Alligator meat including fried, grilled, and stews." },
                        new() { Id = 113, ParentId = 107, Name = "Kangaroo", Description = "Kangaroo meat including steaks, sausages, and stews." },

                new() { Id = 87, ParentId = 76, Name = "Rice Dishes", Description = "Different rice-based dishes including biryani, risotto, etc." },
                new() { Id = 88, ParentId = 76, Name = "Noodles", Description = "Various noodle dishes including ramen, pad Thai, etc." },
                new() { Id = 89, ParentId = 76, Name = "Sushi", Description = "Japanese sushi rolls including nigiri, sashimi, etc." },
                new() { Id = 90, ParentId = 76, Name = "Tacos", Description = "Mexican tacos including beef, chicken, fish tacos, etc." },
                new() { Id = 91, ParentId = 76, Name = "Curries", Description = "Various curry dishes including Indian, Thai, etc." },
                new() { Id = 92, ParentId = 76, Name = "BBQ", Description = "Barbecue dishes including ribs, pulled pork, brisket, etc." },
                new() { Id = 93, ParentId = 76, Name = "Dim Sum", Description = "Chinese dim sum including dumplings, buns, spring rolls, etc." },
                new() { Id = 94, ParentId = 76, Name = "Tapas", Description = "Spanish tapas including small plates like patatas bravas, croquettes, etc." },
                new() { Id = 95, ParentId = 76, Name = "Steamed", Description = "Various steamed dishes including dim sum, steamed fish, etc." },
                new() { Id = 96, ParentId = 76, Name = "Bar Food", Description = "Food typically served in bars including nachos, wings, etc." },
                new() { Id = 97, ParentId = 76, Name = "Comfort Food", Description = "Home-style comforting dishes including mac and cheese, meatloaf, etc." },
                new() { Id = 98, ParentId = 76, Name = "Street Food", Description = "Popular foods sold on streets including kebabs, hot dogs, etc." },
                new() { Id = 99, ParentId = 76, Name = "Finger Food", Description = "Small, easy-to-eat foods served at parties including mini sandwiches, skewers, etc." }
        ];
    }
}