namespace MoiteRecepti.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class RecipesController : Controller
    {
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Cerate()
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            // Todo: Create recipe using service
            // Todo: Redirect to recipe page

            return this.Redirect("/");
        }
    }
}
