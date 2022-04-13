namespace MamcheAmAm.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
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

        public async Task CreateAsync(CreateRecipeInputModel model, string userId, string imagePath)
        {
            // TODO: Validate equal Title recipe from the same user.
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

            Directory.CreateDirectory($"{imagePath}/recipes/");
            foreach (var imageFile in model.Images)
            {
                // Generating the extension. It will be generated with a dot('.').
                var extension = Path.GetExtension(imageFile.FileName).TrimStart('.');

                var currentImage = new Image
                {
                    Extension = extension,
                    CreatedByUserId = userId,
                };

                recipe.Images.Add(currentImage);

                // Generating physicalPath for the image where is it going to be saved.
                var physicalPath = $"{imagePath}/recipes/{currentImage.Id}.{extension}";

                // Reading bytes and coping to directory. -> 1 line code: await imageFile.CopyToAsync(new FileStream(physicalPath, FileMode.Create));
                using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                await imageFile.CopyToAsync(fileStream);
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
