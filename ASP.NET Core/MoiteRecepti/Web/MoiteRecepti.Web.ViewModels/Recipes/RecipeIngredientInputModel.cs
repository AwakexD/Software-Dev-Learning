namespace MoiteRecepti.Web.ViewModels.Recipes
{
    using System.ComponentModel.DataAnnotations;

    public class RecipeIngredientInputModel
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }


        public string Quantity { get; set; }
    }
}
