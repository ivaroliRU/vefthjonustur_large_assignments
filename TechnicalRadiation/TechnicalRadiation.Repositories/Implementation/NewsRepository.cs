using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalRadiation.Models.EntityModels;
using TechnicalRadiation.Models.DtoModels;
using TechnicalRadiation.Models.InputModels;
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
            var item = (from c in _dbContext.NewsItems
                        join n in _dbContext.NewsItemAuthor on c.Id equals n.NewsItemId
                        where n.AuthorId == authorId
                        select new NewsItemDto()
                        {
                            Id = c.Id,
                            Title = c.Title,
                            ImgSource = c.ImgSource,
                            ShortDescription = c.ShortDescription
                        }).ToList();

            return item;
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

        public int CreateNewsItem(NewsItemInputModel item){
            int id = _dbContext.NewsItems.OrderByDescending(x => x.Id).First().Id++;

            _dbContext.NewsItems.Add(new NewsItem(){
                Id = id,
                Title = item.Title,
                ImgSource = item.ImgSource,
                ShortDescription = item.ShortDescription,
                LongDescription = item.LongDescription,
                PublishedDate = item.PublishDate
            });

            return id;
        }

        public int UpdateNewsItemById(int newsId, NewsItemInputModel news){
            var item = _dbContext.NewsItems.FirstOrDefault(x => x.Id == newsId);
            if (item != null) 
            {
                item.Title = news.Title;
                item.ImgSource = news.ImgSource;
                item.ShortDescription = news.ShortDescription;
                item.LongDescription = news.LongDescription;
                item.PublishedDate = news.PublishDate;
            }

            return newsId;
        }

        public int DeleteNewsItemById(int newsId){
            _dbContext.NewsItems.RemoveAt(newsId);
            return newsId;
        }
    }
}