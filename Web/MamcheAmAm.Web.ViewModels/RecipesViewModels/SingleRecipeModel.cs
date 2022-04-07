namespace MamcheAmAm.Web.ViewModels.RecipesViewModels
{
    public class SingleRecipeModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Instruction { get; set; }

        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
