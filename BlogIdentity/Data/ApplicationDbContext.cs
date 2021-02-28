using BlogIdentity.Common;
using BlogIdentity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogIdentity.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
    
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Post>();
            builder.Entity<Blog>().HasData(new Blog { Id = 1, Name = "Codehaks", TimeCreated = DateTime.Now });
            builder.Entity<Blog>().HasData(new Blog { Id = 2, Name = "Devs", TimeCreated = DateTime.Now.AddDays(-5) });
            builder.Entity<Blog>().HasData(new Blog { Id = 3, Name = "Dotnet", TimeCreated = DateTime.Now.AddDays(-3) });
            builder.Entity<Blog>().HasData(new Blog { Id = 4, Name = "Aspcore", TimeCreated = DateTime.Now.AddDays(-2) });
            base.OnModelCreating(builder);
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
