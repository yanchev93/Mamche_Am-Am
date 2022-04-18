namespace MamcheAmAm.Data.Models
{
    using MamcheAmAm.Data.Common.Models;

    public class Rating : BaseModel<int>
    {
        public Rating()
        {

        }

        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public byte Value { get; set; }
    }
}
