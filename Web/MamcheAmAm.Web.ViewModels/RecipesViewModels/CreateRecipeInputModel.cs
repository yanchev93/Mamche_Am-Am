namespace MamcheAmAm.Web.ViewModels.RecipesViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreateRecipeInputModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MinLength(30)]
        public string Instructions { get; set; }

        [Required]
        [Range(1, 24 * 60)]
        [Display(Name = "Preparation Time (in minutes)")]
        public int PreparationTime { get; set; }

        [Required]
        [Range(1, 24 * 60)]
        [Display(Name = "Cooking Time (in minutes)")]
        public int CookingTime { get; set; }

        [Range(1, 80)]
        public int Portions { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required]
        public ICollection<RecipeIngredientInputModel> Ingredients { get; set; }
    }
}
