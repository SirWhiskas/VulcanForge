using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VulcanForge.Interfaces;
using VulcanForge.Repository;

namespace VulcanForge.Controllers
{
    public abstract class BaseController<TModel, TRepository> : ControllerBase where TModel : class where TRepository : IRepositoryBase<TModel>
    {
        protected readonly TRepository Repository;

        public BaseController(TRepository repository)
        {
            this.Repository = repository;
        }

        [HttpGet]
        public IEnumerable<TModel> Get()
        {
            return Repository.FindAll();
        }

        [HttpPost]
        public void Add([FromBody] TModel item)
        {
             Repository.Create(item);
        }        
    }
}