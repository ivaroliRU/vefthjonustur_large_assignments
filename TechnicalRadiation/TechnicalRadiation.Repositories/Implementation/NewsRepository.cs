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
        private readonly TechnicalRadiationDbContext _dbContext;

        public NewsRepository(TechnicalRadiationDbContext dbContext)
        {
            _dbContext = new TechnicalRadiationDbContext();
        }

        public IEnumerable<NewsItemDto> GetAllNewsItems()
        {
            return _dbContext.NewsItems.ToList().Select(c => new NewsItemDto
            {
                Id = c.Id,
                Title = c.Title,
                ImgSource = c.ImgSource,
                ShortDescription = c.ShortDescription
            });
        }
    }
}