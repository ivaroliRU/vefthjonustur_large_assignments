using System.ComponentModel.DataAnnotations;

namespace TechnicalRadiation.Models.InputModels
{
    public class CategoryInputModel
    {
     //Name (required and max length 60)
        [Required]
        [MaxLength(60)]
        public string Name {get; set;}
    }
}