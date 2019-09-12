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
                i.Links.AddReference("self", $"/api/authors/{i.Id}");
                i.Links.AddReference("edit", $"/api/authors/{i.Id}");
                i.Links.AddReference("delete", $"/api/authors/{i.Id}");
                i.Links.AddReference("newsItems", $"/api/authors/{i.Id}/newsItems");
                i.Links.AddListReference("newsItemsDetailed", _newsRepository.GetNewsByAuthor(i.Id).Select(a => new { href = $"/api/authors/{a.Id}" }));
                //i.Links.AddListReference("categories", _categoriesRepository.GetCategoriesById(i.Id).Select(c => new { href = $"/api/categories/{c.Id}" }));
            });

            return items;
        }

        public IEnumerable<AuthorDto> GetAuthorById(int Id)
        {
            return new AuthorDto[] {};
        }
    }
}