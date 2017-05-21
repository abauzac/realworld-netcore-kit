using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sandbox.Server.DomainObjects.Interfaces.Handlers;
using Sandbox.Server.DomainObjects.Interfaces.Handlers.Abstract;
using Sandbox.Server.DomainObjects.Models;
using Sandbox.Server.Http.WebApi.V1.Controllers.Abstract;
using Sandbox.Server.Http.WebApi.V1.Views.ArticleViews;
using System.Linq;
using Sandbox.Server.DomainObjects.Interfaces.Repositories;
using System;

namespace Sandbox.Server.Http.WebApi.V1.Controllers
{

    [Route("api")]
    public class ArticleController : EntityController<Article, IEntityHandler<Article>>
    {
        private IArticleRepository _repository;

        public ArticleController(IArticleHandler handler, IArticleRepository repository) : base(handler)
        {
            this._repository = repository;
        }


        [HttpPost]
        [Route("articles")]
        public async Task<JsonResult> Create([FromBody] RootArticleView request)
        {
            Article entity = new Article();
            request.Article.Hydrate(entity);

            var created = await _handler.Create(entity);

            Response.StatusCode = 201;

            // anon type to have "article" root object name (API contract)
            return Json(new RootArticleView() { Article = new ArticleView(created) } );
        }


        [Route("articles/feed")]
        [HttpGet]
        public async Task<ArticlesView> Feed()
        {
            
            var list = await _handler.RetrieveAll();
            var articles = new ArticlesView();
            // map domain objects to view objects
            articles.Articles = list.Select(x => new ArticleView(x)).ToList();
            articles.ArticlesCount = list.Count();
            return articles;
        }

        [HttpGet]
        [Route("articles")]
        public async Task<ArticlesView> GetBy([FromQuery]string author = "", [FromQuery]string favorited = "", [FromQuery]string tag = "" )
        {
            IEnumerable<Article> articles = null;
            ArticlesView articlesView = new ArticlesView();

            if(!string.IsNullOrEmpty(author))
            {
                throw new NotImplementedException();
                articles = await this._repository.RetrieveByAuthor(author);
            }
            else if(!string.IsNullOrEmpty(favorited))
            {
                throw new NotImplementedException();
               // articles = await this._repository.RetrieveByFavorited(favorited);
            }
            else if(!string.IsNullOrEmpty(tag))
            {
                articles = await this._repository.RetrieveByTag(tag);
            }

            articlesView.Articles = articles.Select(x => new ArticleView(x)).ToList();
            articlesView.ArticlesCount = articles.Count();

            return articlesView;
        }

        [Route("articles/{slug}")]
        [HttpGet]
        public async Task<RootArticleView> Get(string slug )
        {
            var model = await _repository.RetrieveSingleBySlug(slug);
            return new RootArticleView() { Article = new ArticleView(model) };
        }

        [Route("articles/{slug}")]
        [HttpPut]
        public async Task<RootArticleView> Update([FromRoute]string slug, [FromBody]RootArticleView articleVm )
        {

            Article entity = new Article();
            articleVm.Article.Hydrate(entity);

            entity = await (this._handler as IArticleHandler).UpdateForSlug(slug, entity);


            // anon type to have "article" root object name (API contract)
            return new RootArticleView() { Article = new ArticleView(entity) };

        }

        [Route("articles/{slug}")]
        [HttpDelete]
        public async Task<ActionResult> Delete(string slug )
        {
            var numberOfDeleted = await this._repository.DeleteBySlug(slug);
            if(numberOfDeleted == 1){
                return Accepted();
            }else{
                return NotFound();
            }
        }

        [Route("articles/{slug}/favorite")]
        [HttpPost]
        public async Task<RootArticleView> Favorite(string slug )
        {
            
            // TODO 
            throw new NotImplementedException();

        }

        [Route("articles/{slug}/favorite")]
        [HttpDelete]
        public async Task<RootArticleView> Unfavorite(string slug )
        {
             // TODO 
            throw new NotImplementedException();

        }


    }
}