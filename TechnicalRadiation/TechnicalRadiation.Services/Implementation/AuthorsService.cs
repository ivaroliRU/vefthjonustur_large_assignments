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
                LinksHelper.AddAuthorLinks(i);
            });

            return items;
        }

        public AuthorDto GetAuthorById(int Id)
        {
            var item = _authorsRepository.GetAuthorById(Id);

            LinksHelper.AddAuthorLinks(item);

            return item;
        }

        public int CreateAuthor(AuthorInputModel item){
            int id = _dbContext.Authors.OrderByDescending(x => x.Id).First().Id++;

            return id;
        }
        
        public int UpdateAuthorById(int newsId, AuthorInputModel item){
            return 0;
        }
        
        public int DeleteAuthorById(int newsId){
            return 0;
        }
    }
}