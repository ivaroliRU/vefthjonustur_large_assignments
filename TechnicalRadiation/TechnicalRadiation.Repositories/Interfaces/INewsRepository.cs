using System;
using System.Collections.Generic;
using System.Linq;
using TechnicalRadiation.Models.EntityModels;
using TechnicalRadiation.Models.DtoModels;
using TechnicalRadiation.Models.InputModels;

namespace TechnicalRadiation.Repositories.Interfaces
{
    public interface INewsRepository
    {
        IEnumerable<NewsItemDto> GetAllNewsItems();
        IEnumerable<NewsItemDto> GetNewsByAuthor(int authorId);
        NewsItemDetailDto GetNewsItemsById(int newsId);
        int CreateNewsItem(NewsItemInputModel item);
        int UpdateNewsItemById(int newsId, NewsItemInputModel item);
        int DeleteNewsItemById(int newsId);
        void CreateCategoryNewsConnection(int categoryId, int newsId);
        void CreateAuthorNewsConnection(int authorId, int newsId);
    }
}