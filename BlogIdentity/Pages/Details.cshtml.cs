using BlogIdentity.Data;
using BlogIdentity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace BlogIdentity.Pages
{
    public class HitCounterAttribute : ResultFilterAttribute
    {
        private readonly ApplicationDbContext _db;

        public HitCounterAttribute(ApplicationDbContext db)
        {
            _db = db;
        }

        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
 
            await next();
            // -- After
            
            var id = int.Parse(context.HttpContext.Items["id"].ToString());

            var post=await _db.Posts.FindAsync(id);

            post.Hits++;
            await _db.SaveChangesAsync();

        }
    }

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
