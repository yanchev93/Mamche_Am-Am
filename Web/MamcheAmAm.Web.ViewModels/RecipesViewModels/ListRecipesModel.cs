namespace MamcheAmAm.Web.ViewModels.RecipesViewModels
{
    using System.Collections.Generic;

    public class ListRecipesModel : BasePagingModel
    {
        public IEnumerable<SingleRecipeModel> Recipes { get; set; }
    }
}
