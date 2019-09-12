using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalRadiation.Repositories;
using TechnicalRadiation.Services.Interfaces;
using TechnicalRadiation.Models.DtoModels;

namespace TechnicalRadiation.Services.Implementation
{
    public class AuthorsService : IAuthorsService
    {
        public IEnumerable<AuthorDto> GetAllAuthors()
        {
            return new AuthorDto[] {};
        }
    }
}