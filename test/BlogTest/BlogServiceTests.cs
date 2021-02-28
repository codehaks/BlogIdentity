using BlogIdentity.Data;
using BlogIdentity.Models;
using BlogIdentity.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BlogTest
{
    public abstract class TestWithSqlite : IDisposable
    {
        private const string InMemoryConnectionString = "DataSource=:memory:";
        private readonly SqliteConnection _connection;

        protected readonly ApplicationDbContext DbContext;

        protected TestWithSqlite()
        {
            _connection = new SqliteConnection(InMemoryConnectionString);
            _connection.Open();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlite(_connection)
                    .Options;
            DbContext = new ApplicationDbContext(options);
            DbContext.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }

    public class ToDoDbContextTests : TestWithSqlite
    {
        [Fact]
        public async Task DatabaseIsAvailableAndCanBeConnectedTo()
        {
            Assert.True(await DbContext.Database.CanConnectAsync());
        }
    }

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

            var db = new ApplicationDbContext(options);

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

        [Fact]
        public async Task BlogServiceShouldFilterByTermWithSqlite()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                 .UseSqlite("Filename=:memory:")
                 .Options;



            var db = new ApplicationDbContext(options);
       
            await db.Database.MigrateAsync();
            db.Database.EnsureCreated();

            db.Blogs.Add(new Blog { Id = 1, Name = "Codehaks", TimeCreated = DateTime.Now });
            db.Blogs.Add(new Blog { Id = 2, Name = "Devs", TimeCreated = DateTime.Now.AddDays(-5) });
            db.Blogs.Add(new Blog { Id = 3, Name = "Dotnet", TimeCreated = DateTime.Now.AddDays(-3) });
            db.Blogs.Add(new Blog { Id = 4, Name = "Aspcore", TimeCreated = DateTime.Now.AddDays(-2) });
            await db.SaveChangesAsync();

            // Act

            var blogService = new BlogService(db);
            var result = await blogService.GetBlogs("De");
            var r2 = await blogService.GetBlogs(string.Empty);

            // Assert
            Assert.Equal(1, result.Count);
            Assert.Equal(4, r2.Count);



        }

    }
}
