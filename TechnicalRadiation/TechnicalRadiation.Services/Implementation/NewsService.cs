using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalRadiation.Services.Interfaces;
using TechnicalRadiation.Repositories.Interfaces;
using TechnicalRadiation.Common;
using TechnicalRadiation.Models;
using TechnicalRadiation.Models.DtoModels;

namespace TechnicalRadiation.Services.Implementation
{
    public class NewsService : INewsService
    {
        INewsRepository _newsRepository;

        public NewsService(INewsRepository newsRepository){
            _newsRepository = newsRepository;
        }

        public Envelope<NewsItemDto> GetAllNewsItems(int? pageSize, int pageNumber){
            int acutalPSize = 25;

            if(pageSize != null){
                acutalPSize = (int)pageSize;
            }

            IEnumerable<NewsItemDto> items = _newsRepository.GetAllNewsItems();
            IEnumerable<IEnumerable<NewsItemDto>> pages = PageHelper.SplitIntoPages<NewsItemDto>(items, acutalPSize);
            IEnumerable<NewsItemDto> page = pages.ToList()[pageNumber];
            Envelope<NewsItemDto> envelopes = EnvelopeHelper<NewsItemDto>.ListToEnvelope(page, pageNumber);

            return envelopes;
        }

        public NewsItemDto GetNewsItemsById(int newsId){
            var item = _newsRepository.GetNewsItemsById(newsId);
            return item;
        }
    }
}