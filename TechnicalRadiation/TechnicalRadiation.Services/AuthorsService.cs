using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalRadiation.Repositories;

namespace TechnicalRadiation.Services
{
    public class AuthorsService
    {
        public IEnumerable<string> GetAllAuthors()
        {
            return new string[] { "..." };
        }
    }
}