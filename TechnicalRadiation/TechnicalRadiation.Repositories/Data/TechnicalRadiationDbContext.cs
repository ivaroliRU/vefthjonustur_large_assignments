using System;
using System.IO;
using System.Collections.Generic;
using TechnicalRadiation.Models.EntityModels;
using Newtonsoft.Json;

namespace TechnicalRadiation.Repositories.Data
{
    public class TechnicalRadiationDbContext : ITechnicalRadiationDbContext
    {
        private string dataLocation = "../TechnicalRadiation.Repositories/Data/";

        public IEnumerable<NewsItem> NewsItems
        {
            get 
            {
                using (StreamReader r = new StreamReader(dataLocation+"news.json"))
                {
                    string json = r.ReadToEnd();
                    NewsItem[] items = JsonConvert.DeserializeObject<NewsItem[]>(json);
                    return items;
                }
            }
        }
        public IEnumerable<Author> Author
        {
            get 
            {
                using (StreamReader r = new StreamReader("author.json"))
                {
                    string json = r.ReadToEnd();
                    List<Author> items = JsonConvert.DeserializeObject<List<Author>>(json);
                    return items;
                }
            }
        }
        public IEnumerable<Category> Category
        {
            get 
            {
                using (StreamReader r = new StreamReader("category.json"))
                {
                    string json = r.ReadToEnd();
                    List<Category> items = JsonConvert.DeserializeObject<List<Category>>(json);
                    return items;
                }
            }
        }

    }
}