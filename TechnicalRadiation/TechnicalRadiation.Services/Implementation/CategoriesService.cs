using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalRadiation.Services.Interfaces;
using TechnicalRadiation.Repositories.Interfaces;
using TechnicalRadiation.Models;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Models.DtoModels;
using TechnicalRadiation.Models.HyperMedia;
using TechnicalRadiation.Common;

namespace TechnicalRadiation.Services.Implementation
{
    public class CategoriesService : ICategoriesService
    {
       ICategoriesRepository _categoryRepository;

       INewsRepository _newsRepository;

       public CategoriesService(ICategoriesRepository categoryRepository, INewsRepository newsRepository)
       {
           _categoryRepository = categoryRepository;
           _newsRepository = newsRepository;
       }

        public IEnumerable<CategoryDetailDto> GetAllCategories()
        {
            var items = _categoryRepository.GetAllCategories().ToList();

            items.ForEach(i => {
                ServiceHelper.AddCategoryLinks(i);
            });
            return items;
        }

        public CategoryDetailDto GetCategoryById(int Id)
        {
            var item = _categoryRepository.GetCategoryById(Id);
            ServiceHelper.AddCategoryLinks(item);
            return item;
        }

        public int CreateNewCategory(CategoryInputModel category)
        {
            return _categoryRepository.CreateNewCategory(category);
        }

        public int UpdateCategoryById(CategoryInputModel category, int id)
        {
            return _categoryRepository.UpdateCategoryById(category, id);
        }

        public int DeleteCategoryById(int id)
        {
            return _categoryRepository.DeleteCategoryById(id);
        }





       
        
    }
}