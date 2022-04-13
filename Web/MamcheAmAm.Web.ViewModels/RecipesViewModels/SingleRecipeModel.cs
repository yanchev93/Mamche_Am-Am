namespace MamcheAmAm.Web.ViewModels.RecipesViewModels
{
    using System.Linq;

    using AutoMapper;
    using MamcheAmAm.Data.Models;
    using MamcheAmAm.Services.Mapping;

    public class SingleRecipeModel : IMapFrom<Recipe>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Instructions { get; set; }

        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Recipe, SingleRecipeModel>()
                .ForMember(x => x.ImageUrl, opt => opt.MapFrom(r =>
                                 r.Images.FirstOrDefault().RemoteImageUrl != null
                               ? r.Images.FirstOrDefault().RemoteImageUrl
                               : "/images/recipes/" + r.Images.FirstOrDefault().Id + "." + r.Images.FirstOrDefault().Extension));
        }
    }
}
