using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Models.DtoModels;
using TechnicalRadiation.Models.EntityModels;
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

        public AuthorDetailDto GetAuthorById(int authorId){
            var item = (from c in _dbContext.Author
                        where c.Id == authorId
                        select new AuthorDetailDto()
                        {
                            Id = c.Id,
                            Name = c.Name,
                            Bio = c.Bio,
                            ProfileImgSource = c.ProfileImgSource
                        }).FirstOrDefault();

            return item;
        }

        public IEnumerable<AuthorDto> GetAuthersOfNews(int newsId){
            var item = (from c in _dbContext.Author
                        join n in _dbContext.NewsItemAuthor on c.Id equals n.AuthorId
                        where n.NewsItemId == newsId
                        select new AuthorDto()
                        {
                            Id = c.Id,
                            Name = c.Name
                        }).ToList();

            return item;
        }

        public int CreateAuthor(AuthorInputModel author){
            int id = _dbContext.Author.OrderByDescending(x => x.Id).First().Id++;

            _dbContext.Author.Add(new Author(){
                Name = author.Name,
                ProfileImgSource = author.ProfileImgSource,
                Bio = author.Bio,
                CreatedDate = DateTime.Now
            });

            return id;
        }

        public int UpdateAuthorById(int authorId, AuthorInputModel author){
            var item = _dbContext.Author.FirstOrDefault(x => x.Id == authorId);
            if (item != null) 
            {
                item.Name = author.Name;
                item.ProfileImgSource = author.ProfileImgSource;
                item.Bio = author.Bio;
                item.ModifiedDate = DateTime.Now;
            }

            return authorId;
        }

        public int DeleteAuthorById(int authorId){
            var i = _dbContext.Author.Where(item => item.Id == authorId).Single();
            _dbContext.Author.Remove(i);
            return authorId;
        }
    }
}