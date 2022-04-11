namespace MamcheAmAm.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MamcheAmAm.Web.ViewModels.RecipesViewModels;

    public interface IRecipesService
    {
        Task CreateAsync(CreateRecipeInputModel model, string userId, string imagePath);

        IEnumerable<T> GetAllRecipes<T>(int page, int itemsPerPage = 10);

        int GetCountRecipes();

        bool AnyDigitsInIngredientName(CreateRecipeInputModel model);
    }
}
