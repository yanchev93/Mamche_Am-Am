namespace MamcheAmAm.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;

    using MamcheAmAm.Data.Common.Repositories;
    using MamcheAmAm.Data.Models;
    using MamcheAmAm.Services.Data.Helpers;
    using MamcheAmAm.Services.Mapping;
    using MamcheAmAm.Web.ViewModels.RecipesViewModels;

    public class RecipesService : IRecipesService
    {
        private readonly IDeletableEntityRepository<Recipe> recipesRepository;
        private readonly IDeletableEntityRepository<Ingredient> ingredientsRepository;
        private readonly IFirstLetterUppercaseHelperService firstLetterHelper;

        public RecipesService(
            IDeletableEntityRepository<Recipe> recipesRepository,
            IDeletableEntityRepository<Ingredient> ingredientsRepository,
            IFirstLetterUppercaseHelperService firstLetterHelper)
        {
            this.recipesRepository = recipesRepository;
            this.ingredientsRepository = ingredientsRepository;
            this.firstLetterHelper = firstLetterHelper;
        }

        public async Task CreateAsync(CreateRecipeInputModel model, string userId)
        {
            var recipeTitle = this.firstLetterHelper.FirstLetterToUpperCase(model.Title);

            var recipe = new Recipe
            {
                Title = recipeTitle,
                Instructions = model.Instructions,
                CategoryId = model.CategoryId,
                PreparationTime = TimeSpan.FromMinutes(model.PreparationTime),
                CookingTime = TimeSpan.FromMinutes(model.CookingTime),
                Portions = model.Portions,
                CreatedByUserId = userId,
            };

            foreach (var currentIngredient in model.Ingredients)
            {
                // Lowering the ingredient name. Then making every first letter of a word in the input ingredient with upper letter for proper DB insert.
                string properIngredientName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(currentIngredient.IngredientName.ToLower()).Trim();

                var ingredient = this.ingredientsRepository.All()
                    .FirstOrDefault(x => x.Name == properIngredientName);

                if (ingredient == null)
                {
                    ingredient = new Ingredient
                    {
                        Name = properIngredientName,
                    };
                }

                recipe.Ingredients.Add(new RecipeIngredient
                {
                    Ingredient = ingredient,
                    Quantity = currentIngredient.Quantity,
                });
            }

            await this.recipesRepository.AddAsync(recipe);
            await this.recipesRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllRecipes<T>(int page, int itemsPerPage = 9)
        {
            var allRecipes = this.recipesRepository.AllAsNoTracking()
            .OrderByDescending(x => x.Id)
            .Skip((page - 1) * itemsPerPage)
            .Take(itemsPerPage)
            .To<T>()
            .ToList();

            return allRecipes;
        }

        public int GetCountRecipes()
        {
            return this.recipesRepository.All().Count();
        }

        public bool AnyDigitsInIngredientName(CreateRecipeInputModel model)
        {
            bool anyDigitsInIngredientsName = false;

            if (model.Ingredients != null)
            {
                anyDigitsInIngredientsName = model.Ingredients
                    .Select(x => x.IngredientName.Any(char.IsDigit))
                    .Any(x => x == true);
            }

            return anyDigitsInIngredientsName;
        }
    }
}
