using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalRadiation.Models;
using TechnicalRadiation.Models.EntityModels;
using TechnicalRadiation.Models.DtoModels;
using TechnicalRadiation.Repositories.Data;
using TechnicalRadiation.Repositories.Interfaces;

namespace TechnicalRadiation.Repositories.Implementation
{
    public class CategoriesRepository : ICategoriesRepository
    {
         private readonly ITechnicalRadiationDbContext _dbContext;

        public CategoriesRepository(ITechnicalRadiationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CategoryDetailDto> GetAllCategories()
        {
            var items = _dbContext.Category.ToArray().Select(c => new CategoryDetailDto
            {
                Id = c.Id,
                Name = c.Name,
                Slug = c.Slug
            });

            return items;
        }
         public CategoryDetailDto GetCategoryById(int categoryId){
            var item = (from c in _dbContext.Category
                        where c.Id == categoryId
                        select new CategoryDetailDto()
                        {
                            Id = c.Id,
                            Name = c.Name,
                            Slug = c.Slug
                            
                        }).FirstOrDefault();

            return item;
        }
    }
}