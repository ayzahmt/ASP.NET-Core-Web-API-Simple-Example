using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Article.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        readonly ArticleContext context;
        readonly ILogger<ArticlesController> logger;

        public ArticlesController(ArticleContext context, ILogger<ArticlesController> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        // GET api/articles
        [HttpGet]
        public IEnumerable<Article> Get()
        {
            logger.LogInformation("Called GET method.");
            return context.Article.ToList();
        }

        // GET api/articles/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var article = context.Article.FirstOrDefault(x => x.Id == id);
            if (article == null)
            {
                logger.LogError("Article not found with this id: " + id);
                return NotFound();
            }
            logger.LogInformation("Called GET method (by id). Id: " + id);

            return new ObjectResult(article);
        }

        // POST api/articles
        [HttpPost]
        public ActionResult Post([FromBody] Article article)
        {
            context.Article.Add(article);
            context.SaveChanges();

            logger.LogInformation("Inserted. " + JsonConvert.SerializeObject(article));

            return Ok();
        }

        // PUT api/articles/5
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Article article)
        {
            var existingArticle = context.Article.FirstOrDefault(x => x.Id == article.Id);
            if (existingArticle == null)
            {
                return NotFound();
            }

            existingArticle.Name = article.Name;
            existingArticle.Subject = article.Subject;
            existingArticle.Author = article.Author;
            existingArticle.PublishDate = article.PublishDate;

            context.SaveChanges();

            logger.LogInformation("Updated. " + JsonConvert.SerializeObject(article));

            return Ok();
        }

        // DELETE api/articles/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var willBeDeletedArticle = context.Article.FirstOrDefault(x => x.Id == id);
            if (willBeDeletedArticle == null)
            {
                logger.LogError("Article not found with this id: " + id);
                return BadRequest("Not valid a article. Article Id: " + id);
            }

            context.Article.Remove(willBeDeletedArticle);
            context.SaveChanges();

            logger.LogInformation("Deleted. " + JsonConvert.SerializeObject(willBeDeletedArticle));

            return Ok();
        }
    }
}
