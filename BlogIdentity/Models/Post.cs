using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogIdentity.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UserId { get; set; }

        private string _url;

        [BackingField(nameof(_url))]
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        [NotMapped]
        public string ShortLink { get { return "https://" + _url; } }


    }
}
