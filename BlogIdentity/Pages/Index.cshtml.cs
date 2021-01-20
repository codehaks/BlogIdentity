using BlogIdentity.Data;
using BlogIdentity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogIdentity.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _db;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }
        public IList<Post> Posts { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var client = new HttpClient();
            await client.GetAsync("https://google.com");
            Posts = _db.Posts.ToList();
            return Page();
        }
    }
}
