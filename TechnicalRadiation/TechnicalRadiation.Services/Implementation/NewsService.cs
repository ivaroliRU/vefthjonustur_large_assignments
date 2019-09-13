using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalRadiation.Services.Interfaces;
using TechnicalRadiation.Repositories.Interfaces;
using TechnicalRadiation.Models;
using TechnicalRadiation.Models.HyperMedia;
using TechnicalRadiation.Models.DtoModels;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Common;

namespace TechnicalRadiation.Services.Implementation
{
    public class NewsService : INewsService
    {
        INewsRepository _newsRepository;
        IAuthorsRepository _authorsRepository;
        ICategoriesRepository _categoriesRepository;

        public NewsService(INewsRepository newsRepository, IAuthorsRepository authorsRepository, ICategoriesRepository categoriesRepository){
            _newsRepository = newsRepository;
            _authorsRepository = authorsRepository;
            _categoriesRepository = categoriesRepository;
        }

        public Envelope<NewsItemDto> GetAllNewsItems(int pageSize, int pageNumber){
            var items = _newsRepository.GetAllNewsItems().ToList();

            items.ForEach(i => {
                LinksHelper.AddNewsItemLinks(i, _authorsRepository, _categoriesRepository);
            });

            return new Envelope<NewsItemDto>(pageNumber, pageSize, items);
        }

        public NewsItemDetailDto GetNewsItemsById(int newsId){
            var item = _newsRepository.GetNewsItemsById(newsId);
            LinksHelper.AddNewsItemLinks(item, _authorsRepository, _categoriesRepository);
            return item;
        }

        public IEnumerable<NewsItemDto> GetNewsByAuthor(int authorId){
            var items = _newsRepository.GetNewsByAuthor(authorId).ToList();

            items.ForEach(i => {
                LinksHelper.AddNewsItemLinks(i, _authorsRepository, _categoriesRepository);
            });

            return items;
        }

        public int CreateNewsItem(NewsItemInputModel item){
            return _newsRepository.CreateNewsItem(item);
        }

        public int UpdateNewsItemById(int newsId, NewsItemInputModel item){
            return _newsRepository.UpdateNewsItemById(newsId, item);
        }

        public int DeleteNewsItemById(int newsId){
            return _newsRepository.DeleteNewsItemById(newsId);
        }
    }
}