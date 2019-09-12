using TechnicalRadiation.Models.HyperMedia;

namespace TechnicalRadiation.Models.DtoModels
{
    public class NewsItemDto : HyperMediaModel
    {
        public int Id{get;set;}
        public string Title {get;set;}
        public string ImgSource{get;set;}
        public string ShortDescription{get;set;}
    }
}