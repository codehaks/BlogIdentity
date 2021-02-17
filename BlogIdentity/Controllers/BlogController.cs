using BlogIdentity.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogIdentity.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogService _blogService;

        public BlogController(BlogService blogService)
        {
            _blogService = blogService;
        }

        [Route("api/blog/{term?}")]
        public async Task<IActionResult> Get(string term)
        {
            var result = await _blogService.GetBlogs(term);
            return Ok(result);
        }
    }
}
