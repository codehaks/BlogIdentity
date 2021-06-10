using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogIdentity.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //[NotMapped]
        public ICollection<Post> Posts { get; set; }
    }
    public class Post
    {
        public int BlogId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string UserId { get; set; }
    }
}
