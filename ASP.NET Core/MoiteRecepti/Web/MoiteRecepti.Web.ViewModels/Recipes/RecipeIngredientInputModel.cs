namespace MoiteRecepti.Web.ViewModels.Recipes
{
    using System.ComponentModel.DataAnnotations;

    public class RecipeIngredientInputModel
    {
        public string IngredientName { get; set; }

        public string Quantity { get; set; }
    }
}
