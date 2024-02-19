using Microsoft.AspNetCore.Mvc;

namespace MyFirstAspNetCoreApp.Controllers;

public class AddRecipeInputModel
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime CookingDuration { get; set; }
}

public class RecipesController : Controller
{
    public IActionResult Add(AddRecipeInputModel inputModel)
    {
        return this.Json(inputModel);
    }
}