using System;
using System.Collections.Generic;

namespace MyBlog.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Body { get; set; }
        public string Url { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}