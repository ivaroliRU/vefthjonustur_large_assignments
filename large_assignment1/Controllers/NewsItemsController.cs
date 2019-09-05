using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TechnicalRadiation.Controllers
{
    [Route("api/")]
    [ApiController]
    public class NewsItemsController : ControllerBase
    {
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