namespace MamcheAmAm.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MamcheAmAm.Data.Common.Models;

    public class Ingredient : BaseDeletableModel<int>
    {
        public Ingredient()
        {
            this.Recipes = new HashSet<RecipeIngredient>();
        }

        [Required]
        public string Name { get; set; }

        public ICollection<RecipeIngredient> Recipes { get; set; }
    }
}
