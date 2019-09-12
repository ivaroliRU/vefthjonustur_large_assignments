using System;

namespace TechnicalRadiation.Models.EntityModels
{
    public class NewsItem
    {
        public int Id {get; set;}
        public string Title {get; set;}
        public string ImgSource {get; set;}
        public string ShortDescription {get; set;}
        public string LongDescription {get; set;}
        public DateTime PublishedDate {get; set;}
        public string ModifiedBy {get; set;}
        public DateTime CreatedDate {get; set;}
        public DateTime ModifiedDate {get; set;}
    }
}