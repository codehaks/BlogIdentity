using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogIdentity.Common;
using BlogIdentity.Data;
using BlogIdentity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogIdentity.Pages
{
    [TypeFilter(typeof(HitCounterAttribute))]
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
            HttpContext.Items.Add("id", id);
            Post = _db.Posts.Find(id);
        }
    }
}
