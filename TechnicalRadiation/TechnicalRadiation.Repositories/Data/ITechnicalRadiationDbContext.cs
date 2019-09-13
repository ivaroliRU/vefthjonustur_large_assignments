using System;
using System.IO;
using System.Collections.Generic;
using TechnicalRadiation.Models.EntityModels;

namespace TechnicalRadiation.Repositories.Data
{
    public interface ITechnicalRadiationDbContext
    {
        List<NewsItem> NewsItems{get;}
        List<Category> Category{get;}
        List<Author> Author{get;}
        List<NewsItemCategories> NewsItemCategories{get;}
        List<NewsItemAuthors> NewsItemAuthor{get;}
    }
}