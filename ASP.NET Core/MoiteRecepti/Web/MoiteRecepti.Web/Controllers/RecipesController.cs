using MoiteRecepti.Services.Data;
using MoiteRecepti.Web.ViewModels.Recipes;

namespace MoiteRecepti.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class RecipesController : Controller
    {
        private readonly ICategoriesService categoryService;

        public RecipesController(ICategoriesService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateRecipeInputModel();
            viewModel.CategoriesItems = this.categoryService.GetAllKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Cerate(CreateRecipeInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.CategoriesItems = this.categoryService.GetAllKeyValuePairs();
                return this.View(input);
            }

            // Todo: Create recipe using service
            // Todo: Redirect to recipe page

            return this.Redirect("/");
        }
    }
}
