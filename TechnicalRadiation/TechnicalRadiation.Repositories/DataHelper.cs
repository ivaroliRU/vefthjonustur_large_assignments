using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace TechnicalRadiation.Common
{
    public static class DataHelper
    {
        public static void DataToList<T>(out List<T> d, string dataLocation)
        {
            using (StreamReader r = new StreamReader(dataLocation))
            {
                string json = r.ReadToEnd();
                Console.WriteLine(json);
                d = JsonConvert.DeserializeObject<List<T>>(json);
            }
        }

        public static int GetHighestId<T>(){
            return 0;
        }
    }
}