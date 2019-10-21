using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Article.API.Models
{
    public class ArticleContext : DbContext
    {
        public DbSet<Article> Article { get; set; }

        public ArticleContext(DbContextOptions<ArticleContext> options) : base(options)
        {

        }
    }
}
