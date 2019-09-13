using System;
using System.IO;
using System.Collections.Generic;
using TechnicalRadiation.Models.EntityModels;

namespace TechnicalRadiation.Repositories.Data
{
    public interface ITechnicalRadiationDbContext
    {
        IEnumerable<NewsItem> NewsItems{get;}
        IEnumerable<Category> Category{get;}
        IEnumerable<Author> Author{get;}
        IEnumerable<NewsItemCategories> NewsItemCategories{get;}
        IEnumerable<NewsItemAuthors> NewsItemAuthor{get;}
    }
}