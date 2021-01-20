using BlogIdentity.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogIdentity.Common
{
    public class HitCounterAttribute:ResultFilterAttribute
    {
        private readonly ApplicationDbContext _db;

        public HitCounterAttribute(ApplicationDbContext db)
        {
            _db = db;
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {

            //var id = Convert.ToInt32(context.RouteData.Values["id"]);

            //var q = context.HttpContext.Request.QueryString;
            //var id = Convert.ToInt32(q.Value?.Split("=")[1]);

            var id = Convert.ToInt32(context.HttpContext.Items["id"]);


            var p = _db.Posts.Find(id);

            p.Hits++;

            _db.SaveChanges();

            Console.WriteLine("result filted executed!");
            base.OnResultExecuted(context);
        }
    }
}
