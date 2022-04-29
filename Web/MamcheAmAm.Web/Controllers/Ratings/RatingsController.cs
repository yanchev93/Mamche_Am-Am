namespace MamcheAmAm.Web.Controllers.Ratings
{
    using System.Threading.Tasks;

    using MamcheAmAm.Data.Models;
    using MamcheAmAm.Services.Data;
    using MamcheAmAm.Web.ViewModels.RatingsViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class RatingsController : BaseController
    {
        private readonly IRatingService ratingService;
        private readonly UserManager<ApplicationUser> userManager;

        public RatingsController(
            IRatingService ratingService,
            UserManager<ApplicationUser> userManager)
        {
            this.ratingService = ratingService;
            this.userManager = userManager;
        }

        [HttpPost]
        [Authorize]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult<PostRatingResponseModel>> Post(PostRatingInputModel model)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            await this.ratingService.SetRatingAsync(model.RecipeId, user.Id, model.Value);

            var averageRecipeRating = this.ratingService.GetAverageRating(model.RecipeId);
            var avrgRating = new PostRatingResponseModel { AverageRating = averageRecipeRating };

            return avrgRating;
        }
    }
}
