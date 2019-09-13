using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalRadiation.Models;
using TechnicalRadiation.Models.DtoModels;
using TechnicalRadiation.Models.InputModels;

namespace TechnicalRadiation.Services.Interfaces
{
    public interface ICategoriesService
    {
        IEnumerable<CategoryDetailDto> GetAllCategories();
        CategoryDetailDto GetCategoryById(int Id);

        int CreateNewCategory(CategoryInputModel category);
        
        int UpdateCategoryById(CategoryInputModel category, int id);

        int DeleteCategoryById(int id);
    }
}