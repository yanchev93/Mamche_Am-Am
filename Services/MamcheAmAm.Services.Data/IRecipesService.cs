namespace MamcheAmAm.Services.Data
{
    using System.Threading.Tasks;

    using MamcheAmAm.Web.ViewModels.RecipesViewModels;

    public interface IRecipesService
    {
        Task CreateAsync(CreateRecipeInputModel model);

        bool AnyDigitsInIngredientName(CreateRecipeInputModel model);
    }
}
