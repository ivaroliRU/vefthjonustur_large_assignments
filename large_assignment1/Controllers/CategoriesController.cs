using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TechnicalRadiation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        // GET api/categories/
        [HttpGet("")]
        public ActionResult<IEnumerable<string>> GetAllCategories()
        {
            return new string[] { "woohoooooo! virkar aftur :D" };
        }

        // GET api/categories/{categoryId}
        [HttpGet("{categoryId:int}")]
        public ActionResult<IEnumerable<string>> GetCategoryById(int categoryId)
        {
            return new string[] { "Bittu nú, virkar bara allt?" };
        }
    }
}