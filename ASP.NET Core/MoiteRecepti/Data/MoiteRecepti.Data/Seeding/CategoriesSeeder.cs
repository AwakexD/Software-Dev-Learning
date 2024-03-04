namespace MoiteRecepti.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using MoiteRecepti.Data.Models;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.Categories.AnyAsync())
            {
                return;
            }

            await CategoriesSeedAsync(dbContext);
        }

        public static async Task CategoriesSeedAsync(ApplicationDbContext dbContext)
        {
            var categories = new HashSet<Category>();
            var names = new string[] { "Месо", "Зеленчуци", "Плодове", "Хляб", "Супи", "Салати", "Десерти" };

            foreach (var name in names)
            {
                categories.Add(new Category() { Name = name });
            }

            await dbContext.Categories.AddRangeAsync(categories);
        }
    }
}
