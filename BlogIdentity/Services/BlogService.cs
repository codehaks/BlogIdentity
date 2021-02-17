using BlogIdentity.Data;
using BlogIdentity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogIdentity.Services
{
    public class BlogService
    {
        private readonly ApplicationDbContext _db;

        public BlogService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IList<Blog>> GetBlogs(string term)
        {
            if (string.IsNullOrEmpty(term))
            {
                return await _db.Blogs.ToListAsync();
            }

            return await _db.Blogs.Where(b => b.Name.StartsWith(term)).ToListAsync();
        }
    }
}
