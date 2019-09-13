using System;
using System.Collections.Generic;
using System.Linq;
using TechnicalRadiation.Models.EntityModels;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Models.DtoModels;

namespace TechnicalRadiation.Repositories.Interfaces
{
    public interface IAuthorsRepository
    {
        IEnumerable<AuthorDto> GetAllAuthors();
        AuthorDto GetAuthorById(int authorId);
        IEnumerable<AuthorDto> GetAuthersOfNews(int newsId);
        int CreateAuthor(AuthorInputModel author);
        int UpdateAuthorById(int authorId, AuthorInputModel author);
        int DeleteAuthorById(int authorId);
    }
}