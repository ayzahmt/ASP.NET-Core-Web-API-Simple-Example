using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Article.API.Controllers;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Article.API.Repository
{
    public class DetailsRepository : GenericRepository<ArticleDetails>, IDetailsRepository
    {
        public DetailsRepository(ArticleContext context, ILogger<ArticlesController> logger, IMemoryCache memoryCache) : base(context, logger, memoryCache)
        {
        }
    }
}
