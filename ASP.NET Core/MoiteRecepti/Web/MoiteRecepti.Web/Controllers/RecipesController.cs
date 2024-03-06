namespace MoiteRecepti.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using MoiteRecepti.Services.Data;
    using MoiteRecepti.Web.ViewModels.Recipes;

    public class RecipesController : Controller
    {
        private readonly ICategoriesService categoryService;
        private readonly IRecipesService recipesService;

        public RecipesController(ICategoriesService categoryService, IRecipesService recipesService)
        {
            this.categoryService = categoryService;
            this.recipesService = recipesService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateRecipeInputModel();
            viewModel.CategoriesItems = this.categoryService.GetAllKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRecipeInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.CategoriesItems = this.categoryService.GetAllKeyValuePairs();
                return this.View(input);
            }

            await this.recipesService.CreateAsync(input);

            return this.Redirect("/");
        }
    }
}
