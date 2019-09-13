using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models;
using TechnicalRadiation.Models.DtoModels;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Services.Interfaces;
using System.Net.Http.Headers;
using TechnicalRadiation.WebApi.Attributes;

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
            return Ok(_newsService.GetAllNewsItems(pageSize, pageNumber));
        }

        // GET api/{newsItemId}
        [HttpGet]
        [Route("{newsItemId:int}", Name = "GetNewsItemsById")]
        public ActionResult<NewsItemDto> GetNewsItemsById(int newsItemId)
        {
            return Ok(_newsService.GetNewsItemsById(newsItemId));
        }

        // POST api/
        [HttpPost("")]
        [Authorization]
        public IActionResult CreateNewsItem([FromBody] NewsItemInputModel news)
        {
            if (!ModelState.IsValid) { return StatusCode(412, news); }

            var id = _newsService.CreateNewsItem(news);

            return Ok();//CreatedAtRoute("GetNewsItemsById", new { id }, null);
        }

        // PUT api/{newsItemId}
        [HttpPut("{newsItemId:int}")]
        [Authorization]
        public ActionResult UpdateNewsItemById([FromBody] NewsItemInputModel news, int newsItemId)
        {
            if (!ModelState.IsValid) { return StatusCode(412, news); }

            var id = _newsService.UpdateNewsItemById(newsItemId, news);

            return Ok();
        }

        // PUT api/{newsItemId}
        [HttpDelete("{newsItemId:int}")]
        [Authorization]
        public ActionResult DeleteNewsItemById(int newsItemId)
        {
            var id = _newsService.DeleteNewsItemById(newsItemId);

            return Ok();
        }
    }
}