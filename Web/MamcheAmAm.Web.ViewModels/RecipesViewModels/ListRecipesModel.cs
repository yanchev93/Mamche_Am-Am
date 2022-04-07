namespace MamcheAmAm.Web.ViewModels.RecipesViewModels
{
    using System.Collections.Generic;

    public class ListRecipesModel
    {
        public IEnumerable<SingleRecipeModel> Recipes { get; set; }

        public int PageNumber { get; set; }
    }
}
