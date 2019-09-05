using System.ComponentModel.DataAnnotations;

namespace TechnicalRadiation.Models.InputModels
{
    public class AuthorInputModel
    {
        //Name (required), ProfileImgSource (required and must be a valid URL), Bio (max length255)
        [Required]
        public string Name {get; set;}
        [Required]
        [Url]
        public string ProfileImgSource {get; set;}
        [MaxLength(255)]
        public string Bio {get; set;}
    }
}