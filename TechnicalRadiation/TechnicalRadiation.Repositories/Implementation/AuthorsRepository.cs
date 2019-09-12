using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalRadiation.Models.DtoModels;
using TechnicalRadiation.Repositories.Data;
using TechnicalRadiation.Repositories.Interfaces;

namespace TechnicalRadiation.Repositories.Implementation
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly ITechnicalRadiationDbContext _dbContext;

        public AuthorsRepository(ITechnicalRadiationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<AuthorDto> GetAllAuthors()
        {
            var items = _dbContext.Author.ToArray().Select(c => new AuthorDto
            {
                Id = c.Id,
                Name = c.Name
                
            });

            return items;
        }
         public AuthorDto GetAuthorById(int authorId){
            var item = (from c in _dbContext.Author
                        where c.Id == authorId
                        select new AuthorDto()
                        {
                            Id = c.Id,
                            Name = c.Name
                        }).FirstOrDefault();

            return item;
        }
    }
}