using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Article.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Article.API.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        readonly ArticleContext context;
        readonly ILogger<ArticlesController> logger;
        readonly IMemoryCache memoryCache;
        string cacheKey = "articleCacheKey" + typeof(T).FullName;

        public GenericRepository(ArticleContext context, ILogger<ArticlesController> logger, IMemoryCache memoryCache)
        {
            this.context = context;
            this.logger = logger;
            this.memoryCache = memoryCache;
        }

        public IEnumerable<T> SelectAll()
        {
            logger.LogInformation("Called GET method.");

            if (!memoryCache.TryGetValue(cacheKey, out IEnumerable<T> entityList))
            {
                // If memory has not value then retrieve data from database and set cache.
                entityList = context.Set<T>().ToList();

                var cacheOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                    Priority = CacheItemPriority.Normal
                };

                memoryCache.Set(cacheKey, entityList, cacheOptions);

                logger.LogInformation("List has been retrieved from database.");
            }
            else
            {
                logger.LogInformation("List has been retrieved from cache.");
            }

            return entityList;
        }

        public T SelectById(int id)
        {
            logger.LogInformation("Called GET method (by id). Id: " + id);

            var record = context.Set<T>().Find(id);

            if (record == null)
            {
                logger.LogError("Record not found with this id: " + id);
            }

            return record;
        }

        public void Insert([FromBody] T entity)
        {
            context.Set<T>().Add(entity);

            CleanCache(cacheKey);

            logger.LogInformation("Inserted. " + JsonConvert.SerializeObject(entity));
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update([FromBody] T entity)
        {
            context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;

            CleanCache(cacheKey);

            logger.LogInformation("Updated. " + JsonConvert.SerializeObject(entity));
        }

        public void DeleteById(int id)
        {
            var willBeDeletedEntity = context.Set<T>().Find(id);
            if (willBeDeletedEntity == null)
            {
                logger.LogError("Record not found with this id: " + id);
            }

            context.Set<T>().Remove(willBeDeletedEntity);

            CleanCache(cacheKey);
            logger.LogInformation("Deleted. " + JsonConvert.SerializeObject(willBeDeletedEntity));

        }

        void CleanCache(string key)
        {
            memoryCache.Remove(cacheKey);
            logger.LogInformation("Cache cleaned. Cache Key: " + cacheKey);
        }
    }
}
