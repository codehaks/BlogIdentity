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
    public class CreateModel : PageModel
    {
        public Post Post { get; set; }
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnPost()
        {
            Post.UserId = User.GetUserId();

            _db.Posts.Add(Post);

            _db.SaveChanges();
        }
    }
}
