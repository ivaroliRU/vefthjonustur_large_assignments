using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace TechnicalRadiation.Common
{
    public static class DataHelper
    {
        public static void DataToList<T>(this IEnumerable<T> d, string dataLocation)
        {
            using (StreamReader r = new StreamReader(dataLocation))
            {
                string json = r.ReadToEnd();
                d = JsonConvert.DeserializeObject<T[]>(json);
            }
        }
    }
}