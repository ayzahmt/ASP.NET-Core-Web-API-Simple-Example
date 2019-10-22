using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Article.API
{
    public class ArticleDetails
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public string Comment { get; set; }
        public string Commentator { get; set; }
        public DateTime CommentDate { get; set; }
    }

}
