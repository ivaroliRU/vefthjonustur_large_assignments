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
            DataHelper.DataToList(out newItemAuthorsList, dataLocation+"news_author.json");
            DataHelper.DataToList(out NewsItemCategoriesList, dataLocation+"news_category.json");
            DataHelper.DataToList(out NewsItemsList, dataLocation+"news.json");
            DataHelper.DataToList(out AuthorList, dataLocation+"author.json");
            DataHelper.DataToList(out CategoryList, dataLocation+"category.json");
        }

        public List<NewsItemAuthors> NewsItemAuthor
        {
            get 
            {
                return newItemAuthorsList;
            }
        }

        public List<NewsItemCategories> NewsItemCategories
        {
            get 
            {
                return NewsItemCategoriesList;
            }
        }

        public List<NewsItem> NewsItems
        {
            get 
            {
                return NewsItemsList;
            }
        }

        public List<Author> Author
        {
            get 
            {
                return AuthorList;
            }
        }
        public List<Category> Category
        {
            get 
            {
                return CategoryList;
            }
        }

    }
}