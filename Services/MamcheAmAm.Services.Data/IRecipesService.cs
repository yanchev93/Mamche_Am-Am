namespace MamcheAmAm.Services.Data
{
    using System.Threading.Tasks;

    using MamcheAmAm.Web.ViewModels.RecipesViewModels;

    public interface IRecipesService
    {
        Task CreateAsync(CreateRecipeInputModel model, string userId);

        bool AnyDigitsInIngredientName(CreateRecipeInputModel model);
    }
}
