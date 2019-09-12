using System;
using System.IO;
using System.Collections.Generic;
using TechnicalRadiation.Models.EntityModels;

namespace TechnicalRadiation.Repositories.Data
{
    public interface ITechnicalRadiationDbContext
    {
        IEnumerable<NewsItem> NewsItems{get;}
    }
}