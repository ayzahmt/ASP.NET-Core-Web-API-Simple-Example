using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Article.API.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Article.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        readonly IArticleRepository repository;

        public ArticlesController(IArticleRepository repository)
        {
            this.repository = repository;
        }

        // GET api/articles
        [HttpGet]
        public IEnumerable<Article> Get()
        {
            return repository.SelectAll();
        }

        // GET api/articles/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = repository.SelectById(id);
            return Ok(result);
        }

        // POST api/articles
        [HttpPost]
        public ActionResult Post([FromBody] Article article)
        {
            repository.Insert(article);
            repository.Save();

            return Ok();
        }

        // PUT api/articles/5
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Article article)
        {
            repository.Update(article);
            repository.Save();

            return Ok();
        }

        // DELETE api/articles/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            repository.DeleteById(id);
            repository.Save();

            return Ok();
        }
    }
}
