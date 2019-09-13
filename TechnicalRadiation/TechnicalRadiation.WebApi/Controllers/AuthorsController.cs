using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models.DtoModels;
using TechnicalRadiation.Services.Interfaces;

namespace TechnicalRadiation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsService _authorsService;
        private readonly INewsService _newsService;

        public AuthorsController(IAuthorsService authorsService, INewsService newsService)
        {
            _authorsService = authorsService;
            _newsService = newsService;
        }

        // GET api/authors/
        [HttpGet("")]
        public ActionResult<IEnumerable<NewsItemDto>> GetAllAuthors()
        {
            return Ok(_authorsService.GetAllAuthors());
        }

        // GET api/authors/{authorId}
        [HttpGet("{authorId:int}")]
        public ActionResult<IEnumerable<string>> GetAuthorById(int authorId)
        {
            return Ok(_authorsService.GetAuthorById(authorId));
        }

        // GET api/authors/{authorId}/newsItems
        [HttpGet("{authorId:int}/newsItems")]
        public ActionResult<IEnumerable<string>> GetNewsByAuthorById(int authorId)
        {
            return Ok(_newsService.GetNewsByAuthor(authorId));
        }
    }
}