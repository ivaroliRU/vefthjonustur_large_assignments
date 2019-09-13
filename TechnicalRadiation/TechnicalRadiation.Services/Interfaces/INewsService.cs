using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalRadiation.Models;
using TechnicalRadiation.Models.DtoModels;

namespace TechnicalRadiation.Services.Interfaces
{
    public interface INewsService
    {
        Envelope<NewsItemDto> GetAllNewsItems(int pageSize, int pageNumber);
        NewsItemDetailDto GetNewsItemsById(int newsId);
        IEnumerable<NewsItemDto> GetNewsByAuthor(int authorId);
    }
}