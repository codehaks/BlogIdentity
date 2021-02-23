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
        public IConfiguration Configuration { get; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
            : base(options)
        {

            Configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Post>()
            //    .Property(p => p.Title)
            //    .IsConcurrencyToken()
            //    .ValueGeneratedOnUpdate();

            //builder.Entity<Post>()
            //   .Property(p => p.Price)
            //   .IsConcurrencyToken()
            //   .ValueGeneratedOnUpdate();


            base.OnModelCreating(builder);
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
