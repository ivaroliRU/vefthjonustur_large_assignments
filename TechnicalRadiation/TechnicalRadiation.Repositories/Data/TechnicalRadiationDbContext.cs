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
                using (StreamReader r = new StreamReader("data.json"))
                {
                    string json = r.ReadToEnd();
                    List<NewsItem> items = JsonConvert.DeserializeObject<List<NewsItem>>(json);
                    return items;
                }
            }
        }

    }
}