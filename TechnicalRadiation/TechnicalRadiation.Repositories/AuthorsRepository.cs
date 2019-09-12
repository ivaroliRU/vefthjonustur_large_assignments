using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalRadiation.Models.DtoModels;

namespace TechnicalRadiation.Repositories
{
    public class AuthorsRepository
    {
        public IEnumerable<AuthorDto> GetAllAuthors()
        {
            return new AuthorDto[] {};
        }
    }
}