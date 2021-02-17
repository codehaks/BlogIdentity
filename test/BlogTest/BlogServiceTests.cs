using BlogIdentity.Data;
using BlogIdentity.Models;
using BlogIdentity.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BlogTest
{
    public class BlogServiceTests
    {
        [Fact]
        public async Task BlogServiceShouldFilterByTerm()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                 .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                 .Options;

            var fakeConfig = new Mock<Microsoft.Extensions.Configuration.IConfiguration>();

            var db = new ApplicationDbContext(options, fakeConfig.Object);

            db.Blogs.Add(new Blog { Id = 1, Name = "Codehaks", TimeCreated = DateTime.Now });
            db.Blogs.Add(new Blog { Id = 2, Name = "Devs", TimeCreated = DateTime.Now.AddDays(-5) });
            db.Blogs.Add(new Blog { Id = 3, Name = "Dotnet", TimeCreated = DateTime.Now.AddDays(-3) });
            db.Blogs.Add(new Blog { Id = 4, Name = "Aspcore", TimeCreated = DateTime.Now.AddDays(-2) });
            await db.SaveChangesAsync();

            // Act

            var blogService = new BlogService(db);
            var result =await blogService.GetBlogs("De");
            var r2 = await blogService.GetBlogs(string.Empty);

            // Assert
            Assert.Equal(1, result.Count);
            Assert.Equal(4, r2.Count);



        }
        
    }
}
