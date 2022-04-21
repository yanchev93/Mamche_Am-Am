namespace MamcheAmAm.Web.ViewModels.RatingsViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class PostRatingInputModel
    {
        public int RecipeId { get; set; }

        [Range(1, 5)]
        public byte Value { get; set; }
    }
}
