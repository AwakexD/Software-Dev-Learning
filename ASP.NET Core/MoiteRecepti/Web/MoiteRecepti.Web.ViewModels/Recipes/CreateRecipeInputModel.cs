﻿namespace MoiteRecepti.Web.ViewModels.Recipes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class CreateRecipeInputModel
    {
        public CreateRecipeInputModel()
        {
            this.Ingredients = new HashSet<RecipeIngredientInputModel>();
        }

        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [MinLength(50)]
        public string Instructions { get; set; }

        [Range(0, 24 * 60)]
        [Display(Name = "Preparation time in minutes")]
        public int PreparationTime { get; set; }

        [Range(0, 24 * 60)]
        [Display(Name = "Cooking time in minutes")]
        public int CookingTime { get; set; }

        [Required]
        [Range(1, 100)]
        public int PortionsCount { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<RecipeIngredientInputModel> Ingredients { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }
    }
}
