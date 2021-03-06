namespace MamcheAmAm.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MamcheAmAm.Data.Common.Models;

    using static MamcheAmAm.Data.Common.DataConstants;

    public class Recipe : BaseDeletableModel<int>
    {
        public Recipe()
        {
            this.Ingredients = new HashSet<RecipeIngredient>();
            this.Images = new HashSet<Image>();
            this.Ratings = new HashSet<Rating>();
        }

        [Required]
        [MaxLength(RecipeTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public string Instructions { get; set; }

        public TimeSpan PreparationTime { get; set; }

        public TimeSpan CookingTime { get; set; }

        public int Portions { get; set; }

        [Required]
        public string CreatedByUserId { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }

        public virtual ICollection<RecipeIngredient> Ingredients { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
