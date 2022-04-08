namespace MamcheAmAm.Web.ViewModels.RecipesViewModels
{
    using System;
    using System.Collections.Generic;

    public class ListRecipesModel
    {
        public IEnumerable<SingleRecipeModel> Recipes { get; set; }

        public int PageNumber { get; set; }

        public int RecipesCount { get; set; }

        public int ItemsPerPage { get; set; }

        public bool HasPreviousePage => this.PageNumber > 1;

        public bool HasNextPage => this.PageNumber < this.PagesCount;

        public int PreviousPageNumber => this.PageNumber - 1;

        public int NextPageNumber => this.PageNumber + 1;

        public int PagesCount => (int)Math.Ceiling((double)this.RecipesCount / this.ItemsPerPage);

        public int PreviousePageNumber { get; set; }
    }
}
