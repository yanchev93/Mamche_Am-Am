namespace MamcheAmAm.Web.Controllers
{
    using MamcheAmAm.Data.Common.Repositories;
    using MamcheAmAm.Data.Models;
    using MamcheAmAm.Web.ViewModels.RecipesViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class RecipesController : Controller
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;

        public RecipesController(IDeletableEntityRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IActionResult Create()
        {
            this.GetCategories();
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateRecipeInputModel model)
        {
            if (!this.ModelState.IsValid || model.Ingredients.Count > 40)
            {
                this.GetCategories();
                return this.View(model);
            }

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
