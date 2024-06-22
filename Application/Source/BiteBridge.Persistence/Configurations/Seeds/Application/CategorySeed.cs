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
            new() { Id = 1, ParentId = null, Name = "Dietary Preferences"},

                // Subcategories
                new() { Id = 2, ParentId = 1, Name = "Vegetarian"},
				new() { Id = 3, ParentId = 1, Name = "Vegan"},
				new() { Id = 6, ParentId = 1, Name = "Keto"},
				new() { Id = 9, ParentId = 1, Name = "Pescatarian"},
				new() { Id = 10, ParentId = 1, Name = "Halal",},

            // Main Category
             new() { Id = 15, ParentId = null, Name = "Meal Times",},

                // Subcategories under "Meal Times"
                new() { Id = 16, ParentId = 15, Name = "Breakfast"},
				new() { Id = 17, ParentId = 15, Name = "Lunch"},
				new() { Id = 18, ParentId = 15, Name = "Dinner"},

            // Main Category
            new() { Id = 25, ParentId = null, Name = "Cuisines"},

				new() { Id = 26, ParentId = 25, Name = "Asian"},
				new() { Id = 27, ParentId = 25, Name = "Mexican"},
				new() { Id = 29, ParentId = 25, Name = "Mediterranean"},
				new() { Id = 31, ParentId = 25, Name = "French"},
				new() { Id = 32, ParentId = 25, Name = "American" },
				new() { Id = 33, ParentId = 25, Name = "Middle Eastern"},

            // Main Category
            new() { Id = 76, ParentId = null, Name = "Food Types"},

                // Subcategories under "Food Types"
                new() { Id = 77, ParentId = 76, Name = "Seafood"},
				new() { Id = 78, ParentId = 76, Name = "Pasta"},
				new() { Id = 79, ParentId = 76, Name = "Pizza"},
				new() { Id = 80, ParentId = 76, Name = "Burgers"},
				new() { Id = 81, ParentId = 76, Name = "Salads"},
				new() { Id = 82, ParentId = 76, Name = "Soups"},
				new() { Id = 83, ParentId = 76, Name = "Sandwiches"},
				new() { Id = 84, ParentId = 76, Name = "Grilled"},
				new() { Id = 102, ParentId = 76, Name = "Carnivore"},

                    // Subcategories under "Carnivore"
                     new() { Id = 86, ParentId = 102, Name = "Chicken"},
					new() { Id = 85, ParentId = 102, Name = "Beef"},
					new() { Id = 103, ParentId = 102, Name = "Pork"},
					new() { Id = 104, ParentId = 102, Name = "Turkey"},
					new() { Id = 105, ParentId = 102, Name = "Lamb"},

				new() { Id = 87, ParentId = 76, Name = "Rice Dishes" },
				new() { Id = 88, ParentId = 76, Name = "Noodles"},
				new() { Id = 89, ParentId = 76, Name = "Sushi"},
				new() { Id = 97, ParentId = 76, Name = "Comfort Food"},
				new() { Id = 98, ParentId = 76, Name = "Street Food"}
		];
	}
}