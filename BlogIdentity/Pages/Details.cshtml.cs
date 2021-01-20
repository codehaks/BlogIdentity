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
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public DetailsModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public Post Post { get; set; }

        public void OnGet(int id)
        {
            Post = _db.Posts.Find(id);
        }
    }
}
