using System;
using System.Collections.Generic;
using System.Linq;
using TechnicalRadiation.Models.EntityModels;
using TechnicalRadiation.Models.DtoModels;
using TechnicalRadiation.Models.InputModels;

namespace TechnicalRadiation.Repositories.Interfaces
{
    public interface ICategoriesRepository
    {
        IEnumerable<CategoryDetailDto> GetAllCategories();
        CategoryDetailDto GetCategoryById(int categoryId);
        IEnumerable<CategoryDetailDto> GetCategoriesOfNews(int newsId);

        int CreateNewCategory(CategoryInputModel category);

        int UpdateCategoryById(CategoryInputModel category, int id);

        int DeleteCategoryById(int id);
    }
}