using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalRadiation.Models;
using TechnicalRadiation.Models.DtoModels;
using TechnicalRadiation.Models.InputModels;

namespace TechnicalRadiation.Services.Interfaces
{
    public interface IAuthorsService
    {
        IEnumerable<AuthorDto> GetAllAuthors();
        AuthorDetailDto GetAuthorById(int id);
        int CreateAuthor(AuthorInputModel item);
        int UpdateAuthorById(int newsId, AuthorInputModel item);
        int DeleteAuthorById(int newsId);
        void CreateAuthorNewsConnection(int authorId, int newsId);
    }
}