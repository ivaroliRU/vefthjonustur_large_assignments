using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalRadiation.Models;

namespace TechnicalRadiation.Common
{
    public static class PageHelper
    {
        public static IEnumerable<IEnumerable<T>> SplitIntoPages<T>(this IEnumerable<T> source, int chunksize)
        {
            while (source.Any())
            {
                yield return source.Take(chunksize);
                source = source.Skip(chunksize);
            }
        }
    }
}