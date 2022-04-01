namespace MamcheAmAm.Web.ViewModels.RecipesViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class RecipeIngredientInputModel
    {
        [Required]
        [MinLength(2)]
        public string IngredientName { get; set; }

        [Required]
        [MinLength(2)]
        public string Quantity { get; set; }
    }
}
