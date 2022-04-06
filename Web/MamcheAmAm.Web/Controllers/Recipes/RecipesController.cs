namespace MamcheAmAm.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using MamcheAmAm.Data.Common.Repositories;
    using MamcheAmAm.Data.Models;
    using MamcheAmAm.Services.Data;
    using MamcheAmAm.Web.ViewModels.RecipesViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class RecipesController : Controller
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;
        private readonly IRecipesService recipesService;

        public RecipesController(
            IDeletableEntityRepository<Category> categoriesRepository,
            IRecipesService recipesService)
        {
            this.categoriesRepository = categoriesRepository;
            this.recipesService = recipesService;
        }

        public IActionResult Create()
        {
            this.GetCategories();
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRecipeInputModel model)
        {
            if (!this.ModelState.IsValid || model.Ingredients.Count > 40 || this.recipesService.AnyDigitsInIngredientName(model))
            {
                this.GetCategories();
                return this.View(model);
            }

            await this.recipesService.CreateAsync(model);

            return this.Redirect("/");
        }

        // Couldn't make a service to get the categories and send it to the view
        private void GetCategories()
        {
            var categories = this.categoriesRepository.All();
            this.ViewBag.Category = new SelectList(categories, "Id", "Name");
        }
    }
}
