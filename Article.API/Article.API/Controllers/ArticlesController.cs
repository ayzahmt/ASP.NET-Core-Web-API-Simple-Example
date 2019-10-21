using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Article.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        readonly ArticleContext context;

        public ArticlesController(ArticleContext context)
        {
            this.context = context;
        }

        // GET api/articles
        [HttpGet]
        public IEnumerable<Article> Get()
        {
            return context.Article.ToList();
        }

        // GET api/articles/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var article = context.Article.FirstOrDefault(x => x.Id == id);
            if (article == null)
            {
                return NotFound();
            }

            return new ObjectResult(article);
        }

        // POST api/articles
        [HttpPost]
        public ActionResult Post([FromBody] Article article)
        {
            context.Article.Add(article);
            context.SaveChanges();

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

            return Ok();
        }

        // DELETE api/articles/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var willBeDeletedArticle = context.Article.FirstOrDefault(x => x.Id == id);
            if (willBeDeletedArticle == null)
            {
                return BadRequest("Not valid a article. Article Id: " + id);
            }

            context.Article.Remove(willBeDeletedArticle);
            context.SaveChanges();

            return Ok();
        }
    }
}
