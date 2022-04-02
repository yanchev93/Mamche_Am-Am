namespace MamcheAmAm.Web.ViewModels.RecipesViewModels
{
    using System.ComponentModel.DataAnnotations;

    using static MamcheAmAm.Data.Common.DataConstants;

    public class RecipeIngredientInputModel
    {
        [Required]
        [MinLength(IngredientsMinName)]
        public string IngredientName { get; set; }

        [Required]
        [MinLength(IngredientsMinQuantity)]
        public string Quantity { get; set; }
    }
}
