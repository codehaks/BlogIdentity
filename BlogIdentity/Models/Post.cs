using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogIdentity.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime TimeCreated { get; set; }
        public IdentityUser User { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
    public class Post
    {
        public int Id { get; set; }

        [ConcurrencyCheck]
        public string Title { get; set; }

        [ConcurrencyCheck]
        public int? Price { get; set; }

        public string UserId { get; set; }
        //public IdentityUser User { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public int CommentCount { get; set; }

        //[Timestamp]
        //public byte[] Timestamp { get; set; }
    }

    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string UserId { get; set; }
        public string Body { get; set; }
        public IdentityUser User { get; set; }
    }
}
