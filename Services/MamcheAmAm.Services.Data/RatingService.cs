namespace MamcheAmAm.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using MamcheAmAm.Data.Common.Repositories;
    using MamcheAmAm.Data.Models;

    public class RatingService : IRatingService
    {
        private readonly IRepository<Rating> ratingRepository;

        public RatingService(IRepository<Rating> ratingRepository)
        {
            this.ratingRepository = ratingRepository;
        }

        public double GetAverageRating(int recipeId)
        {
            var averageRecipeRating = this.ratingRepository.All().Where(x => x.RecipeId == recipeId).Average(x => x.Value);

            return averageRecipeRating;
        }

        public async Task SetRatingAsync(int recipeId, string userId, byte value)
        {
            var rating = this.ratingRepository.All().FirstOrDefault(x => x.RecipeId == recipeId && x.UserId == userId);

            if (rating == null)
            {
                rating = new Rating
                {
                    RecipeId = recipeId,
                    UserId = userId,
                };

                await this.ratingRepository.AddAsync(rating);
            }

            rating.Value = value;

            await this.ratingRepository.SaveChangesAsync();
        }
    }
}
