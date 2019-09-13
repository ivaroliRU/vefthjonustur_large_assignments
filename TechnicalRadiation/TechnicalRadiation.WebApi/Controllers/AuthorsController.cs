using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models.DtoModels;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Services.Interfaces;
using TechnicalRadiation.WebApi.Attributes;

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

        // POST api/authors/
        [HttpPost("")]
        [Authorization]
        public IActionResult CreateNewAuthor([FromBody] AuthorInputModel author)
        {
            if (!ModelState.IsValid) { return StatusCode(412, author); }

            var id = _authorsService.CreateAuthor(author);

            return Ok();//CreatedAtRoute("GetNewsItemsById", new { id }, null);
        }

        // PUT api/authors/id
        [HttpPut("{authorId:int}")]
        [Authorization]
        public ActionResult UpdateAuthorById([FromBody] AuthorInputModel category, int authorId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is not properly formatted");
            }
            _authorsService.UpdateAuthorById(authorId, category);
            return NoContent();
        }

        // DELETE api/authors/id
        [HttpDelete("{authorId:int}")]
        [Authorization]
        public ActionResult DeleteAuthorById(int authorId)
        {
            _authorsService.DeleteAuthorById(authorId);
            return NoContent();
        }
    }
}