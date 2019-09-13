using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalRadiation.Models;
using TechnicalRadiation.Models.DtoModels;
using TechnicalRadiation.Models.InputModels;

namespace TechnicalRadiation.Services.Interfaces
{
    public interface INewsService
    {
        Envelope<NewsItemDto> GetAllNewsItems(int pageSize, int pageNumber);
        NewsItemDetailDto GetNewsItemsById(int newsId);
        IEnumerable<NewsItemDto> GetNewsByAuthor(int authorId);
        int CreateNewsItem(NewsItemInputModel item);
        int UpdateNewsItemById(int newsId, NewsItemInputModel item);
        int DeleteNewsItemById(int newsId);
    }
}