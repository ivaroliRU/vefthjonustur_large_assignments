using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalRadiation.Services.Interfaces;
using TechnicalRadiation.Repositories.Interfaces;
using TechnicalRadiation.Common;
using TechnicalRadiation.Models;
using TechnicalRadiation.Models.DtoModels;
using TechnicalRadiation.Models.HyperMedia;

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
                i.Links.AddReference("self", $"/api/categories/{i.Id}");
                i.Links.AddReference("edit", $"/api/categories/{i.Id}");
                i.Links.AddReference("delete", $"/api/categories/{i.Id}");
            });
            return items;
        }

        public IEnumerable<CategoryDetailDto> GetCategoryById(int Id)
        {
            return new CategoryDetailDto[] {};
        }
       
        
    }
}