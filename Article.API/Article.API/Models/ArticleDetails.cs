using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Article.API
{
    public class ArticleDetails
    {
        public int Id { get; set; }
        [Required]
        public int ArticleId { get; set; }
        [Required]
        [MaxLength(500)]
        public string Comment { get; set; }
        [Required]
        [MaxLength(50)]
        public string Commentator { get; set; }
        [Required]
        public DateTime CommentDate { get; set; }
    }

}
