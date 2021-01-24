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

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IGetUserClaims claims)
            : base(options)
        {
            options.
            _claims = claims;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Post>()
                .HasQueryFilter(p => p.UserId == _claims.UserId);

            base.OnModelCreating(builder);
        }

        public DbSet<Post> Posts { get; set; }
    }
}
