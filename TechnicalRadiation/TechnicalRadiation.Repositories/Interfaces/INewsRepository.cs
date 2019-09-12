using System;
using System.Collections.Generic;
using System.Linq;
using TechnicalRadiation.Models.EntityModels;
using TechnicalRadiation.Models.DtoModels;

namespace TechnicalRadiation.Repositories.Interfaces
{
    public interface INewsRepository
    {
        IEnumerable<NewsItemDto> GetAllNewsItems();
        NewsItemDto GetNewsItemsById(int newsId);
    }
}