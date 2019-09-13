using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Models.EntityModels;
using TechnicalRadiation.Models.DtoModels;
using TechnicalRadiation.Repositories.Data;
using TechnicalRadiation.Repositories.Interfaces;
using TechnicalRadiation.Common;

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

        public IEnumerable<CategoryDetailDto> GetCategoriesOfNews(int newsId){
            var item = (from c in _dbContext.Category
                        join n in _dbContext.NewsItemCategories on c.Id equals n.CategoryId
                        where n.NewsItemId == newsId
                        select new CategoryDetailDto()
                        {
                            Id = c.Id,
                            Name = c.Name,
                            Slug = c.Slug
                        }).ToList();

            return item;
        }

        public int CreateNewCategory(CategoryInputModel item)
        {
            int id = _dbContext.Category.OrderByDescending(x => x.Id).First().Id++;

            _dbContext.Category.Add(new Category {
                Id = id,
                Name = item.Name,
                Slug = DataHelper.CreateSlug(item.Name)
            });

            return id;
        }

        //int UpdateCategoryById(CategoryInputModel category, int id);
        public int UpdateCategoryById(CategoryInputModel cat, int categoryId){
            var item = _dbContext.Category.FirstOrDefault(x => x.Id == categoryId);
            if (item != null) 
            {
                item.Name = cat.Name;
                item.ModifiedDate = DateTime.Now;
            }

            return categoryId;
        }

        //int DeleteCategoryById(int id);
        public int DeleteCategoryById(int categoryId){
            var i = _dbContext.Category.Where(item => item.Id == categoryId).Single();
            _dbContext.Category.Remove(i);
            return categoryId;
        }
    }
}