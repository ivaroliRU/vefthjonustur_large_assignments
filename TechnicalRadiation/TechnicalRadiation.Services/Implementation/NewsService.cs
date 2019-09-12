using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalRadiation.Services.Interfaces;
using TechnicalRadiation.Repositories.Interfaces;
using TechnicalRadiation.Common;
using TechnicalRadiation.Models;
using TechnicalRadiation.Models.HyperMedia;
using TechnicalRadiation.Models.DtoModels;

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
                i.Links.AddReference("self", $"/api/{i.Id}");
                i.Links.AddReference("edit", $"/api/{i.Id}");
                i.Links.AddReference("delete", $"/api/{i.Id}");
                //i.Links.AddListReference("authors", _authorsRepository.GetAuthersById(i.Id).Select(a => new { href = $"/api/authors/{a.Id}" }));
                //i.Links.AddListReference("categories", _categoriesRepository.GetCategoriesById(i.Id).Select(c => new { href = $"/api/categories/{c.Id}" }));
            });

            return new Envelope<NewsItemDto>(pageNumber, pageSize, items);
        }

        public NewsItemDetailDto GetNewsItemsById(int newsId){
            var item = _newsRepository.GetNewsItemsById(newsId);
            return item;
        }
    }
}