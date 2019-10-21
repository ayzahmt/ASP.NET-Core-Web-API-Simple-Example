using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Article.API.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Subject { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
