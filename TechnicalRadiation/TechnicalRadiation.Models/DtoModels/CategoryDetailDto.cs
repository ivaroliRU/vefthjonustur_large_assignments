using TechnicalRadiation.Models.HyperMedia;

namespace TechnicalRadiation.Models.DtoModels
{
    public class CategoryDetailDto : HyperMediaModel
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public string Slug {get;set;}
    }
}