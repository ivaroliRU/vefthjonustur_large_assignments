using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalRadiation.Models.DtoModels;
using TechnicalRadiation.Repositories.Interfaces;

namespace TechnicalRadiation.Repositories.Implementation
{
    public class AuthorsRepository : IAuthorsRepository
    {
        public IEnumerable<AuthorDto> GetAllAuthors()
        {
            return new AuthorDto[] {};
        }
    }
}