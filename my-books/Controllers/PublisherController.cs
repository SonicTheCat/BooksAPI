using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly PublisherService publisherService;

        public PublisherController(PublisherService publisherService)
        {
            this.publisherService = publisherService;
        }

        [HttpPost("add-new-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            this.publisherService.AddPublisher(publisher);

            return this.Ok();
        }
    }
}
