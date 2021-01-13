using BlogIdentity.Common;
using BlogIdentity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogIdentity.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private readonly IGetUserClaims _claims;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,IGetUserClaims claims)
            : base(options)
        {
            //CurrentUserId = claims.UserId;
            _claims = claims;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Post>().HasQueryFilter(p => p.UserId == _claims.UserId);
            base.OnModelCreating(builder);

        }

        //private readonly string CurrentUserId;

        public DbSet<Post> Posts { get; set; }
    }
}
