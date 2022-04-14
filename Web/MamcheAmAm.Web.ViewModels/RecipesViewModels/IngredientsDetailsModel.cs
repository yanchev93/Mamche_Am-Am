namespace MamcheAmAm.Web.ViewModels.RecipesViewModels
{
    using MamcheAmAm.Data.Models;
    using MamcheAmAm.Services.Mapping;

    public class IngredientsDetailsModel : IMapFrom<RecipeIngredient>
    {
        public string IngredientName { get; set; }

        public string Quantity { get; set; }
    }
}
