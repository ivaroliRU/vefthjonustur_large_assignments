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
    public class AuthorsService : IAuthorsService
    {
        IAuthorsRepository _authorsRepository;
        INewsRepository _newsRepository;

        public AuthorsService(IAuthorsRepository authorsRepository, INewsRepository newsRepository)
        {
            _authorsRepository = authorsRepository;
            _newsRepository = newsRepository;
        }

        public IEnumerable<AuthorDto> GetAllAuthors()
        {
            var items = _authorsRepository.GetAllAuthors().ToList();

            items.ForEach(i => {
                ServiceHelper.AddAuthorLinks(i, _newsRepository);
            });

            return items;
        }

        public AuthorDto GetAuthorById(int Id)
        {
            var item = _authorsRepository.GetAuthorById(Id);

            ServiceHelper.AddAuthorLinks(item, _newsRepository);

            return item;
        }

        public int CreateAuthor(AuthorInputModel item){
            return _authorsRepository.CreateAuthor(item);
        }
        
        public int UpdateAuthorById(int newsId, AuthorInputModel item){
            return _authorsRepository.UpdateAuthorById(newsId, item);
        }
        
        public int DeleteAuthorById(int newsId){
            return _authorsRepository.DeleteAuthorById(newsId);
        }

        public void CreateAuthorNewsConnection(int authorId, int newsId){
            _newsRepository.CreateAuthorNewsConnection(authorId, newsId);
        }
    }
}