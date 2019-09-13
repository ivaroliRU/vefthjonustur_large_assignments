using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Services.Interfaces;
using System.Net.Http.Headers;
using TechnicalRadiation.WebApi.Attributes;

namespace TechnicalRadiation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService){
            _categoriesService = categoriesService;
        }
        
        // GET api/categories/
        [HttpGet("")]
        public ActionResult<IEnumerable<string>> GetAllCategories()
        {
            return Ok(_categoriesService.GetAllCategories());
        }
        
        // POST api/categories/
        [HttpPost("")]
        [Authorization]
        public ActionResult CreateNewCategory([FromBody] CategoryInputModel category)
        {
            if (!ModelState.IsValid) {
                return StatusCode(412, category);
            }
            var id = _categoriesService.CreateNewCategory(category);

            return CreatedAtRoute("GetCategoryById", new {id}, null);
        }

        // GET api/categories/{categoryId}
        [HttpGet("{categoryId:int}")]
        public ActionResult<IEnumerable<string>> GetCategoryById(int categoryId)
        {
            return Ok(_categoriesService.GetAllCategories());
        }

        // PUT api/categories/id
        [HttpPut("{categoryId:int}")]
        [Authorization]
        public ActionResult UpdateCategoryById([FromBody] CategoryInputModel category, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is not properly formatted");
            }
            _categoriesService.UpdateCategoryById(category, id);
            return NoContent();
        }

        // DELETE api/categories/id
        [HttpDelete("{categoryId:int}")]
        [Authorization]
        public ActionResult DeleteCategoryById(int id)
        {
            _categoriesService.DeleteCategoryById(id);
            return NoContent();
        }

        [HttpPut("/{categoryId}/newsItems/{newsItemId}")]
        [Authorization]
        public ActionResult CreateCategoryNewsConnection(int categoryId, int newsItemId)
        {
            _categoriesService.CreateCategoryNewsConnection(categoryId, newsItemId);
            return NoContent();
        }
    }
}