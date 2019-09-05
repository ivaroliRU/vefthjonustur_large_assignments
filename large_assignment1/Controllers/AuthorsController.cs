using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TechnicalRadiation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        // GET api/authors/
        [HttpGet("")]
        public ActionResult<IEnumerable<string>> GetAllAuthors()
        {
            return new string[] { "..." };
        }

        // GET api/authors/{authorId}
        [HttpGet("{authorId:int}")]
        public ActionResult<IEnumerable<string>> GetAuthorById(int authorId)
        {
            return new string[] { "Duddi" };
        }

        // GET api/authors/{}/newsItems
        [HttpGet("{authorId:int}/newsItems")]
        public ActionResult<IEnumerable<string>> GetNewsByAuthorById(int authorId)
        {
            return new string[] { "Frettir" };
        }
    }
}