namespace MamcheAmAm.Web.ViewModels.RecipesViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static MamcheAmAm.Data.Common.DataConstants;

    public class CreateRecipeInputModel
    {
        // Can't use constants in the ErrorMassage. Please check if they are correct!! !! NB !!
        [Required(ErrorMessage = $"Title should be between 3 and 50 characters long.")]
        [MinLength(RecipeTitleMinLength)]
        [MaxLength(RecipeTitleMaxLength)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please provide proper instructions for the recipe. It should have more than 30 characters.")]
        [MinLength(RecipeInstructionMinLength)]
        public string Instructions { get; set; }

        [Required]
        [Range(RecipeMinRangeTime, RecipeMaxRangeTime)]
        [Display(Name = "Preparation Time (in minutes)")]
        public int PreparationTime { get; set; }

        [Required]
        [Range(RecipeMinRangeTime, RecipeMaxRangeTime)]
        [Display(Name = "Cooking Time (in minutes)")]
        public int CookingTime { get; set; }

        [Required]
        [Range(RecipeMinPortionsCount, RecipeMaxPortionsCount)]
        public int Portions { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        // Can't use constants in the ErrorMassage. Please check if they are correct!! !! NB !!
        [Required(ErrorMessage = "There should be atleast 1 ingredient.")]
        public ICollection<RecipeIngredientInputModel> Ingredients { get; set; }
    }
}
