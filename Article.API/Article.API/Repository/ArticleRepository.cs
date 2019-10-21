using Article.API.Controllers;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Article.API.Repository
{
    public class ArticleRepository : GenericRepository<Article>, IArticleRepository
    {
        public ArticleRepository(ArticleContext context, ILogger<ArticlesController> logger, IMemoryCache memoryCache) : base(context, logger, memoryCache)
        {

        }
    }
}
