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
        private readonly IGetUserClaims _claims;
        public IConfiguration Configuration { get; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration, IGetUserClaims claims)
            : base(options)
        {
            _claims = claims;
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var continent = _claims.Continent;

            if (continent is null)
            {
                continent = "DefaultConnection";
            }
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString(continent));
            base.OnConfiguring(optionsBuilder);
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
