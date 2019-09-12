using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalRadiation.Models;

namespace TechnicalRadiation.Common
{
    public static class EnvelopeHelper<T> where T : class
    {
        public static Envelope<T> ListToEnvelope(IEnumerable<T> items, int pageNumber){
            Console.WriteLine(items.Count());
            if(items.Count() > 0){
                return new Envelope<T>(pageNumber, items.Count(), items);
            }
            else{
                Console.WriteLine("Typpi");
                return null;
            }
        }
    }
}