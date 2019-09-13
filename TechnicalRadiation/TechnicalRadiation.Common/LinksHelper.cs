using TechnicalRadiation.Models.HyperMedia;
using TechnicalRadiation.Repositories.Interfaces;
using TechnicalRadiation.Models.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TechnicalRadiation.Common
{
    public static class LinksHelper
    {
        public static void AddNewsItemLinks(this NewsItemDto i, IAuthorsRepository _authorsRepository, ICategoriesRepository _categoriesRepository){
            i.Links.AddReference("self", $"/api/{i.Id}");
            i.Links.AddReference("edit", $"/api/{i.Id}");
            i.Links.AddReference("delete", $"/api/{i.Id}");
            i.Links.AddListReference("authors", _authorsRepository.GetAuthersOfNews(i.Id).Select(a => new { href = $"/api/authors/{a.Id}" }));
            i.Links.AddListReference("categories", _categoriesRepository.GetCategoriesOfNews(i.Id).Select(c => new { href = $"/api/categories/{c.Id}" }));
        }

        public static void AddNewsItemLinks(this NewsItemDetailDto i, IAuthorsRepository _authorsRepository, ICategoriesRepository _categoriesRepository){
            i.Links.AddReference("self", $"/api/{i.Id}");
            i.Links.AddReference("edit", $"/api/{i.Id}");
            i.Links.AddReference("delete", $"/api/{i.Id}");
            i.Links.AddListReference("authors", _authorsRepository.GetAuthersOfNews(i.Id).Select(a => new { href = $"/api/authors/{a.Id}" }));
            i.Links.AddListReference("categories", _categoriesRepository.GetCategoriesOfNews(i.Id).Select(c => new { href = $"/api/categories/{c.Id}" }));
        }

        public static void AddAuthorLinks(this AuthorDto i, INewsRepository _newsRepository){
            i.Links.AddReference("self", $"/api/authors/{i.Id}");
            i.Links.AddReference("edit", $"/api/authors/{i.Id}");
            i.Links.AddReference("delete", $"/api/authors/{i.Id}");
            i.Links.AddReference("newsItems", $"/api/authors/{i.Id}/newsItems");
            i.Links.AddListReference("newsItemsDetailed", _newsRepository.GetNewsByAuthor(i.Id).Select(a => new { href = $"/api/authors/{a.Id}" }));
        }

        public static void AddCategoryLinks(this CategoryDetailDto i){
            i.Links.AddReference("self", $"/api/categories/{i.Id}");
            i.Links.AddReference("edit", $"/api/categories/{i.Id}");
            i.Links.AddReference("delete", $"/api/categories/{i.Id}");
        }
    }
}