using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models;
using TechnicalRadiation.Services.Interfaces;

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

        // GET api/categories/{categoryId}
        [HttpGet("{categoryId:int}")]
        public ActionResult<IEnumerable<string>> GetCategoryById(int categoryId)
        {
            return Ok(_categoriesService.GetAllCategories());
        }
    }
}