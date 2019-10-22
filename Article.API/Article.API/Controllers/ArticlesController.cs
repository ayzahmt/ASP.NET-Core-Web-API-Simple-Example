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
        readonly IDetailsRepository detailsRepository;

        public ArticlesController(IArticleRepository repository, IDetailsRepository detailsRepository)
        {
            this.repository = repository;
            this.detailsRepository = detailsRepository;
        }

        #region Article Methods
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
            var record = repository.SelectById(article.Id);
            if (record == null)
            {
                return BadRequest("Not valid article id. Id:" + article.Id);
            }

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
        #endregion

        #region Details methods
        [HttpGet("details")]
        public IEnumerable<ArticleDetails> GetDetails()
        {
            return detailsRepository.SelectAll();
        }

        [HttpGet("details/{id}")]
        public ActionResult GetDetailsByArticleId(int id)
        {
            var result = detailsRepository.SelectById(id);
            return Ok(result);
        }


        [HttpPut("details/{id}")]
        public ActionResult UpdateDetails([FromBody] ArticleDetails articleDetails)
        {
            var article = detailsRepository.SelectById(articleDetails.ArticleId);
            if (article == null)
            {
                return BadRequest("Not valid article id. Id:" + articleDetails.ArticleId);
            }

            detailsRepository.Update(articleDetails);
            detailsRepository.Save();

            return Ok();
        }

        [HttpPost("details/add")]
        public ActionResult AddComment([FromBody] ArticleDetails articleDetails)
        {
            detailsRepository.Insert(articleDetails);
            detailsRepository.Save();

            return Ok();
        }

        [HttpDelete("details/{id}")]
        public ActionResult DeleteComment(int id)
        {
            detailsRepository.DeleteById(id);
            detailsRepository.Save();

            return Ok();
        }
        #endregion
    }
}
