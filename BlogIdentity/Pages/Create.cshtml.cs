using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogIdentity.Data;
using BlogIdentity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogIdentity.Pages
{
    [Authorize]
    public class CreateModel : PageModel
    {
        [BindProperty]
        public string Title { get; set; }

        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult OnPost()
        {


            var  post = new Post
            {
                UserId = User.GetUserId(),
                Title = Title,
                Price=5
            };
            _db.Posts.Add(post);
            _db.SaveChanges();

            post.Price = 100;
            post.Title = "New!";
            var count=_db.SaveChanges();

            return RedirectToPage("./index");
        }
    }
}
