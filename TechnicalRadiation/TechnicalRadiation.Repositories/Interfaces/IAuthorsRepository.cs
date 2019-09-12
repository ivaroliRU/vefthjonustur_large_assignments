using System;
using System.Collections.Generic;
using System.Linq;
using TechnicalRadiation.Models.EntityModels;
using TechnicalRadiation.Models.DtoModels;

namespace TechnicalRadiation.Repositories.Interfaces
{
    public interface IAuthorsRepository
    {
        IEnumerable<AuthorDto> GetAllAuthors();
        AuthorDto GetAuthorById(int authorId);
    }
}