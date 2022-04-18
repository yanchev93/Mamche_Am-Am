namespace MamcheAmAm.Services.Data
{
    using System.Threading.Tasks;

    public interface IRatingService
    {
        Task SetRatingAsync(int recipeId, string userId, byte value);
    }
}
