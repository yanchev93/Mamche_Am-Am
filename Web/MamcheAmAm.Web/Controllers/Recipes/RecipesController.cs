namespace MamcheAmAm.Web.Controllers
{
    using MamcheAmAm.Data;
    using MamcheAmAm.Web.ViewModels.RecipesViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class RecipesController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public RecipesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Create()
        {
            this.GetCategories();
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateRecipeInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                this.GetCategories();
                return this.View(model);
            }

            return this.Redirect("/");
        }

        private void GetCategories()
        {
            var db = this.dbContext.Categories;
            this.ViewBag.Category = new SelectList(db, "Id", "Name");
        }
    }
}
