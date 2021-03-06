namespace MamcheAmAm.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using MamcheAmAm.Data.Common.Repositories;
    using MamcheAmAm.Data.Models;
    using MamcheAmAm.Services.Data;
    using MamcheAmAm.Web.ViewModels.RecipesViewModels;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class RecipesController : Controller
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;
        private readonly IRecipesService recipesService;
        private readonly IWebHostEnvironment environment;
        private readonly UserManager<ApplicationUser> userManager;

        public RecipesController(
            IDeletableEntityRepository<Category> categoriesRepository,
            IRecipesService recipesService,
            IWebHostEnvironment environment,
            UserManager<ApplicationUser> userManager)
        {
            this.categoriesRepository = categoriesRepository;
            this.recipesService = recipesService;
            this.environment = environment;
            this.userManager = userManager;
        }

        public IActionResult All(int id = 1)
        {
            const int itemsPerPage = 9;
            int pagesCount = (int)Math.Ceiling((double)this.recipesService.GetCountRecipes() / itemsPerPage);

            if (id <= 0 || id > pagesCount)
            {
                id = 1;
            }

            var viewModel = new ListRecipesModel
            {
                Recipes = this.recipesService.GetAllRecipes<SingleRecipeModel>(id, itemsPerPage),
                PageNumber = id,
                RecipesCount = this.recipesService.GetCountRecipes(),
                ItemsPerPage = itemsPerPage,
            };

            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Create()
        {
            this.GetCategories();
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateRecipeInputModel model)
        {
            if (!this.ModelState.IsValid || model.Ingredients.Count > 40 || this.recipesService.AnyDigitsInIngredientName(model))
            {
                this.GetCategories();
                return this.View(model);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            await this.recipesService.CreateAsync(model, user.Id, $"{this.environment.WebRootPath}/images");

            return this.Redirect("/");
        }

        public IActionResult ById(int id)
        {
            var recipeById = this.recipesService.GetById<RecipeDetailsModel>(id);
            return this.View(recipeById);
        }

        // Couldn't make a service to get the categories and send it to the view
        private void GetCategories()
        {
            var categories = this.categoriesRepository.All();
            this.ViewBag.Category = new SelectList(categories, "Id", "Name");
        }
    }
}
