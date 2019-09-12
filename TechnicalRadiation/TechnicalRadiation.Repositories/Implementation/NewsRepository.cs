using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalRadiation.Models.EntityModels;
using TechnicalRadiation.Models.DtoModels;
using TechnicalRadiation.Repositories.Data;
using TechnicalRadiation.Repositories.Interfaces;

namespace TechnicalRadiation.Repositories.Implementation
{
    public class NewsRepository : INewsRepository
    {
        private readonly ITechnicalRadiationDbContext _dbContext;

        public NewsRepository(ITechnicalRadiationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<NewsItemDto> GetAllNewsItems()
        {
            var items = _dbContext.NewsItems.ToArray().Select(c => new NewsItemDto
            {
                Id = c.Id,
                Title = c.Title,
                ImgSource = c.ImgSource,
                ShortDescription = c.ShortDescription
            });

            return items;
        }

        public IEnumerable<NewsItemDto> GetNewsByAuthor(int authorId){
            return null;
        }

        public NewsItemDetailDto GetNewsItemsById(int newsId){
            var item = (from c in _dbContext.NewsItems
                        where c.Id == newsId
                        select new NewsItemDetailDto()
                        {
                            Id = c.Id,
                            Title = c.Title,
                            ImgSource = c.ImgSource,
                            ShortDescription = c.ShortDescription,
                            LongDescription = c.LongDescription,
                            PublishDate = c.PublishedDate
                        }).FirstOrDefault();

            return item;
        }
    }
}