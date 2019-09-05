namespace TechnicalRadiation.Models.EntityModels
{
    public class Author
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string ProfileImgSource {get; set;}
        public string Bio {get; set;}
        public string ModifiedBy {get; set;}
        public Date CreatedDate {get; set;}
        public Date ModifiedDate {get; set;}
    }
}