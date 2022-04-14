namespace MamcheAmAm.Web.ViewModels.RecipesViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using MamcheAmAm.Data.Models;
    using MamcheAmAm.Services.Mapping;

    public class RecipeDetailsModel : IMapFrom<Recipe>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Instructions { get; set; }

        public DateTime CreatedOn { get; set; }

        public TimeSpan PreparationTime { get; set; }

        public TimeSpan CookingTime { get; set; }

        public int Portions { get; set; }

        public string CreatedByUserUserName { get; set; }

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<IngredientsDetailsModel> Ingredients { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Recipe, RecipeDetailsModel>()
                .ForMember(x => x.ImageUrl, opt => opt.MapFrom(r =>
                                 r.Images.FirstOrDefault().RemoteImageUrl != null
                               ? r.Images.FirstOrDefault().RemoteImageUrl
                               : "/images/recipes/" + r.Images.FirstOrDefault().Id + "." + r.Images.FirstOrDefault().Extension));
        }
    }
}
