namespace MamcheAmAm.Web.Controllers
{
    using MamcheAmAm.Web.ViewModels.RecipesViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class RecipesController : Controller
    {
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateRecipeInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            return this.Redirect("/");
        }
    }
}
