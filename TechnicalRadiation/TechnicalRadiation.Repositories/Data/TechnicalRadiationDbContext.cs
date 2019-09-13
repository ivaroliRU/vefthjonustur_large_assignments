using System;
using System.IO;
using System.Collections.Generic;
using TechnicalRadiation.Models.EntityModels;
using TechnicalRadiation.Common;
using Newtonsoft.Json;

namespace TechnicalRadiation.Repositories.Data
{
    public class TechnicalRadiationDbContext : ITechnicalRadiationDbContext
    {
        private string dataLocation = "../TechnicalRadiation.Repositories/Data/";

        public static List<NewsItemAuthors> newItemAuthorsList;
        public static List<NewsItemCategories> NewsItemCategoriesList;
        public static List<NewsItem> NewsItemsList;
        public static List<Author> AuthorList;
        public static List<Category> CategoryList;

        public TechnicalRadiationDbContext()
        {
            DataHelper.DataToList(newItemAuthorsList, dataLocation+"news_author.json");
            DataHelper.DataToList(NewsItemCategoriesList, dataLocation+"news_category.json");
            DataHelper.DataToList(NewsItemsList, dataLocation+"news.json");
            DataHelper.DataToList(AuthorList, dataLocation+"author.json");
            DataHelper.DataToList(CategoryList, dataLocation+"category.json");
        }

        public IEnumerable<NewsItemAuthors> NewsItemAuthor
        {
            get 
            {
                return newItemAuthorsList;
            }
        }

        public IEnumerable<NewsItemCategories> NewsItemCategories
        {
            get 
            {
                return NewsItemCategoriesList;
            }
        }

        public IEnumerable<NewsItem> NewsItems
        {
            get 
            {
                return NewsItemsList;
            }
        }

        public IEnumerable<Author> Author
        {
            get 
            {
                return AuthorList;
            }
        }
        public IEnumerable<Category> Category
        {
            get 
            {
                return CategoryList;
            }
        }

    }
}