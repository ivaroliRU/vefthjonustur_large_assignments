using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models;
using TechnicalRadiation.Models.DtoModels;
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
        public ActionResult<Envelope<NewsItemDto>> GetAllNewsItems([FromQuery] int pageSize = 25, [FromQuery] int pageNumber = 1)
        {
            return _newsService.GetAllNewsItems(pageSize, pageNumber);
        }

        // GET api/{newsItemId}
        [HttpGet("{newsItemId:int}")]
        public ActionResult<NewsItemDto> GetNewsItemsById(int newsItemId)
        {
            return _newsService.GetNewsItemsById(newsItemId);
        }
    }
}