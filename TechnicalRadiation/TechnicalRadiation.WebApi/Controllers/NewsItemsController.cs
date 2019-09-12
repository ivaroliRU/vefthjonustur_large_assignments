using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models;
using TechnicalRadiation.Services.Interfaces;

namespace TechnicalRadiation.Controllers
{
    [Route("api/")]
    [ApiController]
    public class NewsItemsController : ControllerBase
    {
        private readonly INewsService _newsService;

        public NewsItemsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        // GET api/
        [HttpGet("")]
        public ActionResult<IEnumerable<string>> GetAllNewsItems()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/{newsItemId}
        [HttpGet("{newsItemId:int}")]
        public ActionResult<IEnumerable<string>> GetNewsItemsById(int newsId)
        {
            return new string[] { "Virkarr wooohoooo" };
        }
    }
}