using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogIdentity.Data;
using BlogIdentity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogIdentity.Pages
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public string Title { get; set; }

        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public int Price { get; set; }

        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int id)
        {
            var post = _db.Posts.Find(id);
            Title = post.Title;
            Price = post.Price ??= 0;
            Id = post.Id;
        }

        public IActionResult OnPost()
        {
            var post = _db.Posts.Find(Id);
            post.Title = Title;
            post.Price = Price;
            _db.SaveChanges();

            return RedirectToPage("./index");
        }
    }
}
