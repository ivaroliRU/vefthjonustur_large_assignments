using System;
using System.IO;
using System.Collections.Generic;
using TechnicalRadiation.Models.EntityModels;
using Newtonsoft.Json;

namespace TechnicalRadiation.Repositories.Data
{
    public class TechnicalRadiationDbContext : ITechnicalRadiationDbContext
    {
        public IEnumerable<NewsItem> NewsItems
        {
            get 
            {
                using (StreamReader r = new StreamReader("news.json"))
                {
                    string json = r.ReadToEnd();
                    List<NewsItem> items = JsonConvert.DeserializeObject<List<NewsItem>>(json);
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