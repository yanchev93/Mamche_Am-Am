namespace MamcheAmAm.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RecipeIngredient
    {
        public int Id { get; set; }

        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }

        public int IngredientId { get; set; }

        public virtual Ingredient Ingredient { get; set; }

        [Required]
        public string Quantity { get; set; }
    }
}
