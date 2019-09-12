using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalRadiation.Models.DtoModels;

namespace TechnicalRadiation.Services.Interfaces
{
    public interface IAuthorsService
    {
        IEnumerable<AuthorDto> GetAllAuthors();
        IEnumerable<AuthorDto> GetAllAuthorsById(int id);
    }
}